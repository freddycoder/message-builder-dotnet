using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Codesystem;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class FullCodeWrapperTest
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldWrapCodeWithCodeSystem()
		{
			Code code = Ca.Infoway.Messagebuilder.Domainvalue.Payload.AdministrativeGender.MALE;
			string codeSystem = CodeSystem.CANADA.ToString();
			Code fullCode = FullCodeWrapper.Wrap<Code>(code, codeSystem);
			Assert.AreEqual(codeSystem, fullCode.CodeSystem);
			Assert.AreEqual(code.CodeValue, fullCode.CodeValue);
		}
	}
}
