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
 * Last modified: $LastChangedDate: 2013-10-04 19:09:29 -0400 (Fri, 04 Oct 2013) $
 * Revision:      $LastChangedRevision: 7938 $
 */

/// ---------------------------------------------------------------------------------------------------
///  This file was automatically generated by J2CS Translator (http://j2cstranslator.sourceforge.net/). 
///  Version 1.0.0                                                                                      
/// ---------------------------------------------------------------------------------------------------
 
namespace Ca.Infoway.Messagebuilder.Terminology.Codeset.Domain {
	
	using Ca.Infoway.Messagebuilder;
	using ILOG.J2CsMapping.Collections.Generics;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Runtime.CompilerServices;
	
	/// <summary>
	/// The Class ValueSet.
	/// </summary>
	///
	public class ValueSet {
	
		public ValueSet() {
			this.vocabularyDomains = Ca.Infoway.Messagebuilder.CollUtils
					.SynchronizedSet(new HashedSet<VocabularyDomain>());
		}
	
		private Int64? id;
		private String name;
        private String version;
        private ILOG.J2CsMapping.Collections.Generics.ISet<VocabularyDomain> vocabularyDomains;
	
		/// <summary>
		/// Sets the id.
		/// </summary>
		///
		/// <param name="id_0">the new id</param>
		public Int64? Id {
		/// <summary>
		/// Gets the id.
		/// </summary>
		///
		/// <returns>the id</returns>
		  get {
				return this.id;
			}
		/// <summary>
		/// Sets the id.
		/// </summary>
		///
		/// <param name="id_0">the new id</param>
		  set {
				this.id = value;
			}
		}
		
	
		/// <summary>
		/// Sets the name.
		/// </summary>
		///
		/// <param name="name_0">the new name</param>
		public String Name {
		/// <summary>
		/// The name of the value set.
		/// </summary>
		///
		/// <returns>the name</returns>
		  get {
				return this.name;
			}
		/// <summary>
		/// Sets the name.
		/// </summary>
		///
		/// <param name="name_0">the new name</param>
		  set {
				this.name = value;
			}
		}

        /// <summary>
        /// Sets the version.
        /// </summary>
        ///
        /// <param name="name_0">the new version</param>
        public String Version
        {
            /// <summary>
            /// The version of the value set.
            /// </summary>
            ///
            /// <returns>the version</returns>
            get
            {
                return this.version;
            }
            /// <summary>
            /// Sets the version.
            /// </summary>
            ///
            /// <param name="name_0">the new version</param>
            set
            {
                this.version = value;
            }
        }
	
		/// <summary>
		/// Sets the vocabulary domains.
		/// </summary>
		///
		/// <param name="vocabularyDomains_0">the new vocabulary domains</param>
        public ILOG.J2CsMapping.Collections.Generics.ISet<VocabularyDomain> VocabularyDomains
        {
		/// <summary>
		/// Gets the vocabulary domains.
		/// </summary>
		///
		/// <returns>the vocabulary domains</returns>
		  get {
				return this.vocabularyDomains;
			}
		/// <summary>
		/// Sets the vocabulary domains.
		/// </summary>
		///
		/// <param name="vocabularyDomains_0">the new vocabulary domains</param>
		  set {
				this.vocabularyDomains = value;
			}
		}
		
	}
}
