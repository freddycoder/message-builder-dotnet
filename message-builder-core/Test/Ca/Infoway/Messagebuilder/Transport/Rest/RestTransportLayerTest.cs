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
 * Last modified: $LastChangedDate: 2011-05-17 11:48:36 -0400 (Tue, 17 May 2011) $
 * Revision:      $LastChangedRevision: 2666 $
 */

using System;
using NUnit.Framework;


namespace Ca.Infoway.Messagebuilder.Transport.Rest
{
    /// <summary>sharpen.ignore - test - translated manually.</summary>
    /// <remarks>sharpen.ignore - test - translated manually.</remarks>
    [TestFixture]
    public class RestTransportLayerTest
    {

        private RestTransportLayer rest;
        private Client client;
        private CredentialsProvider provider;

        [SetUp]
        public virtual void SetUp()
        {
            client = new RestTransportLayer.StandardHttpClient();
            provider = new TrivialCredentialsProvider(new UsernamePasswordCredentials("ag", "ag"));
            //rest = new RestTransportLayer(client, "http://panacea.intelliware.ca:8080/rest");
            rest = new RestTransportLayer(client, "http://tl7.intelliware.ca/rest");
        }

        [Test]
        public virtual void ShouldSendBasicMessageToServer()
        {
            var result = rest.SendRequestAndGetResponse(provider, CreateMessage());

            Console.WriteLine(result);
        }

        private RequestMessage CreateMessage()
        {
            return SimpleRequestMessage.Create("<myXml></myXml>");
        }

        [Test] [Ignore]
        public virtual void TestShouldThrowExceptionOnServerError()
        {
            try
            {
                rest.SendRequestAndGetResponse(provider, CreateMessage());
                Assert.Fail("expected exception");
            }
            catch (HttpTransportLayerException e)
            {
                Assert.IsTrue(e.Message.Contains("500"), e.Message);
            }
        }

        [Test]
        public virtual void TestShouldRequestUseridAndPassword()
        {
            rest.SendRequestAndGetResponse(provider, CreateMessage());
        }

        [Test] [Ignore]
        public virtual void TestShouldRethrowHttpExceptions()
        {
            try
            {
                rest.SendRequestAndGetResponse(provider, CreateMessage());
                Assert.Fail("expected exception");
            }
            catch (TransportLayerException)
            {
            }
        }

    }

}
