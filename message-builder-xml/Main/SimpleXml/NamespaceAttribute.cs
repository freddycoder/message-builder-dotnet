/*****************************************************************************
 *																			 *
 *						  Copyright (c) 2009-2010 Intelliware				 *
 *							  ALL RIGHTS RESERVED							 *
 *																			 *
 *****************************************************************************
 *
 *	File Name:	RootAttribute.cs
 *
 *	Facility:	.NET SimpleXml library
 *
 *	Purpose:	This module implements RootAttribute, which marks a class as
 *              being an XML element.
 *              
 *              This is the equivalent of SimpleXml's @Root
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
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field, Inherited=false, AllowMultiple=false)]
    public class NamespaceAttribute : BaseAttribute
    {
        /// <summary>
        /// Name of the element, can be used to override the element name that otherwise
        /// will be the type name.
        /// </summary>
        private String  prefix;
		
        private String  reference;

        public String Prefix
        {
            get { return prefix; }
            set { prefix = value; }
        }
		
        public String Reference
        {
            get { return reference; }
            set { reference = value; }
        }
    }
}
