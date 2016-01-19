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
 *	File Name:	FieldMapping.cs
 *
 *	Facility:	.NET SimpleXml library
 *
 *	Purpose:	This module implements FieldMapping class which encapsulates
 *	            field's containment information to aid in the serialization
 *	            of objects
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

namespace Platform.SimpleXml
{
    /// <summary>
    /// Defines list of node types
    /// </summary>
    public enum NodeType : short
    {
        Attribute   = 0, // Represents an XML attribute
        Element     = 1, // Represents an XML element
        Map         = 2, // Represents an XML key based list of elements
        List        = 3, // Represents an XML list of elements
    };

    /// <summary>
    /// Encapsulates mapping information for a field within its container. Note
    /// that the whole purpose of this class is to cache mapping related information.
    /// </summary>
    public class FieldMapping
    {
        public NodeType     NodeType;           // Type of node
        public String       XmlName;            // Xml node name
        public bool         Required;           // Whether required
        public bool         Inline;             // Whether inline (applies to collections)

        public String       ObjBindingName;     // Field name
        public Type         ValueType;          // Value data type

        public FieldInfo    FieldInfo;          // FieldInfo describing the field

        public String       KeyName;            // XML Attribute name containing the key (for maps)
        public Type         MapEntryKeyType;    // Map entry key data type
        public Type         MapEntryValueType;  // Map/list entry data type
        public String       MapEntryXmlName;    // Xml node name for map/list entry

        //
        // Value setter object (FieldInfo, PropertyInfo, or MethodInfo)
        //
        public Object       ValueSetter;
        public Type         ValueSetType;       // Type to convert to before setting the value

        //
        // Value getter object (FieldInfo, PropertyInfo, or MethodInfo)
        //
        public Object       ValueGetter;
        public Type         ValueGetType;       // Type to convert from before using the value //! is this needed
        public Object       KeyValueGetter;     // Reflection based accessor to get the value of the key into a map (if applicable)

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="nodeType"></param>
        public FieldMapping(NodeType nodeType)
        {
            this.NodeType = nodeType;
        }
    }
}
