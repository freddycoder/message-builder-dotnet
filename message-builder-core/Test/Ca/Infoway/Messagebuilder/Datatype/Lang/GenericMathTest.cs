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
using System;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Datatype.Lang
{
	[TestFixture]
	public class GenericMathTest
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestAddIntegers()
		{
			AssertAdd(12, 15);
			AssertAdd(129, 88);
			AssertAdd(null, 256);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestAddIntegersDiff()
		{
			AssertAdd(12, new Diff<Int32?>(15));
			AssertAdd(129, new Diff<Int32?>(88));
			AssertAdd(null, new Diff<Int32?>(256));
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestAddDateAndDiff()
		{
			PlatformDate low = new PlatformDate(0);
			PlatformDate add = GenericMath.Add(low, new Diff<PlatformDate>((PlatformDate)null));
			Assert.AreEqual(low, add);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestAddDateDiff()
		{
			AssertAdd(ParseDate("2006-02-15"), ParseDate("2006-01-15"), new DateDiff(1, Ca.Infoway.Messagebuilder.Domainvalue.Basic.DefaultTimeUnit
				.MONTH));
			AssertAdd(ParseDate("2006-03-15"), ParseDate("2006-02-15"), new DateDiff(1, Ca.Infoway.Messagebuilder.Domainvalue.Basic.DefaultTimeUnit
				.MONTH));
			AssertAdd(ParseDate("2006-02-16"), ParseDate("2006-02-15"), new DateDiff(1, Ca.Infoway.Messagebuilder.Domainvalue.Basic.DefaultTimeUnit
				.DAY));
			AssertAdd(ParseDate("2006-02-20"), ParseDate("2006-02-15"), new DateDiff(5, Ca.Infoway.Messagebuilder.Domainvalue.Basic.DefaultTimeUnit
				.DAY));
			AssertAdd(ParseDate("2006-02-22"), ParseDate("2006-02-15"), new DateDiff(1, Ca.Infoway.Messagebuilder.Domainvalue.Basic.DefaultTimeUnit
				.WEEK));
		}

		private void AssertAdd(PlatformDate expected, PlatformDate date, DateDiff diff)
		{
			Assert.AreEqual(expected, GenericMath.Add(date, diff));
		}

		/// <exception cref="ILOG.J2CsMapping.Util.ParseException"></exception>
		private PlatformDate ParseDate(string @string)
		{
			return DateUtils.ParseDate(@string, new string[] { "yyyy-MM-dd" });
		}

		private void AssertAdd(Int32? i, Diff<Int32?> j)
		{
			Assert.AreEqual((i == null ? 0 : i) + (j == null ? 0 : j.Value), GenericMath.Add(i, j));
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestAddLong()
		{
			AssertAdd(12L, 15L);
			AssertAdd(129L, 88L);
			AssertAdd(129L, null);
		}

		private void AssertAdd(Int32? i, Int32? j)
		{
			Assert.AreEqual((i == null ? 0 : i) + (j == null ? 0 : j), GenericMath.Add(i, j));
		}

		private void AssertAdd(Int64? i, Int64? j)
		{
			Assert.AreEqual((i == null ? 0 : i) + (j == null ? 0 : j), GenericMath.Add(i, j));
		}

		///////////////  Physical Quantities test
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestPhysicalQuantityHalf()
		{
			Assert.AreEqual(new BigDecimal("1.50"), GenericMath.Half(new PhysicalQuantity(new BigDecimal("3.0"), Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.KILOGRAM)).Quantity);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestPhysicalQuantityAverage()
		{
			Assert.AreEqual(new BigDecimal("2.00"), GenericMath.Average(new PhysicalQuantity(new BigDecimal("3.0"), Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.KILOGRAM), new PhysicalQuantity(new BigDecimal("1.0"), Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.KILOGRAM)).Quantity);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestPhysicalQuantityDiff()
		{
			Assert.AreEqual(new BigDecimal("1.0"), GenericMath.Diff(new PhysicalQuantity(new BigDecimal("2.0"), Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.KILOGRAM), new PhysicalQuantity(new BigDecimal("3.0"), Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.KILOGRAM)).Value.Quantity);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestAddPhysicalQuantities()
		{
			AssertAdd(new PhysicalQuantity(new BigDecimal("123"), Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.MILLIMETER), new PhysicalQuantity(new BigDecimal("88"), Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.MILLIMETER));
			Diff<PhysicalQuantity> diff = new Diff<PhysicalQuantity>(new PhysicalQuantity(new BigDecimal("88"), Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.MILLIMETER));
			Assert.AreEqual(new BigDecimal(211), GenericMath.Add(new PhysicalQuantity(new BigDecimal("123"), Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.MILLIMETER), diff).Quantity);
			try
			{
				GenericMath.Add(new PhysicalQuantity(new BigDecimal("123"), Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
					.MILLIMETER), new PhysicalQuantity(new BigDecimal("88"), Ca.Infoway.Messagebuilder.Domainvalue.Basic.DefaultTimeUnit.DAY
					));
				Assert.Fail("mismatched units");
			}
			catch (ArgumentException)
			{
			}
		}

		// expected
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestPhysicalQuantitiesAsNull()
		{
			Assert.AreEqual(null, GenericMath.Add((PhysicalQuantity)null, (PhysicalQuantity)null));
			Assert.AreEqual(new BigDecimal(123), GenericMath.Add(new PhysicalQuantity(new BigDecimal("123"), Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.MILLIMETER), (PhysicalQuantity)null).Quantity);
			Assert.AreEqual(new BigDecimal(123), GenericMath.Add((PhysicalQuantity)null, new PhysicalQuantity(new BigDecimal("123"), 
				Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive.MILLIMETER)).Quantity);
			Assert.AreEqual(null, GenericMath.Add((PhysicalQuantity)null, (Diff<PhysicalQuantity>)null));
			Assert.AreEqual(new BigDecimal(123), GenericMath.Add(new PhysicalQuantity(new BigDecimal("123"), Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.MILLIMETER), (Diff<PhysicalQuantity>)null).Quantity);
			Assert.AreEqual(new BigDecimal(123), GenericMath.Add((PhysicalQuantity)null, new PhysicalQuantity(new BigDecimal("123"), 
				Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive.MILLIMETER)).Quantity);
			Assert.AreEqual(null, GenericMath.Average((PhysicalQuantity)null, (PhysicalQuantity)null));
			Assert.AreEqual(new BigDecimal(61.50), GenericMath.Average(new PhysicalQuantity(new BigDecimal("123"), Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.MILLIMETER), (PhysicalQuantity)null).Quantity);
			Assert.AreEqual(new BigDecimal(61.50), GenericMath.Average((PhysicalQuantity)null, new PhysicalQuantity(new BigDecimal("123"
				), Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive.MILLIMETER)).Quantity);
			Assert.AreEqual(null, GenericMath.Diff((PhysicalQuantity)null, (PhysicalQuantity)null));
			Assert.AreEqual(null, GenericMath.Diff(new PhysicalQuantity(new BigDecimal("123"), Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.MILLIMETER), (PhysicalQuantity)null));
			Assert.AreEqual(null, GenericMath.Diff((PhysicalQuantity)null, new PhysicalQuantity(new BigDecimal("123"), Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.MILLIMETER)));
			Assert.AreEqual(null, GenericMath.Half(((PhysicalQuantity)null)));
		}

		private void AssertAdd(PhysicalQuantity quantity, PhysicalQuantity quantity2)
		{
			Assert.AreEqual(quantity.Quantity.Add(quantity2.Quantity), GenericMath.Add(quantity, quantity2).Quantity);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestPhysicalQuantitiesWithInnerValuesAsNull()
		{
			PhysicalQuantity pqBothOk = new PhysicalQuantity(new BigDecimal("123"), Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.MILLIMETER);
			PhysicalQuantity pqUnitsNull = new PhysicalQuantity(new BigDecimal("123"), null);
			PhysicalQuantity pqValueNull = new PhysicalQuantity(null, Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.MILLIMETER);
			PhysicalQuantity pqBothNull = new PhysicalQuantity(null, null);
			// add
			Assert.AreEqual(null, GenericMath.Add(pqBothNull, pqBothNull).Quantity);
			Assert.AreEqual(new BigDecimal(123), GenericMath.Add(pqBothNull, pqUnitsNull).Quantity);
			AssertPhysicalQuantityAddFails(pqBothNull, pqValueNull);
			AssertPhysicalQuantityAddFails(pqBothNull, pqBothOk);
			Assert.AreEqual(new BigDecimal(123), GenericMath.Add(pqUnitsNull, pqBothNull).Quantity);
			Assert.AreEqual(new BigDecimal(246), GenericMath.Add(pqUnitsNull, pqUnitsNull).Quantity);
			AssertPhysicalQuantityAddFails(pqUnitsNull, pqValueNull);
			AssertPhysicalQuantityAddFails(pqUnitsNull, pqBothOk);
			AssertPhysicalQuantityAddFails(pqValueNull, pqBothNull);
			AssertPhysicalQuantityAddFails(pqValueNull, pqUnitsNull);
			Assert.AreEqual(null, GenericMath.Add(pqValueNull, pqValueNull).Quantity);
			Assert.AreEqual(new BigDecimal(123), GenericMath.Add(pqValueNull, pqBothOk).Quantity);
			AssertPhysicalQuantityAddFails(pqBothOk, pqBothNull);
			AssertPhysicalQuantityAddFails(pqBothOk, pqUnitsNull);
			Assert.AreEqual(new BigDecimal(123), GenericMath.Add(pqBothOk, pqValueNull).Quantity);
			Assert.AreEqual(new BigDecimal(246), GenericMath.Add(pqBothOk, pqBothOk).Quantity);
			// add diff
			Assert.AreEqual(null, GenericMath.Add(pqBothNull, new Diff<PhysicalQuantity>(pqBothNull)).Quantity);
			Assert.AreEqual(new BigDecimal(123), GenericMath.Add(pqBothNull, new Diff<PhysicalQuantity>(pqUnitsNull)).Quantity);
			AssertPhysicalQuantityAddFails(pqBothNull, new Diff<PhysicalQuantity>(pqValueNull));
			AssertPhysicalQuantityAddFails(pqBothNull, new Diff<PhysicalQuantity>(pqBothOk));
			Assert.AreEqual(new BigDecimal(123), GenericMath.Add(pqUnitsNull, new Diff<PhysicalQuantity>(pqBothNull)).Quantity);
			Assert.AreEqual(new BigDecimal(246), GenericMath.Add(pqUnitsNull, new Diff<PhysicalQuantity>(pqUnitsNull)).Quantity);
			AssertPhysicalQuantityAddFails(pqUnitsNull, new Diff<PhysicalQuantity>(pqValueNull));
			AssertPhysicalQuantityAddFails(pqUnitsNull, new Diff<PhysicalQuantity>(pqBothOk));
			AssertPhysicalQuantityAddFails(pqValueNull, new Diff<PhysicalQuantity>(pqBothNull));
			AssertPhysicalQuantityAddFails(pqValueNull, new Diff<PhysicalQuantity>(pqUnitsNull));
			Assert.AreEqual(null, GenericMath.Add(pqValueNull, new Diff<PhysicalQuantity>(pqValueNull)).Quantity);
			Assert.AreEqual(new BigDecimal(123), GenericMath.Add(pqValueNull, new Diff<PhysicalQuantity>(pqBothOk)).Quantity);
			AssertPhysicalQuantityAddFails(pqBothOk, new Diff<PhysicalQuantity>(pqBothNull));
			AssertPhysicalQuantityAddFails(pqBothOk, new Diff<PhysicalQuantity>(pqUnitsNull));
			Assert.AreEqual(new BigDecimal(123), GenericMath.Add(pqBothOk, new Diff<PhysicalQuantity>(pqValueNull)).Quantity);
			Assert.AreEqual(new BigDecimal(246), GenericMath.Add(pqBothOk, new Diff<PhysicalQuantity>(pqBothOk)).Quantity);
			// average
			Assert.AreEqual(null, GenericMath.Average(pqBothNull, pqBothNull).Quantity);
			Assert.AreEqual(new BigDecimal(61.5), GenericMath.Average(pqBothNull, pqUnitsNull).Quantity);
			AssertPhysicalQuantityAverageFails(pqBothNull, pqValueNull);
			AssertPhysicalQuantityAverageFails(pqBothNull, pqBothOk);
			Assert.AreEqual(new BigDecimal(61.5), GenericMath.Average(pqUnitsNull, pqBothNull).Quantity);
			Assert.AreEqual(new BigDecimal(123).SetScale(1), GenericMath.Average(pqUnitsNull, pqUnitsNull).Quantity);
			AssertPhysicalQuantityAverageFails(pqUnitsNull, pqValueNull);
			AssertPhysicalQuantityAverageFails(pqUnitsNull, pqBothOk);
			AssertPhysicalQuantityAverageFails(pqValueNull, pqBothNull);
			AssertPhysicalQuantityAverageFails(pqValueNull, pqUnitsNull);
			Assert.AreEqual(null, GenericMath.Average(pqValueNull, pqValueNull).Quantity);
			Assert.AreEqual(new BigDecimal(61.5), GenericMath.Average(pqValueNull, pqBothOk).Quantity);
			AssertPhysicalQuantityAverageFails(pqBothOk, pqBothNull);
			AssertPhysicalQuantityAverageFails(pqBothOk, pqUnitsNull);
			Assert.AreEqual(new BigDecimal(61.5), GenericMath.Average(pqBothOk, pqValueNull).Quantity);
			Assert.AreEqual(new BigDecimal(123).SetScale(1), GenericMath.Average(pqBothOk, pqBothOk).Quantity);
			// diff
			Assert.AreEqual(null, GenericMath.Diff(pqBothNull, pqBothNull));
			Assert.AreEqual(null, GenericMath.Diff(pqBothNull, pqUnitsNull));
			AssertPhysicalQuantityDiffFails(pqBothNull, pqValueNull);
			AssertPhysicalQuantityDiffFails(pqBothNull, pqBothOk);
			Assert.AreEqual(null, GenericMath.Diff(pqUnitsNull, pqBothNull));
			Assert.AreEqual(new BigDecimal(0), GenericMath.Diff(pqUnitsNull, pqUnitsNull).Value.Quantity);
			AssertPhysicalQuantityDiffFails(pqUnitsNull, pqValueNull);
			AssertPhysicalQuantityDiffFails(pqUnitsNull, pqBothOk);
			AssertPhysicalQuantityDiffFails(pqValueNull, pqBothNull);
			AssertPhysicalQuantityDiffFails(pqValueNull, pqUnitsNull);
			Assert.AreEqual(null, GenericMath.Diff(pqValueNull, pqValueNull));
			Assert.AreEqual(null, GenericMath.Diff(pqValueNull, pqBothOk));
			AssertPhysicalQuantityDiffFails(pqBothOk, pqBothNull);
			AssertPhysicalQuantityDiffFails(pqBothOk, pqUnitsNull);
			Assert.AreEqual(null, GenericMath.Diff(pqBothOk, pqValueNull));
			Assert.AreEqual(new BigDecimal(0), GenericMath.Diff(pqBothOk, pqBothOk).Value.Quantity);
			// half
			Assert.AreEqual(null, GenericMath.Half(pqBothNull).Quantity);
			Assert.AreEqual(new BigDecimal(61.50), GenericMath.Half(pqUnitsNull).Quantity);
			Assert.AreEqual(null, GenericMath.Half(pqValueNull).Quantity);
			Assert.AreEqual(new BigDecimal(61.50), GenericMath.Half(pqBothOk).Quantity);
		}

		private void AssertPhysicalQuantityDiffFails(PhysicalQuantity pq1, PhysicalQuantity pq2)
		{
			try
			{
				GenericMath.Diff(pq1, pq2);
				Assert.Fail("expected PQ diff to throw exception due to mismatching units");
			}
			catch (ArgumentException)
			{
			}
		}

		// expected
		private void AssertPhysicalQuantityAverageFails(PhysicalQuantity pq1, PhysicalQuantity pq2)
		{
			try
			{
				GenericMath.Average(pq1, pq2);
				Assert.Fail("expected PQ average to throw exception due to mismatching units");
			}
			catch (ArgumentException)
			{
			}
		}

		// expected
		private void AssertPhysicalQuantityAddFails(PhysicalQuantity pq, Diff<PhysicalQuantity> diff)
		{
			AssertPhysicalQuantityAddFails(pq, diff.Value);
		}

		private void AssertPhysicalQuantityAddFails(PhysicalQuantity pq1, PhysicalQuantity pq2)
		{
			try
			{
				GenericMath.Add(pq1, pq2);
				Assert.Fail("expected PQ add to throw exception due to mismatching units");
			}
			catch (ArgumentException)
			{
			}
		}
		// expected
	}
}
