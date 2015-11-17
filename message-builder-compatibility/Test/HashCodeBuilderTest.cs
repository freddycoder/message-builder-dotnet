/**
 * Copyright 2013 Canada Health Infoway, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *        http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 * Author:        $LastChangedBy: tmcgrady $
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
﻿using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder {

	[TestFixture]
    public class HashCodeBuilderTest {

        public class TestObject {
            private IList<string> stringList = new List<string>();
            private ISet<string> stringSet = new HashSet<string>();
            private IDictionary<string, string> dictionary = new Dictionary<string, string>();

            public void AddStringToList(string stringValue) {
                stringList.Add(stringValue);
            }

            public void AddStringToSet(string stringValue) {
                stringSet.Add(stringValue);
            }

            public void AddDictionaryEntry(string key, string value) {
                dictionary.Add(key, value);
            }

            public override int GetHashCode() {
                return new HashCodeBuilder()
                        .Append(this.stringList)
                        .Append(this.stringSet)
                        .Append(this.dictionary)
                        .ToHashCode();
            }

        }

        [Test]
        public virtual void TestListSameContents() {
            TestObject object1 = new TestObject();
            TestObject object2 = new TestObject();

            object1.AddStringToList("foo");
            object2.AddStringToList("foo");
            object1.AddStringToList("bar");
            object2.AddStringToList("bar");

            Assert.AreEqual(object1.GetHashCode(), object2.GetHashCode());
        }

        [Test]
        public virtual void TestListDifferentSize() {
            TestObject object1 = new TestObject();
            TestObject object2 = new TestObject();

            object1.AddStringToList("foo");
            object2.AddStringToList("foo");
            object1.AddStringToList("bar");

            Assert.AreNotEqual(object1.GetHashCode(), object2.GetHashCode());
        }

        [Test]
        public virtual void TestListDifferentContents() {
            TestObject object1 = new TestObject();
            TestObject object2 = new TestObject();

            object1.AddStringToList("foo");
            object2.AddStringToList("foo");
            object1.AddStringToList("bar");
            object2.AddStringToList("baz");

            Assert.AreNotEqual(object1.GetHashCode(), object2.GetHashCode());
        }

        [Test]
        public virtual void TestSetContentsDiffer() {
            TestObject object1 = new TestObject();
            TestObject object2 = new TestObject();

            object1.AddStringToSet("string1");
            object2.AddStringToSet("string2");

            Assert.AreNotEqual(object1.GetHashCode(), object2.GetHashCode());
        }

        [Test]
        public virtual void TestSetContentsSame() {
            TestObject object1 = new TestObject();
            TestObject object2 = new TestObject();

            object1.AddStringToSet("string1");
            object2.AddStringToSet("string1");
            object1.AddStringToSet("string2");
            object2.AddStringToSet("string2");

            Assert.AreEqual(object1.GetHashCode(), object2.GetHashCode());
        }

        [Test]
        public virtual void TestDictionaryContentsSame() {
            TestObject object1 = new TestObject();
            TestObject object2 = new TestObject();

            object1.AddDictionaryEntry("key1", "value1");
            object2.AddDictionaryEntry("key1", "value1");
            object1.AddDictionaryEntry("key2", "value2");
            object2.AddDictionaryEntry("key2", "value2");

            Assert.AreEqual(object1.GetHashCode(), object2.GetHashCode());
        }

        [Test]
        public virtual void TestDictionaryContentsDifferentValue() {
            TestObject object1 = new TestObject();
            TestObject object2 = new TestObject();

            object1.AddDictionaryEntry("key1", "value1");
            object2.AddDictionaryEntry("key1", "value1");
            object1.AddDictionaryEntry("key2", "value2");
            object2.AddDictionaryEntry("key2", "value3");

            Assert.AreNotEqual(object1.GetHashCode(), object2.GetHashCode());
        }

        [Test]
        public virtual void TestDictionaryContentsDifferentKey() {
            TestObject object1 = new TestObject();
            TestObject object2 = new TestObject();

            object1.AddDictionaryEntry("key1", "value1");
            object2.AddDictionaryEntry("key1", "value1");
            object1.AddDictionaryEntry("key3", "value2");
            object2.AddDictionaryEntry("key2", "value2");

            Assert.AreNotEqual(object1.GetHashCode(), object2.GetHashCode());
        }
    }
}