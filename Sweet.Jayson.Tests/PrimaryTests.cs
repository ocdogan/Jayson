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
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Threading;
#if !(NET3500 || NET3000 || NET2000)
using System.Threading.Tasks;
#endif
using NUnit.Framework;

using Sweet.Jayson;

namespace Sweet.Jayson.Tests
{
    [TestFixture]
    public class PrimaryTests
    {
		[Test]
		public static void TestGuid1()
		{
			var guid1 = new Guid ("199B7309-8E94-4DB0-BDD9-DA311E8C47AC");
			string json = JaysonConverter.ToJsonString(guid1);
			var guid2 = JaysonConverter.ToObject<Guid>(json);
			Assert.True(guid1 == guid2);
		}

		[Test]
		public static void TestGuid2()
		{
			var simpleObj1 = new VerySimpleJsonValue {
				Value = new Guid ("199B7309-8E94-4DB0-BDD9-DA311E8C47AC")
			};

			JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
			jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;

			string json = JaysonConverter.ToJsonString(simpleObj1, jaysonSerializationSettings);
			var simpleObj2 = JaysonConverter.ToObject<VerySimpleJsonValue>(json);
			Assert.True((Guid)simpleObj1.Value == (Guid)simpleObj2.Value);
		}

		[Test]
		public static void TestGuid3()
		{
			var guid1 = new Guid ("199B7309-8E94-4DB0-BDD9-DA311E8C47AC");

			JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
			jaysonSerializationSettings.GuidAsByteArray = true;

			string json = JaysonConverter.ToJsonString(guid1, jaysonSerializationSettings);
			var guid2 = JaysonConverter.ToObject<Guid>(json);
			Assert.True(guid1 == guid2);
		}

		[Test]
		public static void TestGuid4()
		{
			var simpleObj1 = new VerySimpleJsonValue {
				Value = new Guid ("199B7309-8E94-4DB0-BDD9-DA311E8C47AC")
			};

			JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
			jaysonSerializationSettings.GuidAsByteArray = true;
			jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;

			string json = JaysonConverter.ToJsonString(simpleObj1, jaysonSerializationSettings);
			var simpleObj2 = JaysonConverter.ToObject<VerySimpleJsonValue>(json);
			Assert.True((Guid)simpleObj1.Value == (Guid)simpleObj2.Value);
		}

		[Test]
		public static void TestLong1()
		{
			var long1 = 1998730980944080L;
			string json = JaysonConverter.ToJsonString(long1);
			var long2 = JaysonConverter.ToObject<long>(json);
			Assert.True(long1 == long2);
		}

		[Test]
		public static void TestLong2()
		{
			long? long1 = 1998730980944080L;
			string json = JaysonConverter.ToJsonString(long1);
			var long2 = JaysonConverter.ToObject<long?>(json);
			Assert.True(long1 == long2);
		}

		[Test]
		public static void TestLong3()
		{
			var simpleObj1 = new VerySimpleJsonValue {
				Value = 1998730980944080L
			};

			JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
			jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;

			string json = JaysonConverter.ToJsonString(simpleObj1, jaysonSerializationSettings);
			var simpleObj2 = JaysonConverter.ToObject<VerySimpleJsonValue>(json);
			Assert.IsInstanceOf<long> (simpleObj2.Value);
			Assert.True((long)simpleObj1.Value == (long)simpleObj2.Value);
		}

		[Test]
		public static void TestLong4()
		{
			var simpleObj1 = new VerySimpleJsonValue {
				Value = (long?)1998730980944080L
			};

			JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
			jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;

			string json = JaysonConverter.ToJsonString(simpleObj1, jaysonSerializationSettings);
			var simpleObj2 = JaysonConverter.ToObject<VerySimpleJsonValue>(json);
			Assert.IsInstanceOf<long?> (simpleObj2.Value);
			Assert.True((long?)simpleObj1.Value == (long?)simpleObj2.Value);
		}

		[Test]
		public static void TestInt1()
		{
			var int1 = 1998730980;
			string json = JaysonConverter.ToJsonString(int1);
			var int2 = JaysonConverter.ToObject<int?>(json);
			Assert.True(int1 == int2);
		}

		[Test]
		public static void TestInt2()
		{
			int? int1 = 1998730980;
			string json = JaysonConverter.ToJsonString(int1);
			var int2 = JaysonConverter.ToObject<int?>(json);
			Assert.True(int1 == int2);
		}

		[Test]
		public static void TestInt3()
		{
			var simpleObj1 = new VerySimpleJsonValue {
				Value = 1998730980
			};

			JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
			jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;

			string json = JaysonConverter.ToJsonString(simpleObj1, jaysonSerializationSettings);
			var simpleObj2 = JaysonConverter.ToObject<VerySimpleJsonValue>(json);
			Assert.IsInstanceOf<int> (simpleObj2.Value);
			Assert.True((int)simpleObj1.Value == (int)simpleObj2.Value);
		}

		[Test]
		public static void TestInt4()
		{
			var simpleObj1 = new VerySimpleJsonValue {
				Value = (int?)1998730980
			};

			JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
			jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;

			string json = JaysonConverter.ToJsonString(simpleObj1, jaysonSerializationSettings);
			var simpleObj2 = JaysonConverter.ToObject<VerySimpleJsonValue>(json);
			Assert.IsInstanceOf<int?> (simpleObj2.Value);
			Assert.True((int?)simpleObj1.Value == (int?)simpleObj2.Value);
		}

		[Test]
        public static void TestParseIso8601Date1()
        {
            var date1 = new DateTime(1972, 10, 25, 12, 45, 32, DateTimeKind.Utc);
            var date2 = JaysonCommon.ParseIso8601DateTime("1972-10-25", JaysonDateTimeZoneType.ConvertToUtc);
            Assert.True(date1.Date == date2.Date);
        }

        [Test]
        public static void TestParseIso8601Date2()
        {
            var date1 = new DateTime(1972, 10, 25, 12, 45, 32, DateTimeKind.Utc);
            var date2 = JaysonCommon.ParseIso8601DateTime("1972-10-25T12:45:32Z");
            Assert.True(date1 == date2);
        }

        [Test]
        public static void TestParseIso8601Date3()
        {
            var date1 = new DateTime(1972, 10, 25, 12, 45, 32, DateTimeKind.Local);
            var tz = JaysonCommon.GetUtcOffset(date1);
            string str = String.Format("1972-10-25T12:45:32+{0:00}:{1:00}", tz.Hours, tz.Minutes);
            var date2 = JaysonCommon.ParseIso8601DateTime(str);
            Assert.True(date1 == date2);
        }

        [Test]
        public static void TestParseIso8601Date4()
        {
            var date1 = new DateTime(1972, 10, 25, 12, 45, 32, DateTimeKind.Local);
            var tz = JaysonCommon.GetUtcOffset(date1);
            string str = String.Format("1972-10-25T12:45:32+{0:00}{1:00}", tz.Hours, tz.Minutes);
            var date2 = JaysonCommon.ParseIso8601DateTime(str);
            Assert.True(date1 == date2);
        }

        [Test]
        public static void TestParseIso8601Date5()
        {
            var date1 = new DateTime(1972, 10, 25, 12, 45, 32, DateTimeKind.Local);
            var tz = JaysonCommon.GetUtcOffset(date1);
            string str = String.Format("19721025T124532+{0:00}{1:00}", tz.Hours, tz.Minutes);
            var date2 = JaysonCommon.ParseIso8601DateTime(str);
            Assert.True(date1 == date2);
        }

        [Test]
        public static void TestParseIso8601Date6()
        {
            var date1 = new DateTime(1972, 10, 25, 12, 45, 32, DateTimeKind.Local);
            var tz = JaysonCommon.GetUtcOffset(date1);
            string str = String.Format("19721025T124532+{0:00}:{1:00}", tz.Hours, tz.Minutes);
            var date2 = JaysonCommon.ParseIso8601DateTime(str);
            Assert.True(date1 == date2);
        }

        [Test]
        public static void TestParseIso8601Date7()
        {
            var date1 = new DateTime(1972, 10, 25, 12, 45, 32, DateTimeKind.Utc);
            var date2 = JaysonCommon.ParseIso8601DateTime("19721025T124532Z");
            Assert.True(date1 == date2);
        }

        [Test]
        public static void TestParseIso8601Date8()
        {
            var date1 = new DateTime(1972, 10, 25, 12, 45, 32, DateTimeKind.Utc);
            var date2 = JaysonCommon.ParseIso8601DateTime("19721025T124532Z");
            Assert.True(date1 == date2);
        }

		[Test]
		public static void TestToJsonObject()
		{
			var dto = TestClasses.GetTypedContainerDto();

			JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();

			object jsonObj = null;
			Assert.DoesNotThrow(() =>
				{
					jsonObj = JaysonConverter.ToJsonObject(dto, jaysonSerializationSettings);
				});
			Assert.IsTrue(jsonObj is Dictionary<string, object>);
		}

        [Test]
        public static void TestUseGlobalTypeNames()
        {
            var dto = TestClasses.GetTypedContainerDto();

			JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
			jaysonSerializationSettings.UseGlobalTypeNames = true;
			jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;
			jaysonSerializationSettings.Formatting = true;
			jaysonSerializationSettings.IgnoreNullValues = false;
			jaysonSerializationSettings.CaseSensitive = true;
			jaysonSerializationSettings.DateFormatType = JaysonDateFormatType.Microsoft;
			jaysonSerializationSettings.DateTimeZoneType = JaysonDateTimeZoneType.KeepAsIs;
			jaysonSerializationSettings.DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.ffff%K";

			JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
			jaysonDeserializationSettings.CaseSensitive = false;

			string json = null;
			object jsonObj = null;
			TypedContainerDto dto2 = null;
			Assert.DoesNotThrow(() =>
				{
					json = JaysonConverter.ToJsonString(dto, jaysonSerializationSettings);
					jsonObj = JaysonConverter.Parse(json, jaysonDeserializationSettings);
					dto2 = JaysonConverter.ToObject<TypedContainerDto>(json, jaysonDeserializationSettings);
				});
			Assert.IsNotNull (jsonObj);
			Assert.IsNotNull (dto2);
        }

		[Test]
		public static void TestListT1()
		{
			List<int> list1 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };

			JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
			jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;
			jaysonSerializationSettings.Formatting = true;
			jaysonSerializationSettings.IgnoreNullValues = false;
			jaysonSerializationSettings.CaseSensitive = false;

			JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
			jaysonDeserializationSettings.CaseSensitive = false;

			string json = null;
			List<int> list2 = null;
			Assert.DoesNotThrow(() =>
				{
					json = JaysonConverter.ToJsonString(list1, jaysonSerializationSettings);
					JaysonConverter.Parse(json, jaysonDeserializationSettings);
					list2 = JaysonConverter.ToObject<List<int>>(json, jaysonDeserializationSettings);
				});
			Assert.IsNotNull (list2);
            Assert.AreEqual(list1.Count, list2.Count);
        }

		[Test]
		public static void TestListT2()
		{
			List<int> list1 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };

			JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
			jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.None;
			jaysonSerializationSettings.Formatting = true;
			jaysonSerializationSettings.IgnoreNullValues = false;
			jaysonSerializationSettings.CaseSensitive = false;

			JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
			jaysonDeserializationSettings.CaseSensitive = false;

