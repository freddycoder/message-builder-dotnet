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
using System.IO;
using System.Reflection;
using System.Xml;

namespace Platform.SimpleXml
{
    public class ObjectTreeXmlReader
    {
        private ObjectTreeSupport ots;  // Tree support object

        /// <summary>
        /// Constructor
        /// </summary>
        public ObjectTreeXmlReader()
        {
            ots = new ObjectTreeSupport();
        }

        /// <summary>
        /// Instantiates an instance of specified type
        /// </summary>
        /// <param name="t">Type to instantiate the instance from</param>
        /// <returns>Instantiated instance</returns>
        private Object InstantiateObject(Type t)
        {
            return Activator.CreateInstance(t);
        }

        /// <summary>
        /// Populates those field of the specified object that are mapped to XML attributes
        /// </summary>
        /// <param name="t">Type of object</param>
        /// <param name="inst">Object to populate</param>
        /// <param name="reader">XmlReader to read from</param>
        private void PopulateAttributes(Type t, Object inst, XmlReader reader)
        {
            int i = -1;

            for (i = 0; i < reader.AttributeCount; i++)
            {
                reader.MoveToAttribute(i);

                FieldMapping desc = ots.LookupField(t, reader.Name);
                if (null != desc)
                    Helpers.SetFieldValue(desc, reader.Value, t, inst);
            }

            if (i >= 0)
                reader.MoveToElement();
        }

        /// <summary>
        /// Reads and returns an object of specified type from specified XmlReader. This
        /// method instantiates an object of specified type, and recursively populates
        /// its fields from attributes and sub elements.
        /// </summary>
        /// <param name="t">Type of object</param>
        /// <param name="r">XmlReader object</param>
        /// <returns>The read object</returns>
        public Object Read(Type t, XmlReader r)
        {
            using (XmlReader reader = r.ReadSubtree())
            {
                reader.Read();

                //
                // We assume reader is positioned on the XML element for the specified type
                //
                Object res = InstantiateObject(t);

                PopulateAttributes(t, res, reader); // Populate from attributes if any
                
                //
                // This variable is used in the situations when we read the content
                // of a node, in which case the pointer has already been advanced to
                // the next node so there's no need to call Read().
                //
                bool dontAdvance = false;
                while (dontAdvance || reader.Read())
                {
                    dontAdvance = false; // Clear the flag

                    if (reader.NodeType == XmlNodeType.EndElement || reader.NodeType == XmlNodeType.Text)
                        continue;

                    FieldMapping desc = ots.LookupField(t, reader.Name);
                    if (null == desc)
                    {
                        //Console.WriteLine(string.Format("{0} skipped. within type: {1}", reader.Name, t.ToString()));

                        reader.Skip();
                        continue; // Skip ones we don't care for
                    }

                    Object fieldValue = null;

                    switch (desc.NodeType)
                    {
                        case NodeType.Element:

                            if (Helpers.IsSerializable(desc.FieldInfo.FieldType))
                                fieldValue = Read(desc.FieldInfo.FieldType, reader);
                            else
                            {
                                fieldValue = reader.ReadElementContentAsString();
                                dontAdvance = true;
                            }

                            Helpers.SetFieldValue(desc, fieldValue, t, res);
                            break;

                        case NodeType.Map:

                            //
                            // Ensure we have a dictionary instance.
                            //
                            Object dict = desc.FieldInfo.GetValue(res);
                            if (null == dict)
                            {
                                Type t1 = typeof(Dictionary<,>);
                                Type[] args = { desc.MapEntryKeyType, desc.MapEntryValueType };

                                Type t2 = t1.MakeGenericType(args);

                                dict = Activator.CreateInstance(t2);

                                Helpers.SetFieldValue(desc.ObjBindingName, dict, t, res);
                            }

                            String key = reader.GetAttribute(desc.KeyName); // Get the key

                            //
                            // Get the entry value
                            //
                            fieldValue = null;

                            if (reader.ReadToDescendant(desc.MapEntryXmlName))
                            {
                                if (Helpers.IsSerializable(desc.MapEntryValueType))
                                    fieldValue = Read(desc.MapEntryValueType, reader);
                                else
                                {
                                    fieldValue = reader.ReadElementContentAsString();
                                    dontAdvance = true;
                                }
                                
                                if (null != fieldValue)
                                {
                                    MethodInfo mi = desc.ValueType.GetMethod("Add");
                                    mi.Invoke(dict, new Object[] { key, fieldValue });
                                }
                            }

                            break;

                        case NodeType.List:

                            //
                            // Ensure we have a dictionary instance.
                            //
                            Object list = desc.FieldInfo.GetValue(res);
                            if (null == list)
                            {
                                Type t1 = typeof(List<>);
                                Type[] args = { desc.MapEntryValueType };

                                Type t2 = t1.MakeGenericType(args);

                                list = Activator.CreateInstance(t2);

                                Helpers.SetFieldValue(desc.ObjBindingName, list, t, res);
                            }
						
                            //
                            // Get the entry value
                            //
                            fieldValue = null;

                            if (Helpers.IsSerializable(desc.MapEntryValueType))
                                fieldValue = Read(desc.MapEntryValueType, reader);
                            else
                            {
                                fieldValue = reader.ReadElementContentAsString();
                                dontAdvance = true;
                            }
                            
                            if (null != fieldValue)
                            {
                                MethodInfo mi = list.GetType().GetMethod("Add");
                                mi.Invoke(list, new Object[] { fieldValue });
                            }

                            break;
                    }
                }

                return res;
            }
        }

        /// <summary>
        /// The file based entry point method to the reader
        /// </summary>
        /// <param name="rootType">The type of the root object to populate from the XML file</param>
        /// <param name="fi">FileInfo object describing the file</param>
        /// <returns>Read object, or null if an error occurs</returns>
        public Object Read(Type rootType, FileInfo fi)
        {
            Object res = null;
            FileStream fs = null;

            try
            {
                fs = fi.OpenRead();
                res = Read(rootType, fs);
            }
            finally
            {
                if (null != fs)
                    fs.Close();
            }

            return res;
        }

        /// <summary>
        /// The file based entry point method to the reader
        /// </summary>
        /// <param name="rootType">The type of the root object to populate from the XML file</param>
        /// <param name="s">Input stream (note that caller is responsible for closing the stream)</param>
        /// <returns>Read object, or null if an error occurs</returns>
        public Object Read(Type rootType, Stream s)
        {
            Object res = null;

            XmlReaderSettings xrs = new XmlReaderSettings();
            xrs.IgnoreComments = true;
            xrs.IgnoreWhitespace = true;
            xrs.ValidationType = ValidationType.None;

            using (XmlReader reader = XmlReader.Create(s, xrs))
            {
                String name = Helpers.ExtractElementName(rootType);
                if (reader.ReadToFollowing(name))
                {
                    using (XmlReader r = reader.ReadSubtree())
                    {
                        if (r.Read())
                            res = Read(rootType, r);
                    }
                }
            }

            return res;
        }
    }
}
