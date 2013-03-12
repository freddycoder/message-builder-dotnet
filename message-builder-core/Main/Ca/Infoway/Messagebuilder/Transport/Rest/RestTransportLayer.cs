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
using System.IO;
using System.Net;
using System.Text;
using Ca.Infoway.Messagebuilder.J5goodies;
using log4net;


namespace Ca.Infoway.Messagebuilder.Transport.Rest
{

    /// <summary>Implementation of a transport layer for REST (Representational State Transfer).</summary>
    /// <remarks>
    /// Implementation of a transport layer for REST (Representational State Transfer).
    /// REST is one of two common interfaces for HL7 messages. HL7 messages are POSTed to an HTTP server.
    /// Makes use of Apache Commons HttpClient for communication.
    /// </remarks>
    /// <author>
    /// <a href="http://www.intelliware.ca/">Intelliware Development</a>
    /// sharpen.ignore - transport - TBD!
    /// </author>
    public class RestTransportLayer : TransportLayer
    {
        internal class StandardHttpClient : Client
        {
            public virtual int ExecuteMethod(PostMethod method)
            {
                var request = (HttpWebRequest)WebRequest.Create(method.Uri);

                request.Method = "POST";
                request.ContentType = method.MimeType;
                request.ContentLength = method.Content.Length;

                if (!String.IsNullOrEmpty(method.UserName))
                {
                    request.Credentials = new NetworkCredential(method.UserName, String.IsNullOrEmpty(method.Password) ? String.Empty : method.Password);
                }

                var requestStream = request.GetRequestStream();

                requestStream.Write(method.Content, 0, method.Content.Length);
                requestStream.Flush();
                requestStream.Close();

                try
                {
                    method.Response = (HttpWebResponse)request.GetResponse();

                }
                catch (WebException ex)
                {
                    //.NET throws if the server answers with a 500 status code
                    if (ex.Response != null)
                    {
                        method.Response = (HttpWebResponse)ex.Response;
                    }
                    else
                    {
                        throw;
                    }
                }

                return (int)method.Response.StatusCode;

            }
        }

        private Client client;
        private string url;
        private ILog log = LogManager.GetLogger(typeof(RestTransportLayer));

        /// <summary>Constructs a REST transport layer for the given url.</summary>
        /// <remarks>Constructs a REST transport layer for the given url. Makes use of the default tranport mechanism (HttpClient)
        /// 	</remarks>
        /// <param name="url">the target url to send messages to</param>
        public RestTransportLayer(string url)
            : this(new StandardHttpClient(), url)
        {
        }

        /// <summary>Constructs a REST transport layer for the given url.</summary>
        /// <remarks>Constructs a REST transport layer for the given url. Makes use of provided client instead of the default HttpClient.
        /// 	</remarks>
        /// <param name="client">the transport client to use</param>
        /// <param name="url">the target url to send messages to</param>
        public RestTransportLayer(Client client, string url)
        {
            this.client = client;
            this.url = url;
        }

        /// <summary>Sends a request message synchronously and returns a response message as a string.</summary>
        /// <remarks>Sends a request message synchronously and returns a response message as a string.</remarks>
        /// <param name="credentialsProvider">object to obtain Credentials from</param>
        /// <param name="requestMessage">the message to be sent</param>
        /// <returns>the response message as a string</returns>
        public virtual string SendRequestAndGetResponse(CredentialsProvider credentialsProvider, RequestMessage requestMessage)
        {
            try
            {
                return PostMessage(credentialsProvider, requestMessage);
            }
            catch (IOException e)
            {
                throw new TransportLayerException(e);
            }
        }

        private string PostMessage(CredentialsProvider credentialsProvider, RequestMessage requestMessage)
        {
            bool repeat;
            int repeatCount = 0;
            string result = null;
            int statusCode;

            do
            {
                repeat = false;

                var method = CreatePostMethod();

                method.Content = Encoding.Default.GetBytes(requestMessage.GetMessageAsString());

                statusCode = client.ExecuteMethod(method);

                if (statusCode == (int)HttpStatusCode.Unauthorized)
                {
                    log.Info("Authorization required.  Now prompting for userid/password");
                    repeat = HandleCredentials(credentialsProvider, method);
                }
                else
                {
                    if (IsOk(statusCode))
                    {
                        result = method.GetResponseBodyAsString();
                    }
                    else
                    {
                        log.Warn("Status code " + statusCode + " received from server");
                    }
                }

            }
            while (repeat && ++repeatCount < 3);

            if (!IsOk(statusCode))
            {
                throw new HttpTransportLayerException(statusCode);
            }

            return result;
        }

        protected virtual PostMethod CreatePostMethod()
        {
            var method = new PostMethod(url) { MimeType = MimeTypes.XML, Charset = "UTF-8" };

            method.MimeType = MimeTypes.XML;
            method.Charset = "UTF-8";

            return new PostMethod(url);
        }

        private static bool HandleCredentials(CredentialsProvider credentialProvider, PostMethod postMethod)
        {
            var credentials = (UsernamePasswordCredentials)credentialProvider.GetCredentials();

            if (credentials != null)
            {
                postMethod.UserName = credentials.GetUsername();
                postMethod.Password = credentials.GetPassword();
            }

            return credentials != null;
        }

        private static bool IsOk(int statusCode)
        {
            return statusCode == 200;// HttpStatus.SC_OK;
        }
    }

}
