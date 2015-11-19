using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Model;
using Ca.Infoway.Messagebuilder.Model.Mock;

namespace Ca.Infoway.Messagebuilder.Model.Mock
{
	[System.Serializable]
	[Hl7PartTypeMappingAttribute(new string[] { "PORX_MT980010CA.DetectedIssueManagement", "PORX_MT980030CA.DetectedIssueManagement"
		 })]
	public class DetectedIssueManagementBean : MessagePartBean
	{
		private const long serialVersionUID = 5300042834504076009L;

		private CD code = new CDImpl();

		private CD statusCode = new CDImpl();

		private AuthorBean author = new AuthorBean();

		private ST text = new STImpl();

		public DetectedIssueManagementBean() : base()
		{
		}

		[Hl7XmlMappingAttribute(new string[] { "code" })]
		public virtual ActDetectedIssueManagementCode GetCode()
		{
			return (ActDetectedIssueManagementCode)this.code.Value;
		}

		public virtual void SetCode(ActDetectedIssueManagementCode code)
		{
			this.code.Value = code;
		}

		public virtual ActStatus GetStatusCode()
		{
			return (ActStatus)this.statusCode.Value;
		}

		public virtual void SetStatusCode(ActStatus statusCode)
		{
			this.statusCode.Value = statusCode;
		}

		[Hl7XmlMappingAttribute(new string[] { "author" })]
		public virtual AuthorBean GetAuthor()
		{
			return author;
		}

		public virtual void SetAuthor(AuthorBean author)
		{
			this.author = author;
		}

		[Hl7XmlMappingAttribute(new string[] { "text" })]
		public virtual string GetText()
		{
			return this.text.Value;
		}

		public virtual void SetText(string text)
		{
			this.text.Value = text;
		}
	}
}
