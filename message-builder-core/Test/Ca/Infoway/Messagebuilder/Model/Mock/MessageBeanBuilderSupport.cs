/**
 * Copyright 2013 Canada Health Infoway, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *        http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 * Author:        $LastChangedBy: tmcgrady $
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using System;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Model.Mock;
using Ca.Infoway.Messagebuilder.Resolver;

namespace Ca.Infoway.Messagebuilder.Model.Mock
{
	public class MessageBeanBuilderSupport
	{
		public static readonly PlatformDate EFFECTIVE_TIME = DateUtil.GetDate(2008, 8, 18);

		public static void PopulateStandardValues(NoPayloadResponseMessageBean bean)
		{
			PopulateStandardValuesV02(bean);
			PopulateAcknowledgement(bean);
		}

		public static void PopulateStandardValuesV01(NoPayloadResponseMessageBean bean)
		{
			PopulateStandardValuesV01(bean);
			PopulateAcknowledgement(bean);
		}

		public static void PopulateStandardValuesV01(NewBaseMessageBean bean)
		{
			bean.MessageIdentifier = new Identifier("2.16.124.113620.1.1.1.1.2", "293844");
			bean.MessageTimestamp = DateUtil.GetDate(2008, 5, 25, 14, 16, 10, 0);
			bean.ProcessingCode = Ca.Infoway.Messagebuilder.Domainvalue.Transport.ProcessingID.PRODUCTION;
			bean.ProcessingMode = Ca.Infoway.Messagebuilder.Domainvalue.Transport.ProcessingMode.CURRENT_PROCESSING;
			bean.ResponseType = Ca.Infoway.Messagebuilder.Domainvalue.Transport.ResponseMode.IMMEDIATE;
			bean.DesiredAcknowledgmentType = Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementCondition.ALWAYS;
			bean.Receiver = new Receiver();
			bean.Receiver.DeviceId = new Identifier("1.2.3", "123");
			bean.Receiver.SetTelecommunicationAddress(new TelecommunicationAddress(CodeResolverRegistry.Lookup<Ca.Infoway.Messagebuilder.Domainvalue.URLScheme
				>("http"), "123.456.789.10"));
			bean.Sender = new Sender();
			bean.Sender.DeviceId = new Identifier("1.2.3", "123");
			bean.Sender.ManufacturerModelNumber = "1.0";
			bean.Sender.SoftwareName = "Panacea Pharmacy";
			bean.Sender.TelecommunicationAddress = new TelecommunicationAddress();
			bean.Sender.TelecommunicationAddress.Address = "987.654.321.0";
			bean.Sender.TelecommunicationAddress.UrlScheme = CodeResolverRegistry.Lookup<Ca.Infoway.Messagebuilder.Domainvalue.URLScheme
				>("http");
		}

		public static void PopulateStandardValuesV02(NewBaseMessageBean bean)
		{
			PopulateStandardValuesV01(bean);
		}

		public static void PopulateStandardValues(ControlActEventBean controlActEvent)
		{
			controlActEvent.EventId = new Identifier("2.16.840.1.113883.1.6", "8141234");
			controlActEvent.StatusCode = CodeResolverRegistry.Lookup<ActStatus>("new");
			controlActEvent.EffectiveTime = EFFECTIVE_TIME;
			controlActEvent.Author = CreateAuthorV01();
			ServiceDeliveryLocationBean location = new ServiceDeliveryLocationBean();
			PopulateLocation(location);
			controlActEvent.Location = location;
		}

		public static void PopulateAcknowledgement(AcknowledgementBean acknowledgement)
		{
			acknowledgement.AcknowledgementType = Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementType.ACCEPT_ACKNOWLEDGEMENT_COMMIT_ACCEPT;
			acknowledgement.TargetMessage = new Identifier("11.22.33.44", "1234");
		}

		private static void PopulateAcknowledgement(NoPayloadResponseMessageBean bean)
		{
			bean.DesiredAcknowledgmentType = Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementCondition.NEVER;
			// TM - OLDTEAL - any need to preserve these lines? 
			bean.Acknowledgement.AcknowledgementType = Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementType.APPLICATION_ACKNOWLEDGEMENT_ACCEPT;
			bean.Acknowledgement.TargetMessage = new Identifier("2.16.124.113620.1.1.1.1.2", "293844");
		}

		private static AuthorBean CreateAuthorV01()
		{
			AuthorBean result = new AuthorBean();
			result.Time = DateUtil.GetDate(2008, 8, 18, 18, 18, 0, 0);
			result.Id = new Identifier("2.16.840.1.113883.4.267", "EHR ID EXT");
			result.SetLicenseNumber(new Identifier("2.16.840.1.113883.4.268", "55555"));
			// I'm a little unhappy about this. The data setup seems too HL7-y. Would it be better to retain the PersonNameBean and the adaptor?
			PersonName name = new PersonName();
			name.AddNamePart(new EntityNamePart("Jane", PersonNamePartType.GIVEN));
			name.AddNamePart(new EntityNamePart("Doe", PersonNamePartType.FAMILY));
			result.SetName(name);
			return result;
		}

		private static void PopulateLocation(ServiceDeliveryLocationBean location)
		{
			location.SetIdentifier(new Identifier("2.16.124.113620.1.1.11111", "1"));
			location.SetName("Intelliware's Pharmacy");
		}

		public static void PopulateStandardValuesV01(QueryControlActEventBean<QueryCriteria> controlActEvent)
		{
			PopulateStandardValuesV01((ControlActEventBean)controlActEvent);
			ServiceDeliveryLocationBean location = new ServiceDeliveryLocationBean();
			PopulateLocation(location);
			controlActEvent.Location = location;
		}

		private static void PopulateStandardValuesV01(ControlActEventBean controlActEvent)
		{
			controlActEvent.EventId = new Identifier("2.16.840.1.113883.1.6", "8141234");
			controlActEvent.StatusCode = CodeResolverRegistry.Lookup<ActStatus>("new");
			controlActEvent.EffectiveTime = EFFECTIVE_TIME;
			controlActEvent.Author = CreateAuthorV01();
		}

		public static void PopulateDetectedIssue(DetectedIssueBean detectedIssue)
		{
			detectedIssue.SetCode(CodeResolverRegistry.Lookup<ActDetectedIssueCode>("VALIDAT"));
			detectedIssue.SetPriorityCode(CodeResolverRegistry.Lookup<ActIssuePriority>("I"));
			detectedIssue.SetStatusCode(CodeResolverRegistry.Lookup<ActStatus>("NORMAL"));
			detectedIssue.SetText("patient not found");
			detectedIssue.SetSeverityObservation(CreateSeverityObservation());
		}

		private static SeverityObservationBean CreateSeverityObservation()
		{
			SeverityObservationBean severityObservation = new SeverityObservationBean();
			severityObservation.SetCode(CodeResolverRegistry.Lookup<Ca.Infoway.Messagebuilder.Domainvalue.ActCode>("DX"));
			severityObservation.SetStatusCode(CodeResolverRegistry.Lookup<ActStatus>("NORMAL"));
			return severityObservation;
		}

		public static IndeterminatePersonBean CreatePersonBean()
		{
			IndeterminatePersonBean personBean = new IndeterminatePersonBean();
			personBean.SetAdministrativeGenderCode(Ca.Infoway.Messagebuilder.Domainvalue.Payload.AdministrativeGender.FEMALE);
			personBean.SetBirthTime(new PlatformDate());
			personBean.SetName(new PersonName());
			personBean.GetName().AddNamePart(new EntityNamePart("Jane", PersonNamePartType.GIVEN));
			personBean.GetName().AddNamePart(new EntityNamePart("Doe", PersonNamePartType.FAMILY));
			return personBean;
		}

		// TM - OLDTEAL - can this be removed?
		[Obsolete]
		public static void PopulateBetterStandardValuesV02(NewBaseMessageBean messageAttributes)
		{
			PopulateStandardValuesV02(messageAttributes);
			messageAttributes.Receiver.TelecommunicationAddress.UrlScheme = Ca.Infoway.Messagebuilder.Domainvalue.Basic.URLScheme.HTTP;
			messageAttributes.Receiver.TelecommunicationAddress.Address = "123.255.255.10";
		}

		public static void PopulateMoreBetterStandardValues(NewBaseMessageBean messageAttributes)
		{
			PopulateBetterStandardValuesV02(messageAttributes);
			messageAttributes.Sender.DeviceId = new Identifier("2.16.124.113620.1.2.100", "111");
			messageAttributes.Receiver.DeviceId = new Identifier("2.16.124.113620.1.2.100", "222");
			messageAttributes.MessageIdentifier = new Identifier("1ee83ff1-08ab-4fe7-b573-ea777e9bad51");
			messageAttributes.ConformanceProfileIdentifiers.Add(new Identifier("1ee83ff1-08ab-4fe7-b573-ea777e9bad52"));
			if (messageAttributes is NoPayloadResponseMessageBean)
			{
				((NoPayloadResponseMessageBean)messageAttributes).Acknowledgement = new AcknowledgementBean();
				((NoPayloadResponseMessageBean)messageAttributes).Acknowledgement.AcknowledgementType = Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementType
					.APPLICATION_ACKNOWLEDGEMENT_ACCEPT;
				((NoPayloadResponseMessageBean)messageAttributes).Acknowledgement.TargetMessage = new Identifier("1ee83ff1-08ab-4fe7-b573-ea777e9bad41"
					);
			}
		}
	}
}
