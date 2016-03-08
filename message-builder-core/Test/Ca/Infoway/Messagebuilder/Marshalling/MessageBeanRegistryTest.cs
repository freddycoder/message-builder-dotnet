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


using System;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
    [TestFixture]
    public class MessageBeanRegistryTest
    {
        // DummyClass is in message-builder-test-assembly 

        public static MessageDescription CR     = new MessageDescription("DummyClass", "PRPA_IN10110XXX");
        public static MessageDescription CERX = new MessageDescription("DummyClass", "PORX_IN02019XXX");
        public static MessageDescription COMMON = new MessageDescription("DummyClass", "MCCI_IN00000XXX");

        [Test] [Ignore]
        public void shouldFindMessageBeanType() 
        {
            // NOTE: MessageBeanRegistry will look into assemblies deployed in the same folder as the app

            // I've copied the assembly 'message-builder-test-assembly.dll' product of the message-builder-test-assembly project to 
            // this project's /bin/Debug/ folder so MessageBeanRegistry will load it from there and this test passes.
            // A different approach probably will be needed in the build server

            var messageDescriptions = new[] { CR, CERX, COMMON };

            var messageBeanRegistry = MessageBeanRegistry.GetInstance();
                    
            foreach (var description in messageDescriptions)
            {
                var interactionBeanType = 
                    messageBeanRegistry.GetInteractionBeanType(new MessageTypeKey(MockVersionNumber.MOCK_NEWFOUNDLAND, description.getInteractionId()));

                Assert.AreEqual(description.getMessageType(), interactionBeanType.Name, "type");
            }
        }
    }

    public class MessageDescription
    {
        private String messageType;
        private String interactionId;

        public MessageDescription(String messageType, String interactionId)
        {
            this.messageType = messageType;
            this.interactionId = interactionId;
        }
        public String getMessageType()
        {
            return this.messageType;
        }
        public String getInteractionId()
        {
            return this.interactionId;
        }
    }


}

