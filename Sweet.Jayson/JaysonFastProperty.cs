﻿# region License
//	The MIT License (MIT)
//
//	Copyright (c) 2015, Cagatay Dogan
//
//	Permission is hereby granted, free of charge, to any person obtaining a copy
//	of this software and associated documentation files (the "Software"), to deal
//	in the Software without restriction, including without limitation the rights
//	to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//	copies of the Software, and to permit persons to whom the Software is
//	furnished to do so, subject to the following conditions:
//
//		The above copyright notice and this permission notice shall be included in
//		all copies or substantial portions of the Software.
//
//		THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//		IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//		FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//		AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//		LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//		OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//		THE SOFTWARE.
# endregion License

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Sweet.Jayson
{
    # region JaysonFastProperty

    internal sealed class JaysonFastProperty : IJaysonFastMember
    {
        private delegate void ByRefAction(ref object instance, object value);

        private bool m_Get;
        private bool m_Set;
        private bool m_Overriden;

        private Type m_MemberType;
        private PropertyInfo m_PropInfo;

        private bool m_CanRead;
        private bool m_CanWrite;
#if (NET3500 || NET3000 || NET2000)
        private bool m_IsValueType;
#endif

        private ByRefAction m_SetRefDelegate;
        private Func<object, object> m_GetDelegate;
#if (NET3500 || NET3000 || NET2000)
		private Action<object, object> m_SetDelegate;
#endif

        public JaysonFastMemberType Type
        {
            get { return JaysonFastMemberType.Property; }
        }

        public Type MemberType
        {
            get { return m_MemberType; }
        }

        public bool CanRead
        {
            get { return m_CanRead; }
        }

        public bool CanWrite
        {
            get { return m_CanWrite; }
        }

        public bool Overriden
        {
            get { return m_Overriden; }
        }

        public JaysonFastProperty(PropertyInfo pi, bool initGet = true, bool initSet = true)
        {
            m_PropInfo = pi;
            m_MemberType = m_PropInfo.PropertyType;
#if (NET3500 || NET3000 || NET2000)
            m_IsValueType = pi.DeclaringType.IsValueType;
#endif

            m_CanRead = m_PropInfo.CanRead;
            m_CanWrite = m_PropInfo.CanWrite;

            if (initGet)
            {
                m_Get = true;
                InitializeGet(pi);
            }

            if (initSet)
            {
                m_Set = true;
                InitializeSet(pi);
            }
        }

        private void InitializeGet(PropertyInfo pi)
        {
            MethodInfo getMethod = pi.GetGetMethod();
            if (getMethod != null)
            {
                var instanceVar = Expression.Parameter(typeof(object), "instance");

                Type declaringT = pi.DeclaringType;
                UnaryExpression instanceCast = !declaringT.IsValueType ?
                    Expression.TypeAs(instanceVar, declaringT) :
                    Expression.Convert(instanceVar, declaringT);

                Expression callExp = Expression.Call(instanceCast, getMethod);
                Expression toObjectExp = Expression.TypeAs(callExp, typeof(object));

                var overridingMetod = JaysonCommon.GetOverridingMethod(pi);
                if (overridingMetod != null)
                {
                    m_Overriden = true;
                    var memberName = pi.Name;
                    var memberNameExp = Expression.Constant(memberName, typeof(string));
                    callExp = Expression.Call(overridingMetod, memberNameExp, toObjectExp);
                    toObjectExp = Expression.TypeAs(callExp, typeof(object));
                }

                var lmd = Expression.Lambda<Func<object, object>>(toObjectExp, instanceVar);
                m_GetDelegate = lmd.Compile();
            }
        }

        private void InitializeSet(PropertyInfo pi)
        {
            MethodInfo setMethod = pi.GetSetMethod();
            if (setMethod != null)
            {
                Type declaringT = pi.DeclaringType;

#if (NET3500 || NET3000 || NET2000)
				if (declaringT.IsValueType) {
					m_SetRefDelegate = delegate(ref object instance, object value) {
						m_PropInfo.SetValue (instance, value, null);
					};
				} else {
					var instanceExp = Expression.Parameter (typeof(object), "instance");
					var valueExp = Expression.Parameter (typeof(object), "value");

					// value as T is slightly faster than (T)value, so if it's not a value type, use that
					UnaryExpression instanceCast = Expression.TypeAs (instanceExp, declaringT);

					UnaryExpression valueCast = !m_MemberType.IsValueType ?
					    Expression.TypeAs (valueExp, m_MemberType) : 
					    Expression.Convert (valueExp, m_MemberType);

					Expression callExp = Expression.Call (instanceCast, setMethod, valueCast);

					m_SetDelegate = Expression.Lambda<Action<object, object>> (callExp, 
						new ParameterExpression[] { instanceExp, valueExp }).Compile ();
				}
#else
                var instanceExp = Expression.Parameter(typeof(object).MakeByRefType(), "instance");
                var valueExp = Expression.Parameter(typeof(object), "value");

                // value as T is slightly faster than (T)value, so if it's not a value type, use that
                UnaryExpression instanceCast = !declaringT.IsValueType ?
                    Expression.TypeAs(instanceExp, declaringT) :
                    Expression.Convert(instanceExp, declaringT);

                UnaryExpression valueCast = !m_MemberType.IsValueType ?
                    Expression.TypeAs(valueExp, m_MemberType) :
                    Expression.Convert(valueExp, m_MemberType);

                List<Expression> expBlockList = new List<Expression>();

                var instanceRefExp = Expression.Variable(declaringT, "instanceRef");
                expBlockList.Add(Expression.Assign(instanceRefExp, instanceCast));

                MemberExpression propertyExp = Expression.Property(instanceRefExp, pi);
                BinaryExpression assignExp = Expression.Assign(propertyExp, valueCast);

                expBlockList.Add(assignExp);

                Expression toObjectExp = Expression.Assign(instanceExp,
                    Expression.Convert(instanceRefExp, typeof(object)));
                expBlockList.Add(toObjectExp);

                Expression blockExp = Expression.Block(new[] { instanceRefExp }, expBlockList);

                m_SetRefDelegate = Expression.Lambda<ByRefAction>(blockExp,
                    new ParameterExpression[] { instanceExp, valueExp }).Compile();
#endif
            }
        }

        public object Get(object instance)
        {
            if (m_CanRead)
            {
                if (!m_Get)
                {
                    m_Get = true;
                    InitializeGet(m_PropInfo);
                }
                return m_GetDelegate(instance);
            }
            return null;
        }

        public void Set(ref object instance, object value)
        {
            if (m_CanWrite)
            {
                if (!m_Set)
                {
                    m_Set = true;
                    InitializeSet(m_PropInfo);
                }
#if (NET3500 || NET3000 || NET2000)
                if (m_IsValueType) {
                    if (m_SetRefDelegate != null) {
                        m_SetRefDelegate(ref instance, value);
                    }
                } else if (m_SetDelegate != null) {
                    m_SetDelegate(instance, value);
                }
#else
                if (m_SetRefDelegate != null)
                {
                    m_SetRefDelegate(ref instance, value);
                }
#endif
            }
        }
    }

    # endregion JaysonFastProperty
}