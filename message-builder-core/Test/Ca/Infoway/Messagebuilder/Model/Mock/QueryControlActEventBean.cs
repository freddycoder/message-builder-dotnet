using System;
using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Model.Mock;

namespace Ca.Infoway.Messagebuilder.Model.Mock
{
	[System.Serializable]
	[Hl7PartTypeMappingAttribute(new string[] { "MFMI_MT700751CA.ControlActEvent" })]
	public class QueryControlActEventBean<PL> : ControlActEventBean
	{
		private const long serialVersionUID = 7409413947816976194L;

		private ConsentEventBean consentEvent;

		private QueryByParameterBean<PL> queryByParameter = new QueryByParameterBean<PL>();

		public QueryControlActEventBean()
		{
		}

		public QueryControlActEventBean(PL criteria)
		{
			this.queryByParameter.ParameterList = criteria;
		}

		public virtual PL GetCriteria()
		{
			return this.queryByParameter.ParameterList;
		}

		public virtual Identifier QueryId
		{
			get
			{
				return this.queryByParameter.QueryIdentifier;
			}
			set
			{
				Identifier queryId = value;
				this.queryByParameter.QueryIdentifier = queryId;
			}
		}

		public virtual Int32? QueryLimit
		{
			get
			{
				return this.queryByParameter.QueryLimit;
			}
			set
			{
				Int32? queryLimit = value;
				this.queryByParameter.QueryLimit = queryLimit;
			}
		}

		[Hl7XmlMappingAttribute("subjectOf2/consentEvent")]
		public virtual ConsentEventBean ConsentEvent
		{
			get
			{
				return consentEvent;
			}
			set
			{
				ConsentEventBean consentEvent = value;
				this.consentEvent = consentEvent;
			}
		}

		[Hl7XmlMappingAttribute("queryByParameter")]
		public virtual QueryByParameterBean<PL> QueryByParameter
		{
			get
			{
				return this.queryByParameter;
			}
			set
			{
				QueryByParameterBean<PL> queryByParameter = value;
				this.queryByParameter = queryByParameter;
			}
		}
	}
}
