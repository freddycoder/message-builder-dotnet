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
 * Author:        $LastChangedBy: gng $
 * Last modified: $LastChangedDate: 2015-11-19 18:20:12 -0500 (Fri, 30 Jan 2015) $
 * Revision:      $LastChangedRevision: 9755 $
 */


using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Model.Cerx.Dispense;
using Ca.Infoway.Messagebuilder.Model.Common;
using Ca.Infoway.Messagebuilder.Model.Cr;
using Ca.Infoway.Messagebuilder.Model.Mock;
using Ca.Infoway.Messagebuilder.Model.Pr;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	/// <summary>This class registers beans for test purposes.</summary>
	/// <remarks>This class registers beans for test purposes.</remarks>
	public class MockMessageBeanRegistry
	{
		private static bool initialized = false;

		public static void Initialize()
		{
			if (!initialized)
			{
				MessageBeanRegistry.GetInstance().RegisterClass(typeof(MockMessageBean), MockVersionNumber.MOCK_NEWFOUNDLAND);
				MessageBeanRegistry.GetInstance().RegisterClass(typeof(MockSubType), MockVersionNumber.MOCK_NEWFOUNDLAND);
				MessageBeanRegistry.GetInstance().RegisterClass(typeof(FindCandidatesQueryMessageBean), MockVersionNumber.MOCK_NEWFOUNDLAND);
				MessageBeanRegistry.GetInstance().RegisterClass(typeof(FindCandidatesCriteria), MockVersionNumber.MOCK_NEWFOUNDLAND);
				MessageBeanRegistry.GetInstance().RegisterClass(typeof(GenericResponseMessageBean), MockVersionNumber.MOCK_NEWFOUNDLAND);
				MessageBeanRegistry.GetInstance().RegisterClass(typeof(UpdatePasswordRequestMessageBean), MockVersionNumber.MOCK_NEWFOUNDLAND);
				MessageBeanRegistry.GetInstance().RegisterClass(typeof(RegistrationControlActEventBean<>), MockVersionNumber.MOCK_NEWFOUNDLAND);
				MessageBeanRegistry.GetInstance().RegisterClass(typeof(PasswordChangeBean), MockVersionNumber.MOCK_NEWFOUNDLAND);
				MessageBeanRegistry.GetInstance().RegisterClass(typeof(AcknowledgementBean), MockVersionNumber.MOCK_NEWFOUNDLAND);
				MessageBeanRegistry.GetInstance().RegisterClass(typeof(AcknowledgementDetailBean), MockVersionNumber.MOCK_NEWFOUNDLAND);
				MessageBeanRegistry.GetInstance().RegisterClass(typeof(AssignedDeviceBean), MockVersionNumber.MOCK_NEWFOUNDLAND);
				MessageBeanRegistry.GetInstance().RegisterClass(typeof(AssignedPersonBean), MockVersionNumber.MOCK_NEWFOUNDLAND);
				MessageBeanRegistry.GetInstance().RegisterClass(typeof(AuthorBean), MockVersionNumber.MOCK_NEWFOUNDLAND);
				MessageBeanRegistry.GetInstance().RegisterClass(typeof(RegistrationRequestBean<>), MockVersionNumber.MOCK_NEWFOUNDLAND);
				MessageBeanRegistry.GetInstance().RegisterClass(typeof(RecordDispenseProcessingRequestMessageBean), MockVersionNumber.MOCK_NEWFOUNDLAND
					);
				MessageBeanRegistry.GetInstance().RegisterClass(typeof(RegistrationControlActEventBean<>), MockVersionNumber.MOCK_NEWFOUNDLAND);
				MessageBeanRegistry.GetInstance().RegisterClass(typeof(QueryControlActEventBean<>), MockVersionNumber.MOCK_NEWFOUNDLAND);
				MessageBeanRegistry.GetInstance().RegisterClass(typeof(Sender), MockVersionNumber.MOCK_NEWFOUNDLAND);
				MessageBeanRegistry.GetInstance().RegisterClass(typeof(ServiceDeliveryLocationBean), MockVersionNumber.MOCK_NEWFOUNDLAND);
				MessageBeanRegistry.GetInstance().RegisterClass(typeof(Receiver), MockVersionNumber.MOCK_NEWFOUNDLAND);
				MessageBeanRegistry.GetInstance().RegisterClass(typeof(QueryByParameterBean<>), MockVersionNumber.MOCK_NEWFOUNDLAND);
				MessageBeanRegistry.GetInstance().RegisterClass(typeof(BeanA), MockVersionNumber.MOCK_NEWFOUNDLAND);
				MessageBeanRegistry.GetInstance().RegisterClass(typeof(BeanB), MockVersionNumber.MOCK_NEWFOUNDLAND);
				MessageBeanRegistry.GetInstance().RegisterClass(typeof(SimpleInteraction), MockVersionNumber.MOCK_NEWFOUNDLAND);
				
				MessageBeanRegistry.GetInstance().RegisterClass(typeof(QuantityObservationEventBean), MockVersionNumber.MOCK_NEWFOUNDLAND);
				MessageBeanRegistry.GetInstance().RegisterClass(typeof(InFulfillmentOfBean), MockVersionNumber.MOCK_MR2009);
				
				initialized = true;
			}
		}
	}
}
