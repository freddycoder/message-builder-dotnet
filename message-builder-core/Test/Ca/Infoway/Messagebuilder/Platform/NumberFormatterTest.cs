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
 * Author:        $LastChangedBy: gng $
 * Last modified: $LastChangedDate: 2015-11-19 18:20:12 -0500 (Fri, 30 Jan 2015) $
 * Revision:      $LastChangedRevision: 9755 $
 */


using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Platform;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Platform
{
	[TestFixture]
	public class NumberFormatterTest
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldFormatBigDecimal()
		{
			Assert.AreEqual("1.00", new NumberFormatter().Format(new BigDecimal("1.0"), 10, 1, 2, true), "result");
			Assert.AreEqual("1", new NumberFormatter().Format(new BigDecimal("1.0"), 10, 1, 2, false), "result");
			Assert.AreEqual("11.00", new NumberFormatter().Format(new BigDecimal("11111.0"), 5, 2, 2, true), "result");
			// BCH: This result is questionable.  Confirm at a later date.
			Assert.AreEqual("11", new NumberFormatter().Format(new BigDecimal("11111.0"), 5, 2, 2, false), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldRound()
		{
			Assert.AreEqual("1.01", new NumberFormatter().Format(new BigDecimal("1.008"), 10, 1, 2, true), "result");
		}
	}
}
