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


using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Domainvalue;

namespace Ca.Infoway.Messagebuilder.Platform
{

	[TestFixture]
	public class GenericClassUtilTest
	{

        [Test]
        public virtual void TestIsInstanceOfANYNull() {
            Assert.IsFalse(GenericClassUtil.IsInstanceOfANY(null));
        }

        [Test]
        public virtual void TestIsInstanceOfANYDifferentObject() {
            Assert.IsFalse(GenericClassUtil.IsInstanceOfANY("abcd"));
        }

        [Test]
        public virtual void TestIsInstanceofANYTrue() {
            Assert.IsTrue(GenericClassUtil.IsInstanceOfANY(new CD_R2Impl<Code>()));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public virtual void TestGetValueFromANYWrongObject() {
            GenericClassUtil.GetValueFromANY("abcd");
        }

        [Test]
        public virtual void TestGetValueFromANYNonNullValue() {
            CD_R2<UnitsOfMeasureCaseSensitive> anyValue = CreateCDR2Instance();

            Assert.AreEqual(anyValue.Value, GenericClassUtil.GetValueFromANY(anyValue));
        }

        [Test]
        public virtual void TestGetValueFromANYNullValue() {
            CD_R2<UnitsOfMeasureCaseSensitive> anyValue = CreateCDR2Instance();
            anyValue.Value = null;

            Assert.AreEqual(anyValue.Value, GenericClassUtil.GetValueFromANY(anyValue));
        }

        [Test]
        public virtual void TestConvertToBareANYNullValue() {
            Assert.IsNull(GenericClassUtil.ConvertToBareANYCollection(null));
        }

        [Test]
        public virtual void TestConvertToBareANYNonCollectionType() {
            CD_R2<UnitsOfMeasureCaseSensitive> anyValue = CreateCDR2Instance();

            Assert.IsNull(GenericClassUtil.ConvertToBareANYCollection(anyValue));
        }

        [Test]
        public virtual void TestConvertToBareANYCollectionType() {
            var first = new CodedTypeR2<UnitsOfMeasureCaseSensitive>(Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive.CUP);
            var second = new CodedTypeR2<UnitsOfMeasureCaseSensitive>(Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive.DECALITRE);
            var third = new CodedTypeR2<UnitsOfMeasureCaseSensitive>(Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive.GALLON);

            LIST<CD_R2<UnitsOfMeasureCaseSensitive>, CodedTypeR2<UnitsOfMeasureCaseSensitive>> list =
                new LISTImpl<CD_R2<UnitsOfMeasureCaseSensitive>, CodedTypeR2<UnitsOfMeasureCaseSensitive>>(typeof(CD_R2Impl<UnitsOfMeasureCaseSensitive>));
            list.RawList().Add(first);
            list.RawList().Add(second);
            list.RawList().Add(third);

            ICollection<BareANY> bareANYCollection = GenericClassUtil.ConvertToBareANYCollection(list);
            IEnumerator<BareANY> enumerator = bareANYCollection.GetEnumerator();
            enumerator.MoveNext();
            Assert.AreSame(first, enumerator.Current.BareValue);
            enumerator.MoveNext();
            Assert.AreSame(second, enumerator.Current.BareValue);
            enumerator.MoveNext();
            Assert.AreSame(third, enumerator.Current.BareValue);
        }

        [Test]
        public virtual void TestCastDateIntervalWrongType() {
            Assert.IsNull(GenericClassUtil.CastBareValueAsIntervalDate("abcd"));
            Assert.IsNull(GenericClassUtil.CastBareValueAsIntervalDate(new Interval<string>("abcd", SetOperator.CONVEX_HULL)));
        }

        [Test]
        public virtual void TestCastDateIntervalCorrectType() {
            object expected = new Interval<PlatformDate>(new PlatformDate(), SetOperator.CONVEX_HULL);
            object actual = GenericClassUtil.CastBareValueAsIntervalDate(expected);
            Assert.AreSame(expected, actual);
        }

        [Test]
        public virtual void TestAdaptValueAdaptNotRequired() {
            BareANY original = new CDImpl();
            Assert.AreSame(original, GenericClassUtil.AdaptValue(original));
        }

        [Test]
        public virtual void TestAdaptValueDateInterval() {
            IVL_TSImpl original = new IVL_TSImpl();
            original.Value = new DateInterval();
            original.NullFlavor = Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION;
            original.DataType = StandardDataType.IVL_TS;
            original.Language = "Fr";
            original.DisplayName = "Display Name";
            original.Translations.Add(new CDImpl(Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive.CUP));
            original.Translations.Add(new CDImpl(Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive.GALLON));
            original.OriginalText = "Original Text";
            original.IsCdata = false;
            original.Unsorted = true;
            original.Operator = SetOperator.CONVEX_HULL;

            BareANY adaptedValue = GenericClassUtil.AdaptValue(original);
            Assert.IsTrue(adaptedValue is SXCM_R2Impl<MbDate>);

            SXCM_R2Impl<MbDate> actualValue = (SXCM_R2Impl<MbDate>)adaptedValue;
            Assert.AreSame(original.Value, actualValue.Value);
            Assert.AreSame(original.NullFlavor, actualValue.NullFlavor);
            Assert.AreSame(original.DataType, actualValue.DataType);
            Assert.AreSame(original.Language, actualValue.Language);
            Assert.AreSame(original.DisplayName, actualValue.DisplayName);
            Assert.AreSame(original.OriginalText, actualValue.OriginalText);
            Assert.AreEqual(original.IsCdata, actualValue.IsCdata);
            Assert.AreEqual(original.Unsorted, actualValue.Unsorted);
            Assert.AreEqual(original.Operator, actualValue.Operator);
            AssertTranslations(original.Translations, actualValue.Translations);
        }

        [Test]
        public virtual void TestAdaptValuePeriodicInterval() {
            PIVL_R2Impl original = new PIVL_R2Impl();
            original.Value = new PeriodicIntervalTimeR2(1, null);
            original.NullFlavor = Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION;
            original.DataType = StandardDataType.IVL_TS;
            original.Language = "Fr";
            original.DisplayName = "Display Name";
            original.Translations.Add(new CDImpl(Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive.CUP));
            original.Translations.Add(new CDImpl(Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive.GALLON));
            original.OriginalText = "Original Text";
            original.IsCdata = false;
            original.Unsorted = true;
            original.Operator = SetOperator.CONVEX_HULL;

            BareANY adaptedValue = GenericClassUtil.AdaptValue(original);
            Assert.IsTrue(adaptedValue is SXCM_R2Impl<MbDate>);

            SXCM_R2Impl<MbDate> actualValue = (SXCM_R2Impl<MbDate>)adaptedValue;
            Assert.AreSame(original.Value, actualValue.Value);
            Assert.AreSame(original.NullFlavor, actualValue.NullFlavor);
            Assert.AreSame(original.DataType, actualValue.DataType);
            Assert.AreSame(original.Language, actualValue.Language);
            Assert.AreSame(original.DisplayName, actualValue.DisplayName);
            Assert.AreSame(original.OriginalText, actualValue.OriginalText);
            Assert.AreEqual(original.IsCdata, actualValue.IsCdata);
            Assert.AreEqual(original.Unsorted, actualValue.Unsorted);
            Assert.AreEqual(original.Operator, actualValue.Operator);
            AssertTranslations(original.Translations, actualValue.Translations);
        }

        [Test]
        public virtual void TestAdaptValueEventRelatedPeriodicInterval() {
            ANYImpl<EventRelatedPeriodicIntervalTime> original = new ANYImpl<EventRelatedPeriodicIntervalTime>();
            original.Value = new EventRelatedPeriodicIntervalTime();
            original.NullFlavor = Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION;
            original.DataType = StandardDataType.IVL_TS;
            original.Language = "Fr";
            original.DisplayName = "Display Name";
            original.Translations.Add(new CDImpl(Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive.CUP));
            original.Translations.Add(new CDImpl(Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive.GALLON));
            original.OriginalText = "Original Text";
            original.IsCdata = false;
            original.Unsorted = true;
            original.Operator = SetOperator.CONVEX_HULL;

            BareANY adaptedValue = GenericClassUtil.AdaptValue(original);
            Assert.IsTrue(adaptedValue is SXCM_R2Impl<MbDate>);

            SXCM_R2Impl<MbDate> actualValue = (SXCM_R2Impl<MbDate>)adaptedValue;
            Assert.AreSame(original.Value, actualValue.Value);
            Assert.AreSame(original.NullFlavor, actualValue.NullFlavor);
            Assert.AreSame(original.DataType, actualValue.DataType);
            Assert.AreSame(original.Language, actualValue.Language);
            Assert.AreSame(original.DisplayName, actualValue.DisplayName);
            Assert.AreSame(original.OriginalText, actualValue.OriginalText);
            Assert.AreEqual(original.IsCdata, actualValue.IsCdata);
            Assert.AreEqual(original.Unsorted, actualValue.Unsorted);
            Assert.AreEqual(original.Operator, actualValue.Operator);
            AssertTranslations(original.Translations, actualValue.Translations);
        }

        private void AssertTranslations(IList<CD> expectedTranslations, IList<CD> actualTranslations) {
            Assert.AreEqual(expectedTranslations.Count, actualTranslations.Count);
            for (int i = 0; i < expectedTranslations.Count; i++) {
                Assert.AreEqual(expectedTranslations[i], actualTranslations[i]);
            }
        }

        private CD_R2<UnitsOfMeasureCaseSensitive> CreateCDR2Instance() {
            CD_R2<UnitsOfMeasureCaseSensitive> anyValue = new CD_R2Impl<UnitsOfMeasureCaseSensitive>();
            anyValue.Value = new CodedTypeR2<UnitsOfMeasureCaseSensitive>(Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive.CUP);
            return anyValue;
        }
		
		[Test]
		public void ShouldInstantiateList() 
		{
			Type t = typeof(List<>);
			foreach (Type argument in t.GetGenericArguments()) {
				Console.WriteLine(argument.Name);
			}
			
			List<TemplateArgument> arguments = new List<TemplateArgument>();
			arguments.Add(new TemplateArgument(typeof(String), new List<TemplateArgument>()));
			Object o = GenericClassUtil.Instantiate(typeof(List<>), arguments);
			Assert.AreEqual("System.Collections.Generic.List`1[System.String]", o.GetType().ToString(), "type");
		}

		[Test]
		public void ShouldInstantiateListFromDictionary() 
		{
			Type t = typeof(List<>);
			IDictionary<String,Type> dictionary = new Dictionary<String,Type>();
			dictionary.Add("T", typeof(String));
			Object o = GenericClassUtil.Instantiate(typeof(List<>), dictionary);
			Assert.AreEqual("System.Collections.Generic.List`1[System.String]", o.GetType().ToString(), "type");
		}

		[Test]
		public void ShouldInstantiateListOfLists() 
		{
			List<TemplateArgument> arguments = new List<TemplateArgument>();
			List<TemplateArgument> subArguments = new List<TemplateArgument>();
			subArguments.Add(new TemplateArgument(typeof(String), new List<TemplateArgument>()));
			arguments.Add(new TemplateArgument(typeof(List<>), subArguments));
			Object o = GenericClassUtil.Instantiate(typeof(List<>), arguments);
			Assert.AreEqual("System.Collections.Generic.List`1[System.Collections.Generic.List`1[System.String]]", o.GetType().ToString(), "type");
		}

		[Test]
		public void ShouldInstantiateNonGenericType() 
		{
			Object o = GenericClassUtil.Instantiate(typeof(ArrayList), new List<TemplateArgument>());
			Assert.AreEqual("System.Collections.ArrayList", o.GetType().ToString(), "type");
		}
	}
}
