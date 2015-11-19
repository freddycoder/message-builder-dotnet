using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.DevTools;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Platform;

namespace Ca.Infoway.Messagebuilder.DevTools
{
	public class DefaultValueHolder : ValueHolder
	{
		public override Identifier GetId()
		{
			return new Identifier(UUID.RandomUUID().ToString(), null);
		}

		public override PlatformDate GetCreationTime()
		{
			return new PlatformDate();
		}

		public override string GetSecurityText()
		{
			return "SecurityToken";
		}

		public override ResponseMode GetResponseModeCode()
		{
			return Ca.Infoway.Messagebuilder.Domainvalue.Transport.ResponseMode.IMMEDIATE;
		}

		public override IList<Identifier> GetProfileId()
		{
			IList<Identifier> conformanceProfileIdentifiers = base.GetProfileId();
			conformanceProfileIdentifiers.Clear();
			conformanceProfileIdentifiers.Add(new Identifier("1.1.1", "ext1"));
			return conformanceProfileIdentifiers;
		}

		public override ProcessingID GetProcessingCode()
		{
			return Ca.Infoway.Messagebuilder.Domainvalue.Transport.ProcessingID.PRODUCTION;
		}

		public override ProcessingMode GetProcessingModeCode()
		{
			return Ca.Infoway.Messagebuilder.Domainvalue.Transport.ProcessingMode.CURRENT_PROCESSING;
		}

		public override AcknowledgementCondition GetAcceptAckCode()
		{
			return Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementCondition.ALWAYS;
		}

		public override ReceiverValueHolder GetReceiver()
		{
			return PopulateReceiver();
		}

		public override SenderValueHolder GetSender()
		{
			return PopulateSender();
		}

		public override ToBeRespondedToByValueHolder GetRespondTo()
		{
			return PopulateRespondTo();
		}

		public override IList<RoutingInstructionLinesValueHolder> GetAttentionLine()
		{
			RoutingInstructionLinesValueHolder bean = new RoutingInstructionLinesValueHolder();
			bean.SetKeyWordText("routing type");
			bean.SetValue("routing name");
			RoutingInstructionLinesValueHolder bean2 = new RoutingInstructionLinesValueHolder();
			bean2.SetKeyWordText("another routing type");
			bean2.SetValue("another routing name");
			IList<RoutingInstructionLinesValueHolder> result = new List<RoutingInstructionLinesValueHolder>();
			result.Add(bean);
			result.Add(bean2);
			return result;
		}

		private ReceiverValueHolder PopulateReceiver()
		{
			ReceiverValueHolder receiver = new ReceiverValueHolder();
			receiver.SetDeviceName("Receiver Application Name");
			receiver.SetTelecom(new TelecommunicationAddress(Ca.Infoway.Messagebuilder.Domainvalue.Basic.URLScheme.HTTP, "192.168.2.1"
				));
			receiver.SetDeviceAgentAgentOrganizationId(new Identifier("1.1.2", "ext2"));
			receiver.SetDeviceId(new Identifier("1.1.3", "ext3"));
			return receiver;
		}

		private SenderValueHolder PopulateSender()
		{
			SenderValueHolder sender = new SenderValueHolder();
			sender.SetTelecom(new TelecommunicationAddress(Ca.Infoway.Messagebuilder.Domainvalue.Basic.URLScheme.HTTP, "192.168.2.2")
				);
			sender.SetDeviceId(new Identifier("1.1.4", "ext4"));
			sender.SetDeviceManufacturerModelName("1.0");
			sender.SetDeviceSoftwareName("MBT Pharmacy");
			sender.SetDeviceDesc("Configuration information");
			sender.SetDeviceName("Sending Application Name");
			sender.SetDeviceExistenceTime(IntervalFactory.CreateLow<PlatformDate>(new PlatformDate()));
			sender.SetDeviceAgentAgentOrganizationId(new Identifier("1.1.5", "ext5"));
			return sender;
		}

		private ToBeRespondedToByValueHolder PopulateRespondTo()
		{
			ToBeRespondedToByValueHolder bean = new ToBeRespondedToByValueHolder();
			bean.SetDeviceId(new Identifier("1.1.6", "ext6"));
			bean.SetTelecom(new TelecommunicationAddress(Ca.Infoway.Messagebuilder.Domainvalue.Basic.URLScheme.HTTP, "192.168.2.3"));
			return bean;
		}
	}
}
