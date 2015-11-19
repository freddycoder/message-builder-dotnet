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
	public class EnR2PropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestEnR2PropertyFormatterWhenConformanceLevelIsNotSpecified()
		{
			string result = new EnR2PropertyFormatter().Format(GetContext("name", "EN"), new ENImpl<EntityName>());
			Assert.AreEqual("<name nullFlavor=\"NI\"/>", result.Trim());
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
			string result = formatter.Format(GetContext("name", "EN", SpecificationVersion.V01R04_3), new PNImpl(personName));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("something in text node", "<name use=\"L\"><given>Steve</given><family>Shaw</family></name>", result, true);
		}
	}
}
