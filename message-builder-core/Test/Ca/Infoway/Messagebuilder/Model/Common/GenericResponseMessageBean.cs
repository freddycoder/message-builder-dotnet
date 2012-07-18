using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Model.Mock;

namespace Ca.Infoway.Messagebuilder.Model.Common
{
	[System.Serializable]
	[Hl7PartTypeMappingAttribute("MCCI_IN000002CA")]
	public class GenericResponseMessageBean : NoPayloadResponseMessageBean
	{
		private const long serialVersionUID = 5191719298094899922L;

		public GenericResponseMessageBean()
		{
			ClearControlActEvent();
		}
	}
}
