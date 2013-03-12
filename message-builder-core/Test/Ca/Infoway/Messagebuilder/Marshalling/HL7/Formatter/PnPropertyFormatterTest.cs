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
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class PnPropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNull()
		{
			string result = new PnPropertyFormatter().Format(GetContext("name", "PN.BASIC", SpecificationVersion.R02_04_02), new PNImpl
				());
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name nullFlavor=\"NI\"/>", result.Trim(), "named null format");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNullNoUse()
		{
			PnPropertyFormatter formatter = new PnPropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddNamePart(new EntityNamePart("Steve Shaw"));
			string result = formatter.Format(GetContext("name", "PN.SIMPLE", SpecificationVersion.R02_04_02), new PNImpl(personName));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.AreEqual("<name>Steve Shaw</name>", result.Trim(), "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNullWithUse()
		{
			PnPropertyFormatter formatter = new PnPropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			personName.AddNamePart(new EntityNamePart("Steve Shaw"));
			string result = formatter.Format(GetContext("name", "PN.SIMPLE", SpecificationVersion.R02_04_02), new PNImpl(personName));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name use=\"L\">Steve Shaw</name>", result.Trim(), "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatSimpleWithMoreThanOneSimplePart()
		{
			PnPropertyFormatter formatter = new PnPropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			personName.AddNamePart(new EntityNamePart("Steve"));
			personName.AddNamePart(new EntityNamePart("Shaw"));
			string result = formatter.Format(GetContext("name", "PN.SIMPLE", SpecificationVersion.R02_04_02), new PNImpl(personName));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.AreEqual("<name use=\"L\">SteveShaw</name>", result.Trim(), "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatSimpleWithMixedParts()
		{
			PnPropertyFormatter formatter = new PnPropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			personName.AddNamePart(new EntityNamePart("Steve"));
			personName.AddNamePart(new EntityNamePart("Shaw", PersonNamePartType.FAMILY));
			string result = formatter.Format(GetContext("name", "PN.SIMPLE", SpecificationVersion.R02_04_02), new PNImpl(personName));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.AreEqual("<name use=\"L\">Steve<family>Shaw</family></name>", result.Trim(), "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatSimpleWithMoreOneNonSimplePart()
		{
			PnPropertyFormatter formatter = new PnPropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			personName.AddNamePart(new EntityNamePart("Steve Shaw", PersonNamePartType.FAMILY));
			string result = formatter.Format(GetContext("name", "PN.SIMPLE", SpecificationVersion.R02_04_02), new PNImpl(personName));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.AreEqual("<name use=\"L\"><family>Steve Shaw</family></name>", result.Trim(), "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNullWithMultipleUses()
		{
			PnPropertyFormatter formatter = new PnPropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.PSEUDONYM);
			personName.AddNamePart(new EntityNamePart("Steve Shaw"));
			string result = formatter.Format(GetContext("name", "PN.SIMPLE", SpecificationVersion.R02_04_02), new PNImpl(personName));
			Assert.IsTrue(this.result.IsValid());
			Assert.IsTrue("<name use=\"P L\">Steve Shaw</name>".Equals(result.Trim()) || "<name use=\"L P\">Steve Shaw</name>".Equals
				(result.Trim()), "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestUsesForCeRx()
		{
			PnPropertyFormatter formatter = new PnPropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			personName.AddNamePart(new EntityNamePart("Steve Shaw"));
			string result = formatter.Format(GetContext("name", "PN.SIMPLE", SpecificationVersion.V01R04_3), new PNImpl(personName));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name use=\"L\">Steve Shaw</name>", result.Trim(), "something in text node");
			this.result.ClearErrors();
			personName.Uses.Clear();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.PSEUDONYM);
			result = formatter.Format(GetContext("name", "PN.SIMPLE", SpecificationVersion.V01R04_3), new PNImpl(personName));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name use=\"P\">Steve Shaw</name>", result.Trim(), "something in text node");
			this.result.ClearErrors();
			personName.Uses.Clear();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LICENSE);
			result = formatter.Format(GetContext("name", "PN.SIMPLE", SpecificationVersion.V01R04_3), new PNImpl(personName));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.AreEqual("<name use=\"C\">Steve Shaw</name>", result.Trim(), "something in text node");
			this.result.ClearErrors();
			personName.Uses.Clear();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.HEALTH_CARD);
			result = formatter.Format(GetContext("name", "PN.SIMPLE", SpecificationVersion.V01R04_3), new PNImpl(personName));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.AreEqual("<name use=\"HC\">Steve Shaw</name>", result.Trim(), "something in text node");
			this.result.ClearErrors();
			personName.Uses.Clear();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.OFFICIAL_REGISTRY);
			result = formatter.Format(GetContext("name", "PN.SIMPLE", SpecificationVersion.V01R04_3), new PNImpl(personName));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.AreEqual("<name use=\"OR\">Steve Shaw</name>", result.Trim(), "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestUsesForMr2007()
		{
			PnPropertyFormatter formatter = new PnPropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			personName.AddNamePart(new EntityNamePart("Steve Shaw"));
			string result = formatter.Format(GetContext("name", "PN.SIMPLE", SpecificationVersion.V02R02), new PNImpl(personName));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name use=\"L\">Steve Shaw</name>", result.Trim(), "something in text node");
			this.result.ClearErrors();
			personName.Uses.Clear();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.PSEUDONYM);
			result = formatter.Format(GetContext("name", "PN.SIMPLE", SpecificationVersion.V02R02), new PNImpl(personName));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name use=\"P\">Steve Shaw</name>", result.Trim(), "something in text node");
			this.result.ClearErrors();
			personName.Uses.Clear();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LICENSE);
			result = formatter.Format(GetContext("name", "PN.SIMPLE", SpecificationVersion.V02R02), new PNImpl(personName));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name use=\"C\">Steve Shaw</name>", result.Trim(), "something in text node");
			this.result.ClearErrors();
			personName.Uses.Clear();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.HEALTH_CARD);
			result = formatter.Format(GetContext("name", "PN.SIMPLE", SpecificationVersion.V02R02), new PNImpl(personName));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name use=\"HC\">Steve Shaw</name>", result.Trim(), "something in text node");
			this.result.ClearErrors();
			personName.Uses.Clear();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.OFFICIAL_REGISTRY);
			result = formatter.Format(GetContext("name", "PN.SIMPLE", SpecificationVersion.V02R02), new PNImpl(personName));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.AreEqual("<name use=\"OR\">Steve Shaw</name>", result.Trim(), "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestUsesForMr2009()
		{
			PnPropertyFormatter formatter = new PnPropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			personName.AddNamePart(new EntityNamePart("Steve Shaw"));
			string result = formatter.Format(GetContext("name", "PN.SIMPLE", SpecificationVersion.R02_04_03), new PNImpl(personName));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name use=\"L\">Steve Shaw</name>", result.Trim(), "something in text node");
			this.result.ClearErrors();
			personName.Uses.Clear();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.PSEUDONYM);
			result = formatter.Format(GetContext("name", "PN.SIMPLE", SpecificationVersion.R02_04_03), new PNImpl(personName));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name use=\"P\">Steve Shaw</name>", result.Trim(), "something in text node");
			this.result.ClearErrors();
			personName.Uses.Clear();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LICENSE);
			result = formatter.Format(GetContext("name", "PN.SIMPLE", SpecificationVersion.R02_04_03), new PNImpl(personName));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name use=\"C\">Steve Shaw</name>", result.Trim(), "something in text node");
			this.result.ClearErrors();
			personName.Uses.Clear();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.HEALTH_CARD);
			result = formatter.Format(GetContext("name", "PN.SIMPLE", SpecificationVersion.R02_04_03), new PNImpl(personName));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.AreEqual("<name use=\"HC\">Steve Shaw</name>", result.Trim(), "something in text node");
			this.result.ClearErrors();
			personName.Uses.Clear();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.OFFICIAL_REGISTRY);
			result = formatter.Format(GetContext("name", "PN.SIMPLE", SpecificationVersion.R02_04_03), new PNImpl(personName));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name use=\"OR\">Steve Shaw</name>", result.Trim(), "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNullWithQualifier()
		{
			PnPropertyFormatter formatter = new PnPropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			personName.AddNamePart(new EntityNamePart("Shaw", PersonNamePartType.FAMILY, "BR"));
			string result = formatter.Format(GetContext("name", "PN.BASIC", SpecificationVersion.V02R02), new PNImpl(personName));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name use=\"L\"><family qualifier=\"BR\">Shaw</family></name>", result.Trim(), "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestBasicForCeRxWithMultipleNameParts()
		{
			PnPropertyFormatter formatter = new PnPropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			personName.AddNamePart(new EntityNamePart("Steve", PersonNamePartType.GIVEN));
			personName.AddNamePart(new EntityNamePart("Shaw", PersonNamePartType.FAMILY));
			string result = formatter.Format(GetContext("name", "PN.BASIC", SpecificationVersion.V01R04_3), new PNImpl(personName));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name use=\"L\"><given>Steve</given><family>Shaw</family></name>", result.Trim(), "something in text node"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestBasicForCeRxWithSimpleName()
		{
			PnPropertyFormatter formatter = new PnPropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			personName.AddNamePart(new EntityNamePart("Steve Shaw", null));
			string result = formatter.Format(GetContext("name", "PN.BASIC", SpecificationVersion.V01R04_3), new PNImpl(personName));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name use=\"L\">Steve Shaw</name>", result.Trim(), "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestBasicForCeRxWithSimpleNameInvalid()
		{
			PnPropertyFormatter formatter = new PnPropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			personName.AddNamePart(new EntityNamePart("Steve", null));
			personName.AddNamePart(new EntityNamePart("Shaw", null));
			string result = formatter.Format(GetContext("name", "PN.BASIC", SpecificationVersion.V01R04_3), new PNImpl(personName));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.AreEqual("<name use=\"L\">SteveShaw</name>", result.Trim(), "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestBasicForCeRxWithSimpleNameInvalidMixedParts()
		{
			PnPropertyFormatter formatter = new PnPropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			personName.AddNamePart(new EntityNamePart("Steve", PersonNamePartType.GIVEN));
			personName.AddNamePart(new EntityNamePart("Shaw", null));
			string result = formatter.Format(GetContext("name", "PN.BASIC", SpecificationVersion.V01R04_3), new PNImpl(personName));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.AreEqual("<name use=\"L\"><given>Steve</given>Shaw</name>", result.Trim(), "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNullWithQualifierMr2009()
		{
			PnPropertyFormatter formatter = new PnPropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			personName.AddNamePart(new EntityNamePart("Shaw", PersonNamePartType.FAMILY, "IN"));
			string result = formatter.Format(GetContext("name", "PN.BASIC", SpecificationVersion.R02_04_03), new PNImpl(personName));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name use=\"L\"><family qualifier=\"IN\">Shaw</family></name>", result.Trim(), "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNullWithQualifierMr2009Full()
		{
			PnPropertyFormatter formatter = new PnPropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			personName.AddNamePart(new EntityNamePart("Shaw", PersonNamePartType.FAMILY, "BR"));
			string result = formatter.Format(GetContext("name", "PN.FULL", SpecificationVersion.R02_04_03), new PNImpl(personName));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name use=\"L\"><family qualifier=\"BR\">Shaw</family></name>", result.Trim(), "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNullWithInvalidQualifierMr2009()
		{
			PnPropertyFormatter formatter = new PnPropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			personName.AddNamePart(new EntityNamePart("Shaw", PersonNamePartType.FAMILY, "BR"));
			string result = formatter.Format(GetContext("name", "PN.BASIC", SpecificationVersion.R02_04_02), new PNImpl(personName));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.AreEqual("<name use=\"L\"><family qualifier=\"BR\">Shaw</family></name>", result.Trim(), "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNullWithInvalidQualifier()
		{
			PnPropertyFormatter formatter = new PnPropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			personName.AddNamePart(new EntityNamePart("Shaw", PersonNamePartType.FAMILY, "XX"));
			string result = formatter.Format(GetContext("name", "PN.FULL", SpecificationVersion.R02_04_02), new PNImpl(personName));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.AreEqual("<name use=\"L\"><family qualifier=\"XX\">Shaw</family></name>", result.Trim(), "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNullWithInvalidQualifierCeRx()
		{
			PnPropertyFormatter formatter = new PnPropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			personName.AddNamePart(new EntityNamePart("Shaw", PersonNamePartType.FAMILY, "BR"));
			string result = formatter.Format(GetContext("name", "PN.BASIC", SpecificationVersion.V01R04_3), new PNImpl(personName));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.AreEqual("<name use=\"L\"><family qualifier=\"BR\">Shaw</family></name>", result.Trim(), "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatSimpleNoParts()
		{
			PnPropertyFormatter formatter = new PnPropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			string result = formatter.Format(GetContext("name", "PN.SIMPLE", SpecificationVersion.R02_04_02), new PNImpl(personName));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name use=\"L\"></name>", result.Trim(), "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatBasicNoParts()
		{
			PnPropertyFormatter formatter = new PnPropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			string result = formatter.Format(GetContext("name", "PN.BASIC", SpecificationVersion.R02_04_02), new PNImpl(personName));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name use=\"L\"></name>", result.Trim(), "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatFullNoParts()
		{
			PnPropertyFormatter formatter = new PnPropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			string result = formatter.Format(GetContext("name", "PN.FULL", SpecificationVersion.R02_04_02), new PNImpl(personName));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.AreEqual("<name use=\"L\"></name>", result.Trim(), "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatSearchNoParts()
		{
			PnPropertyFormatter formatter = new PnPropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			string result = formatter.Format(GetContext("name", "PN.SEARCH", SpecificationVersion.R02_04_02), new PNImpl(personName));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.AreEqual("<name use=\"L\"></name>", result.Trim(), "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueMaxLength()
		{
			PnPropertyFormatter formatter = new PnPropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			personName.AddNamePart(new EntityNamePart("12345678901234567890123456789012345678901234567890", PersonNamePartType.FAMILY
				));
			string result = formatter.Format(GetContext("name", "PN.BASIC", SpecificationVersion.R02_04_02), new PNImpl(personName));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name use=\"L\"><family>12345678901234567890123456789012345678901234567890</family></name>", result.Trim
				(), "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueInvalidLength()
		{
			PnPropertyFormatter formatter = new PnPropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			personName.AddNamePart(new EntityNamePart("123456789012345678901234567890123456789012345678901", PersonNamePartType.FAMILY
				));
			string result = formatter.Format(GetContext("name", "PN.BASIC", SpecificationVersion.R02_04_02), new PNImpl(personName));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			// max length + 1
			Assert.AreEqual("<name use=\"L\"><family>123456789012345678901234567890123456789012345678901</family></name>", result.Trim
				(), "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueInvalidPartType()
		{
			PnPropertyFormatter formatter = new PnPropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			personName.AddNamePart(new EntityNamePart("namegoeshere", PersonNamePartType.DELIMITER));
			string result = formatter.Format(GetContext("name", "PN.BASIC", SpecificationVersion.R02_04_02), new PNImpl(personName));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			// part type not allowed
			Assert.AreEqual("<name use=\"L\"><delimiter>namegoeshere</delimiter></name>", result.Trim(), "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueMaxLengthCeRx()
		{
			PnPropertyFormatter formatter = new PnPropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			personName.AddNamePart(new EntityNamePart("123456789012345678901234567890", PersonNamePartType.FAMILY));
			string result = formatter.Format(GetContext("name", "PN.BASIC", SpecificationVersion.V01R04_3), new PNImpl(personName));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name use=\"L\"><family>123456789012345678901234567890</family></name>", result.Trim(), "something in text node"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueInvalidLengthCeRx()
		{
			PnPropertyFormatter formatter = new PnPropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			personName.AddNamePart(new EntityNamePart("1234567890123456789012345678901", PersonNamePartType.FAMILY));
			string result = formatter.Format(GetContext("name", "PN.BASIC", SpecificationVersion.V01R04_3), new PNImpl(personName));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			// max length + 1
			Assert.AreEqual("<name use=\"L\"><family>1234567890123456789012345678901</family></name>", result.Trim(), "something in text node"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNullMultipleNameParts()
		{
			PnPropertyFormatter formatter = new PnPropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			personName.AddNamePart(new EntityNamePart("prefix", PersonNamePartType.PREFIX, "IN"));
			personName.AddNamePart(new EntityNamePart("given1", PersonNamePartType.GIVEN));
			personName.AddNamePart(new EntityNamePart("given2", PersonNamePartType.GIVEN));
			personName.AddNamePart(new EntityNamePart("given3", PersonNamePartType.GIVEN));
			personName.AddNamePart(new EntityNamePart("given4", PersonNamePartType.GIVEN));
			personName.AddNamePart(new EntityNamePart("family", PersonNamePartType.FAMILY));
			personName.AddNamePart(new EntityNamePart("suffix", PersonNamePartType.SUFFIX, "IN"));
			string result = formatter.Format(GetContext("name", "PN.BASIC", SpecificationVersion.R02_04_02), new PNImpl(personName));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name use=\"L\"><prefix qualifier=\"IN\">prefix</prefix><given>given1</given><given>given2</given><given>given3</given><given>given4</given><family>family</family><suffix qualifier=\"IN\">suffix</suffix></name>"
				, result.Trim(), "well formed name");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueTooManyNameParts()
		{
			PnPropertyFormatter formatter = new PnPropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			personName.AddNamePart(new EntityNamePart("prefix", PersonNamePartType.PREFIX, "IN"));
			personName.AddNamePart(new EntityNamePart("given1", PersonNamePartType.GIVEN));
			personName.AddNamePart(new EntityNamePart("given2", PersonNamePartType.GIVEN));
			personName.AddNamePart(new EntityNamePart("given3", PersonNamePartType.GIVEN));
			personName.AddNamePart(new EntityNamePart("given4", PersonNamePartType.GIVEN));
			personName.AddNamePart(new EntityNamePart("given5", PersonNamePartType.GIVEN));
			personName.AddNamePart(new EntityNamePart("family", PersonNamePartType.FAMILY));
			personName.AddNamePart(new EntityNamePart("suffix", PersonNamePartType.SUFFIX, "IN"));
			string result = formatter.Format(GetContext("name", "PN.BASIC", SpecificationVersion.R02_04_02), new PNImpl(personName));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			// too many parts
			Assert.AreEqual("<name use=\"L\"><prefix qualifier=\"IN\">prefix</prefix><given>given1</given><given>given2</given><given>given3</given><given>given4</given><given>given5</given><family>family</family><suffix qualifier=\"IN\">suffix</suffix></name>"
				, result.Trim(), "well formed name");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueReservedXmlCharsTooLong()
		{
			PnPropertyFormatter formatter = new PnPropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			personName.AddNamePart(new EntityNamePart("<cats think they're > humans & dogs 99% of the time/>"));
			string result = formatter.Format(GetContext("name", "PN.SIMPLE", SpecificationVersion.R02_04_02), new PNImpl(personName));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.AreEqual("<name use=\"L\">&lt;cats think they&apos;re &gt; humans &amp; dogs 99% of the time/&gt;</name>".Trim(), 
				result.Trim(), "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueReservedXmlChars()
		{
			PnPropertyFormatter formatter = new PnPropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			personName.AddNamePart(new EntityNamePart("<cats tk they're > humans & dogs 99% of the time/>"));
			string result = formatter.Format(GetContext("name", "PN.SIMPLE", SpecificationVersion.R02_04_02), new PNImpl(personName));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name use=\"L\">&lt;cats tk they&apos;re &gt; humans &amp; dogs 99% of the time/&gt;</name>".Trim(), result
				.Trim(), "something in text node");
		}
	}
}
