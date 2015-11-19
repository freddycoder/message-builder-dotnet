using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Model;
using Ca.Infoway.Messagebuilder.Model.Mock;

namespace Ca.Infoway.Messagebuilder.Model.Mock
{
	[System.Serializable]
	[Hl7PartTypeMappingAttribute(new string[] { "PORX_MT060040CA.DetectedIssueEvent", "PORX_MT060060CA.DetectedIssueEvent", "PORX_MT980010CA.DetectedIssueEvent"
		, "PORX_MT980030CA.DetectedIssueEvent", "PORX_MT030040CA.DetectedIssueEvent", "PORX_MT060190CA.DetectedIssueEvent" })]
	public class DetectedIssueBean : MessagePartBean
	{
		private const long serialVersionUID = -3496935518970888871L;

		protected CD code = new CDImpl();

		protected ST text = new STImpl();

		protected CD statusCode = new CDImpl();

		protected CD priorityCode = new CDImpl();

		protected SeverityObservationBean severityObservation = new SeverityObservationBean();

		protected DetectedIssueDefinition issueDescription;

		protected IList<DetectedIssueManagementBean> issueManagements = new List<DetectedIssueManagementBean>();

		public DetectedIssueBean()
		{
		}

		public DetectedIssueBean(ActIssuePriority priorityCode, ActDetectedIssueCode code, ActStatus statusCode, string text)
		{
			SetCode(code);
			SetPriorityCode(priorityCode);
			SetStatusCode(statusCode);
			SetText(text);
		}

		[Hl7XmlMappingAttribute("code")]
		public virtual ActDetectedIssueCode GetCode()
		{
			return (ActDetectedIssueCode)this.code.Value;
		}

		public virtual void SetCode(ActDetectedIssueCode code)
		{
			this.code.Value = code;
		}

		[Hl7XmlMappingAttribute("text")]
		public virtual string GetText()
		{
			return this.text.Value;
		}

		public virtual void SetText(string text)
		{
			this.text.Value = text;
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

		[Hl7XmlMappingAttribute("priorityCode")]
		public virtual ActIssuePriority GetPriorityCode()
		{
			return (ActIssuePriority)this.priorityCode.Value;
		}

		public virtual void SetPriorityCode(ActIssuePriority priorityCode)
		{
			this.priorityCode.Value = priorityCode;
		}

		[Hl7XmlMappingAttribute(new string[] { "subjectOf/severityObservation", "subjectOf2/severityObservation" })]
		public virtual SeverityObservationBean GetSeverityObservation()
		{
			return this.severityObservation;
		}

		public virtual void SetSeverityObservation(SeverityObservationBean severityObservation)
		{
			this.severityObservation = severityObservation;
		}

		[Hl7XmlMappingAttribute("instantiation/detectedIssueDefinition")]
		public virtual DetectedIssueDefinition GetIssueDescription()
		{
			return issueDescription;
		}

		public virtual void SetIssueDescription(DetectedIssueDefinition issueDescription)
		{
			this.issueDescription = issueDescription;
		}

		[Hl7XmlMappingAttribute("mitigatedBy/detectedIssueManagement")]
		public virtual IList<DetectedIssueManagementBean> GetIssueManagements()
		{
			return this.issueManagements;
		}

		public virtual void SetIssueManagements(IList<DetectedIssueManagementBean> issueManagements)
		{
			this.issueManagements = issueManagements;
		}
	}
}
