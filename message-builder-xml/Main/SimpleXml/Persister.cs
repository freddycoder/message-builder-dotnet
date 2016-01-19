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

namespace Platform.SimpleXml
{
    public class Persister : Serializer
    {
        #region Serializer Members

        /// <summary>
        /// Reads specified XML file into an object graph with specified
        /// type as its root.
        /// </summary>
        /// <param name="type">Type of root object</param>
        /// <param name="fi">FileInfo object describing the file</param>
        /// <returns>Read object, or null if an error occurs</returns>
        public object Read(Type type, System.IO.FileInfo fi)
        {
            ObjectTreeXmlReader otxr = new ObjectTreeXmlReader();
            return otxr.Read(type, fi);
        }

        /// <summary>
        /// Reads specified XML stream into an object graph with specified
        /// type as its root.
        /// </summary>
        /// <param name="type">Type of root object</param>
        /// <param name="s">Input stream object (caller is responsible for closing the stream)</param>
        /// <returns>Read object or null if an error occurs </returns>
        public object Read(Type type, System.IO.Stream s)
        {
            Object res = null;

            ObjectTreeXmlReader otxr = new ObjectTreeXmlReader();
            res = otxr.Read(type, s);

            return res;
        }

        /// <summary>
        /// Serializes object graph with specified root object into XML and
        /// writes it to the specified output stream
        /// </summary>
        /// <param name="domain">Root object</param>
        /// <param name="s">Output stream (caller is responsible for closing the stream)</param>
        public void Write(object domain, System.IO.Stream s)
        {
            ObjectTreeXmlWriter otxw = new ObjectTreeXmlWriter();
            otxw.Write(domain, s);
        }

        /// <summary>
        /// Serializes object graph with specified root object into XML and
        /// writes it to the specified file
        /// </summary>
        /// <param name="domain">Root object</param>
        /// <param name="fi">Output file</param>
        public void Write(object domain, System.IO.FileInfo fi)
        {
            ObjectTreeXmlWriter otxw = new ObjectTreeXmlWriter();
            otxw.Write(domain, fi);
        }

        #endregion
    }
}
