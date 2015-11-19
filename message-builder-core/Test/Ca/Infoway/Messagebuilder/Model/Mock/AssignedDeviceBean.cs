using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Model;

namespace Ca.Infoway.Messagebuilder.Model.Mock
{
	[System.Serializable]
	[Hl7PartTypeMappingAttribute(new string[] { "COCT_MT090310CA.AssignedDevice" })]
	public class AssignedDeviceBean : MessagePartBean
	{
		private const long serialVersionUID = 5659630456107426952L;

		private II id = new IIImpl();

		private ST assignedRepository = new STImpl();

		private ST representedRepositoryJurisdiction = new STImpl();

		[Hl7XmlMappingAttribute("id")]
		public virtual Identifier Id
		{
			get
			{
				return this.id.Value;
			}
			set
			{
				Identifier id = value;
				this.id.Value = id;
			}
		}

		[Hl7XmlMappingAttribute("assignedRepository/name")]
		public virtual string AssignedRepository
		{
			get
			{
				return this.assignedRepository.Value;
			}
			set
			{
				string assignedRepository = value;
				this.assignedRepository.Value = assignedRepository;
			}
		}

		[Hl7XmlMappingAttribute("representedRepositoryJurisdiction/name")]
		public virtual string RepresentedRepositoryJurisdiction
		{
			get
			{
				return this.representedRepositoryJurisdiction.Value;
			}
			set
			{
				string representedRepositoryJurisdiction = value;
				this.representedRepositoryJurisdiction.Value = representedRepositoryJurisdiction;
			}
		}
	}
}
