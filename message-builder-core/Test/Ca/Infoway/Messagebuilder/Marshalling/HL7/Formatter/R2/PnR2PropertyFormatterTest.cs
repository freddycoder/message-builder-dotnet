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
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	[TestFixture]
	public class PnR2PropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNull()
		{
			string result = new EnR2PropertyFormatter().Format(GetContext("name", "PN", SpecificationVersion.R02_04_02), new PNImpl()
				);
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name nullFlavor=\"NI\"/>", result.Trim(), "named null format");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNullNoUse()
		{
			EnR2PropertyFormatter formatter = new EnR2PropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddNamePart(new EntityNamePart("Steve Shaw"));
			string result = formatter.Format(GetContext("name", "PN", SpecificationVersion.R02_04_02), new PNImpl(personName));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("something in text node", "<name>Steve Shaw</name>", result, true);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNullWithUse()
		{
			EnR2PropertyFormatter formatter = new EnR2PropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			personName.AddNamePart(new EntityNamePart("Steve Shaw"));
			string result = formatter.Format(GetContext("name", "PN", SpecificationVersion.R02_04_02), new PNImpl(personName));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("something in text node", "<name use=\"L\">Steve Shaw</name>", result, true);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatSimpleWithMoreThanOneSimplePart()
		{
			EnR2PropertyFormatter formatter = new EnR2PropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			personName.AddNamePart(new EntityNamePart("Steve"));
			personName.AddNamePart(new EntityNamePart("Shaw"));
			string result = formatter.Format(GetContext("name", "PN", SpecificationVersion.R02_04_02), new PNImpl(personName));
			Assert.IsTrue(this.result.IsValid());
			System.Console.Out.WriteLine(result);
			Assert.AreEqual("<name use=\"L\">" + SystemUtils.LINE_SEPARATOR + "  Steve" + SystemUtils.LINE_SEPARATOR + "  Shaw" + SystemUtils
				.LINE_SEPARATOR + "</name>" + SystemUtils.LINE_SEPARATOR, result, "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatSimpleWithMixedParts()
		{
			EnR2PropertyFormatter formatter = new EnR2PropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			personName.AddNamePart(new EntityNamePart("Steve"));
			personName.AddNamePart(new EntityNamePart("Shaw", PersonNamePartType.FAMILY));
			string result = formatter.Format(GetContext("name", "PN", SpecificationVersion.R02_04_02), new PNImpl(personName));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("something in text node", "<name use=\"L\">Steve<family>Shaw</family></name>", result, true);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatSimpleWithTwoNonSimpleParts()
		{
			EnR2PropertyFormatter formatter = new EnR2PropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			personName.AddNamePart(new EntityNamePart("Steve", PersonNamePartType.GIVEN));
			personName.AddNamePart(new EntityNamePart("Shaw", PersonNamePartType.FAMILY));
			string result = formatter.Format(GetContext("name", "PN", SpecificationVersion.R02_04_02), new PNImpl(personName));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name use=\"L\">" + SystemUtils.LINE_SEPARATOR + "  <given>Steve</given>" + SystemUtils.LINE_SEPARATOR +
				 "  <family>Shaw</family>" + SystemUtils.LINE_SEPARATOR + "</name>" + SystemUtils.LINE_SEPARATOR, result, "formatted text node"
				);
			AssertXml("something in text node", "<name use=\"L\"><given>Steve</given><family>Shaw</family></name>", result, true);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatSimpleWithNullFlavorPart()
		{
			EnR2PropertyFormatter formatter = new EnR2PropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			personName.AddNamePart(new EntityNamePart(PersonNamePartType.GIVEN, Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor
				.MASKED));
			personName.AddNamePart(new EntityNamePart("Shaw", PersonNamePartType.FAMILY));
			string result = formatter.Format(GetContext("name", "PN", SpecificationVersion.R02_04_02), new PNImpl(personName));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name use=\"L\">" + SystemUtils.LINE_SEPARATOR + "  <given nullFlavor=\"MSK\"/>" + SystemUtils.LINE_SEPARATOR
				 + "  <family>Shaw</family>" + SystemUtils.LINE_SEPARATOR + "</name>" + SystemUtils.LINE_SEPARATOR, result, "formatted text node"
				);
			AssertXml("something in text node", "<name use=\"L\"><given nullFlavor=\"MSK\"/><family>Shaw</family></name>", result, true
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNullWithMultipleUses()
		{
			EnR2PropertyFormatter formatter = new EnR2PropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.PSEUDONYM);
			personName.AddNamePart(new EntityNamePart("Steve Shaw"));
			string result = formatter.Format(GetContext("name", "PN", SpecificationVersion.R02_04_02), new PNImpl(personName));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("something in text node", "<name use=\"L P\">Steve Shaw</name>", result.Trim(), true);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestUsesForMr2009()
		{
			EnR2PropertyFormatter formatter = new EnR2PropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			personName.AddNamePart(new EntityNamePart("Steve Shaw"));
			string result = formatter.Format(GetContext("name", "PN", SpecificationVersion.R02_04_03), new PNImpl(personName));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("something in text node", "<name use=\"L\">Steve Shaw</name>", result, true);
			this.result.ClearErrors();
			personName.Uses.Clear();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.PSEUDONYM);
			result = formatter.Format(GetContext("name", "PN", SpecificationVersion.R02_04_03), new PNImpl(personName));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("something in text node", "<name use=\"P\">Steve Shaw</name>", result, true);
			this.result.ClearErrors();
			personName.Uses.Clear();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LICENSE);
			result = formatter.Format(GetContext("name", "PN", SpecificationVersion.R02_04_03), new PNImpl(personName));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("something in text node", "<name use=\"C\">Steve Shaw</name>", result, true);
			this.result.ClearErrors();
			personName.Uses.Clear();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.OFFICIAL_REGISTRY);
			result = formatter.Format(GetContext("name", "PN", SpecificationVersion.R02_04_03), new PNImpl(personName));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("something in text node", "<name use=\"OR\">Steve Shaw</name>", result, true);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNullWithQualifier()
		{
			EnR2PropertyFormatter formatter = new EnR2PropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			personName.AddNamePart(new EntityNamePart("Shaw", PersonNamePartType.FAMILY, Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNamePartQualifier
				.BIRTH));
			string result = formatter.Format(GetContext("name", "PN", SpecificationVersion.V02R02), new PNImpl(personName));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("something in text node", "<name use=\"L\"><family qualifier=\"BR\">Shaw</family></name>", result, true);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestBasicForCeRxWithMultipleNameParts()
		{
			EnR2PropertyFormatter formatter = new EnR2PropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			personName.AddNamePart(new EntityNamePart("Steve", PersonNamePartType.GIVEN));
			personName.AddNamePart(new EntityNamePart("Shaw", PersonNamePartType.FAMILY));
			string result = formatter.Format(GetContext("name", "PN", SpecificationVersion.V01R04_3), new PNImpl(personName));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("something in text node", "<name use=\"L\"><given>Steve</given><family>Shaw</family></name>", result, true);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatSimpleNoParts()
		{
			EnR2PropertyFormatter formatter = new EnR2PropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			string result = formatter.Format(GetContext("name", "PN", SpecificationVersion.R02_04_02), new PNImpl(personName));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("something in text node", "<name use=\"L\"></name>", result, true);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueWithDelimiterPartType()
		{
			EnR2PropertyFormatter formatter = new EnR2PropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			personName.AddNamePart(new EntityNamePart("namegoeshere", PersonNamePartType.DELIMITER));
			string result = formatter.Format(GetContext("name", "PN", SpecificationVersion.R02_04_02), new PNImpl(personName));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("something in text node", "<name use=\"L\"><delimiter>namegoeshere</delimiter></name>", result, true);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNullMultipleNameParts()
		{
			EnR2PropertyFormatter formatter = new EnR2PropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			personName.AddNamePart(new EntityNamePart("prefix", PersonNamePartType.PREFIX, Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNamePartQualifier
				.INITIAL));
			personName.AddNamePart(new EntityNamePart("given1", PersonNamePartType.GIVEN));
			personName.AddNamePart(new EntityNamePart("given2", PersonNamePartType.GIVEN));
			personName.AddNamePart(new EntityNamePart("given3", PersonNamePartType.GIVEN));
			personName.AddNamePart(new EntityNamePart("given4", PersonNamePartType.GIVEN));
			personName.AddNamePart(new EntityNamePart("family", PersonNamePartType.FAMILY));
			personName.AddNamePart(new EntityNamePart("suffix", PersonNamePartType.SUFFIX, Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNamePartQualifier
				.INITIAL));
			string result = formatter.Format(GetContext("name", "PN", SpecificationVersion.R02_04_02), new PNImpl(personName));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("well formed name", "<name use=\"L\"><prefix qualifier=\"IN\">prefix</prefix><given>given1</given><given>given2</given><given>given3</given><given>given4</given><family>family</family><suffix qualifier=\"IN\">suffix</suffix></name>"
				, result, true);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueReservedXmlChars()
		{
			EnR2PropertyFormatter formatter = new EnR2PropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			personName.AddNamePart(new EntityNamePart("<cats tk they're > humans & dogs 99% of the time/>"));
			string result = formatter.Format(GetContext("name", "PN", SpecificationVersion.R02_04_02), new PNImpl(personName));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("something in text node", "<name use=\"L\">&lt;cats tk they&apos;re &gt; humans &amp; dogs 99% of the time/&gt;</name>"
				, result, true);
		}
	}
}
