using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Xml;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Datatype
{
	[TestFixture]
	public class StandardDataTypeTest
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldGetHl7TypeName()
		{
			Hl7TypeName typeName = StandardDataType.AD_BASIC.TypeName;
			Assert.AreEqual("AD.BASIC", typeName.ToString(), "name");
			Assert.AreEqual("AD", typeName.UnspecializedName, "unqualified name");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldGetRootName()
		{
			Assert.AreEqual("AD", StandardDataType.AD_BASIC.TypeName.RootName, "AD");
			Assert.AreEqual("IVL", StandardDataType.IVL_FULL_DATE.TypeName.RootName, "IVL");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldCalculateIsCoded()
		{
			Assert.IsTrue(StandardDataType.CD.Coded, "CD");
			Assert.IsTrue(StandardDataType.CD_LAB.Coded, "CD.LAB");
			Assert.IsTrue(StandardDataType.CV.Coded, "CV");
			Assert.IsFalse(StandardDataType.ST.Coded, "ST");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldResolveSimpleXmlType()
		{
			Assert.AreEqual(StandardDataType.II, StandardDataType.ConvertSimpleXmlToDataType("InstanceIdentifier"), "II");
			Assert.AreEqual(StandardDataType.TS_DATE, StandardDataType.ConvertSimpleXmlToDataType("PartialDate"), "TS.DATE");
		}
	}
}
