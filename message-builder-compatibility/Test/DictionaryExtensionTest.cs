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
	public class DictionaryExtensionTest {

        [Test]
        public virtual void TestSafeGetNullKey() {
            IDictionary<string, string> dictionary = new Dictionary<string, string>();

            Assert.IsNull(dictionary.SafeGet(null));
        }

        [Test]
        public virtual void TestSafeGetKeyDoesNotExist() {
            IDictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("key", "value");

            Assert.IsNull(dictionary.SafeGet("some-other-key"));
        }

        [Test]
        public virtual void TestSafeGetKeyExists() {
            IDictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("key", "value");

            Assert.AreEqual("value", dictionary.SafeGet("key"));
        }
    }
}