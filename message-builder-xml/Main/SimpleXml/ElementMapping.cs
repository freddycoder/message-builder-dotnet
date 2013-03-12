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
 *	File Name:	ElementMapping.cs
 *
 *	Facility:	.NET SimpleXml library
 *
 *	Purpose:	This module implements ElementMapping class, which encapsulates
 *	            mapping information for entities used by the writing process.
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

namespace Platform.SimpleXml
{
    public class ElementMapping
    {
        public String               XmlName;        // XML tag name

        public List<FieldMapping>   Attributes;     // Attribute mappings
        public List<FieldMapping>   SubElements;    // Sub element mappings

        /// <summary>
        /// Adds an attribute mapping
        /// </summary>
        /// <param name="attr"></param>
        public void AddAttribute(FieldMapping attr)
        {
            if (null == Attributes)
                Attributes = new List<FieldMapping>();

            Attributes.Add(attr);
        }

        /// <summary>
        /// Adds a sub element mapping
        /// </summary>
        /// <param name="subElem"></param>
        public void AddSubElement(FieldMapping subElem)
        {
            if (null == SubElements)
                SubElements = new List<FieldMapping>();

            SubElements.Add(subElem);
        }
    }
}
