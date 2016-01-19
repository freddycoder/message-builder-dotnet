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


/*****************************************************************************
 *																			 *
 *						  Copyright (c) 2009-2010 Intelliware				 *
 *							  ALL RIGHTS RESERVED							 *
 *																			 *
 *****************************************************************************
 *
 *	File Name:	ObjectTreeXmlWriter.cs
 *
 *	Facility:	.NET SimpleXml library
 *
 *	Purpose:	This module implements ObjectTreeXmlWriter class, which is
 *	            responsible for the logic to write an object graph to an
 *	            XML file/stream.
 *              
 *	Author:		Fadel Al-Jaifi, Affinity Systems
 *
 *	Revision History
 *
 *	Date		Author				Description
 *	-------		------------------	-----------------------------------------
 *	Apr10		Fadel Al-Jaifi		Original version
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Xml;

namespace Platform.SimpleXml
{
    public class ObjectTreeXmlWriter
    {
        ObjectTreeSupport ots;  // Object tree support object

        /// <summary>
        /// Constructor
        /// </summary>
        public ObjectTreeXmlWriter()
        {
            ots = new ObjectTreeSupport();
        }

        /// <summary>
        /// Processes a dictionary object, by writing all its key based elements
        /// </summary>
        /// <typeparam name="TA">Type of key within the dictionary</typeparam>
        /// <typeparam name="TB">Type of value within the dictionary</typeparam>
        /// <param name="dict">Dictionary object</param>
        /// <param name="dictMapping">Field mapping describing the dictionary itself within its containing object</param>
        /// <param name="writer">XmlWriter object</param>
        private void ProcessDictElements<TA, TB>(IDictionary<TA, TB> dict, FieldMapping dictMapping, XmlWriter writer)
        {
            foreach (TA key in dict.Keys)
            {
                TB entry = dict[key];

                writer.WriteStartElement(dictMapping.XmlName); // Entry tag

                String mapKeyValue = key.ToString();
                writer.WriteAttributeString(dictMapping.KeyName, mapKeyValue); // Write key attribute

                Write(entry, null, writer, dictMapping.MapEntryXmlName); // Write the entry

                writer.WriteEndElement(); // Close entry tag
            }
        }

        /// <summary>
        /// Processes a list object, by writing all its elements
        /// </summary>
        /// <typeparam name="TA">Type of value within the list</typeparam>
        /// <param name="list">List object</param>
        /// <param name="listMapping">Field mapping describing the list itself within its containing object</param>
        /// <param name="writer">XmlWriter object</param>
        private void ProcessListElements<TA>(IList<TA> list, FieldMapping listMapping, XmlWriter writer)
        {
            foreach (TA entry in list)
                Write(entry, null, writer, listMapping.XmlName);
        }

        /// <summary>
        /// Writes out those fields of specified object that are mapped to XML attributes
        /// </summary>
        /// <param name="obj">Object to write its attributes</param>
        /// <param name="em">Element mapping of the object</param>
        /// <param name="writer">XmlWriter object</param>
        private void WriteAttributes(Object obj, ElementMapping em, XmlWriter writer)
        {
            Type objType = obj.GetType();

            for (int i = 0, length = null != em.Attributes ? em.Attributes.Count : 0; i < length; i++)
            {
                FieldMapping fm = em.Attributes[i];
                Object value = Helpers.GetFieldValue(fm, objType, obj, typeof(String));

                if (null != value)
                {
                    String strValue = value.ToString();
                    writer.WriteAttributeString(fm.XmlName, strValue);
                }
            }
        }

        /// <summary>
        /// Writes out the specified object. This method writes the element for the object, and
        /// recursively writes out all attributes and sub elements.
        /// </summary>
        /// <param name="obj">Object to write</param>
        /// <param name="fm">Field mapping of the object within its containing object (optional).
        /// When provided, the logic will use it to determine whether element is to be "inline"'d,
        /// in which case the logic will not write an outer tag for it. Also the XmlName field of the
        /// mapping will take precedence in determining the tag name over the name mentioned in
        /// the element mapping.
        /// </param>
        /// <param name="writer">XmlWriter object</param>
        /// <param name="tagName">Specifies the tag name to use for the object (optional). This
        /// parameter can be used to override what the tag name that the logic would normally use,
        /// it is mainly to be used when writing collections, since the name of each entry's tag
        /// can be customized at the collection declaration level (e.g. via [ElementMap] or
        /// [ElemenList] attributes). When this parameter is set to null, the logic will get the
        /// name from either the field mapping object (if provided) or from the element mapping object.
        /// </param>
        private void Write(Object obj, FieldMapping fm, XmlWriter writer, String tagName)
        {
            Type objType = obj.GetType();

            ElementMapping em = ots.GetElementMapping(objType);
            if (null == em)
                throw new ArgumentException("Don;t know how to handle this object", objType.ToString());
            
            String xmlName = tagName; // Allow caller to override tag name
            
            //
            // If the tag name was not overriden by the caller, then it would be the name
            // specified by the mapping in the elment's container, if not specified then
            // it is the name as specified by the element mapping.
            //
            if (null == xmlName) // Tag name not provided, use the one in field mapping
                xmlName = null != fm ? fm.XmlName : em.XmlName;

            //
            // For nodes that are marked as inline, we don't write a tag for them.
            //
            bool inline = null != fm ? fm.Inline : false;

            if (!inline)
            {
                writer.WriteStartElement(xmlName); // Start of element
                WriteAttributes(obj, em, writer); // Write attributes
            }

            int i = 0, length = length = null != em.SubElements ? em.SubElements.Count : 0;

            //
            // If the element has no sub-elements, we treat it as a leaf node so we write its
            // body value. Note that we do the XML encoding ourselves because XmlWriter
            // implementation does not encode single or double quotes within the body of a tag,
            // but SimpleXml framework does.
            //
            if (0 == length)
                writer.WriteRaw(Helpers.XmlEncode(obj.ToString()));
            else // Otherwise, drill down the object
            {
                //
                // Write sub elements.
                //
                for (i = 0; i < length; i++)
                {
                    FieldMapping subMapping = em.SubElements[i];
                    Object value = null;

                    switch (subMapping.NodeType)
                    {
                        case NodeType.Element:
                            value = Helpers.GetFieldValue(subMapping, objType, obj, subMapping.ValueType);

                            if (null != value)
                                Write(value, subMapping, writer, null); // Drill down

                            break;

                        case NodeType.Map:
                            {
                                //
                                // Note that we assume that map based fields are using an IDictionary
                                // based object, with its key being of type String.
                                //

                                value = Helpers.GetFieldValue(subMapping, objType, obj, subMapping.ValueType);

                                if (null != value)
                                {
                                    Type gt = typeof(IDictionary<,>);

                                    if (null != value.GetType().GetInterface("IDictionary`2"))
                                    {
                                        MethodInfo mi = this.GetType().GetMethod("ProcessDictElements",
                                            BindingFlags.NonPublic | BindingFlags.Instance);

                                        MethodInfo si = mi.MakeGenericMethod(value.GetType().GetGenericArguments());
                                        si.Invoke(this, new Object[] { value, subMapping, writer });
                                    }
                                }

                                break;
                            }

                        case NodeType.List:
                            {
                                //
                                // Note that we assume that list based fields are using an IList based object.
                                //

                                value = Helpers.GetFieldValue(subMapping, objType, obj, subMapping.ValueType);
                                if (null != value)
                                {
                                    Type gt = typeof(IList<>);

                                    if (null != value.GetType().GetInterface("IList`1"))
                                    {
                                        MethodInfo mi = this.GetType().GetMethod("ProcessListElements",
                                            BindingFlags.NonPublic | BindingFlags.Instance);

                                        MethodInfo si = mi.MakeGenericMethod(value.GetType().GetGenericArguments());
                                        si.Invoke(this, new Object[] { value, subMapping, writer });
                                    }
                                }

                                break;
                            }
                    }

                }
            }

            if (!inline)
                writer.WriteEndElement(); // End of element

        }

        /// <summary>
        /// The file based entry point to the writer
        /// </summary>
        /// <param name="rootObj">Root object</param>
        /// <param name="fi"></param>
        public void Write(Object rootObj, FileInfo fi)
        {
            FileStream fs = null;

            try
            {
                fs = fi.OpenWrite();
                Write(rootObj, fs);
            }
            finally
            {
                if (null != fs)
                    fs.Close();
            }
        }

        /// <summary>
        /// The file based entry point to the writer
        /// </summary>
        /// <param name="rootObj">Root object</param>
        /// <param name="s">Output stream (note that caller is responsible for closing the stream)</param>
        public void Write(Object rootObj, Stream s)
        {
            XmlWriterSettings xws = new XmlWriterSettings();
            xws.CloseOutput = true;
            xws.Indent = true;
            xws.OmitXmlDeclaration = true;
            xws.IndentChars = "   ";
            xws.CheckCharacters = false;
            xws.Encoding = Encoding.UTF8;

            using (XmlWriter writer = XmlWriter.Create(s, xws))
            {
                Write(rootObj, null, writer, null);
            }
        }
    }
}
