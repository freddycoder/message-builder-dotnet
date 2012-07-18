using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Model;

namespace Ca.Infoway.Messagebuilder.Model.Mock
{
	[System.Serializable]
	public class SeverityObservationBean : MessagePartBean
	{
		private const long serialVersionUID = 3635762510647290962L;

		private CD code = new CDImpl();

		private CD statusCode = new CDImpl();

		private CD severityObservation = new CDImpl();

		public SeverityObservationBean() : base()
		{
		}

		[Hl7XmlMappingAttribute("code")]
		public virtual Ca.Infoway.Messagebuilder.Domainvalue.ActCode GetCode()
		{
			return (Ca.Infoway.Messagebuilder.Domainvalue.ActCode)this.code.Value;
		}

		public virtual void SetCode(Ca.Infoway.Messagebuilder.Domainvalue.ActCode code)
		{
			this.code.Value = code;
		}

		[Hl7XmlMappingAttribute("statusCode")]
		public virtual ActStatus GetStatusCode()
		{
			return (ActStatus)this.statusCode.Value;
		}

		public virtual void SetStatusCode(ActStatus statusCode)
		{
			this.statusCode.Value = statusCode;
		}

		[Hl7XmlMappingAttribute("value")]
		public virtual SeverityObservation GetSeverityObservation()
		{
			return (SeverityObservation)this.severityObservation.Value;
		}

		public virtual void SetSeverityObservation(SeverityObservation severityObservation)
		{
			this.severityObservation.Value = severityObservation;
		}
	}
}
