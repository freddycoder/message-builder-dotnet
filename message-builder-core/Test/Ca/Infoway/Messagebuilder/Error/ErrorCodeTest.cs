using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Lang;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Error
{
	[TestFixture]
	public class ErrorCodeTest
	{
		[Test]
		public virtual void TestAllHl7ErrorCodesAreInErrorCode()
		{
			IList<Hl7ErrorCode> oldErrorCode = EnumPattern.Values<Hl7ErrorCode>();
			for (int i = 0; i < oldErrorCode.Count; i++)
			{
				ErrorCode newErrorCode = TransformError.TransformCode(oldErrorCode[i]);
				if (newErrorCode == null)
				{
					Assert.Fail("ErrorCode is missing Hl7ErrorCode: " + oldErrorCode[i].Name);
				}
			}
		}
	}
}
