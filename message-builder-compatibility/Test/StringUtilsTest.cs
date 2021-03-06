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
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder {

	[TestFixture]
	public class StringUtilsTest {

        [Test]
        public virtual void TestEqualsIgnoreCaseBothNull() {
            Assert.IsTrue(StringUtils.EqualsIgnoreCase(null, null));
        }

        [Test]
        public virtual void TestEqualsIgnoreCaseOneNull() {
            Assert.IsFalse(StringUtils.EqualsIgnoreCase("string1", null));
        }

        [Test]
        public virtual void TestEqualsIgnoreCaseDifferentStrings() {
            Assert.IsFalse(StringUtils.EqualsIgnoreCase("string1", "string2"));
        }

        [Test]
        public virtual void TestEqualsIgnoreCaseDifferentCase() {
            Assert.IsTrue(StringUtils.EqualsIgnoreCase("string1", "StRInG1"));
        }

        [Test]
        public virtual void TestEqualsIgnoreCaseSameCase() {
            Assert.IsTrue(StringUtils.EqualsIgnoreCase("string1", "string1"));
        }
    }

}