			string json = null;
			List<int> list2 = null;
			Assert.DoesNotThrow(() =>
				{
					json = JaysonConverter.ToJsonString(list1, jaysonSerializationSettings);
					JaysonConverter.Parse(json, jaysonDeserializationSettings);
					list2 = JaysonConverter.ToObject<List<int>>(json, jaysonDeserializationSettings);
				});
			Assert.IsNotNull (list2);
            Assert.AreEqual(list1.Count, list2.Count);
		}

        [Test]
        public static void TestListT3()
        {
            List<int[]> list1 = new List<int[]> { 
                new int[] {1, 2, 3}, 
                new int[] {4, 5, 6, 7, 8} 
            };

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.None;
            jaysonSerializationSettings.Formatting = true;
            jaysonSerializationSettings.IgnoreNullValues = false;
            jaysonSerializationSettings.CaseSensitive = false;

            JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
            jaysonDeserializationSettings.CaseSensitive = false;

            string json = null;
            List<int[]> list2 = null;
            Assert.DoesNotThrow(() =>
            {
                json = JaysonConverter.ToJsonString(list1, jaysonSerializationSettings);
                JaysonConverter.Parse(json, jaysonDeserializationSettings);
                list2 = JaysonConverter.ToObject<List<int[]>>(json, jaysonDeserializationSettings);
            });
            Assert.IsNotNull(list2);
            Assert.AreEqual(list1.Count, list2.Count);
        }

        [Test]
        public static void TestListT4()
        {
            List<int[,]> list1 = new List<int[,]> { 
                new int[,] { 
                    { 1, 2 }, 
                    { 3, 4 } 
                }, 
                new int[,] { 
                    { 5, 6 }, 
                    { 7, 8 } 
                } 
            };

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.None;
            jaysonSerializationSettings.Formatting = true;
            jaysonSerializationSettings.IgnoreNullValues = false;
            jaysonSerializationSettings.CaseSensitive = false;

            JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
            jaysonDeserializationSettings.CaseSensitive = false;

            string json = null;
            List<int[,]> list2 = null;
            Assert.DoesNotThrow(() =>
            {
                json = JaysonConverter.ToJsonString(list1, jaysonSerializationSettings);
                JaysonConverter.Parse(json, jaysonDeserializationSettings);
                list2 = JaysonConverter.ToObject<List<int[,]>>(json, jaysonDeserializationSettings);
            });
            Assert.IsNotNull(list2);
            Assert.AreEqual(list1.Count, list2.Count);
        }

        [Test]
        public static void TestListT5()
        {
            List<Dictionary<string, int[,]>> list1 = new List<Dictionary<string, int[,]>> { 
                new Dictionary<string, int[,]> { 
                    { "A", new int[,] { { 1, 2 }, { 3, 4 } } }, 
                    { "B", new int[,] { { 5, 6 }, { 7, 8 } } } 
                }
            };

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;
            jaysonSerializationSettings.Formatting = true;
            jaysonSerializationSettings.IgnoreNullValues = false;
            jaysonSerializationSettings.CaseSensitive = false;

            JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
            jaysonDeserializationSettings.CaseSensitive = false;

            string json = null;
            dynamic list2 = null;
            Assert.DoesNotThrow(() =>
            {
                json = JaysonConverter.ToJsonString(list1, jaysonSerializationSettings);
                JaysonConverter.Parse(json, jaysonDeserializationSettings);
                list2 = JaysonConverter.ToObject(json, jaysonDeserializationSettings);
            });
            Assert.IsNotNull(list2);
            Assert.AreEqual(list1.Count, list2.Count);
        }

        [Test]
        public static void TestListT6()
        {
            List<Dictionary<string, List<int[,]>>> list1 = new List<Dictionary<string, List<int[,]>>> { 
                new Dictionary<string, List<int[,]>> { 
                    { "A", new List<int[,]> { new int[,] { { 1, 2 }, { 3, 4 } } } }, 
                    { "B", new List<int[,]> { new int[,] { { 5, 6 }, { 7, 8 } } } }
                }
            };

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;
            jaysonSerializationSettings.Formatting = true;
            jaysonSerializationSettings.IgnoreNullValues = false;
            jaysonSerializationSettings.CaseSensitive = false;

            JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
            jaysonDeserializationSettings.CaseSensitive = false;

            string json = null;
            dynamic list2 = null;
            Assert.DoesNotThrow(() =>
            {
                json = JaysonConverter.ToJsonString(list1, jaysonSerializationSettings);
                JaysonConverter.Parse(json, jaysonDeserializationSettings);
                list2 = JaysonConverter.ToObject(json, jaysonDeserializationSettings);
            });
            Assert.IsNotNull(list2);
            Assert.AreEqual(list1.Count, list2.Count);
        }

        [Test]
        public static void TestDictionaryTK1()
        {
            Dictionary<string, int> dictionary1 = new Dictionary<string, int> { 
                { "1", 2 }, 
                { "3", 4 }, 
                { "5", 6 }, 
                { "7", 8 } 
            };

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;
            jaysonSerializationSettings.Formatting = true;
            jaysonSerializationSettings.IgnoreNullValues = false;
            jaysonSerializationSettings.CaseSensitive = false;

            JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
            jaysonDeserializationSettings.CaseSensitive = false;

            string json = null;
            Dictionary<string, int> dictionary2 = null;
            Assert.DoesNotThrow(() =>
            {
                json = JaysonConverter.ToJsonString(dictionary1, jaysonSerializationSettings);
                JaysonConverter.Parse(json, jaysonDeserializationSettings);
                dictionary2 = JaysonConverter.ToObject<Dictionary<string, int>>(json, jaysonDeserializationSettings);
            });
            Assert.IsNotNull(dictionary2);
            Assert.AreEqual(dictionary1.Count, dictionary2.Count);
        }

        [Test]
        public static void TestDictionaryTK2()
        {
            Dictionary<string, int> dictionary1 = new Dictionary<string, int> { 
                { "1", 2 }, 
                { "3", 4 }, 
                { "5", 6 }, 
                { "7", 8 } 
            };

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.None;
            jaysonSerializationSettings.Formatting = true;
            jaysonSerializationSettings.IgnoreNullValues = false;
            jaysonSerializationSettings.CaseSensitive = false;

            JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
            jaysonDeserializationSettings.CaseSensitive = false;

            string json = null;
            Dictionary<string, int> dictionary2 = null;
            Assert.DoesNotThrow(() =>
            {
                json = JaysonConverter.ToJsonString(dictionary1, jaysonSerializationSettings);
                JaysonConverter.Parse(json, jaysonDeserializationSettings);
                dictionary2 = JaysonConverter.ToObject<Dictionary<string, int>>(json, jaysonDeserializationSettings);
            });
            Assert.IsNotNull(dictionary2);
            Assert.AreEqual(dictionary1.Count, dictionary2.Count);
        }

        [Test]
        public static void TestDictionaryTK3()
        {
            Dictionary<string, int[]> dictionary1 = new Dictionary<string, int[]> { 
                { "A", new int[] { 1, 2, 3 } }, 
                { "B", new int[] { 4, 5, 6, 7, 8 } } 
            };

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.None;
            jaysonSerializationSettings.Formatting = true;
            jaysonSerializationSettings.IgnoreNullValues = false;
            jaysonSerializationSettings.CaseSensitive = false;

            JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
            jaysonDeserializationSettings.CaseSensitive = false;

            string json = null;
            Dictionary<string, int[]> dictionary2 = null;
            Assert.DoesNotThrow(() =>
            {
                json = JaysonConverter.ToJsonString(dictionary1, jaysonSerializationSettings);
                JaysonConverter.Parse(json, jaysonDeserializationSettings);
                dictionary2 = JaysonConverter.ToObject<Dictionary<string, int[]>>(json, jaysonDeserializationSettings);
            });
            Assert.IsNotNull(dictionary2);
            Assert.AreEqual(dictionary1.Count, dictionary2.Count);
        }

        [Test]
        public static void TestDictionaryTK4()
        {
            Dictionary<string, int[,]> dictionary1 = new Dictionary<string, int[,]> { 
                { "A", new int[,] { { 1, 2 }, { 3, 4 } } }, 
                { "B", new int[,] { { 5, 6 }, { 7, 8 } } } 
            };

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.None;
            jaysonSerializationSettings.Formatting = true;
            jaysonSerializationSettings.IgnoreNullValues = false;
            jaysonSerializationSettings.CaseSensitive = false;

            JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
            jaysonDeserializationSettings.CaseSensitive = false;

            string json = null;
            Dictionary<string, int[,]> dictionary2 = null;
            Assert.DoesNotThrow(() =>
            {
                json = JaysonConverter.ToJsonString(dictionary1, jaysonSerializationSettings);
                JaysonConverter.Parse(json, jaysonDeserializationSettings);
                dictionary2 = JaysonConverter.ToObject<Dictionary<string, int[,]>>(json, jaysonDeserializationSettings);
            });
            Assert.IsNotNull(dictionary2);
            Assert.AreEqual(dictionary1.Count, dictionary2.Count);
        }
        [Test]
        public static void TestDictionaryTK5()
        {
            Dictionary<string, List<int>> dictionary1 = new Dictionary<string, List<int>> { 
                { "1", new List<int> { 2 } }, 
                { "3", new List<int> { 4 } }, 
                { "5", new List<int> { 6 } }, 
                { "7", new List<int> { 8 } } 
            };

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;
            jaysonSerializationSettings.Formatting = true;
            jaysonSerializationSettings.IgnoreNullValues = false;
            jaysonSerializationSettings.CaseSensitive = false;

            JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
            jaysonDeserializationSettings.CaseSensitive = false;

            string json = null;
            Dictionary<string, List<int>> dictionary2 = null;
            Assert.DoesNotThrow(() =>
            {
                json = JaysonConverter.ToJsonString(dictionary1, jaysonSerializationSettings);
                JaysonConverter.Parse(json, jaysonDeserializationSettings);
                dictionary2 = JaysonConverter.ToObject<Dictionary<string, List<int>>>(json, jaysonDeserializationSettings);
            });
            Assert.IsNotNull(dictionary2);
            Assert.AreEqual(dictionary1.Count, dictionary2.Count);
        }

        [Test]
        public static void TestDictionaryTK6()
        {
            Dictionary<string, List<int>> dictionary1 = new Dictionary<string, List<int>> { 
                { "1", new List<int> { 2 } }, 
                { "3", new List<int> { 4 } }, 
                { "5", new List<int> { 6 } }, 
                { "7", new List<int> { 8 } } 
            };

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.None;
            jaysonSerializationSettings.Formatting = true;
            jaysonSerializationSettings.IgnoreNullValues = false;
            jaysonSerializationSettings.CaseSensitive = false;

            JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
            jaysonDeserializationSettings.CaseSensitive = false;

            string json = null;
            Dictionary<string, List<int>> dictionary2 = null;
            Assert.DoesNotThrow(() =>
            {
                json = JaysonConverter.ToJsonString(dictionary1, jaysonSerializationSettings);
                JaysonConverter.Parse(json, jaysonDeserializationSettings);
                dictionary2 = JaysonConverter.ToObject<Dictionary<string, List<int>>>(json, jaysonDeserializationSettings);
            });
            Assert.IsNotNull(dictionary2);
            Assert.AreEqual(dictionary1.Count, dictionary2.Count);
        }

        [Test]
        public static void TestDictionaryTK7()
        {
            Dictionary<string, List<int[]>> dictionary1 = new Dictionary<string, List<int[]>> { 
                { "A", new List<int[]> { new int[] { 1, 2, 3 } } }, 
                { "B", new List<int[]> { new int[] { 4, 5, 6, 7, 8 } } } 
            };

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.None;
            jaysonSerializationSettings.Formatting = true;
            jaysonSerializationSettings.IgnoreNullValues = false;
            jaysonSerializationSettings.CaseSensitive = false;

            JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
            jaysonDeserializationSettings.CaseSensitive = false;

            string json = null;
            Dictionary<string, List<int[]>> dictionary2 = null;
            Assert.DoesNotThrow(() =>
            {
                json = JaysonConverter.ToJsonString(dictionary1, jaysonSerializationSettings);
                JaysonConverter.Parse(json, jaysonDeserializationSettings);
                dictionary2 = JaysonConverter.ToObject<Dictionary<string, List<int[]>>>(json, jaysonDeserializationSettings);
            });
            Assert.IsNotNull(dictionary2);
            Assert.AreEqual(dictionary1.Count, dictionary2.Count);
        }

        [Test]
        public static void TestDictionaryTK8()
        {
            Dictionary<string, List<int[,]>> dictionary1 = new Dictionary<string, List<int[,]>> { 
                { "A", new List<int[,]> { new int[,] { { 1, 2 }, { 3, 4 } } } }, 
                { "B", new List<int[,]> { new int[,] { { 5, 6 }, { 7, 8 } } } } 
            };

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.None;
            jaysonSerializationSettings.Formatting = true;
            jaysonSerializationSettings.IgnoreNullValues = false;
            jaysonSerializationSettings.CaseSensitive = false;

            JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
            jaysonDeserializationSettings.CaseSensitive = false;

            string json = null;
            Dictionary<string, List<int[,]>> dictionary2 = null;
            Assert.DoesNotThrow(() =>
            {
                json = JaysonConverter.ToJsonString(dictionary1, jaysonSerializationSettings);
                JaysonConverter.Parse(json, jaysonDeserializationSettings);
                dictionary2 = JaysonConverter.ToObject<Dictionary<string, List<int[,]>>>(json, jaysonDeserializationSettings);
            });
            Assert.IsNotNull(dictionary2);
            Assert.AreEqual(dictionary1.Count, dictionary2.Count);
        }

        [Test]
        public static void TestDictionaryTK9()
        {
            Dictionary<string, IList<int[,]>> dictionary1 = new Dictionary<string, IList<int[,]>> { 
                { "A", new List<int[,]> { new int[,] { { 1, 2 }, { 3, 4 } } } }, 
                { "B", new List<int[,]> { new int[,] { { 5, 6 }, { 7, 8 } } } } 
            };

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.None;
            jaysonSerializationSettings.Formatting = true;
            jaysonSerializationSettings.IgnoreNullValues = false;
            jaysonSerializationSettings.CaseSensitive = false;

            JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
            jaysonDeserializationSettings.CaseSensitive = false;

            string json = null;
            Dictionary<string, IList<int[,]>> dictionary2 = null;
            Assert.DoesNotThrow(() =>
            {
                json = JaysonConverter.ToJsonString(dictionary1, jaysonSerializationSettings);
                JaysonConverter.Parse(json, jaysonDeserializationSettings);
                dictionary2 = JaysonConverter.ToObject<Dictionary<string, IList<int[,]>>>(json, jaysonDeserializationSettings);
            });
            Assert.IsNotNull(dictionary2);
            Assert.AreEqual(dictionary1.Count, dictionary2.Count);
        }

        [Test]
		public static void TestMultiDimentionalArray1()
		{
			int[,] intArray2D = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };

			JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
			jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.None;
			jaysonSerializationSettings.Formatting = true;
			jaysonSerializationSettings.IgnoreNullValues = false;
			jaysonSerializationSettings.CaseSensitive = false;

			JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
			jaysonDeserializationSettings.CaseSensitive = false;

			string json = null;
			int[,] intArray2D2 = null;
			Assert.DoesNotThrow(() =>
				{
					json = JaysonConverter.ToJsonString(intArray2D, jaysonSerializationSettings);
					JaysonConverter.Parse(json, jaysonDeserializationSettings);
					intArray2D2 = JaysonConverter.ToObject<int[,]>(json, jaysonDeserializationSettings);
				});
			Assert.IsNotNull (intArray2D2);
		}

		[Test]
		public static void TestMultiDimentionalArray2()
		{
			int[,] intArray2D = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };

			JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
			jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;
			jaysonSerializationSettings.Formatting = true;
			jaysonSerializationSettings.IgnoreNullValues = false;
			jaysonSerializationSettings.CaseSensitive = false;

			JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
			jaysonDeserializationSettings.CaseSensitive = false;

			string json = null;
			int[,] intArray2D2 = null;
			Assert.DoesNotThrow(() =>
				{
					json = JaysonConverter.ToJsonString(intArray2D, jaysonSerializationSettings);
					JaysonConverter.Parse(json, jaysonDeserializationSettings);
					intArray2D2 = JaysonConverter.ToObject<int[,]>(json, jaysonDeserializationSettings);
				});
			Assert.IsNotNull (intArray2D2);
		}

		[Test]
		public static void TestMultiDimentionalArray3()
		{
			int[,] intArray2D = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };

			JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
			jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.AllButNoPrimitive;
			jaysonSerializationSettings.Formatting = true;
			jaysonSerializationSettings.IgnoreNullValues = false;
			jaysonSerializationSettings.CaseSensitive = false;

			JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
			jaysonDeserializationSettings.CaseSensitive = false;

			string json = null;
			int[,] intArray2D2 = null;
			Assert.DoesNotThrow(() =>
				{
					json = JaysonConverter.ToJsonString(intArray2D, jaysonSerializationSettings);
					JaysonConverter.Parse(json, jaysonDeserializationSettings);
					intArray2D2 = JaysonConverter.ToObject<int[,]>(json, jaysonDeserializationSettings);
				});
			Assert.IsNotNull (intArray2D2);
		}

		[Test]
		public static void TestMultiDimentionalEmptyArray1()
		{
			int[,] intArray2D = new int[,] { { }, { }, { }, { } };

			JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
			jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.None;
			jaysonSerializationSettings.Formatting = true;
			jaysonSerializationSettings.IgnoreNullValues = false;
			jaysonSerializationSettings.CaseSensitive = false;

			JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
			jaysonDeserializationSettings.CaseSensitive = false;

			string json = null;
			int[,] intArray2D2 = null;
			Assert.DoesNotThrow(() =>
				{
					json = JaysonConverter.ToJsonString(intArray2D, jaysonSerializationSettings);
					JaysonConverter.Parse(json, jaysonDeserializationSettings);
					intArray2D2 = JaysonConverter.ToObject<int[,]>(json, jaysonDeserializationSettings);
				});
			Assert.IsNotNull (intArray2D2);
		}

		[Test]
		public static void TestMultiDimentionalEmptyArray2()
		{
			int[,] intArray2D = new int[,] { { }, { }, { }, { } };

			JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
			jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;
			jaysonSerializationSettings.Formatting = true;
			jaysonSerializationSettings.IgnoreNullValues = false;
			jaysonSerializationSettings.CaseSensitive = false;

			JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
			jaysonDeserializationSettings.CaseSensitive = false;

			string json = null;
			int[,] intArray2D2 = null;
			Assert.DoesNotThrow(() =>
				{
					json = JaysonConverter.ToJsonString(intArray2D, jaysonSerializationSettings);
					JaysonConverter.Parse(json, jaysonDeserializationSettings);
					intArray2D2 = JaysonConverter.ToObject<int[,]>(json, jaysonDeserializationSettings);
				});
			Assert.IsNotNull (intArray2D2);
		}

		[Test]
		public static void TestMultiDimentionalEmptyArray3()
		{
			int[,] intArray2D = new int[,] { { }, { }, { }, { } };

			JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
			jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.AllButNoPrimitive;
			jaysonSerializationSettings.Formatting = true;
			jaysonSerializationSettings.IgnoreNullValues = false;
			jaysonSerializationSettings.CaseSensitive = false;

			JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
			jaysonDeserializationSettings.CaseSensitive = false;

			string json = null;
			int[,] intArray2D2 = null;
			Assert.DoesNotThrow(() =>
				{
					json = JaysonConverter.ToJsonString(intArray2D, jaysonSerializationSettings);
					JaysonConverter.Parse(json, jaysonDeserializationSettings);
					intArray2D2 = JaysonConverter.ToObject<int[,]>(json, jaysonDeserializationSettings);
				});
			Assert.IsNotNull (intArray2D2);
		}

		[Test]
		public static void TestListAndMultiDimentionalArray1()
		{
			List<int[,]> intArray2D = new List<int[,]> { new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } } };

			JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
			jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.None;
			jaysonSerializationSettings.Formatting = true;
			jaysonSerializationSettings.IgnoreNullValues = false;
			jaysonSerializationSettings.CaseSensitive = false;

			JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
			jaysonDeserializationSettings.CaseSensitive = false;

			string json = null;
			List<int[,]> intArray2D2 = null;
			Assert.DoesNotThrow(() =>
				{
					json = JaysonConverter.ToJsonString(intArray2D, jaysonSerializationSettings);
					JaysonConverter.Parse(json, jaysonDeserializationSettings);
					intArray2D2 = JaysonConverter.ToObject<List<int[,]>>(json, jaysonDeserializationSettings);
				});
			Assert.IsNotNull (intArray2D2);
		}

		[Test]
		public static void TestListAndMultiDimentionalArray2()
		{
			List<int[,]> intArray2D = new List<int[,]> { new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } } };

			JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
			jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;
			jaysonSerializationSettings.Formatting = true;
			jaysonSerializationSettings.IgnoreNullValues = false;
			jaysonSerializationSettings.CaseSensitive = false;

			JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
			jaysonDeserializationSettings.CaseSensitive = false;

			string json = null;
			List<int[,]> intArray2D2 = null;
			Assert.DoesNotThrow(() =>
				{
					json = JaysonConverter.ToJsonString(intArray2D, jaysonSerializationSettings);
					JaysonConverter.Parse(json, jaysonDeserializationSettings);
					intArray2D2 = JaysonConverter.ToObject<List<int[,]>>(json, jaysonDeserializationSettings);
				});
			Assert.IsNotNull (intArray2D2);
		}

		[Test]
		public static void TestListAndMultiDimentionalArray3()
		{
			List<int[,]> intArray2D = new List<int[,]> { new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } } };

			JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
			jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.AllButNoPrimitive;
			jaysonSerializationSettings.Formatting = true;
			jaysonSerializationSettings.IgnoreNullValues = false;
			jaysonSerializationSettings.CaseSensitive = false;

			JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
			jaysonDeserializationSettings.CaseSensitive = false;

			string json = null;
			List<int[,]> intArray2D2 = null;
			Assert.DoesNotThrow(() =>
				{
					json = JaysonConverter.ToJsonString(intArray2D, jaysonSerializationSettings);
					JaysonConverter.Parse(json, jaysonDeserializationSettings);
					intArray2D2 = JaysonConverter.ToObject<List<int[,]>>(json, jaysonDeserializationSettings);
				});
			Assert.IsNotNull (intArray2D2);
		}

		[Test]
		public static void TestListAndMultiDimentionalArray4()
		{
			List<int[,]> intArray2D = new List<int[,]> { new int[,] { { }, { }, { }, { } } };

			JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
			jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.AllButNoPrimitive;
			jaysonSerializationSettings.Formatting = true;
			jaysonSerializationSettings.IgnoreNullValues = false;
			jaysonSerializationSettings.CaseSensitive = false;

			JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
			jaysonDeserializationSettings.CaseSensitive = false;

			string json = null;
			List<int[,]> intArray2D2 = null;
			Assert.DoesNotThrow(() =>
				{
					json = JaysonConverter.ToJsonString(intArray2D, jaysonSerializationSettings);
					JaysonConverter.Parse(json, jaysonDeserializationSettings);
					intArray2D2 = JaysonConverter.ToObject<List<int[,]>>(json, jaysonDeserializationSettings);
				});
			Assert.IsNotNull (intArray2D2);
		}

		[Test]
		public static void TestListAndMultiDimentionalArray5()
		{
			List<int[,]> intArray2D = new List<int[,]> { new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } } };

			JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
			jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.AllButNoPrimitive;
			jaysonSerializationSettings.Formatting = false;
			jaysonSerializationSettings.IgnoreNullValues = false;
			jaysonSerializationSettings.CaseSensitive = false;

			JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
			jaysonDeserializationSettings.CaseSensitive = false;

			string json = null;
			List<int[,]> intArray2D2 = null;
			Assert.DoesNotThrow(() =>
				{
					json = JaysonConverter.ToJsonString(intArray2D, jaysonSerializationSettings);
					JaysonConverter.Parse(json, jaysonDeserializationSettings);
					intArray2D2 = JaysonConverter.ToObject<List<int[,]>>(json, jaysonDeserializationSettings);
				});
			Assert.IsNotNull (intArray2D2);
		}

		[Test]
        public static void TestComplexObject()
        {
            var dto = TestClasses.GetTypedContainerDto();

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;
            jaysonSerializationSettings.Formatting = true;
            jaysonSerializationSettings.IgnoreNullValues = false;
            jaysonSerializationSettings.CaseSensitive = false;
            jaysonSerializationSettings.DateFormatType = JaysonDateFormatType.Microsoft;
            jaysonSerializationSettings.DateTimeZoneType = JaysonDateTimeZoneType.KeepAsIs;
            jaysonSerializationSettings.DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.ffff%K";

            JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
            jaysonDeserializationSettings.CaseSensitive = false;

			string json = null;
			TypedContainerDto dto2 = null;
            Assert.DoesNotThrow(() =>
            {
                json = JaysonConverter.ToJsonString(dto, jaysonSerializationSettings);
                JaysonConverter.Parse(json, jaysonDeserializationSettings);
				dto2 = JaysonConverter.ToObject<TypedContainerDto>(json, jaysonDeserializationSettings);
            });
			Assert.IsNotNull (dto2);
        }

        [Test]
        public static void TestTypeOverride()
        {
            var dto1 = TestClasses.GetTypedContainerDto();

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;
            jaysonSerializationSettings.Formatting = true;
            jaysonSerializationSettings.IgnoreNullValues = false;
            jaysonSerializationSettings.CaseSensitive = false;
            jaysonSerializationSettings.DateFormatType = JaysonDateFormatType.Microsoft;
            jaysonSerializationSettings.DateTimeZoneType = JaysonDateTimeZoneType.KeepAsIs;
            jaysonSerializationSettings.DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.ffff%K";
            jaysonSerializationSettings.AddTypeOverride(new JaysonTypeOverride<TextElementDto>()
                .IgnoreMember("ElementType")
                .SetMemberAlias("ElementId", "id"));

            JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
            jaysonDeserializationSettings.CaseSensitive = false;
            jaysonDeserializationSettings.
                AddTypeOverride(new JaysonTypeOverride<TextElementDto, TextElementDto2>()).
                AddTypeOverride(new JaysonTypeOverride<TextElementDto2>().
                    SetMemberAlias("ElementId", "id").
                    IgnoreMember("ElementType")); 

            TypedContainerDto dto2 = null;
            Assert.DoesNotThrow(() =>
            {
                string json = JaysonConverter.ToJsonString(dto1, jaysonSerializationSettings);
                JaysonConverter.Parse(json, jaysonDeserializationSettings);
                dto2 = JaysonConverter.ToObject<TypedContainerDto>(json, jaysonDeserializationSettings);
            });
            Assert.IsNotNull(dto2);
        }

        [Test]
        public static void TestInterfaceDeserializationUsingSType()
        {
            var dto = TestClasses.GetTypedContainerNoDto();

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;
            jaysonSerializationSettings.Formatting = true;
            jaysonSerializationSettings.IgnoreNullValues = false;
            jaysonSerializationSettings.CaseSensitive = false;
            jaysonSerializationSettings.DateFormatType = JaysonDateFormatType.Microsoft;
            jaysonSerializationSettings.DateTimeZoneType = JaysonDateTimeZoneType.KeepAsIs;

            JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
            jaysonDeserializationSettings.CaseSensitive = false;

            object result = null;
            Assert.DoesNotThrow(() =>
            {
                string json = JaysonConverter.ToJsonString(dto, jaysonSerializationSettings);
                JaysonConverter.Parse(json, jaysonDeserializationSettings);
                result = JaysonConverter.ToObject<ITypedContainerNoDto>(json, jaysonDeserializationSettings);
            });

            Assert.IsNotNull(result);
            Assert.IsTrue(result is ITypedContainerNoDto);
        }

        private class TestBinder : System.Runtime.Serialization.SerializationBinder
        {
            public override Type BindToType(string assemblyName, string typeName)
            {
                if (typeName.EndsWith("ITypedContainerNoDto"))
                {
                    return typeof(TypedContainerNoDto);
                }
                if (typeName.EndsWith("IJsonValueContainerNoDto"))
                {
                    return typeof(JsonValueContainerNoDto);
                }
                return null;
            }

            public override void BindToName(Type serializedType, out string assemblyName, out string typeName)
            {
                assemblyName = null;
                typeName = null;
            }
        }

        [Test]
        public static void TestInterfaceDeserializationUsingBinder()
        {
            var dto = TestClasses.GetTypedContainerNoDto();

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.None;
            jaysonSerializationSettings.Formatting = true;
            jaysonSerializationSettings.IgnoreNullValues = false;
            jaysonSerializationSettings.CaseSensitive = false;

            jaysonSerializationSettings.DateFormatType = JaysonDateFormatType.Microsoft;
            jaysonSerializationSettings.DateTimeZoneType = JaysonDateTimeZoneType.KeepAsIs;

            JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
            jaysonDeserializationSettings.CaseSensitive = false;
            jaysonDeserializationSettings.Binder = new TestBinder();

            object result = null;
            Assert.DoesNotThrow(() =>
            {
                string json = JaysonConverter.ToJsonString(dto, jaysonSerializationSettings);
                JaysonConverter.Parse(json, jaysonDeserializationSettings);
                result = JaysonConverter.ToObject<ITypedContainerNoDto>(json, jaysonDeserializationSettings);
            });

            Assert.IsNotNull(result);
            Assert.IsTrue(result is ITypedContainerNoDto);
        }

        [Test]
        public static void TestInterfaceDeserializationUsingObjectActivator()
        {
            var dto = TestClasses.GetTypedContainerNoDto();

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.None;
            jaysonSerializationSettings.Formatting = true;
            jaysonSerializationSettings.IgnoreNullValues = false;
            jaysonSerializationSettings.CaseSensitive = false;

            jaysonSerializationSettings.DateFormatType = JaysonDateFormatType.Microsoft;
            jaysonSerializationSettings.DateTimeZoneType = JaysonDateTimeZoneType.KeepAsIs;


            JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
            jaysonDeserializationSettings.CaseSensitive = false;
            jaysonDeserializationSettings.ObjectActivator = delegate(Type objType,
                IDictionary<string, object> parsedObject,
                out bool useDefaultCtor)
            {
                useDefaultCtor = true;
                if (objType == typeof(ITypedContainerNoDto))
                {
                    useDefaultCtor = false;
                    return new TypedContainerNoDto();
                }
                if (objType == typeof(IJsonValueContainerNoDto))
                {
                    useDefaultCtor = false;
                    return new JsonValueContainerNoDto();
                }
                return null;
            };

            object result = null;
            Assert.DoesNotThrow(() =>
            {
                string json = JaysonConverter.ToJsonString(dto, jaysonSerializationSettings);
                JaysonConverter.Parse(json, jaysonDeserializationSettings);
                result = JaysonConverter.ToObject<ITypedContainerNoDto>(json, jaysonDeserializationSettings);
            });

            Assert.IsNotNull(result);
            Assert.IsTrue(result is ITypedContainerNoDto);
        }

        [Test]
        public static void TestSerializeDeserializeDateWithCustomDateTimeFormat()
        {
            var date1 = new DateTime(1972, 10, 25, 12, 45, 32, DateTimeKind.Utc);

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;
            jaysonSerializationSettings.Formatting = true;
            jaysonSerializationSettings.DateTimeFormat = "dd/MM/yyyy HH:mm:ss.fff%K";
            jaysonSerializationSettings.DateFormatType = JaysonDateFormatType.CustomDate;
            jaysonSerializationSettings.DateTimeZoneType = JaysonDateTimeZoneType.KeepAsIs;

            JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
            jaysonDeserializationSettings.DateTimeFormat = "dd/MM/yyyy HH:mm:ss.fff%K";

            string json = JaysonConverter.ToJsonString(date1, jaysonSerializationSettings);

            Assert.True(json.Contains("25\\/10\\/1972 12:45:32.000Z"));
            var date2 = JaysonConverter.ToObject<DateTime?>(json, jaysonDeserializationSettings);
            Assert.NotNull(date2);
            Assert.IsAssignableFrom<DateTime>(date2);
            Assert.True(date1 == (DateTime)date2);
        }

        [Test]
        public static void TestSerializeDateTimeUtc()
        {
            var date1 = new DateTime(1972, 10, 25, 12, 45, 32, DateTimeKind.Utc);

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;
            jaysonSerializationSettings.Formatting = true;
            jaysonSerializationSettings.DateFormatType = JaysonDateFormatType.Iso8601;
            jaysonSerializationSettings.DateTimeZoneType = JaysonDateTimeZoneType.KeepAsIs;

            string json = JaysonConverter.ToJsonString(date1, jaysonSerializationSettings);
            Assert.True(json.Contains("1972-10-25T12:45:32Z"));
            var date2 = JaysonConverter.ToObject<DateTime?>(json);
            Assert.NotNull(date2);
            Assert.IsAssignableFrom<DateTime>(date2);
            Assert.True(date1 == (DateTime)date2);
        }

        [Test]
        public static void TestSerializeDateTimeLocal()
        {
            var date1 = new DateTime(1972, 10, 25, 12, 45, 32, DateTimeKind.Local);

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;
            jaysonSerializationSettings.Formatting = true;
            jaysonSerializationSettings.DateFormatType = JaysonDateFormatType.Iso8601;
            jaysonSerializationSettings.DateTimeZoneType = JaysonDateTimeZoneType.KeepAsIs;

            string json = JaysonConverter.ToJsonString(date1, jaysonSerializationSettings);
            Assert.True(json.Contains("1972-10-25T12:45:32+") || json.Contains("1972-10-25T12:45:32-"));
            var date2 = JaysonConverter.ToObject<DateTime?>(json);
            Assert.NotNull(date2);
            Assert.IsAssignableFrom<DateTime>(date2);
            Assert.True(date1 == (DateTime)date2);
        }

        [Test]
        public static void TestSerializeDateTimeUnspecified()
        {
            var date1 = new DateTime(1972, 10, 25, 12, 45, 32, DateTimeKind.Unspecified);

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;
            jaysonSerializationSettings.Formatting = true;
            jaysonSerializationSettings.DateFormatType = JaysonDateFormatType.Iso8601;
            jaysonSerializationSettings.DateTimeZoneType = JaysonDateTimeZoneType.KeepAsIs;

            string json = JaysonConverter.ToJsonString(date1, jaysonSerializationSettings);
            Assert.True(json.Contains("1972-10-25T12:45:32+") || json.Contains("1972-10-25T12:45:32-"));
            var date2 = JaysonConverter.ToObject<DateTime?>(json);
            Assert.NotNull(date2);
            Assert.IsAssignableFrom<DateTime>(date2);
            Assert.True(date1 == (DateTime)date2);
        }

        [Test]
        public static void TestSerializeDateTimeUtcMicrosoft()
        {
            var date1 = new DateTime(1972, 10, 25, 12, 45, 32, DateTimeKind.Utc);
            var dto1 = new VerySimpleJsonValue
            {
                Value = date1
            };

            JaysonSerializationSettings jaysonSerializationSettings = new JaysonSerializationSettings();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;
            jaysonSerializationSettings.Formatting = true;
            jaysonSerializationSettings.DateFormatType = JaysonDateFormatType.Microsoft;
            jaysonSerializationSettings.DateTimeZoneType = JaysonDateTimeZoneType.KeepAsIs;

            string json = JaysonConverter.ToJsonString(dto1, jaysonSerializationSettings);
            Assert.True(json.Contains("/Date("));
            var dto2 = JaysonConverter.ToObject<VerySimpleJsonValue>(json);
            Assert.NotNull(dto2);
            Assert.NotNull(dto2.Value);
            Assert.IsAssignableFrom<DateTime>(dto2.Value);
            Assert.True(date1 == (DateTime)dto2.Value);
        }

        [Test]
        public static void TestSerializeDateTimeLocalMicrosoft()
        {
            var date1 = new DateTime(1972, 10, 25, 12, 45, 32, DateTimeKind.Local);
            var dto1 = new VerySimpleJsonValue
            {
                Value = date1
            };

            JaysonSerializationSettings jaysonSerializationSettings = new JaysonSerializationSettings();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;
            jaysonSerializationSettings.Formatting = true;
            jaysonSerializationSettings.DateFormatType = JaysonDateFormatType.Microsoft;
            jaysonSerializationSettings.DateTimeZoneType = JaysonDateTimeZoneType.KeepAsIs;

            string json = JaysonConverter.ToJsonString(dto1, jaysonSerializationSettings);
            Assert.True(json.Contains("/Date(") && (json.Contains("+") || json.Contains("-")));
            var dto2 = JaysonConverter.ToObject<VerySimpleJsonValue>(json);
            Assert.NotNull(dto2);
            Assert.NotNull(dto2.Value);
            Assert.IsAssignableFrom<DateTime>(dto2.Value);
            Assert.True(date1 == (DateTime)dto2.Value);
        }

        [Test]
        public static void TestSerializeDateTimeUnspecifiedMicrosoft()
        {
            var date1 = new DateTime(1972, 10, 25, 12, 45, 32, DateTimeKind.Unspecified);
            var dto1 = new VerySimpleJsonValue
            {
                Value = date1
            };

            JaysonSerializationSettings jaysonSerializationSettings = new JaysonSerializationSettings();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;
            jaysonSerializationSettings.Formatting = true;
            jaysonSerializationSettings.DateFormatType = JaysonDateFormatType.Microsoft;
            jaysonSerializationSettings.DateTimeZoneType = JaysonDateTimeZoneType.KeepAsIs;

            string json = JaysonConverter.ToJsonString(dto1, jaysonSerializationSettings);
            Assert.True(json.Contains("/Date(") && (json.Contains("+") || json.Contains("-")));
            var dto2 = JaysonConverter.ToObject<VerySimpleJsonValue>(json);
            Assert.NotNull(dto2);
            Assert.NotNull(dto2.Value);
            Assert.IsAssignableFrom<DateTime>(dto2.Value);
            Assert.True(date1 == (DateTime)dto2.Value);
        }

        [Test]
        public static void TestDeserializeDateTimeConvertToUtc()
        {
            var date1 = new DateTime(1972, 10, 25, 12, 45, 32, DateTimeKind.Local);

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;
            jaysonSerializationSettings.Formatting = true;
            jaysonSerializationSettings.DateFormatType = JaysonDateFormatType.Iso8601;
            jaysonSerializationSettings.DateTimeZoneType = JaysonDateTimeZoneType.KeepAsIs;

            string json = JaysonConverter.ToJsonString(date1, jaysonSerializationSettings);
            Assert.True(json.Contains("1972-10-25T12:45:32"));

            JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
            jaysonDeserializationSettings.DateTimeZoneType = JaysonDateTimeZoneType.ConvertToUtc;

            var date2 = JaysonConverter.ToObject<DateTime>(json, jaysonDeserializationSettings);
            Assert.NotNull(date2);
            Assert.IsAssignableFrom<DateTime>(date2);
            Assert.True(date2.Kind == DateTimeKind.Utc);
        }

        [Test]
        public static void TestDeserializeDateTimeConvertToLocal()
        {
            var date1 = new DateTime(1972, 10, 25, 12, 45, 32, DateTimeKind.Utc);

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;
            jaysonSerializationSettings.Formatting = true;
            jaysonSerializationSettings.DateFormatType = JaysonDateFormatType.Iso8601;
            jaysonSerializationSettings.DateTimeZoneType = JaysonDateTimeZoneType.KeepAsIs;

            string json = JaysonConverter.ToJsonString(date1, jaysonSerializationSettings);
            Assert.True(json.Contains("1972-10-25T12:45:32"));

            JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
            jaysonDeserializationSettings.DateTimeZoneType = JaysonDateTimeZoneType.ConvertToLocal;

            var date2 = JaysonConverter.ToObject<DateTime>(json, jaysonDeserializationSettings);
            Assert.NotNull(date2);
            Assert.IsAssignableFrom<DateTime>(date2);
            Assert.True(date2.Kind == DateTimeKind.Local);
        }

        [Test]
        public static void TestDeserializeDateTimeKeepAsIs()
        {
            var date1 = new DateTime(1972, 10, 25, 12, 45, 32, DateTimeKind.Local);

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;
            jaysonSerializationSettings.Formatting = true;
            jaysonSerializationSettings.DateFormatType = JaysonDateFormatType.Iso8601;
            jaysonSerializationSettings.DateTimeZoneType = JaysonDateTimeZoneType.KeepAsIs;

            string json = JaysonConverter.ToJsonString(date1, jaysonSerializationSettings);
            Assert.True(json.Contains("1972-10-25T12:45:32"));

            JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
            jaysonDeserializationSettings.DateTimeZoneType = JaysonDateTimeZoneType.KeepAsIs;

            var date2 = JaysonConverter.ToObject<DateTime>(json, jaysonDeserializationSettings);
            Assert.NotNull(date2);
            Assert.IsAssignableFrom<DateTime>(date2);
            Assert.True(date1 == date2);
            Assert.True(date2.Kind == DateTimeKind.Local);
        }

        [Test]
        public static void TestDecimal1()
        {
            var dcml1 = 12345.67890123456789m;

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;
            jaysonSerializationSettings.Formatting = true;

            string json = JaysonConverter.ToJsonString(dcml1, jaysonSerializationSettings);
            Assert.True(json.Contains(".Decimal"));
            var dcml2 = JaysonConverter.ToObject(json);
            Assert.NotNull(dcml2);
            Assert.IsAssignableFrom<decimal>(dcml2);
            Assert.True(dcml1 == (decimal)dcml2);
        }

        [Test]
        public static void TestDecimal2()
        {
            var dcml1 = 12345.67890123456789m;

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.None;
            jaysonSerializationSettings.Formatting = true;

            string json = JaysonConverter.ToJsonString(dcml1, jaysonSerializationSettings);
            Assert.True(json == "12345.67890123456789");
            var dcml2 = JaysonConverter.ToObject(json);
            Assert.NotNull(dcml2);
            Assert.IsAssignableFrom<decimal>(dcml2);
            Assert.True(dcml1 == (decimal)dcml2);
        }

        [Test]
        public static void TestDecimal3()
        {
            var dcml1 = 12345.67890123456789m;
            var dto1 = new VerySimpleJsonValue
            {
                Value = dcml1
            };

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;
            jaysonSerializationSettings.Formatting = true;

            string json = JaysonConverter.ToJsonString(dto1, jaysonSerializationSettings);
            Assert.True(json.Contains(".Decimal"));
            var dto2 = JaysonConverter.ToObject<VerySimpleJsonValue>(json);
            Assert.NotNull(dto2);
            Assert.NotNull(dto2.Value);
            Assert.IsAssignableFrom<Decimal>(dto2.Value);
            Assert.True(dcml1 == (Decimal)dto2.Value);
        }

        [Test]
        public static void TestList1()
        {
            var list1 = new List<object> { null, true, false, 1, 1.4, 123456.6f, 1234.56789m, "Hello", "World", 
				new VerySimpleJsonValue { 
					Value = new VerySimpleJsonValue { 
						Value = true 
					} 
				} 
			};

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;
            jaysonSerializationSettings.Formatting = true;

            string json = JaysonConverter.ToJsonString(list1, jaysonSerializationSettings);
            Assert.True(json.Contains("Hello") && json.Contains("World"));
            var list2 = JaysonConverter.ToObject(json);
            Assert.NotNull(list2);
            Assert.IsAssignableFrom<List<object>>(list2);
            Assert.True(list1.Count == ((List<object>)list2).Count);
        }

        [Test]
        public static void TestList2()
        {
            var list1 = new List<object> { null, true, false, 1, 1.4, 123456.6d, 1234.56789m, "Hello", "World", 
				new VerySimpleJsonValue { 
					Value = new VerySimpleJsonValue { 
						Value = true 
					} 
				} 
			};

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.None;
            jaysonSerializationSettings.Formatting = true;

            string json = JaysonConverter.ToJsonString(list1, jaysonSerializationSettings);
            Assert.True(json.Contains("Hello") && json.Contains("World"));
            var list2 = JaysonConverter.ToObject(json);
            Assert.NotNull(list2);
            Assert.IsAssignableFrom<List<object>>(list2);
            Assert.True(list1.Count == ((IList<object>)list2).Count);
        }

        [Test]
        public static void TestList3()
        {
            var list1 = new ArrayList { null, true, false, 1, 1.4, 123456.6d, 1234.56789m, "Hello", "World", 
				new VerySimpleJsonValue { 
					Value = new VerySimpleJsonValue { 
						Value = true 
					} 
				} 
			};

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;
            jaysonSerializationSettings.Formatting = true;

            string json = JaysonConverter.ToJsonString(list1, jaysonSerializationSettings);
            Assert.True(json.Contains("Hello") && json.Contains("World"));
            var list2 = JaysonConverter.ToObject(json);
            Assert.NotNull(list2);
            Assert.IsAssignableFrom<ArrayList>(list2);
            Assert.True(list1.Count == ((IList)list2).Count);
        }

        [Test]
        public static void TestArrayList1()
        {
            var list1 = new ArrayList { null, true, false, 1, 1.4, 123456.6d, 1234.56789m, "Hello", "World", 
				new VerySimpleJsonValue { 
					Value = new VerySimpleJsonValue { 
						Value = true 
					} 
				} 
			};

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.None;
            jaysonSerializationSettings.Formatting = true;

            JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
            jaysonDeserializationSettings.ArrayType = ArrayDeserializationType.Array;

            string json = JaysonConverter.ToJsonString(list1, jaysonSerializationSettings);
            Assert.True(json.Contains("Hello") && json.Contains("World"));
            var list2 = JaysonConverter.ToObject(json, jaysonDeserializationSettings);
            Assert.NotNull(list2);
            Assert.IsAssignableFrom<object[]>(list2);
            Assert.True(list2.GetType().IsArray);
            Assert.True(list1.Count == ((IList)list2).Count);
        }

        [Test]
        public static void TestArrayList2()
        {
            var list1 = new ArrayList { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.None;
            jaysonSerializationSettings.Formatting = true;

            JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
            jaysonDeserializationSettings.ArrayType = ArrayDeserializationType.ArrayDefined;

            string json = JaysonConverter.ToJsonString(list1, jaysonSerializationSettings);
            Assert.True(json.Contains("1") && json.Contains("2"));
            var list2 = JaysonConverter.ToObject(json, jaysonDeserializationSettings);
            Assert.NotNull(list2);
            Assert.True(list2.GetType().IsArray);
            Assert.True(list1.Count == ((IList)list2).Count);
        }

        [Test]
        public static void TestArrayList3()
        {
            var list1 = new ArrayList { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, null };

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.None;
            jaysonSerializationSettings.Formatting = true;

            JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
            jaysonDeserializationSettings.ArrayType = ArrayDeserializationType.Array;

            string json = JaysonConverter.ToJsonString(list1, jaysonSerializationSettings);
            Assert.True(json.Contains("1") && json.Contains("2"));
            var list2 = JaysonConverter.ToObject(json, jaysonDeserializationSettings);
            Assert.NotNull(list2);
            Assert.True(list2.GetType().IsArray);
            Assert.True(list1.Count == ((IList)list2).Count);
        }

        [Test]
        public static void TestArray1a()
        {
            var list1 = new int[] { };

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;
            jaysonSerializationSettings.Formatting = true;

            JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
            jaysonDeserializationSettings.ArrayType = ArrayDeserializationType.ArrayDefined;

            string json = JaysonConverter.ToJsonString(list1, jaysonSerializationSettings);
            var list2 = JaysonConverter.ToObject(json, jaysonDeserializationSettings);
            Assert.NotNull(list2);
            Assert.True(list2.GetType().IsArray);
			Assert.AreEqual(list1.Length, ((IList)list2).Count);
			Assert.AreEqual(((IList)list2).Count, 0);
        }

		[Test]
		public static void TestArray1b()
		{
			var list1 = new int[] { };

			JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
			jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;
			jaysonSerializationSettings.Formatting = true;

			JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
			jaysonDeserializationSettings.ArrayType = ArrayDeserializationType.ArrayDefined;

			string json = JaysonConverter.ToJsonString(list1, jaysonSerializationSettings);
			var list2 = JaysonConverter.ToObject<int[]>(json, jaysonDeserializationSettings);
			Assert.NotNull(list2);
			Assert.True(list2.GetType().IsArray);
			Assert.AreEqual(list1.Length, list2.Length);
			Assert.AreEqual(list2.Length, 0);
		}

		[Test]
        public static void TestArray2a()
        {
            var list1 = new int[][] { };

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;
            jaysonSerializationSettings.Formatting = true;

            JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
            jaysonDeserializationSettings.ArrayType = ArrayDeserializationType.ArrayDefined;

            string json = JaysonConverter.ToJsonString(list1, jaysonSerializationSettings);
            var list2 = JaysonConverter.ToObject(json, jaysonDeserializationSettings);
            Assert.NotNull(list2);
            Assert.True(list2.GetType().IsArray);
			Assert.AreEqual(list1.Length, ((IList)list2).Count);
			Assert.AreEqual(((IList)list2).Count, 0);
        }

		[Test]
		public static void TestArray2b()
		{
			var list1 = new int[][] { };

			JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
			jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;
			jaysonSerializationSettings.Formatting = true;

			JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
			jaysonDeserializationSettings.ArrayType = ArrayDeserializationType.ArrayDefined;

			string json = JaysonConverter.ToJsonString(list1, jaysonSerializationSettings);
			var list2 = JaysonConverter.ToObject<int[][]>(json, jaysonDeserializationSettings);
			Assert.NotNull(list2);
			Assert.True(list2.GetType().IsArray);
			Assert.AreEqual(list1.Length, list2.Length);
			Assert.AreEqual(list2.Length, 0);
		}

		[Test]
		public static void TestArray3a()
		{
			var list1 = new int[][] { new int[] { } };

			JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
			jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;
			jaysonSerializationSettings.Formatting = true;

			JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
			jaysonDeserializationSettings.ArrayType = ArrayDeserializationType.ArrayDefined;

			string json = JaysonConverter.ToJsonString(list1, jaysonSerializationSettings);
			var list2 = JaysonConverter.ToObject(json, jaysonDeserializationSettings);
			Assert.NotNull(list2);
			Assert.True(list2.GetType().IsArray);
			Assert.AreEqual(list1.Length, ((IList)list2).Count);
			Assert.AreEqual(((IList)list2).Count, 1);
			Assert.True(((IList)list2)[0].GetType ().IsArray);
			Assert.AreEqual(((IList)((IList)list2)[0]).Count, 0);
		}

		[Test]
		public static void TestArray3b()
		{
			var list1 = new int[][] { new int[] { } };

			JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
			jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;
			jaysonSerializationSettings.Formatting = true;

			JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
			jaysonDeserializationSettings.ArrayType = ArrayDeserializationType.ArrayDefined;

			string json = JaysonConverter.ToJsonString(list1, jaysonSerializationSettings);
			var list2 = JaysonConverter.ToObject<int[][]>(json, jaysonDeserializationSettings);
			Assert.NotNull(list2);
			Assert.True(list2.GetType().IsArray);
			Assert.AreEqual(list1.Length, list2.Length);
			Assert.AreEqual(list2.Length, 1);
			Assert.AreEqual(list2[0].Length, 0);
		}

		[Test]
		public static void TestArray4a()
		{
			var list1 = new int[,] { };

			JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
			jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;
			jaysonSerializationSettings.Formatting = true;

			JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
			jaysonDeserializationSettings.ArrayType = ArrayDeserializationType.ArrayDefined;

			string json = JaysonConverter.ToJsonString(list1, jaysonSerializationSettings);
			var list2 = JaysonConverter.ToObject(json, jaysonDeserializationSettings);
			Assert.NotNull(list2);
			Assert.True(list2.GetType().IsArray);
			Assert.AreEqual(list1.Length, ((IList)list2).Count);
		}

		[Test]
		public static void TestArray4b()
		{
			var list1 = new int[,] { };

			JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
			jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;
			jaysonSerializationSettings.Formatting = true;

			JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
			jaysonDeserializationSettings.ArrayType = ArrayDeserializationType.ArrayDefined;

			string json = JaysonConverter.ToJsonString(list1, jaysonSerializationSettings);
			var list2 = JaysonConverter.ToObject<int[,]>(json, jaysonDeserializationSettings);
			Assert.NotNull(list2);
			Assert.True(list2.GetType().IsArray);
			Assert.AreEqual(list1.Length, list2.Length);
			Assert.AreEqual(list2.Rank, 2);
			Assert.AreEqual(list2.GetLength (0), 0);
			Assert.AreEqual(list2.GetLength (1), 0);
		}

        [Test]
        public static void TestArray5a()
        {
            var list1 = new int[,,] { };

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;
            jaysonSerializationSettings.Formatting = true;

            JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
            jaysonDeserializationSettings.ArrayType = ArrayDeserializationType.ArrayDefined;

            string json = JaysonConverter.ToJsonString(list1, jaysonSerializationSettings);
            var list2 = JaysonConverter.ToObject(json, jaysonDeserializationSettings);
            Assert.NotNull(list2);
            Assert.True(list2.GetType().IsArray);
			Assert.AreEqual(list1.Length, ((IList)list2).Count);
        }

		[Test]
		public static void TestArray5b()
		{
			var list1 = new int[,,] { };

			JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
			jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;
			jaysonSerializationSettings.Formatting = true;

			JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
			jaysonDeserializationSettings.ArrayType = ArrayDeserializationType.ArrayDefined;

			string json = JaysonConverter.ToJsonString(list1, jaysonSerializationSettings);
			var list2 = JaysonConverter.ToObject<int[,,]>(json, jaysonDeserializationSettings);
			Assert.NotNull(list2);
			Assert.True(list2.GetType().IsArray);
			Assert.AreEqual(list1.Length, list2.Length);
			Assert.AreEqual(list2.Rank, 3);
			Assert.AreEqual(list2.GetLength (0), 0);
			Assert.AreEqual(list2.GetLength (1), 0);
			Assert.AreEqual(list2.GetLength (2), 0);
		}

		[Test]
		public static void TestArray6a()
		{
			var list1 = new int[,,,] { };

			JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
			jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;
			jaysonSerializationSettings.Formatting = true;

			JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
			jaysonDeserializationSettings.ArrayType = ArrayDeserializationType.ArrayDefined;

			string json = JaysonConverter.ToJsonString(list1, jaysonSerializationSettings);
			var list2 = JaysonConverter.ToObject(json, jaysonDeserializationSettings);
			Assert.NotNull(list2);
			Assert.True(list2.GetType().IsArray);
			Assert.AreEqual(list1.Length, ((IList)list2).Count);
		}

		[Test]
		public static void TestArray6b()
		{
			var list1 = new int[,,,] { };

			JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
			jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;
			jaysonSerializationSettings.Formatting = true;

			JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
			jaysonDeserializationSettings.ArrayType = ArrayDeserializationType.ArrayDefined;

			string json = JaysonConverter.ToJsonString(list1, jaysonSerializationSettings);
			var list2 = JaysonConverter.ToObject<int[,,,]>(json, jaysonDeserializationSettings);
			Assert.NotNull(list2);
			Assert.True(list2.GetType().IsArray);
			Assert.AreEqual(list1.Length, list2.Length);
			Assert.AreEqual(list2.Rank, 4);
			Assert.AreEqual(list2.GetLength (0), 0);
			Assert.AreEqual(list2.GetLength (1), 0);
			Assert.AreEqual(list2.GetLength (2), 0);
			Assert.AreEqual(list2.GetLength (3), 0);
		}

        [Test]
        public static void TestArray7a()
        {
            var list1 = new int[][][] { 
                new int[][] { 
                    new int[] { }, 
                    new int[] { } 
                }, 
                new int[][] { }, 
                new int[][] {
                    new int[] { }
                } 
            };

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;
            jaysonSerializationSettings.Formatting = true;

            JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
            jaysonDeserializationSettings.ArrayType = ArrayDeserializationType.ArrayDefined;

            string json = JaysonConverter.ToJsonString(list1, jaysonSerializationSettings);
            var list2 = JaysonConverter.ToObject(json, jaysonDeserializationSettings);
            Assert.NotNull(list2);
            Assert.True(list2.GetType().IsArray);
			Assert.AreEqual(list1.Length, ((IList)list2).Count);

			Assert.AreEqual(((IList)list2).Count, 3);

			Assert.AreEqual(((IList)((IList)list2)[0]).Count, 2);
			Assert.AreEqual(((IList)((IList)list2)[1]).Count, 0);
			Assert.AreEqual(((IList)((IList)list2)[2]).Count, 1);
        }

        [Test]
        public static void TestArray7b()
        {
            var list1 = new int[][][] { 
                new int[][] { 
                    new int[] { }, 
                    new int[] { } 
                }, 
                new int[][] { }, 
                new int[][] {
                    new int[] { }
                } 
            };

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.None;
            jaysonSerializationSettings.Formatting = true;

            JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
            jaysonDeserializationSettings.ArrayType = ArrayDeserializationType.ArrayDefined;

            string json = JaysonConverter.ToJsonString(list1, jaysonSerializationSettings);
            var list2 = JaysonConverter.ToObject<int[][][]>(json, jaysonDeserializationSettings);
            Assert.NotNull(list2);
            Assert.True(list2.GetType().IsArray);
			Assert.AreEqual(list1.Length, list2.Length);

			Assert.AreEqual(list2.Length, 3);

			Assert.AreEqual(list2[0].Length, 2);
			Assert.AreEqual(list2[1].Length, 0);
			Assert.AreEqual(list2[2].Length, 1);

			Assert.AreEqual(list2[0][0].Length, 0);
			Assert.AreEqual(list2[0][1].Length, 0);
			Assert.AreEqual(list2[2][0].Length, 0);
        }

        [Test]
        public static void TestArray8a()
        {
            var list1 = new int[,,] { { }, { }, { } };

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;
            jaysonSerializationSettings.Formatting = true;

            JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
            jaysonDeserializationSettings.ArrayType = ArrayDeserializationType.ArrayDefined;

            string json = JaysonConverter.ToJsonString(list1, jaysonSerializationSettings);
            var list2 = JaysonConverter.ToObject(json, jaysonDeserializationSettings);
            Assert.NotNull(list2);
            Assert.True(list2.GetType().IsArray);
			Assert.AreEqual(list1.Length, ((Array)list2).Length);

			Assert.AreEqual(((Array)list2).Rank, 3);

			Assert.AreEqual(((Array)list2).GetLength (0), 3);
			Assert.AreEqual(((Array)list2).GetLength (1), 0);
			Assert.AreEqual(((Array)list2).GetLength (2), 0);
        }

		[Test]
		public static void TestArray8b()
		{
			var list1 = new int[,,] { { }, { }, { } };

			JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
			jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;
			jaysonSerializationSettings.Formatting = true;

			JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
			jaysonDeserializationSettings.ArrayType = ArrayDeserializationType.ArrayDefined;

			string json = JaysonConverter.ToJsonString(list1, jaysonSerializationSettings);
			var list2 = JaysonConverter.ToObject<int[,,]>(json, jaysonDeserializationSettings);

			Assert.NotNull(list2);
			Assert.True(list2.GetType().IsArray);
			Assert.AreEqual(list1.Length, list2.Length);

			Assert.AreEqual(list2.Rank, 3);

			Assert.AreEqual(list2.GetLength (0), 3);
			Assert.AreEqual(list2.GetLength (1), 0);
			Assert.AreEqual(list2.GetLength (2), 0);
		}

        [Test]
        public static void TestArray9a()
        {
            var list1 = new int[][,] { 
				new int[,] { }, 
                new int[,] { { 1, 2 } }, 
				new int[,] { { 3, 4 }, { 5, 6 } }, 
				new int[,] { { 7, 8, 9 }, { 10, 11, 12 }, { 13, 14, 15 } }
            };

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.None;
            jaysonSerializationSettings.Formatting = true;

            JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
            jaysonDeserializationSettings.ArrayType = ArrayDeserializationType.ArrayDefined;

            string json = JaysonConverter.ToJsonString(list1, jaysonSerializationSettings);
            var list2 = JaysonConverter.ToObject<int[][,]>(json, jaysonDeserializationSettings);
            
			Assert.NotNull(list2);
            Assert.True(list2.GetType().IsArray);
			Assert.AreEqual(list1.Length, list2.Length);

			Assert.AreEqual(list2.Length, 4);
			Assert.AreEqual(list2[0].Rank, 2);
			Assert.AreEqual(list2[1].Rank, 2);
			Assert.AreEqual(list2[2].Rank, 2);
			Assert.AreEqual(list2[3].Rank, 2);

			Assert.AreEqual(list2[0].GetLength (0), 0);
			Assert.AreEqual(list2[1].GetLength (0), 1);
			Assert.AreEqual(list2[1].GetLength (1), 2);
			Assert.AreEqual(list2[2].GetLength (0), 2);
			Assert.AreEqual(list2[2].GetLength (1), 2);
			Assert.AreEqual(list2[3].GetLength (0), 3);
			Assert.AreEqual(list2[3].GetLength (1), 3);

			Assert.AreEqual(list2[1][0,0], 1);
			Assert.AreEqual(list2[1][0,1], 2);

			Assert.AreEqual(list2[2][0,0], 3);
			Assert.AreEqual(list2[2][0,1], 4);
			Assert.AreEqual(list2[2][1,0], 5);
			Assert.AreEqual(list2[2][1,1], 6);

			Assert.AreEqual(list2[3][0,0], 7);
			Assert.AreEqual(list2[3][0,1], 8);
			Assert.AreEqual(list2[3][0,2], 9);
			Assert.AreEqual(list2[3][1,0], 10);
			Assert.AreEqual(list2[3][1,1], 11);
			Assert.AreEqual(list2[3][1,2], 12);
			Assert.AreEqual(list2[3][2,0], 13);
			Assert.AreEqual(list2[3][2,1], 14);
			Assert.AreEqual(list2[3][2,2], 15);
        }

		[Test]
		public static void TestArray10a()
		{
			var list1 = new int[,][] { 
				{ 
					new int[] { 1, 2 }, 
					new int[] { 3, 4 } 
				}, 
			};

			JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
			jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.None;
			jaysonSerializationSettings.Formatting = true;

			JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
			jaysonDeserializationSettings.ArrayType = ArrayDeserializationType.ArrayDefined;

			string json = JaysonConverter.ToJsonString(list1, jaysonSerializationSettings);
			var list2 = JaysonConverter.ToObject<int[,][]>(json, jaysonDeserializationSettings);

			Assert.NotNull(list2);
			Assert.True(list2.GetType().IsArray);
			Assert.AreEqual(list1.Length, list2.Length);

			Assert.AreEqual(list2[0,0][0], 1);
			Assert.AreEqual(list2[0,0][1], 2);
			Assert.AreEqual(list2[0,1][0], 3);
			Assert.AreEqual(list2[0,1][1], 4);
		}

		[Test]
		public static void TestArray10b()
		{
			var list1 = new int[][,] { 
				new int[,] {
					{ 1, 2 }, 
					{ 3, 4 },
					{ 5, 6 }
				}, 
			};

			JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
			jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.None;
			jaysonSerializationSettings.Formatting = true;

			JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
			jaysonDeserializationSettings.ArrayType = ArrayDeserializationType.ArrayDefined;

			string json = JaysonConverter.ToJsonString(list1, jaysonSerializationSettings);
			var list2 = JaysonConverter.ToObject<int[][,]>(json, jaysonDeserializationSettings);
			Assert.NotNull(list2);
			Assert.True(list2.GetType().IsArray);

			Assert.AreEqual(list1.Length, list2.Length);

			Assert.AreEqual(list2[0][0,0], 1);
			Assert.AreEqual(list2[0][0,1], 2);
			Assert.AreEqual(list2[0][1,0], 3);
			Assert.AreEqual(list2[0][1,1], 4);
			Assert.AreEqual(list2[0][2,0], 5);
			Assert.AreEqual(list2[0][2,1], 6);
		}

        [Test]
        public static void TestArray11()
        {
            var list1 = new int[,][] { 
                { 
					new int[] { 1 }, 
					new int[] { 2, 3 }
				}, 
                { 
					new int[] { 4, 5, 6 }, 
					new int[] { 7, 8, 9, 10 }
				}, 
                { 
					new int[] { 11, 12, 13, 14, 15 } ,
					new int[] { 16, 17, 18, 19, 20, 21 } 
				}
            };

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.None;
            jaysonSerializationSettings.Formatting = true;

            JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
            jaysonDeserializationSettings.ArrayType = ArrayDeserializationType.ArrayDefined;

            string json = JaysonConverter.ToJsonString(list1, jaysonSerializationSettings);
            var list2 = JaysonConverter.ToObject<int[,][]>(json, jaysonDeserializationSettings);
            Assert.NotNull(list2);
            Assert.True(list2.GetType().IsArray);

			Assert.AreEqual(list2.Rank, 2);

			Assert.AreEqual(list2[0,0].Length, 1);
			Assert.AreEqual(list2[0,1].Length, 2);
			Assert.AreEqual(list2[1,0].Length, 3);
			Assert.AreEqual(list2[1,1].Length, 4);
			Assert.AreEqual(list2[2,0].Length, 5);
			Assert.AreEqual(list2[2,1].Length, 6);

			Assert.AreEqual(list2[0,0][0], 1);
			Assert.AreEqual(list2[0,1][0], 2);
			Assert.AreEqual(list2[0,1][1], 3);

			Assert.AreEqual(list2[1,0][0], 4);
			Assert.AreEqual(list2[1,0][1], 5);
			Assert.AreEqual(list2[1,0][2], 6);
			Assert.AreEqual(list2[1,1][0], 7);
			Assert.AreEqual(list2[1,1][1], 8);
			Assert.AreEqual(list2[1,1][2], 9);
			Assert.AreEqual(list2[1,1][3], 10);

			Assert.AreEqual(list2[2,0][0], 11);
			Assert.AreEqual(list2[2,0][1], 12);
			Assert.AreEqual(list2[2,0][2], 13);
			Assert.AreEqual(list2[2,0][3], 14);
			Assert.AreEqual(list2[2,0][4], 15);

			Assert.AreEqual(list2[2,1][0], 16);
			Assert.AreEqual(list2[2,1][1], 17);
			Assert.AreEqual(list2[2,1][2], 18);
			Assert.AreEqual(list2[2,1][3], 19);
			Assert.AreEqual(list2[2,1][4], 20);
			Assert.AreEqual(list2[2,1][5], 21);
        }

        [Test]
        public static void TestArray12()
        {
            var list1 = new int[][][,] { 
                new int[][,] { 
                    new int[,] { { 1, 2 }, { 3, 4 } }, 
                    new int[,] { { 5, 6 }, { 7, 8 } } 
                }, 
				new int[][,] { }, 
				new int[][,] { 
					new int[,] { { 9, 10 } }
				}, 
                new int[][,] {
                    new int[,] { { 11, 12 }, { 13, 14 } }
                } 
            };

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.None;
            jaysonSerializationSettings.Formatting = true;

            JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
            jaysonDeserializationSettings.ArrayType = ArrayDeserializationType.ArrayDefined;

            string json = JaysonConverter.ToJsonString(list1, jaysonSerializationSettings);
            var list2 = JaysonConverter.ToObject<int[][][,]>(json, jaysonDeserializationSettings);
            Assert.NotNull(list2);
            Assert.True(list2.GetType().IsArray);
			Assert.True(list1.Length == list2.Length);
        }

        [Test]
        public static void TestReadOnlyCollection1()
        {
            var list1 = new ReadOnlyCollection<object>(
                new List<object> { null, true, false, 1, 1.4, 123456.6d, 1234.56789m, "Hello", "World", 
					new VerySimpleJsonValue { 
						Value = new VerySimpleJsonValue { 
							Value = true 
						} 
					} 
				});

            JaysonSerializationSettings jaysonSerializationSettings = JaysonSerializationSettings.DefaultClone();
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;
            jaysonSerializationSettings.Formatting = true;

            string json = JaysonConverter.ToJsonString(list1, jaysonSerializationSettings);
            Assert.True(json.Contains("Hello") && json.Contains("World"));
            var list2 = JaysonConverter.ToObject(json);
            Assert.NotNull(list2);
            Assert.IsAssignableFrom<ReadOnlyCollection<object>>(list2);
            Assert.True(list1.Count == ((IList<object>)list2).Count);
        }

        #if !(NET4000 || NET3500 || NET3000 || NET2000)
        [Test]
        public static void TestReadOnlyDictionary1()
        {
            var dict1 = new ReadOnlyDictionary<object, object>(
                new Dictionary<object, object> { 
					{ "null", null }, 
					{ true, false }, 
					{ 1, 1.4 }, 
					{ 123456.6d, 1234.56789m },
					{ "Hello", "World" }, 
					{ (int?)13579, new VerySimpleJsonValue { 
							Value = new VerySimpleJsonValue { 
								Value = true 
							} 
						} 
					}
				});

            JaysonSerializationSettings jaysonSerializationSettings = new JaysonSerializationSettings();
            jaysonSerializationSettings.IgnoreNullValues = false;
            jaysonSerializationSettings.TypeNames = JaysonTypeNameSerialization.All;
            jaysonSerializationSettings.Formatting = true;

            string json = JaysonConverter.ToJsonString(dict1, jaysonSerializationSettings);
            Assert.True(json.Contains("Hello") && json.Contains("World"));
            var dict2 = JaysonConverter.ToObject(json);
            Assert.NotNull(dict2);
            Assert.IsAssignableFrom<ReadOnlyDictionary<object, object>>(dict2);
            Assert.True(dict1.Count == ((ReadOnlyDictionary<object, object>)dict2).Count);
        }
        #endif

        [Test]
        public static void TestParse()
        {
            var dto1 = new SimpleObj
            {
                Value1 = "Hello",
                Value2 = "World"
            };

            string json = JaysonConverter.ToJsonString(dto1, new JaysonSerializationSettings());
            var obj = JaysonConverter.Parse(json);
            Assert.NotNull(obj);
            Assert.True(typeof(IDictionary<string, object>).IsAssignableFrom(obj.GetType()));
            Assert.True(((IDictionary<string, object>)obj).Count == 2);
        }

        [Test]
        public static void TestNoFormatting()
        {
            var dto1 = new SimpleObj
            {
                Value1 = "Hello",
                Value2 = "World"
            };

            JaysonSerializationSettings jaysonSerializationSettings = new JaysonSerializationSettings
            {
                Formatting = false
            };

            string json = JaysonConverter.ToJsonString(dto1, jaysonSerializationSettings);
            Assert.True(json.Contains("\"Value1\":\"Hello\"") &&
                json.Contains("\"Value2\":\"World\""));
        }

        [Test]
        public static void TestFormatting()
        {
            var dto1 = new SimpleObj
            {
                Value1 = "Hello",
                Value2 = "World"
            };

            JaysonSerializationSettings jaysonSerializationSettings = new JaysonSerializationSettings
            {
                Formatting = true
            };

            string json = JaysonConverter.ToJsonString(dto1, jaysonSerializationSettings);
            Assert.True(json.Contains("\"Value1\": \"Hello\"") &&
                json.Contains("\"Value2\": \"World\""));
        }

        [Test]
        public static void TestIncludeTypeInfoAuto()
        {
            var dto1 = new SimpleObj
            {
                Value1 = "Hello",
                Value2 = "World"
            };

            JaysonSerializationSettings jaysonSerializationSettings = new JaysonSerializationSettings
            {
                Formatting = false,
                TypeNameInfo = JaysonTypeNameInfo.TypeName,
                TypeNames = JaysonTypeNameSerialization.Auto
            };

            string json = JaysonConverter.ToJsonString(dto1, jaysonSerializationSettings);
            Assert.AreEqual(json, @"{""$type"":""Sweet.Jayson.Tests.SimpleObj"",""Value2"":""World"",""Value1"":""Hello""}");
        }

        [Test]
        public static void TestIncludeTypeInfo()
        {
            var dto1 = new SimpleObj
            {
                Value1 = "Hello",
                Value2 = "World"
            };

            JaysonSerializationSettings jaysonSerializationSettings = new JaysonSerializationSettings
            {
                Formatting = false,
                TypeNameInfo = JaysonTypeNameInfo.TypeName,
                TypeNames = JaysonTypeNameSerialization.All
            };

            string json = JaysonConverter.ToJsonString(dto1, jaysonSerializationSettings);
            Assert.AreEqual(json, @"{""$type"":""Sweet.Jayson.Tests.SimpleObj"",""Value2"":""World"",""Value1"":""Hello""}");
        }

        [Test]
        public static void TestIncludeTypeInfoWithAssembly()
        {
            var dto1 = new SimpleObj
            {
                Value1 = "Hello",
                Value2 = "World"
            };

            JaysonSerializationSettings jaysonSerializationSettings = new JaysonSerializationSettings
            {
                Formatting = false,
                TypeNameInfo = JaysonTypeNameInfo.TypeNameWithAssembly,
                TypeNames = JaysonTypeNameSerialization.All
            };

            string json = JaysonConverter.ToJsonString(dto1, jaysonSerializationSettings);
            Assert.AreEqual(json, @"{""$type"":""Sweet.Jayson.Tests.SimpleObj, Sweet.Jayson.Tests"",""Value2"":""World"",""Value1"":""Hello""}");
        }

        [Test]
        public static void TestSerializeSimpleDataTable()
        {
            DataTable dt1 = new DataTable("My DataTable 1", "myTableNamespace");
            dt1.Columns.Add(new DataColumn("col1", typeof(string), null, MappingType.Element));
            dt1.Columns.Add(new DataColumn("col2", typeof(bool)));
            dt1.Columns.Add(new DataColumn("col3", typeof(DateTime)));
            dt1.Columns.Add(new DataColumn("col4", typeof(SimpleObj)));

            dt1.Rows.Add(new object[] { null, true, new DateTime (1972, 10, 25, 12, 45, 32, DateTimeKind.Utc),
				new SimpleObj {
					Value1 = "Hello",
					Value2 = "World 1"
				}});
            dt1.Rows.Add(new object[] { "row2", false, new DateTime (1972, 10, 25, 12, 45, 32, DateTimeKind.Local),
				new SimpleObj {
					Value1 = "Hello",
					Value2 = "World 2"
				}});

            JaysonSerializationSettings jaysonSerializationSettings = new JaysonSerializationSettings
            {
                Formatting = true,
                TypeNameInfo = JaysonTypeNameInfo.TypeNameWithAssembly,
                TypeNames = JaysonTypeNameSerialization.Auto
            };

            string json = JaysonConverter.ToJsonString(dt1, jaysonSerializationSettings);
            Assert.True(json.Contains("My DataTable 1") && json.Contains("myTableNamespace"));
        }

        [Test]
        public static void TestSerializeSimpleDataSet()
        {
            DataSet ds = new DataSet("My DataSet");

            DataTable dt1 = new DataTable("My DataTable 1", "myTableNamespace");
            dt1.Columns.Add(new DataColumn("col1", typeof(string), null, MappingType.Element));
            dt1.Columns.Add(new DataColumn("col2", typeof(bool)));
            dt1.Columns.Add(new DataColumn("col3", typeof(DateTime)));
            dt1.Columns.Add(new DataColumn("col4", typeof(SimpleObj)));

            dt1.Rows.Add(new object[] { null, true, new DateTime (1972, 10, 25, 12, 45, 32, DateTimeKind.Utc),
				new SimpleObj {
					Value1 = "Hello",
					Value2 = "World 1"
				}});
            dt1.Rows.Add(new object[] { "row2", false, new DateTime (1972, 10, 25, 12, 45, 32, DateTimeKind.Local),
				new SimpleObj {
					Value1 = "Hello",
					Value2 = "World 2"
				}});

            ds.Tables.Add(dt1);

            JaysonSerializationSettings jaysonSerializationSettings = new JaysonSerializationSettings
            {
                Formatting = true,
                TypeNameInfo = JaysonTypeNameInfo.TypeNameWithAssembly,
                TypeNames = JaysonTypeNameSerialization.Auto
            };

            string json = JaysonConverter.ToJsonString(ds, jaysonSerializationSettings);
            Assert.True(json.Contains("My DataSet") && json.Contains("My DataTable 1") &&
                json.Contains("myTableNamespace"));
        }

        [Test]
        public static void TestDeserializeSimpleDataTable()
        {
            DataTable dt1 = new DataTable("My DataTable 1", "myTableNamespace");
            dt1.Columns.Add(new DataColumn("col1", typeof(string), null, MappingType.Element));
            dt1.Columns.Add(new DataColumn("col2", typeof(bool)));
            dt1.Columns.Add(new DataColumn("col3", typeof(DateTime)));
            dt1.Columns.Add(new DataColumn("col4", typeof(SimpleObj)));

            dt1.Rows.Add(new object[] { null, true, new DateTime (1972, 10, 25, 12, 45, 32, DateTimeKind.Utc),
				new SimpleObj {
					Value1 = "Hello",
					Value2 = "World 1"
				}});
            dt1.Rows.Add(new object[] { "row2", false, new DateTime (1972, 10, 25, 12, 45, 32, DateTimeKind.Local),
				new SimpleObj {
					Value1 = "Hello",
					Value2 = "World 2"
				}});

            JaysonSerializationSettings jaysonSerializationSettings = new JaysonSerializationSettings
            {
                Formatting = false,
                TypeNameInfo = JaysonTypeNameInfo.TypeNameWithAssembly,
                TypeNames = JaysonTypeNameSerialization.Auto
            };

            JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
            jaysonDeserializationSettings.CaseSensitive = true;

            string json = JaysonConverter.ToJsonString(dt1, jaysonSerializationSettings);
            DataTable dt2 = JaysonConverter.ToObject<DataTable>(json, jaysonDeserializationSettings);

            Assert.IsNotNull(dt2);
            Assert.True(dt1.Columns.Count == dt2.Columns.Count);
        }

        [Test]
        public static void TestDeserializeSimpleDataSet()
        {
            DataSet ds1 = new DataSet("My DataSet");

            DataTable dt1 = new DataTable("My DataTable 1", "myTableNamespace");
            dt1.Columns.Add(new DataColumn("col1", typeof(string), null, MappingType.Element));
            dt1.Columns.Add(new DataColumn("col2", typeof(bool)));
            dt1.Columns.Add(new DataColumn("col3", typeof(DateTime)));
            dt1.Columns.Add(new DataColumn("col4", typeof(SimpleObj)));

            dt1.Rows.Add(new object[] { null, true, new DateTime (1972, 10, 25, 12, 45, 32, DateTimeKind.Utc),
				new SimpleObj {
					Value1 = "Hello",
					Value2 = "World 1"
				}});
            dt1.Rows.Add(new object[] { "row2", false, new DateTime (1972, 10, 25, 12, 45, 32, DateTimeKind.Local),
				new SimpleObj {
					Value1 = "Hello",
					Value2 = "World 2"
				}});

            ds1.Tables.Add(dt1);

            JaysonSerializationSettings jaysonSerializationSettings = new JaysonSerializationSettings
            {
                Formatting = true,
                TypeNameInfo = JaysonTypeNameInfo.TypeNameWithAssembly,
                TypeNames = JaysonTypeNameSerialization.Auto
            };

            JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
            jaysonDeserializationSettings.CaseSensitive = true;

            string json = JaysonConverter.ToJsonString(ds1, jaysonSerializationSettings);
            Assert.True(json.Contains("My DataSet") && json.Contains("My DataTable 1") &&
                json.Contains("myTableNamespace"));

            DataSet ds2 = JaysonConverter.ToObject<DataSet>(json, jaysonDeserializationSettings);

            Assert.IsNotNull(ds2);
            Assert.True(ds1.Tables.Count == ds2.Tables.Count);
        }

        [Test]
        public static void TestDeserializeComplexDataSet()
        {
            DataSet ds1 = new DataSet("My DataSet");

            DataTable dt1 = new DataTable("My DataTable 1", "myTableNamespace1");
            dt1.Columns.Add(new DataColumn("id", typeof(long)));
            dt1.Columns.Add(new DataColumn("col1", typeof(string), null, MappingType.Element));
            dt1.Columns.Add(new DataColumn("col2", typeof(bool)));
            dt1.Columns.Add(new DataColumn("col3", typeof(DateTime)));
            dt1.Columns.Add(new DataColumn("col4", typeof(SimpleObj)));

            dt1.Columns[0].Unique = true;
            dt1.Columns[0].ExtendedProperties.Add("x1", "X1");

            dt1.Rows.Add(new object[] { 0, null, true, new DateTime (1972, 10, 25, 12, 45, 32, DateTimeKind.Utc),
				new SimpleObj {
					Value1 = "Hello",
					Value2 = "World 1"
				}});
            dt1.Rows.Add(new object[] { 1, "row2", false, new DateTime (1972, 10, 25, 12, 45, 32, DateTimeKind.Local),
				new SimpleObj {
					Value1 = "Hello",
					Value2 = "World 2"
				}});

            dt1.ExtendedProperties.Add("x2", 2);

            DataTable dt2 = new DataTable("My DataTable 2", "myTableNamespace2");
            dt2.Columns.Add(new DataColumn("id", typeof(long)));
            dt2.Columns.Add(new DataColumn("parentid", typeof(long)));
            dt2.Columns.Add(new DataColumn("col1", typeof(string)));

            dt2.Columns[0].Unique = true;
            dt2.ExtendedProperties.Add("x3", 3);

            dt2.Rows.Add(new object[] { 0, 0, "string1" });
            dt2.Rows.Add(new object[] { 1, 1, "string2" });
            dt2.Rows.Add(new object[] { 2, 0, "string3" });
            dt2.Rows.Add(new object[] { 3, 1, "string4" });
            dt2.Rows.Add(new object[] { 4, 0, "string5" });
            dt2.Rows.Add(new object[] { 5, 1, "string6" });
            dt2.Rows.Add(new object[] { 6, 0, "string7" });
            dt2.Rows.Add(new object[] { 7, 1, "string8" });
            dt2.Rows.Add(new object[] { 8, 0, "string9" });
            dt2.Rows.Add(new object[] { 9, 1, "string10" });

            ds1.Tables.Add(dt1);
            ds1.Tables.Add(dt2);
            ds1.ExtendedProperties.Add("x4", true);

            ds1.Relations.Add(new DataRelation("dr1", dt1.Columns[0], dt2.Columns[1], true));

            JaysonSerializationSettings jaysonSerializationSettings = new JaysonSerializationSettings
            {
                Formatting = true,
                TypeNameInfo = JaysonTypeNameInfo.TypeNameWithAssembly,
                TypeNames = JaysonTypeNameSerialization.All
            };

            JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
            jaysonDeserializationSettings.CaseSensitive = true;

            string json = JaysonConverter.ToJsonString(ds1, jaysonSerializationSettings);
            Assert.True(json.Contains("My DataSet") &&
                json.Contains("My DataTable 1") && json.Contains("myTableNamespace1") &&
                json.Contains("My DataTable 2") && json.Contains("myTableNamespace2"));

            DataSet ds2 = JaysonConverter.ToObject<DataSet>(json, jaysonDeserializationSettings);

            Assert.IsNotNull(ds2);
            Assert.True(ds1.Tables.Count == ds2.Tables.Count);
            Assert.IsNotNull(ds2.Tables["My DataTable 1", "myTableNamespace1"]);
            Assert.IsNotNull(ds2.Tables["My DataTable 2", "myTableNamespace2"]);
            Assert.IsNotNull(ds2.Relations["dr1"]);
        }

        [Test]
        public static void TestSerializeDeserializeCustomDataSetTypeAll()
        {
            CustomDataSet1 ds1 = new CustomDataSet1();

            ds1.Table1.Rows.Add(new object[] { 0, null, "y1" });
            ds1.Table1.Rows.Add(new object[] { 1, "row2", "y2" });

            ds1.Table2.Rows.Add(new object[] { 0, 0, 0, "y1" });
            ds1.Table2.Rows.Add(new object[] { 0, 1, 1, "y2" });
            ds1.Table2.Rows.Add(new object[] { 0, 2, 0, "y3" });
            ds1.Table2.Rows.Add(new object[] { 0, 3, 1, "y4" });
            ds1.Table2.Rows.Add(new object[] { 0, 4, 0, "y5" });
            ds1.Table2.Rows.Add(new object[] { 1, 0, 0, "y6" });
            ds1.Table2.Rows.Add(new object[] { 1, 1, 1, "y7" });
            ds1.Table2.Rows.Add(new object[] { 1, 2, 0, "y8" });
            ds1.Table2.Rows.Add(new object[] { 1, 3, 1, "y9" });
            ds1.Table2.Rows.Add(new object[] { 1, 4, 0, "y10" });

            ds1.Table1.Columns[0].ExtendedProperties.Add("x1", "X1");
            ds1.Table1.ExtendedProperties.Add("x2", 2);
            ds1.Table2.ExtendedProperties.Add("x3", 3);
            ds1.ExtendedProperties.Add("x4", true);

            JaysonSerializationSettings jaysonSerializationSettings = new JaysonSerializationSettings
            {
                Formatting = true,
                TypeNameInfo = JaysonTypeNameInfo.TypeNameWithAssembly,
                TypeNames = JaysonTypeNameSerialization.All
            };

            JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
            jaysonDeserializationSettings.CaseSensitive = true;

            string json = JaysonConverter.ToJsonString(ds1, jaysonSerializationSettings);
            DataSet ds2 = JaysonConverter.ToObject<DataSet>(json, jaysonDeserializationSettings);
            DataSet ds3 = JaysonConverter.ToObject<CustomDataSet1>(json, jaysonDeserializationSettings);

            Assert.IsNotNull(ds2);
            Assert.True(ds1.Tables.Count == ds2.Tables.Count);
            Assert.True(ds1.Tables.Count == ds3.Tables.Count);
        }

        [Test]
        public static void TestSerializeDeserializeCustomDataSetTypeNone()
        {
            CustomDataSet1 ds1 = new CustomDataSet1();

            ds1.Table1.Rows.Add(new object[] { 0, null, "y1" });
            ds1.Table1.Rows.Add(new object[] { 1, "row2", "y2" });

            ds1.Table2.Rows.Add(new object[] { 0, 0, 0, "y1" });
            ds1.Table2.Rows.Add(new object[] { 0, 1, 1, "y2" });
            ds1.Table2.Rows.Add(new object[] { 0, 2, 0, "y3" });
            ds1.Table2.Rows.Add(new object[] { 0, 3, 1, "y4" });
            ds1.Table2.Rows.Add(new object[] { 0, 4, 0, "y5" });
            ds1.Table2.Rows.Add(new object[] { 1, 0, 0, "y6" });
            ds1.Table2.Rows.Add(new object[] { 1, 1, 1, "y7" });
            ds1.Table2.Rows.Add(new object[] { 1, 2, 0, "y8" });
            ds1.Table2.Rows.Add(new object[] { 1, 3, 1, "y9" });
            ds1.Table2.Rows.Add(new object[] { 1, 4, 0, "y10" });

            ds1.Table1.Columns[0].ExtendedProperties.Add("x1", "X1");
            ds1.Table1.ExtendedProperties.Add("x2", 2);
            ds1.Table2.ExtendedProperties.Add("x3", 3);
            ds1.ExtendedProperties.Add("x4", true);

            JaysonSerializationSettings jaysonSerializationSettings = new JaysonSerializationSettings
            {
                Formatting = true,
                TypeNameInfo = JaysonTypeNameInfo.TypeNameWithAssembly,
                TypeNames = JaysonTypeNameSerialization.None
            };

            JaysonDeserializationSettings jaysonDeserializationSettings = JaysonDeserializationSettings.DefaultClone();
            jaysonDeserializationSettings.CaseSensitive = true;

            string json = JaysonConverter.ToJsonString(ds1, jaysonSerializationSettings);
            DataSet ds2 = JaysonConverter.ToObject<DataSet>(json, jaysonDeserializationSettings);
            DataSet ds3 = JaysonConverter.ToObject<CustomDataSet1>(json, jaysonDeserializationSettings);

            Assert.IsNotNull(ds2);
            Assert.True(ds1.Tables.Count == ds2.Tables.Count);
            Assert.True(ds1.Tables.Count == ds3.Tables.Count);
        }

		[Test]
		public static void TestToJsonObjectCustomDataSet()
		{
			CustomDataSet1 ds1 = new CustomDataSet1();

			ds1.Table1.Rows.Add(new object[] { 0, null, "y1" });
			ds1.Table1.Rows.Add(new object[] { 1, "row2", "y2" });

			ds1.Table2.Rows.Add(new object[] { 0, 0, 0, "y1" });
			ds1.Table2.Rows.Add(new object[] { 0, 1, 1, "y2" });
			ds1.Table2.Rows.Add(new object[] { 0, 2, 0, "y3" });
			ds1.Table2.Rows.Add(new object[] { 0, 3, 1, "y4" });
			ds1.Table2.Rows.Add(new object[] { 0, 4, 0, "y5" });
			ds1.Table2.Rows.Add(new object[] { 1, 0, 0, "y6" });
			ds1.Table2.Rows.Add(new object[] { 1, 1, 1, "y7" });
			ds1.Table2.Rows.Add(new object[] { 1, 2, 0, "y8" });
			ds1.Table2.Rows.Add(new object[] { 1, 3, 1, "y9" });
			ds1.Table2.Rows.Add(new object[] { 1, 4, 0, "y10" });

			ds1.Table1.Columns[0].ExtendedProperties.Add("x1", "X1");
			ds1.Table1.ExtendedProperties.Add("x2", 2);
			ds1.Table2.ExtendedProperties.Add("x3", 3);
			ds1.ExtendedProperties.Add("x4", true);

			JaysonSerializationSettings jaysonSerializationSettings = new JaysonSerializationSettings
			{
				Formatting = true,
				TypeNameInfo = JaysonTypeNameInfo.TypeNameWithAssembly,
				TypeNames = JaysonTypeNameSerialization.None
			};

			var jsonObj = JaysonConverter.ToJsonObject(ds1, jaysonSerializationSettings);

			Assert.IsNotNull(jsonObj);
		}
    }
}
