/*****************************************************************************
 *																			 *
 *						  Copyright (c) 2009-2010 Intelliware				 *
 *							  ALL RIGHTS RESERVED							 *
 *																			 *
 *****************************************************************************
 *
 *	File Name:	Persister.cs
 *
 *	Facility:	.NET SimpleXml library
 *
 *	Purpose:	This module implements Persister class, which is the default
 *	            implementation of the Serializer interface
 *              
 *              This is the equivalent of SimpleXml's Persister class
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
    public class Persister : Serializer
    {
        #region Serializer Members

        /// <summary>
        /// Reads specified XML file into an object graph with specified
        /// type as its root.
        /// </summary>
        /// <param name="type">Type of root object</param>
        /// <param name="fi">FileInfo object describing the file</param>
        /// <returns>Read object, or null if an error occurs</returns>
        public object Read(Type type, System.IO.FileInfo fi)
        {
            ObjectTreeXmlReader otxr = new ObjectTreeXmlReader();
            return otxr.Read(type, fi);
        }

        /// <summary>
        /// Reads specified XML stream into an object graph with specified
        /// type as its root.
        /// </summary>
        /// <param name="type">Type of root object</param>
        /// <param name="s">Input stream object (caller is responsible for closing the stream)</param>
        /// <returns>Read object or null if an error occurs </returns>
        public object Read(Type type, System.IO.Stream s)
        {
            Object res = null;

            ObjectTreeXmlReader otxr = new ObjectTreeXmlReader();
            res = otxr.Read(type, s);

            return res;
        }

        /// <summary>
        /// Serializes object graph with specified root object into XML and
        /// writes it to the specified output stream
        /// </summary>
        /// <param name="domain">Root object</param>
        /// <param name="s">Output stream (caller is responsible for closing the stream)</param>
        public void Write(object domain, System.IO.Stream s)
        {
            ObjectTreeXmlWriter otxw = new ObjectTreeXmlWriter();
            otxw.Write(domain, s);
        }

        /// <summary>
        /// Serializes object graph with specified root object into XML and
        /// writes it to the specified file
        /// </summary>
        /// <param name="domain">Root object</param>
        /// <param name="fi">Output file</param>
        public void Write(object domain, System.IO.FileInfo fi)
        {
            ObjectTreeXmlWriter otxw = new ObjectTreeXmlWriter();
            otxw.Write(domain, fi);
        }

        #endregion
    }
}
