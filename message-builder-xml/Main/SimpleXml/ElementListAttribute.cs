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
 * Last modified: $LastChangedDate: 2012-01-18 21:44:35 -0500 (Wed, 18 Jan 2012) $
 * Revision:      $LastChangedRevision: 4352 $
 */

/*****************************************************************************
 *																			 *
 *						  Copyright (c) 2009-2010 Intelliware				 *
 *							  ALL RIGHTS RESERVED							 *
 *																			 *
 *****************************************************************************
 *
 *	File Name:	ElementListAttribute.cs
 *
 *	Facility:	.NET SimpleXml library
 *
 *	Purpose:	This module implements ElementListAttribute, which marks a
 *              field as being a list of XML elements.
 *              
 *              This is the equivalent of SimpleXml's @ElementList
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
    public class ElementListAttribute : BaseAttribute
    {
        /// <summary>
        /// Name of each element. Used only when inline is false
        /// </summary>
        private String  name;

        /// <summary>
        /// Name of each element. Can be null, in which case the name will be extracted
        /// from the value type (class name, or name specified by its [Root] attribute).
        /// </summary>
        private String  entry;

        //
        // Note the following are just to have the full list of arguments. The current
        // serialization handling of them is described below.
        //

        /// <summary>
        /// Whether required. Note that this value is currently ignored by the serialization
        /// </summary>
        private bool    required;

        /// <summary>
        /// Whether the list is inline. Note that only inline lists are properly supported,
        /// an attempt has been made to handle non inline ones but hasn't been tested or
        /// verified.
        /// </summary>
        private bool    inline;

        /// <summary>
        /// Gets or sets the name of the entity
        /// </summary>
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public String Entry
        {
            get { return entry; }
            set { entry = value; }
        }

        /// <summary>
        /// Gets or sets whether entity is required
        /// </summary>
        public bool Required
        {
            get { return required; }
            set { required = value; }
        }

        public bool Inline
        {
            get { return inline; }
            set { inline = value; }
        }
    }
}
