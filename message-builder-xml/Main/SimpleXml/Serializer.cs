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
 *	File Name:	Serializer.cs
 *
 *	Facility:	.NET SimpleXml library
 *
 *	Purpose:	This module defines Serializer interface, which defines the
 *	            list of methods to be implemented by classes that wish to
 *	            handle XML serialization as being defined by SimpleXml
 *	            framework.
 *              
 *              This is the equivalent of SimpleXml's Serializer interface
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

namespace Platform.SimpleXml
{
    public interface Serializer
    {
        /// <summary>
        /// Reads specified XML file into an object graph with specified
        /// type as its root.
        /// </summary>
        /// <param name="type">Type of root object</param>
        /// <param name="fi">FileInfo object describing the file</param>
        /// <returns>Read object, or null if an error occurs</returns>
        Object Read(Type type, FileInfo fi);

        /// <summary>
        /// Reads specified XML stream into an object graph with specified
        /// type as its root.
        /// </summary>
        /// <param name="type">Type of root object</param>
        /// <param name="s">Input stream object</param>
        /// <returns>Read object, or null if an error occurs</returns>
        Object Read(Type type, Stream s);

        /// <summary>
        /// Serializes object graph with specified root object into XML and
        /// writes it to the specified output stream
        /// </summary>
        /// <param name="domain">Root object</param>
        /// <param name="s">Output stream</param>
        void Write(Object domain, Stream s);

        /// <summary>
        /// Serializes object graph with specified root object into XML and
        /// writes it to the specified file
        /// </summary>
        /// <param name="domain">Root object</param>
        /// <param name="fi">Output file</param>
        void Write(Object domain, FileInfo fi);
    }
}
