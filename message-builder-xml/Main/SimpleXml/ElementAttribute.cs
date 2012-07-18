/*****************************************************************************
 *																			 *
 *						  Copyright (c) 2009-2010 Intelliware				 *
 *							  ALL RIGHTS RESERVED							 *
 *																			 *
 *****************************************************************************
 *
 *	File Name:	ElementAttribute.cs
 *
 *	Facility:	.NET SimpleXml library
 *
 *	Purpose:	This module implements ElementAttribute, which marks a
 *              field as being an XML elements.
 *              
 *              This is the equivalent of SimpleXml's @Element
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
    public class ElementAttribute : BaseAttribute
    {
        /// <summary>
        /// The name of the XML tag for the element. Can be null, in which case the
        /// name will be extracted from the data type (class name, or name specified
        /// by its [Root] attribute).
        /// </summary>
        private String  name;
		
		private bool data;

        //
        // Note the following are just to have the full list of arguments. The current
        // serialization handling of them is described below.
        //

        /// <summary>
        /// Whether required. Note that this value is currently ignored by the serialization
        /// </summary>
        private bool    required;

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
		
        public bool Data
        {
            get { return data; }
            set { data = value; }
        }
    }
}
