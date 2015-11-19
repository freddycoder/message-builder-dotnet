using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Model;

namespace Ca.Infoway.Messagebuilder.Model.Mock
{
	[System.Serializable]
	[Hl7PartTypeMappingAttribute(new string[] { "PRPA_MT101102CA.PersonalRelationship", "PRPA_MT101001CA.PersonalRelationship"
		, "PRPA_MT101002CA.PersonalRelationship" })]
	public class PersonalRelationshipBean : MessagePartBean
	{
		private const long serialVersionUID = -42113751918781255L;

		private CD roleType = new CDImpl();

		private II id = new IIImpl();

		private PN name = new PNImpl();

		[Hl7XmlMappingAttribute("code")]
		public virtual PersonalRelationshipRoleType GetRoleType()
		{
			return (PersonalRelationshipRoleType)this.roleType.Value;
		}

		public virtual void SetRoleType(PersonalRelationshipRoleType roleType)
		{
			this.roleType.Value = roleType;
		}

		[Hl7XmlMappingAttribute("relationshipHolder/id")]
		public virtual Identifier GetId()
		{
			return this.id.Value;
		}

		public virtual void SetId(Identifier id)
		{
			this.id.Value = id;
		}

		[Hl7XmlMappingAttribute("relationshipHolder/name")]
		public virtual PersonName GetName()
		{
			return this.name.Value;
		}

		public virtual void SetName(PersonName name)
		{
			this.name.Value = name;
		}
	}
}
