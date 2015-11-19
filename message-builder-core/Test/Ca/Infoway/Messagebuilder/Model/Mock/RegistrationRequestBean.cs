using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Model.Mock;
using Ca.Infoway.Messagebuilder.Platform;

namespace Ca.Infoway.Messagebuilder.Model.Mock
{
	[Hl7PartTypeMappingAttribute(new string[] { "MFMI_MT700711CA.Subject2", "MFMI_MT700716CA.Subject2" })]
	public class RegistrationRequestBean<RR>
	{
		private const long serialVersionUID = -6919002674167520092L;

		private readonly ICollection<ReplacementOfBean> priorRegistrations = new LinkedSet<ReplacementOfBean>();

		protected AssignedDeviceBean assignedDevice;

		protected RR record;

		[Hl7XmlMappingAttribute("registrationRequest/subject/registeredRole")]
		public virtual RR Record
		{
			get
			{
				return this.record;
			}
			set
			{
				RR record = value;
				this.record = record;
			}
		}

		[Hl7XmlMappingAttribute("registrationRequest/custodian/assignedDevice")]
		public virtual AssignedDeviceBean AssignedDevice
		{
			get
			{
				return this.assignedDevice;
			}
			set
			{
				AssignedDeviceBean custodian = value;
				this.assignedDevice = custodian;
			}
		}

		[Hl7XmlMappingAttribute("registrationRequest/replacementOf")]
		public virtual ICollection<ReplacementOfBean> PriorRegistrations
		{
			get
			{
				return priorRegistrations;
			}
		}
	}
}
