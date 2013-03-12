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
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ca.Infoway.Messagebuilder.Datatype.Lang
{
    using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
    using Ca.Infoway.Messagebuilder.Domainvalue.Basic;
    using NUnit;
    using System;
    using System.Reflection;

    [NUnit.Framework.TestFixture]
    class GenericMathTest
    {
        [NUnit.Framework.Test]
        public void TestAddIntegers()
        {
            AssertAdd(12, 15);
            AssertAdd(129, 88);
            AssertAdd(null, 256);
        }

        [NUnit.Framework.Test]
        public void TestAddIntegersDiff()
        {
            AssertAdd(12, new Diff<int?>(15));
            AssertAdd(129, new Diff<int?>(88));
            AssertAdd(null, new Diff<int?>(256));
        }

        [NUnit.Framework.Test]
        public void TestAddDateAndDiff()
        {
            PlatformDate low = new PlatformDate(new DateTime(0));
            PlatformDate add = GenericMath.Add(low, new Diff<PlatformDate>((PlatformDate)null));
            NUnit.Framework.Assert.AreEqual(low, add);
        }

        [NUnit.Framework.Test]
        public void TestAddDateDiff()
        {
            AssertAdd(parseDate("2006-02-15"), parseDate("2006-01-15"), new DateDiff(1, DefaultTimeUnit.MONTH));
            AssertAdd(parseDate("2006-03-15"), parseDate("2006-02-15"), new DateDiff(1, DefaultTimeUnit.MONTH));
            AssertAdd(parseDate("2006-02-16"), parseDate("2006-02-15"), new DateDiff(1, DefaultTimeUnit.DAY));
            AssertAdd(parseDate("2006-02-20"), parseDate("2006-02-15"), new DateDiff(5, DefaultTimeUnit.DAY));
            AssertAdd(parseDate("2006-02-22"), parseDate("2006-02-15"), new DateDiff(1, DefaultTimeUnit.WEEK));
        }

        private PlatformDate parseDate(String dateString) 
        {
            DateTime dateTime = DateTime.Parse(dateString);
            return new PlatformDate(dateTime);
        }

        private void AssertAdd(PlatformDate expected, PlatformDate date, DateDiff diff)
        {
            NUnit.Framework.Assert.AreEqual(expected, GenericMath.Add(date, diff));
        }

        private void AssertAdd(int? i, int? j)
        {
            int i_value = 0;
            int j_value = 0;
            if (i.HasValue)
            {
                i_value = i.Value;
            }
            if (j.HasValue)
            {
                j_value = j.Value;
            }
            NUnit.Framework.Assert.AreEqual(i_value + j_value, GenericMath.Add(i, j));
        }

        private void AssertAdd(int? i, Diff<int?> j) 
        {
            int i_value = 0;
            int j_value = 0;

            if (i.HasValue)
            {
                i_value = i.Value;
            }

            if (j != null)
            {
                j_value = (int)j.GetValue();
            }

            NUnit.Framework.Assert.AreEqual(i_value + j_value, GenericMath.Add(i, j));
        }

        [NUnit.Framework.Test]
        public void TestAddLong()
        {
            AssertAdd(12L, 15L);
            AssertAdd(129L, 88L);
            AssertAdd(129L, null);
        }

        private void AssertAdd(long? i, long? j)
        {
            long i_value = 0;
            long j_value = 0;

            if (i.HasValue)
            {
                i_value = i.Value;
            }
            if (j.HasValue)
            {
                j_value = j.Value;
            }
            NUnit.Framework.Assert.AreEqual(i_value + j_value, GenericMath.Add(i, j));
        }

        //Physical Quantities Tests
        [NUnit.Framework.Test]
        public void TestPhysicalQuantityHalf()
        {
            NUnit.Framework.Assert.AreEqual(new BigDecimal(1.50), GenericMath.Half(new PhysicalQuantity(new BigDecimal(3.0), UnitsOfMeasureCaseSensitive.KILOGRAM)).Quantity);
        }

        [NUnit.Framework.Test]
        public void TestPhysicalQuantityAverage()
        {
            NUnit.Framework.Assert.AreEqual(new BigDecimal(2.00), GenericMath.Average(
                new PhysicalQuantity(new BigDecimal(3.0), UnitsOfMeasureCaseSensitive.KILOGRAM), 
                new PhysicalQuantity(new BigDecimal(1.0), UnitsOfMeasureCaseSensitive.KILOGRAM)).Quantity);
        }

        [NUnit.Framework.Test]
        public void TestPhysicalQuantityDiff()
        {
            NUnit.Framework.Assert.AreEqual(new BigDecimal(1.0), GenericMath.Diff(
                new PhysicalQuantity(new BigDecimal(2.0), UnitsOfMeasureCaseSensitive.KILOGRAM), 
                new PhysicalQuantity(new BigDecimal(3.0), UnitsOfMeasureCaseSensitive.KILOGRAM)).Value.Quantity);
        }

        [NUnit.Framework.Test]
        public void TestAddPhysicalQuantities()
        {
            AssertAdd(new PhysicalQuantity(new BigDecimal(123.0), UnitsOfMeasureCaseSensitive.MILLIMETER), new PhysicalQuantity(new BigDecimal(88.0), UnitsOfMeasureCaseSensitive.MILLIMETER));

            Diff<PhysicalQuantity> diff = new Diff<PhysicalQuantity>(new PhysicalQuantity(new BigDecimal(88.0), UnitsOfMeasureCaseSensitive.MILLIMETER));
            NUnit.Framework.Assert.AreEqual(new BigDecimal(211.0), GenericMath.Add(new PhysicalQuantity(new BigDecimal(123.0), UnitsOfMeasureCaseSensitive.MILLIMETER), diff).Quantity);

            try
            {
                GenericMath.Add(new PhysicalQuantity(new BigDecimal(121.0), UnitsOfMeasureCaseSensitive.MILLIMETER), new PhysicalQuantity(new BigDecimal(88.0), UnitsOfMeasureCaseSensitive.DAY));
                NUnit.Framework.Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        [NUnit.Framework.Test]
        public void testPhysicalQuantitiesAsNull()
        {
            NUnit.Framework.Assert.AreEqual(null, GenericMath.Add((PhysicalQuantity)null, (PhysicalQuantity)null));
            NUnit.Framework.Assert.AreEqual(new BigDecimal(123.0), GenericMath.Add(new PhysicalQuantity(new BigDecimal(123.0), UnitsOfMeasureCaseSensitive.MILLIMETER), (PhysicalQuantity)null).Quantity);
            NUnit.Framework.Assert.AreEqual(new BigDecimal(123.0), GenericMath.Add((PhysicalQuantity)null, new PhysicalQuantity(new BigDecimal(123.0), UnitsOfMeasureCaseSensitive.MILLIMETER)).Quantity);

            NUnit.Framework.Assert.AreEqual(null, GenericMath.Add((PhysicalQuantity)null, (Diff<PhysicalQuantity>)null));
            NUnit.Framework.Assert.AreEqual(new BigDecimal(123.0), GenericMath.Add(new PhysicalQuantity(new BigDecimal(123.0), UnitsOfMeasureCaseSensitive.MILLIMETER), (Diff<PhysicalQuantity>)null).Quantity);
            NUnit.Framework.Assert.AreEqual(new BigDecimal(123.0), GenericMath.Add((PhysicalQuantity)null, new PhysicalQuantity(new BigDecimal(123.0), UnitsOfMeasureCaseSensitive.MILLIMETER)).Quantity);

            NUnit.Framework.Assert.AreEqual(null, GenericMath.Average((PhysicalQuantity)null, (PhysicalQuantity)null));
            NUnit.Framework.Assert.AreEqual(new BigDecimal(61.50), GenericMath.Average(new PhysicalQuantity(new BigDecimal(123.0), UnitsOfMeasureCaseSensitive.MILLIMETER), (PhysicalQuantity)null).Quantity);
            NUnit.Framework.Assert.AreEqual(new BigDecimal(61.50), GenericMath.Average((PhysicalQuantity)null, new PhysicalQuantity(new BigDecimal(123.0), UnitsOfMeasureCaseSensitive.MILLIMETER)).Quantity);

            NUnit.Framework.Assert.AreEqual(null, GenericMath.Diff((PhysicalQuantity)null, (PhysicalQuantity)null));
            NUnit.Framework.Assert.AreEqual(null, GenericMath.Diff(new PhysicalQuantity(new BigDecimal(123.0), UnitsOfMeasureCaseSensitive.MILLIMETER), (PhysicalQuantity)null));
            NUnit.Framework.Assert.AreEqual(null, GenericMath.Diff((PhysicalQuantity)null, new PhysicalQuantity(new BigDecimal(123.0), UnitsOfMeasureCaseSensitive.MILLIMETER)));

            NUnit.Framework.Assert.AreEqual(null, GenericMath.Half((PhysicalQuantity)null));
        }

        private void AssertAdd(PhysicalQuantity quantity, PhysicalQuantity quantity2)
        {
            NUnit.Framework.Assert.AreEqual(quantity.Quantity.Add(quantity2.Quantity), GenericMath.Add(quantity, quantity2).Quantity);
        }

        [NUnit.Framework.Test]
        public void TestPhysicalQuantitesWithInnerValuesAsNull()
        {
            PhysicalQuantity pqBothOk = new PhysicalQuantity(new BigDecimal(123.0), UnitsOfMeasureCaseSensitive.MILLIMETER);
            PhysicalQuantity pqUnitsNull = new PhysicalQuantity(new BigDecimal(123.0), null);
            PhysicalQuantity pqValueNull = new PhysicalQuantity(null, UnitsOfMeasureCaseSensitive.MILLIMETER);
            PhysicalQuantity pqBothNull = new PhysicalQuantity(null, null);

            //add

            NUnit.Framework.Assert.AreEqual(null, GenericMath.Add(pqBothNull, pqBothNull).Quantity);
            NUnit.Framework.Assert.AreEqual(new BigDecimal(123.0), GenericMath.Add(pqBothNull, pqUnitsNull).Quantity);
            AssertPhysicalQuantityAddFails(pqBothNull, pqValueNull);
            AssertPhysicalQuantityAddFails(pqUnitsNull, pqBothOk);

            NUnit.Framework.Assert.AreEqual(new BigDecimal(123.0), GenericMath.Add(pqUnitsNull, pqBothNull).Quantity);
            NUnit.Framework.Assert.AreEqual(new BigDecimal(246.0), GenericMath.Add(pqUnitsNull, pqUnitsNull).Quantity);
            AssertPhysicalQuantityAddFails(pqUnitsNull, pqValueNull);
            AssertPhysicalQuantityAddFails(pqUnitsNull, pqBothOk);

            AssertPhysicalQuantityAddFails(pqValueNull, pqBothNull);
            AssertPhysicalQuantityAddFails(pqValueNull, pqUnitsNull);
            NUnit.Framework.Assert.AreEqual(null, GenericMath.Add(pqValueNull, pqValueNull).Quantity);
            NUnit.Framework.Assert.AreEqual(new BigDecimal(123.0), GenericMath.Add(pqValueNull, pqBothOk).Quantity);

            AssertPhysicalQuantityAddFails(pqBothOk, pqBothNull);
            AssertPhysicalQuantityAddFails(pqBothOk, pqUnitsNull);
            NUnit.Framework.Assert.AreEqual(new BigDecimal(123.0), GenericMath.Add(pqBothOk, pqValueNull).Quantity);
            NUnit.Framework.Assert.AreEqual(new BigDecimal(246.0), GenericMath.Add(pqBothOk, pqBothOk).Quantity);

            //add diff
            NUnit.Framework.Assert.AreEqual(null, GenericMath.Add(pqBothNull, new Diff<PhysicalQuantity>(pqBothNull)).Quantity);
            NUnit.Framework.Assert.AreEqual(new BigDecimal(123.0), GenericMath.Add(pqBothNull, new Diff<PhysicalQuantity>(pqUnitsNull)).Quantity);
            AssertPhysicalQuantityAddFails(pqBothNull, new Diff<PhysicalQuantity>(pqValueNull));
            AssertPhysicalQuantityAddFails(pqBothNull, new Diff<PhysicalQuantity>(pqBothOk));

            NUnit.Framework.Assert.AreEqual(new BigDecimal(123.0), GenericMath.Add(pqUnitsNull, new Diff<PhysicalQuantity>(pqBothNull)).Quantity);
            NUnit.Framework.Assert.AreEqual(new BigDecimal(246.0), GenericMath.Add(pqUnitsNull, new Diff<PhysicalQuantity>(pqUnitsNull)).Quantity);
            AssertPhysicalQuantityAddFails(pqUnitsNull, new Diff<PhysicalQuantity>(pqValueNull));
            AssertPhysicalQuantityAddFails(pqUnitsNull, new Diff<PhysicalQuantity>(pqBothOk));

            AssertPhysicalQuantityAddFails(pqValueNull, new Diff<PhysicalQuantity>(pqBothNull));
            AssertPhysicalQuantityAddFails(pqValueNull, new Diff<PhysicalQuantity>(pqUnitsNull));
            NUnit.Framework.Assert.AreEqual(null, GenericMath.Add(pqValueNull, new Diff<PhysicalQuantity>(pqValueNull)).Quantity);
            NUnit.Framework.Assert.AreEqual(new BigDecimal(123.0), GenericMath.Add(pqValueNull, new Diff<PhysicalQuantity>(pqBothOk)).Quantity);

            AssertPhysicalQuantityAddFails(pqBothOk, new Diff<PhysicalQuantity>(pqBothNull));
            AssertPhysicalQuantityAddFails(pqBothOk, new Diff<PhysicalQuantity>(pqUnitsNull));
            NUnit.Framework.Assert.AreEqual(new BigDecimal(123.0), GenericMath.Add(pqBothOk, new Diff<PhysicalQuantity>(pqValueNull)).Quantity);
            NUnit.Framework.Assert.AreEqual(new BigDecimal(246.0), GenericMath.Add(pqBothOk, new Diff<PhysicalQuantity>(pqBothOk)).Quantity);

            //average
            NUnit.Framework.Assert.AreEqual(null, GenericMath.Average(pqBothNull, pqBothNull).Quantity);
            NUnit.Framework.Assert.AreEqual(new BigDecimal(61.5), GenericMath.Average(pqBothNull, pqUnitsNull).Quantity);
            AssertPhysicalQuantityAverageFails(pqBothNull, pqValueNull);
            AssertPhysicalQuantityAverageFails(pqBothNull, pqBothOk);

            NUnit.Framework.Assert.AreEqual(new BigDecimal(61.5), GenericMath.Average(pqUnitsNull, pqBothNull).Quantity);
            NUnit.Framework.Assert.AreEqual(new BigDecimal(123.0), GenericMath.Average(pqUnitsNull, pqUnitsNull).Quantity);
            AssertPhysicalQuantityAverageFails(pqUnitsNull, pqValueNull);
            AssertPhysicalQuantityAverageFails(pqUnitsNull, pqBothOk);

            AssertPhysicalQuantityAverageFails(pqValueNull, pqBothNull);
            AssertPhysicalQuantityAverageFails(pqValueNull, pqUnitsNull);
            NUnit.Framework.Assert.AreEqual(null, GenericMath.Average(pqValueNull, pqValueNull).Quantity);
            NUnit.Framework.Assert.AreEqual(new BigDecimal(61.5), GenericMath.Average(pqValueNull, pqBothOk).Quantity);

            AssertPhysicalQuantityAverageFails(pqBothOk, pqBothNull);
            AssertPhysicalQuantityAverageFails(pqBothOk, pqUnitsNull);
            NUnit.Framework.Assert.AreEqual(new BigDecimal(61.5), GenericMath.Average(pqBothOk, pqValueNull).Quantity);
            NUnit.Framework.Assert.AreEqual(new BigDecimal(123.0), GenericMath.Average(pqBothOk, pqBothOk).Quantity);

            //diff
            NUnit.Framework.Assert.AreEqual(null, GenericMath.Diff(pqBothNull, pqBothNull));
            NUnit.Framework.Assert.AreEqual(null, GenericMath.Diff(pqBothNull, pqUnitsNull));
            AssertPhysicalQuantityDiffFails(pqBothNull, pqValueNull);
            AssertPhysicalQuantityDiffFails(pqBothNull, pqBothOk);

            NUnit.Framework.Assert.AreEqual(null, GenericMath.Diff(pqUnitsNull, pqBothNull));
            NUnit.Framework.Assert.AreEqual(new BigDecimal(0.0), GenericMath.Diff(pqUnitsNull, pqUnitsNull).Value.Quantity);
            AssertPhysicalQuantityDiffFails(pqUnitsNull, pqValueNull);
            AssertPhysicalQuantityDiffFails(pqUnitsNull, pqBothOk);

            AssertPhysicalQuantityDiffFails(pqValueNull, pqBothNull);
            AssertPhysicalQuantityDiffFails(pqValueNull, pqUnitsNull);
            NUnit.Framework.Assert.AreEqual(null, GenericMath.Diff(pqValueNull, pqValueNull));
            NUnit.Framework.Assert.AreEqual(null, GenericMath.Diff(pqValueNull, pqBothOk));

            AssertPhysicalQuantityDiffFails(pqBothOk, pqBothNull);
            AssertPhysicalQuantityDiffFails(pqBothOk, pqUnitsNull);
            NUnit.Framework.Assert.AreEqual(null, GenericMath.Diff(pqBothOk, pqValueNull));
            NUnit.Framework.Assert.AreEqual(new BigDecimal(0.0), GenericMath.Diff(pqBothOk, pqBothOk).Value.Quantity);

            //half
            NUnit.Framework.Assert.AreEqual(null, GenericMath.Half(pqBothNull).Quantity);
            NUnit.Framework.Assert.AreEqual(new BigDecimal(61.50), GenericMath.Half(pqUnitsNull).Quantity);
            NUnit.Framework.Assert.AreEqual(null, GenericMath.Half(pqValueNull).Quantity);
            NUnit.Framework.Assert.AreEqual(new BigDecimal(61.50), GenericMath.Half(pqBothOk).Quantity);
        }

        private void AssertPhysicalQuantityAddFails(PhysicalQuantity pq1, PhysicalQuantity pq2)
        {
            try
            {
                GenericMath.Add(pq1, pq2);
                NUnit.Framework.Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void AssertPhysicalQuantityDiffFails(PhysicalQuantity pq1, PhysicalQuantity pq2)
        {
            try
            {
                GenericMath.Diff(pq1, pq2);
                NUnit.Framework.Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void AssertPhysicalQuantityAverageFails(PhysicalQuantity pq1, PhysicalQuantity pq2)
        {
            try
            {
                GenericMath.Average(pq1, pq2);
                NUnit.Framework.Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void AssertPhysicalQuantityAddFails(PhysicalQuantity pq, Diff<PhysicalQuantity> diff)
        {
            AssertPhysicalQuantityAddFails(pq, diff.Value);
        }
    }
}
