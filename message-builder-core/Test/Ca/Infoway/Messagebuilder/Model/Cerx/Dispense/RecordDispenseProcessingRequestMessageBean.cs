using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Model;
using Ca.Infoway.Messagebuilder.Model.Cerx.Dispense;

namespace Ca.Infoway.Messagebuilder.Model.Cerx.Dispense
{
	[Hl7PartTypeMappingAttribute("PORX_IN020190CA")]
	public class RecordDispenseProcessingRequestMessageBean : IInteraction
	{
		private const long serialVersionUID = -6285495099388770893L;

		public virtual RecordDispenseProcessingRequestMessageBean GetTargetReference()
		{
			return this;
		}
	}
}
