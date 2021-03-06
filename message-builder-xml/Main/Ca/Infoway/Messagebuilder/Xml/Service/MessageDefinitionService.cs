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


/// ---------------------------------------------------------------------------------------------------
///  This file was automatically generated by J2CS Translator (http://j2cstranslator.sourceforge.net/). 
///  Version 1.0.0                                                                                      
/// ---------------------------------------------------------------------------------------------------
 
namespace Ca.Infoway.Messagebuilder.Xml.Service {
	
	using Ca.Infoway.Messagebuilder.Xml;
	using ILOG.J2CsMapping.Collections.Generics;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Runtime.CompilerServices;
	
	/// <summary>
	/// A service for looking up defintions of components of a message.
	/// </summary>
	///
	public interface MessageDefinitionService {

        /// <summary>
        /// Initialize the service. Pre-initializing the service during system
        /// start-up can improve the performance of the first user call to do real work.
        /// </summary>
        void Initialize();
	
		/// <summary>
		/// Get a message part by name and version.
		/// </summary>
		///
		/// <param name="version">- the version</param>
		/// <param name="type">- the type name</param>
		/// <returns>the message part</returns>
		MessagePart GetMessagePart(VersionNumber version, String type);
	
		/// <summary>
		/// Get an interaction by name and version.
		/// </summary>
		///
		/// <param name="version">- the version</param>
		/// <param name="type">- the type name</param>
		/// <returns>the interaction</returns>
		Interaction GetInteraction(VersionNumber version, String type);
	
		/// <summary>
		/// Get all interactions across all versions.
		/// </summary>
		///
		/// <param name="includeDuplicateInteractionsWithChangedBusinessNames">- a flag indicating whether or not to include duplicates</param>
		/// <returns>the interactions</returns>
		IList<Interaction> GetAllInteractions(
				bool includeDuplicateInteractionsWithChangedBusinessNames);
	
		/// <summary>
		/// Get all interactions for a particular version of the specification.
		/// </summary>
		///
		/// <param name="version">- the version</param>
		/// <returns>the interactions</returns>
		IList<Interaction> GetAllInteractions(VersionNumber version);
	
		/// <summary>
		/// Get all the versions known by this service.
		/// </summary>
		///
		/// <returns>the versions</returns>
		ICollection<String> SupportedVersions {
		/// <summary>
		/// Get all the versions known by this service.
		/// </summary>
		///
		/// <returns>the versions</returns>
		  get;
		}
		
	
		/// <summary>
		/// Get all the versions for a particular interaction.
		/// </summary>
		///
		/// <param name="type">- the type name of the interaction</param>
		/// <returns>the versions</returns>
		ICollection<String> GetSupportedVersionsForInteraction(String type);
	
		/// <summary>
		/// Get all the message parts for a particular interaction and version.
		/// </summary>
		///
		/// <param name="interaction">- the interaction</param>
		/// <param name="version">- the version</param>
		/// <returns>- the message parts</returns>
		IDictionary<String, MessagePart> GetAllMessageParts(Interaction interaction,
				VersionNumber version);
	
		/// <summary>
		/// Get all message parts for a specific version.
		/// </summary>
		///
		/// <param name="version">- the version</param>
		/// <returns>the message parts</returns>
		ICollection<MessagePart> GetAllMessageParts(VersionNumber version);

        /// <summary>
        /// Determine if the message set for the given version has been generated for R2 data types.
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        bool IsR2(VersionNumber version);

        /// <summary>
        /// Determine if the message set for the given version defines CDA documents
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        bool IsCda(VersionNumber version);

        /// <summary>
        /// Returns constraints for a given relationship. Null is returned if no constraints are found.
        /// </summary>
        /// <param name="version"></param>
        /// <param name="constrainedType"></param>
        /// <returns>the constraints</returns>
        ConstrainedDatatype GetConstraints(VersionNumber version, string constrainedType);

        /// <summary>
        /// Returns all the schematron test definitions for a specific message set
        /// </summary>
        /// <param name="version"></param>
        /// <returns>the schematron context definitions</returns>
        IList<SchematronContext> GetAllSchematronContexts(VersionNumber version);

        /// <summary>
        /// Returns all the package locations for a specific message set
        /// </summary>
        /// <param name="version"></param>
        /// <returns>the package locations</returns>
        IList<PackageLocation> GetAllPackageLocations(VersionNumber version);
	}}
