/**
 * Copyright 2012 Canada Health Infoway, Inc.
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
 * Last modified: $LastChangedDate: 2011-05-17 11:48:36 -0400 (Tue, 17 May 2011) $
 * Revision:      $LastChangedRevision: 2666 $
 */

using System;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder
{
	[TestFixture]
	public class BigDecimalTest
	{
		
		[Test]
		public virtual void TestPlusOperator()
		{
			Assert.AreEqual(new BigDecimal("50") + new BigDecimal("50"), new BigDecimal("100"));
		}
		
		[Test]
		public virtual void TestMultiplyOperator()
		{
			Assert.AreEqual(new BigDecimal("25") * new BigDecimal("4"), new BigDecimal("100"));
		}

		[Test]
		public virtual void TestSubstractOperator()
		{
			Assert.AreEqual(new BigDecimal("100") - new BigDecimal("75"), new BigDecimal("25"));
		}

		[Test]
		public virtual void TestDivideOperator()
		{
			Assert.AreEqual(new BigDecimal("1") / new BigDecimal("4"), new BigDecimal(".25"));
		}

		[Test]
		public virtual void TestDifferentFromOperator()
		{
			Assert.IsTrue(new BigDecimal("5") != new BigDecimal("25"));
			Assert.IsFalse(new BigDecimal("5") != new BigDecimal("5"));
		}

		[Test]
		public virtual void TestDifferentFromOperatorRightNull()
		{
			Assert.IsTrue(new BigDecimal("5") != null);
		}

		[Test]
		public virtual void TestDifferentFromOperatorLeftNull()
		{
			Assert.IsTrue(null != new BigDecimal("5"));
		}
		
		[Test]
		public virtual void TestLowerThanOperator()
		{
			Assert.IsTrue(new BigDecimal("5") < new BigDecimal("25"));
		}

		[Test]
		public virtual void TestEqualToOperator()
		{
			Assert.IsTrue(new BigDecimal("5") == new BigDecimal("5"));
			Assert.IsFalse(new BigDecimal("5") == new BigDecimal("25"));
		}

		[Test]
		public virtual void TestEqualToOperatorRightNull()
		{
			Assert.IsFalse(new BigDecimal("5") == null);
		}

		[Test]
		public virtual void TestEqualToOperatorLeftNull()
		{
			Assert.IsFalse(null == new BigDecimal("5"));
		}
		
		[Test]
		public virtual void TestGreaterThanOperator()
		{
			Assert.IsTrue(new BigDecimal("25") > new BigDecimal("5"));
		}
		
	}
}

