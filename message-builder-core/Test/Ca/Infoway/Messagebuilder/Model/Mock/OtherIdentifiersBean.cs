using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Model;

namespace Ca.Infoway.Messagebuilder.Model.Mock
{
	[System.Serializable]
	[Hl7PartTypeMappingAttribute(new string[] { "PRPA_MT101102CA.OtherIDs", "PRPA_MT101001CA.OtherIDs", "PRPA_MT101002CA.OtherIDs"
		 })]
	public class OtherIdentifiersBean : MessagePartBean
	{
		private const long serialVersionUID = 3230221453725587616L;

		private readonly SET<II, Identifier> ids = new SETImpl<II, Identifier>(typeof(IIImpl));

		private readonly CD code = new CDImpl();

		private readonly II organizationId = new IIImpl();

		private readonly ST organizationName = new STImpl();

		[Hl7XmlMappingAttribute(new string[] { "id" })]
		public virtual ICollection<Identifier> GetIds()
		{
			return this.ids.RawSet();
		}

		public virtual Identifier GetId()
		{
			return this.GetIds().IsEmpty() ? null : this.GetIds().GetEnumerator().Current;
		}

		[Hl7XmlMappingAttribute(new string[] { "code" })]
		public virtual OtherIdentifierRoleType GetCode()
		{
			return (OtherIdentifierRoleType)this.code.Value;
		}

		public virtual void SetCode(OtherIdentifierRoleType code)
		{
			this.code.Value = code;
		}

		[Hl7XmlMappingAttribute(new string[] { "scopingIdOrganization/id", "assigningIdOrganization/id" })]
		public virtual Identifier GetOrganizationId()
		{
			return this.organizationId.Value;
		}

		public virtual void SetOrganizationId(Identifier organizationId)
		{
			this.organizationId.Value = organizationId;
		}

		[Hl7XmlMappingAttribute(new string[] { "scopingIdOrganization/name", "assigningIdOrganization/name" })]
		public virtual string GetOrganizationName()
		{
			return this.organizationName.Value;
		}

		public virtual void SetOrganizationName(string organizationName)
		{
			this.organizationName.Value = organizationName;
		}
	}
}
