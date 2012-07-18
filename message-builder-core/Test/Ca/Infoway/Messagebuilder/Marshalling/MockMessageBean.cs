using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Model;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	[Hl7PartTypeMappingAttribute("MOCK_IN123456CA")]
	public class MockMessageBean : IInteraction
	{
		private const long serialVersionUID = -8148180862570811368L;

		private MockSubType type = new MockSubType();

		[Hl7XmlMappingAttribute("theType")]
		public virtual MockSubType Type
		{
			get
			{
				return type;
			}
			set
			{
				MockSubType type = value;
				this.type = type;
			}
		}
	}
}
