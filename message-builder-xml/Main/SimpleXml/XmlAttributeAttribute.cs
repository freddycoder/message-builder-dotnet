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
 *	File Name:	XmlAttributeAttribute.cs
 *
 *	Facility:	.NET SimpleXml library
 *
 *	Purpose:	This module implements XmlAttributeAttribute, which marks a
 *              field as being an XML attribute.
 *              
 *              This is the equivalent of SimpleXml's @Attribute
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
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public class XmlAttributeAttribute : BaseAttribute
    {
        /// <summary>
        /// The name of the XML attribute. Can be null, in which case the
        /// name will be extracted from the data type (class name, or name specified
        /// by its [Root] attribute).
        /// </summary>
        private String  name;

        //
        // Note the following are just to have the full list of arguments. The current
        // serialization handling of them is described below.
        //

        /// <summary>
        /// Whether required. Note that this value is currently ignored by the serialization
        /// </summary>
        private bool    required;

        /// <summary>
        /// Value to write when the object mapped to the attribute does not have a value.
        /// Currently ignored by serialization logic.
        /// </summary>
        private String  empty;

        /// <summary>
        /// Gets or sets the name of the entity
        /// </summary>
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Gets or sets whether entity is required
        /// </summary>
        public bool Required
        {
            get { return required; }
            set { required = value; }
        }

        /// <summary>
        /// Gets or sets value to be written when entity is null
        /// </summary>
        public String Empty
        {
            get { return empty; }
            set { empty = value; }
        }
    }
}
