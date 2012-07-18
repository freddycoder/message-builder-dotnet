using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class GenericDataTypeFactoryTest
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldFindIntervalTypes()
		{
			AssertType("IVL<PQ.BASIC>");
			AssertType("IVL<TS.FULLDATETIME>");
			AssertType("IVL<TS.DATE>");
		}

		private void AssertType(string type)
		{
			Assert.IsNotNull(GenericDataTypeFactory.Create(type), "type " + type);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldFindListTypes()
		{
			AssertType("LIST<II.OID>");
			AssertType("LIST<GTS.BOUNDEDPIVL>");
			AssertType("LIST<PN.BASIC>");
			AssertType("LIST<TEL.PHONEMAIL>");
		}
	}
}
