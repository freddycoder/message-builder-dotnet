using System;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Model;
using Ca.Infoway.Messagebuilder.Model.Mock;
using Ca.Infoway.Messagebuilder.Platform;

namespace Ca.Infoway.Messagebuilder.Model.Mock
{
	[System.Serializable]
	[Hl7PartTypeMappingAttribute(new string[] { "COCT_MT050203CA.Person", "PRPA_MT101001CA.Person", "PRPA_MT101002CA.Person", 
		"PRPA_MT101102CA.Person" })]
	public class IndeterminatePersonBean : MessagePartBean
	{
		private const long serialVersionUID = 768511136435678165L;

		private readonly LIST<PN, PersonName> names = new LISTImpl<PN, PersonName>(typeof(PNImpl));

		private readonly LIST<TEL, TelecommunicationAddress> telecom = new LISTImpl<TEL, TelecommunicationAddress>(typeof(TELImpl
			));

		private readonly CD administrativeGenderCode = new CDImpl();

		private readonly TS birthTime = new TSImpl();

		private readonly BL deceasedIndicator = new BLImpl();

		private readonly TS deceasedTime = new TSImpl();

		private readonly BL multipleBirthIndicator = new BLImpl();

		private readonly INT multipleBirthOrderNumber = new INTImpl();

		private readonly LIST<AD, PostalAddress> addresses = new LISTImpl<AD, PostalAddress>(typeof(ADImpl));

		private readonly ICollection<OtherIdentifiersBean> asOtherIds = new LinkedSet<OtherIdentifiersBean>();

		private readonly IList<PersonalRelationshipBean> personalRelationships = new List<PersonalRelationshipBean>();

		private readonly SET<II, Identifier> ids = new SETImpl<II, Identifier>(typeof(IIImpl));

		public virtual PersonName GetName()
		{
			return this.GetNames().IsEmpty() ? null : this.GetNames()[0];
		}

		public virtual void SetName(PersonName name)
		{
			this.GetNames().Add(name);
		}

		[Hl7XmlMappingAttribute("name")]
		public virtual IList<PersonName> GetNames()
		{
			return this.names.RawList();
		}

		[Hl7XmlMappingAttribute("telecom")]
		public virtual IList<TelecommunicationAddress> GetTelecom()
		{
			return this.telecom.RawList();
		}

		[Hl7XmlMappingAttribute("administrativeGenderCode")]
		public virtual AdministrativeGender GetAdministrativeGenderCode()
		{
			return (AdministrativeGender)this.administrativeGenderCode.Value;
		}

		public virtual void SetAdministrativeGenderCode(AdministrativeGender administrativeGenderCode)
		{
			this.administrativeGenderCode.Value = administrativeGenderCode;
		}

		[Hl7XmlMappingAttribute("birthTime")]
		public virtual PlatformDate GetBirthTime()
		{
			return this.birthTime.Value;
		}

		public virtual void SetBirthTime(PlatformDate birthTime)
		{
			this.birthTime.Value = birthTime;
		}

		[Hl7XmlMappingAttribute("deceasedInd")]
		public virtual Boolean? GetDeceasedIndicator()
		{
			return this.deceasedIndicator.Value;
		}

		public virtual void SetDeceasedIndicator(Boolean? deceased)
		{
			this.deceasedIndicator.Value = deceased;
		}

		[Hl7XmlMappingAttribute("deceasedTime")]
		public virtual PlatformDate GetDeceasedTime()
		{
			return this.deceasedTime.Value;
		}

		public virtual void SetDeceasedTime(PlatformDate deceasedTime)
		{
			this.deceasedTime.Value = deceasedTime;
		}

		[Hl7XmlMappingAttribute("multipleBirthInd")]
		public virtual Boolean? GetMultipleBirthIndicator()
		{
			return this.multipleBirthIndicator.Value;
		}

		public virtual void SetMultipleBirthIndicator(Boolean? multipleBirthIndicator)
		{
			this.multipleBirthIndicator.Value = multipleBirthIndicator;
		}

		[Hl7XmlMappingAttribute("multipleBirthOrderNumber")]
		public virtual Int32? GetMultipleBirthOrderNumber()
		{
			return this.multipleBirthOrderNumber.Value;
		}

		public virtual void SetMultipleBirthOrderNumber(Int32? multipleBirthOrderNumber)
		{
			this.multipleBirthOrderNumber.Value = multipleBirthOrderNumber;
		}

		[Hl7XmlMappingAttribute("addr")]
		public virtual IList<PostalAddress> GetAddresses()
		{
			return this.addresses.RawList();
		}

		[Hl7XmlMappingAttribute("asOtherIDs")]
		public virtual ICollection<OtherIdentifiersBean> GetAsOtherIds()
		{
			return asOtherIds;
		}

		[Hl7XmlMappingAttribute("personalRelationship")]
		public virtual IList<PersonalRelationshipBean> GetPersonalRelationships()
		{
			return this.personalRelationships;
		}

		[Hl7XmlMappingAttribute(new string[] { "id" })]
		public virtual ICollection<Identifier> GetIds()
		{
			return this.ids.RawSet();
		}
	}
}
