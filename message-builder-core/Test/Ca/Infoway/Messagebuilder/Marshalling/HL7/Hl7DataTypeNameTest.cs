using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7
{
	[TestFixture]
	public class Hl7DataTypeNameTest
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestShouldDetermineUnqualifiedName()
		{
			Hl7DataTypeName name = Hl7DataTypeName.Create("TS.FULLDATE");
			Assert.AreEqual("TS", name.GetUnqualifiedVersion().ToString());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestShouldRecognizeQualifiedTypes()
		{
			Hl7DataTypeName name = Hl7DataTypeName.Create("TS.FULLDATE");
			Assert.IsTrue(name.IsQualified(), "TS.FULLDATE");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestShouldDetermineUnqualifiedCollectionName()
		{
			Hl7DataTypeName name = Hl7DataTypeName.Create("SET<TS.FULLDATE>");
			Assert.AreEqual("SET<TS>", name.GetUnqualifiedVersion().ToString());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestShouldDetermineUnqualifiedComplicatedName()
		{
			Hl7DataTypeName name = Hl7DataTypeName.Create("RTO<MO.CAD,PQ.BASIC>");
			Assert.AreEqual("RTO<MO,PQ>", name.GetUnqualifiedVersion().ToString());
		}
	}
}
