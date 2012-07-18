/**
 * Copyright 2012 Canada Health Infoway, Inc.
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
using Ca.Infoway.Messagebuilder.Transport.Mohawk.Sample;
using Ca.Infoway.Messagebuilder.Util.Xml;
using NUnit.Framework;
using Platform.Xml.Sax;


namespace Ca.Infoway.Messagebuilder.Transport.Mohawk
{
    /// <summary>sharpen.ignore - test - translated manually.</summary>
    /// <remarks>sharpen.ignore - test - translated manually.</remarks>
    [TestFixture]
    public class MohawkTransportLayerTest
    {
        private static readonly string TRIVIAL_MESSAGE = "<REPC_IN000012CA xmlns=\"urn:hl7-org:v3\" ></REPC_IN000012CA>";

        private Client client;
        private MohawkTransportLayer transport;


        [SetUp]
        public virtual void SetUp()
        {
            client = new MohawkTransportLayer.StandardHttpClient();
            transport = new MohawkTransportLayer(client, "http://142.222.45.132:8080/soap/hl7/v3/ca/v2.04.2/Service.svc");

        }

        [Test]
        public virtual void ShouldMapToCorrectService()
        {
            var method = transport.CreatePostMethod(SimpleRequestMessage.Create("<REPC_IN000012CA></REPC_IN000012CA>"));

            Assert.AreEqual(new Uri("http://142.222.45.132:8080/soap/hl7/v3/ca/v2.04.2/Service.svc/", true), method.Uri, "url");
        }

        [Test]
        public virtual void ShouldWrapInSoapEnvelope()
        {
            byte[] soapEnvelope = 
                transport.WrapInSoapEnvelope(
                new DocumentFactory().CreateFromString(TRIVIAL_MESSAGE), 
                new ServiceDefinition ("/blah/", "myAction"));

            string xml = System.Text.Encoding.ASCII.GetString(soapEnvelope);

            Assert.IsTrue(xml.Contains("Body"), xml);
            AssertIsValidXml(soapEnvelope);
        }


        [Test]
        [Ignore]
        public virtual void ShouldRun()
        {
            var transportLayer = new MohawkTransportLayer();

            var credentialsProvider = new _CredentialsProvider_35();

            var requestMessage 
                = SimpleRequestMessage.Create(new DocumentFactory().CreateFromStream(Platform.ResourceLoader.GetResource
                (typeof(MohawkSender), "findCandidatesQuery.xml")));

            string response = transportLayer.SendRequestAndGetResponse(credentialsProvider, requestMessage);

            Console.Out.WriteLine(response);
        }

        private static void AssertIsValidXml(byte[] soapEnvelope)
        {
            try
            {
                new DocumentFactory().CreateFromByteArray(soapEnvelope);
            }
            catch (SAXException e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        [ExpectedException(typeof(HttpTransportLayerException))]
		//[Category("failing-in-nant")]
        public virtual void ShouldThrowExceptionOnBadState()
        {
            transport.SendRequestAndGetResponse(null, SimpleRequestMessage.Create("<REPC_IN000012CA></REPC_IN000012CA>"));
        }



        private sealed class _CredentialsProvider_35 : CredentialsProvider
        {
            public _CredentialsProvider_35()
            {
            }

            public Credentials GetCredentials()
            {
                return new UsernamePasswordCredentials("username", "password");
            }
        }
    }

}
