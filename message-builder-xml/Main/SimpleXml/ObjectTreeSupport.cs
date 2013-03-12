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
 * Last modified: $LastChangedDate: 2013-03-01 17:48:17 -0500 (Fri, 01 Mar 2013) $
 * Revision:      $LastChangedRevision: 6663 $
 */

/*****************************************************************************
 *																			 *
 *						  Copyright (c) 2009-2010 Intelliware				 *
 *							  ALL RIGHTS RESERVED							 *
 *																			 *
 *****************************************************************************
 *
 *	File Name:	ObjectTreeSupport.cs
 *
 *	Facility:	.NET SimpleXml library
 *
 *	Purpose:	This module implements ObjectTreeSupport class, which is
 *	            responsible for the logic to compute the XML mappings of
 *	            objects and their fields. 
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
using System.Xml;
using System.Reflection;

namespace Platform.SimpleXml
{
    public class ObjectTreeSupport
    {
        private IDictionary<String, FieldMapping> fieldMappingCache;
        private IDictionary<String, FieldInfo[]> fieldsCache = new Dictionary<String, FieldInfo[]>();
        
        private IDictionary<String, ElementMapping> elemCache;

        /// <summary>
        /// Constructor
        /// </summary>
        public ObjectTreeSupport()
        {
            fieldMappingCache = new Dictionary<String, FieldMapping>();
            elemCache = new Dictionary<String, ElementMapping>();
        }

        /// <summary>
        /// Returns a field mapping object given a FieldInfo object
        /// </summary>
        /// <param name="fi">FieldInfo object representing a field within its container</param>
        /// <param name="cacheKeyValue">Key to be used by field mapping caching</param>
        /// <returns>FieldMapping object if found, otherwise null</returns>
        public FieldMapping GetFieldMapping(FieldInfo fi, String cacheKeyValue)
        {
            FieldMapping desc = null;

            BaseAttribute attr = Helpers.ExtractAttribute(fi);
            if (null != attr)
            {
                String cacheKey = fi.DeclaringType.FullName + "_" + cacheKeyValue;

                if (!fieldMappingCache.TryGetValue(cacheKey, out desc))
                {
                    if (attr is XmlAttributeAttribute)
                    {
                        XmlAttributeAttribute attrAttr = attr as XmlAttributeAttribute;

                        desc = new FieldMapping(NodeType.Attribute);

                        desc.XmlName = null != attrAttr.Name ? attrAttr.Name : fi.Name;
                        desc.Required = attrAttr.Required;
                        desc.ValueType = fi.FieldType;
                        desc.ObjBindingName = fi.Name;
                        desc.FieldInfo = fi;
                    }
                    else if (attr is ElementAttribute)
                    {
                        ElementAttribute elemAttr = attr as ElementAttribute;

                        desc = new FieldMapping(NodeType.Element);
                        desc.XmlName = null != elemAttr.Name ? elemAttr.Name : fi.Name;
                        desc.Required = elemAttr.Required;
                        desc.ValueType = fi.FieldType;
                        desc.ObjBindingName = fi.Name;
                        desc.FieldInfo = fi;
                    }
                    else if (attr is ElementMapAttribute)
                    {
                        ElementMapAttribute mapAttr = attr as ElementMapAttribute;

                        desc = new FieldMapping(NodeType.Map);
                        desc.Inline = mapAttr.Inline;
                        desc.KeyName = mapAttr.Key;
                        desc.ValueType = fi.FieldType;
                        desc.ObjBindingName = fi.Name;
                        desc.FieldInfo = fi;

                        //
                        // Get entry element name.
                        //
                        if (fi.FieldType.IsGenericType)
                        {
                            Type[] gargs = fi.FieldType.GetGenericArguments();
                            desc.MapEntryKeyType = gargs[0];
                            desc.MapEntryValueType = gargs[1];

                            desc.MapEntryXmlName = Helpers.ExtractElementName(desc.MapEntryValueType);
                        }

                        //
                        // Get map element name
                        //
                        if (mapAttr.Inline)
                            desc.XmlName = null != mapAttr.Entry ? mapAttr.Entry : "entry";
                        else
                            desc.XmlName = mapAttr.Name;
                    }
                    else if (attr is ElementListAttribute)
                    {
                        ElementListAttribute listAttr = attr as ElementListAttribute;

                        desc = new FieldMapping(NodeType.List);
                        desc.Inline = listAttr.Inline;
                        desc.ValueType = fi.FieldType;
                        desc.ObjBindingName = fi.Name;
                        desc.FieldInfo = fi;

                        //
                        // Get entry element name.
                        //
                        if (fi.FieldType.IsGenericType)
                        {
                            Type[] gargs = fi.FieldType.GetGenericArguments();
                            desc.MapEntryValueType = gargs[0];

                            //!desc.MapEntryName = Helpers.ExtractElementName(desc.MapEntryValueType);
                        }

                        //
                        // Get list entry name.
                        //
                        if (listAttr.Inline)
                        {
                            String entryName = null != desc.MapEntryValueType ?
                                Helpers.ToCamelCase(desc.MapEntryValueType.Name) : null;

                            desc.XmlName = null != listAttr.Entry ? listAttr.Entry :
                                (null != entryName ? entryName : "entry");
                        }
                        else
                            desc.XmlName = listAttr.Name;
                    }

                    if (desc.XmlName.Equals(cacheKeyValue))
                        fieldMappingCache.Add(cacheKey, desc);
                }
            }

            return desc;
        }

        /// <summary>
        /// Looks up and returns a field mapping object given the containing type and the
        /// XML tag/attribute name within the scope of the containing object
        /// </summary>
        /// <param name="t">The type of the containing object</param>
        /// <param name="xmlName">The XML tag/attribute name within the scope of the
        /// containing object</param>
        /// <returns>FieldMapping object if found, otherwise null</returns>
        public FieldMapping LookupField(Type t, String xmlName)
        {
            FieldMapping res = null;

            String cacheKey = t.FullName + "_" + xmlName;
            if (fieldMappingCache.TryGetValue(cacheKey, out res))
                return res;

            if (null == res)
            {
                FieldInfo[] fis = null;

                if (!fieldsCache.TryGetValue(t.FullName, out fis))
                {
                    fis = t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                    fieldsCache.Add(t.FullName, fis);
                }

                for (int i = 0; i < fis.Length; i++)
                {
                    FieldInfo fi = fis[i];

                    FieldMapping desc = GetFieldMapping(fi, xmlName);
                    if (null == desc)
                        continue;

                    if (String.Equals(xmlName, desc.XmlName))
                    {
                        res = desc;
                        break;
                    }
                }
            }

            return res;
        }

        /// <summary>
        /// Returns an element mapping object representing the specified type
        /// </summary>
        /// <param name="t">Type to return its element mapping</param>
        /// <returns>Element mapping object if found, otherwise null</returns>
        public ElementMapping GetElementMapping(Type t)
        {
            ElementMapping res = null;

            String cacheKey = t.FullName;
            if (!elemCache.TryGetValue(cacheKey, out res))
            {
                ElementMapping em = new ElementMapping();

                em.XmlName = Helpers.ExtractElementName(t);

                FieldInfo[] fis = t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

                for (int i = 0; i < fis.Length; i++)
                {
                    FieldInfo fi = fis[i];

                    FieldMapping desc = GetFieldMapping(fi, fi.Name);
                    if (null == desc)
                        continue;

                    switch (desc.NodeType)
                    {
                        case NodeType.Attribute:
                            em.AddAttribute(desc);

                            break;

                        default:
                            em.AddSubElement(desc);
                            break;
                    }
                }

                elemCache.Add(cacheKey, em);
                res = em;
            }

            return res;
        }
    }
}
