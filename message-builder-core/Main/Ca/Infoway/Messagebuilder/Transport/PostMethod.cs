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
using System.IO;
using System.Net;

namespace Ca.Infoway.Messagebuilder.Transport
{
    public class PostMethod
    {
        public PostMethod(string uri)
        {
            Uri = uri;
        }

        public string MimeType { get; set; }

        public byte[] Content { get; set; }

        public string Uri { get; set; }

        public HttpWebResponse Response { get; set; }

        public string Charset { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string GetResponseBodyAsString()
        {
            var streamReader = new StreamReader(Response.GetResponseStream());

            return streamReader.ReadToEnd();
        }
    }
}
