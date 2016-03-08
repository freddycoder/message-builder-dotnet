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
using System.Collections.Generic;
﻿using NUnit.Framework;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Domainvalue;

namespace Ca.Infoway.Messagebuilder.Marshalling {

    [TestFixture]
    public class CodedTypeR2HelperTest {

        [Test]
        public virtual void TestIsCodedTypeR2NotTrue() {
            Assert.IsFalse(CodedTypeR2Helper.IsCodedTypeR2(null));
            Assert.IsFalse(CodedTypeR2Helper.IsCodedTypeR2(new CDImpl()));
            Assert.IsFalse(CodedTypeR2Helper.IsCodedTypeR2(new CD_R2Impl<Code>()));
        }

        [Test]
        public virtual void TestIsCodedTypeR2True() {
            Assert.IsTrue(CodedTypeR2Helper.IsCodedTypeR2(new CodedTypeR2<Code>()));
            Assert.IsTrue(CodedTypeR2Helper.IsCodedTypeR2(new CodedTypeR2<UnitsOfMeasureCaseSensitive>()));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public virtual void TestGetCodeValueInvalidArgument() {
            CodedTypeR2Helper.GetCodeValue(new CD_R2Impl<Code>());
        }

        [Test]
        public virtual void TestGetCodeValueValidArgument() {
            CodedTypeR2<UnitsOfMeasureCaseSensitive> codedType = new CodedTypeR2<UnitsOfMeasureCaseSensitive>();
            codedType.Code = Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive.CUP;
            Assert.AreEqual("[cup_us]", CodedTypeR2Helper.GetCodeValue(codedType));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public virtual void TestGetCodeInvalidArgument() {
            CodedTypeR2Helper.GetCode(new CS_R2Impl<UnitsOfMeasureCaseSensitive>());
        }

        [Test]
        public virtual void TestGetCodeValidArgument() {
            CodedTypeR2<UnitsOfMeasureCaseSensitive> codedType = new CodedTypeR2<UnitsOfMeasureCaseSensitive>();
            codedType.Code = Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive.CUP;
            Assert.AreEqual(codedType.Code, CodedTypeR2Helper.GetCode(codedType));
        }

        [Test]
        public virtual void TestConvertCodedTypeR2ToSpecificTypeNullArgument() {
            Assert.IsNull(CodedTypeR2Helper.ConvertCodedTypeR2(null, typeof(UnitsOfMeasureCaseSensitive)));
        }

        [Test]
        public virtual void TestConvertCodedTypeR2ToSpecificTypeNonCodeTypeArgument() {
            CodedTypeR2<Code> codedType = new CodedTypeR2<Code>();
            codedType.Code = Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive.CUP;

            object convertedValue = CodedTypeR2Helper.ConvertCodedTypeR2(codedType, typeof(string));

            Assert.IsTrue(convertedValue is CodedTypeR2<Code>);

            CodedTypeR2<Code> actualValue = (CodedTypeR2<Code>)convertedValue;
            Assert.AreEqual(codedType.Code, actualValue.Code);
        }

        [Test]
        public virtual void TestConvertCodedTypeR2ToSpecificType() {
            CodedTypeR2<Code> codedType = new CodedTypeR2<Code>();
            codedType.Code = Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive.CUP;
            codedType.CodeSystemName = "code system";
            codedType.CodeSystemVersion = "version";
            codedType.DisplayName = "display name";
            codedType.NullFlavorForTranslationOnly = Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.ASKED_BUT_UNKNOWN;
            codedType.OriginalText = new EncapsulatedData("original text");
            IList<CodeRole> qualifier = new List<CodeRole>();
            qualifier.Add(new CodeRole());
            codedType.Qualifier = qualifier;
            IList<CodedTypeR2<Code>> translation = new List<CodedTypeR2<Code>>();
            translation.Add(new CodedTypeR2<Code>());
            codedType.Translation = translation;
            codedType.SimpleValue = "simple value";
            codedType.Operator = SetOperator.CONVEX_HULL;
            codedType.Value = new BigDecimal("5");
            codedType.ValidTime = new Interval<PlatformDate>(new PlatformDate(), SetOperator.CONVEX_HULL);
            codedType.Qty = 32;

            object convertedValue = CodedTypeR2Helper.ConvertCodedTypeR2(codedType, typeof(UnitsOfMeasureCaseSensitive));

            Assert.IsTrue(convertedValue is CodedTypeR2<UnitsOfMeasureCaseSensitive>);

            CodedTypeR2<UnitsOfMeasureCaseSensitive> actualValue = (CodedTypeR2<UnitsOfMeasureCaseSensitive>)convertedValue;
            Assert.AreEqual(codedType.Code, actualValue.Code);
            Assert.AreEqual(codedType.CodeSystemName, actualValue.CodeSystemName);
            Assert.AreEqual(codedType.CodeSystemVersion, actualValue.CodeSystemVersion);
            Assert.AreEqual(codedType.DisplayName, actualValue.DisplayName);
            Assert.AreEqual(codedType.NullFlavorForTranslationOnly, actualValue.NullFlavorForTranslationOnly);
            Assert.AreEqual(codedType.OriginalText, actualValue.OriginalText);
            Assert.AreEqual(codedType.Qualifier, actualValue.Qualifier);
            Assert.AreEqual(codedType.Translation, actualValue.Translation);
            Assert.AreEqual(codedType.SimpleValue, actualValue.SimpleValue);
            Assert.AreEqual(codedType.Operator, actualValue.Operator);
            Assert.AreEqual(codedType.Value, actualValue.Value);
            Assert.AreEqual(codedType.ValidTime, actualValue.ValidTime);
            Assert.AreEqual(codedType.Qty, actualValue.Qty);
        }

        [Test]
        public virtual void TestConvertCodedTypeR2FromSpecificTypeNullArgument() {
            Assert.IsNull(CodedTypeR2Helper.ConvertCodedTypeR2(null));
        }

        [Test]
        public virtual void TestConvertCodedTypeR2FromSpecificType() {
            CodedTypeR2<UnitsOfMeasureCaseSensitive> codedType = new CodedTypeR2<UnitsOfMeasureCaseSensitive>();
            codedType.Code = Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive.CUP;
            codedType.CodeSystemName = "code system";
            codedType.CodeSystemVersion = "version";
            codedType.DisplayName = "display name";
            codedType.NullFlavorForTranslationOnly = Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.ASKED_BUT_UNKNOWN;
            codedType.OriginalText = new EncapsulatedData("original text");
            IList<CodeRole> qualifier = new List<CodeRole>();
            qualifier.Add(new CodeRole());
            codedType.Qualifier = qualifier;
            IList<CodedTypeR2<Code>> translation = new List<CodedTypeR2<Code>>();
            translation.Add(new CodedTypeR2<Code>());
            codedType.Translation = translation;
            codedType.SimpleValue = "simple value";
            codedType.Operator = SetOperator.CONVEX_HULL;
            codedType.Value = new BigDecimal("5");
            codedType.ValidTime = new Interval<PlatformDate>(new PlatformDate(), SetOperator.CONVEX_HULL);
            codedType.Qty = 32;

            CodedTypeR2<Code> actualValue = CodedTypeR2Helper.ConvertCodedTypeR2(codedType);
            Assert.AreEqual(codedType.Code, actualValue.Code);
            Assert.AreEqual(codedType.CodeSystemName, actualValue.CodeSystemName);
            Assert.AreEqual(codedType.CodeSystemVersion, actualValue.CodeSystemVersion);
            Assert.AreEqual(codedType.DisplayName, actualValue.DisplayName);
            Assert.AreEqual(codedType.NullFlavorForTranslationOnly, actualValue.NullFlavorForTranslationOnly);
            Assert.AreEqual(codedType.OriginalText, actualValue.OriginalText);
            Assert.AreEqual(codedType.Qualifier, actualValue.Qualifier);
            Assert.AreEqual(codedType.Translation, actualValue.Translation);
            Assert.AreEqual(codedType.SimpleValue, actualValue.SimpleValue);
            Assert.AreEqual(codedType.Operator, actualValue.Operator);
            Assert.AreEqual(codedType.Value, actualValue.Value);
            Assert.AreEqual(codedType.ValidTime, actualValue.ValidTime);
            Assert.AreEqual(codedType.Qty, actualValue.Qty);
        }

        [Test]
        public virtual void TestCreateCSList() {
            CollectionHelper list = CodedTypeR2Helper.CreateCSList(typeof(UnitsOfMeasureCaseSensitive));
            Assert.IsTrue(list is LISTImpl<CS_R2<UnitsOfMeasureCaseSensitive>, CodedTypeR2<UnitsOfMeasureCaseSensitive>>);
        }

        [Test]
        public virtual void TestCreateCEInstance() {
            BareANY bareANY = CodedTypeR2Helper.CreateCEInstance(typeof(UnitsOfMeasureCaseSensitive));
            Assert.IsTrue(bareANY is CE_R2Impl<UnitsOfMeasureCaseSensitive>);
        }

        [Test]
        public virtual void TestCreateSXCMInstance() {
            BareANY bareANY = CodedTypeR2Helper.CreateSXCMInstance(typeof(UnitsOfMeasureCaseSensitive));
            Assert.IsTrue(bareANY is SXCM_R2Impl<CodedTypeR2<UnitsOfMeasureCaseSensitive>>);
        }
    }
}