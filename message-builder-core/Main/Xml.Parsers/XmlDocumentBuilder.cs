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
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Platform.Xml.Sax;
using System.IO;

namespace Platform.Xml.Parsers
{
    public class XmlDocumentBuilder
    {
        private XmlEntityResolver           entityResolver;
        private XmlDocumentBuilderFactory   factory;

        internal XmlDocumentBuilder(XmlDocumentBuilderFactory factory)
        {
            this.factory = factory;
        }

        public XmlDocument Parse(FileInfo fi)
        {
            FileStream fileStream = fi.OpenRead();
            try
            {
                return Parse(fileStream);
            }
            finally
            {
                fileStream.Close();
            }
        }

        public XmlDocument Parse(Stream s)
        {
            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            doc.Load(s); //! How are we handling exceptions?

            return doc;
        }


        public XmlDocument Parse(XmlReader reader)
        {
            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            doc.Load(reader); //! How are we handling exceptions?

            return doc;
        }

        public bool isNamespaceAware()
        {
            return factory.NamespaceAware;
        }

        public bool isValidating()
        {
            return factory.Validating;
        }

        public void SetEntityResolver(XmlEntityResolver entityResolver)
        {
            this.entityResolver = entityResolver;
        }

        /*[Obsolete("not yet implemented")]
        public void setErrorHandler(ErrorHandler eh)
        {
            throw new NotImplementedException();
        }*/

        public XmlDocument NewDocument()
        {
            return new XmlDocument();
        }
    }
}
