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

namespace Ca.Infoway.Messagebuilder.Domainvalue.Basic
{
	
	using Ca.Infoway.Messagebuilder;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Runtime.CompilerServices;
	using System.Runtime.Serialization;
	
	/// <summary>
	/// The cerx AD.Basic states that the country is a SC data type (meaning that the c is optional but the text description is always manadatory){@link Code} can not model this type. In the future we may want to handle this type? 
	/// For now we are just using the text description directly and ignoring any iso3166-alpha2 c that may be present.
	/// </summary>
	///
	[Serializable]
	public class Country : Ca.Infoway.Messagebuilder.Domainvalue.Country {
	
		private const long serialVersionUID = 407008735068117828L;
	
		/// <summary>
		/// Canada.
		/// </summary>
		///
		public static readonly Country CANADA = new Country("CA", "Canada");
		/// <summary>
		/// United States.
		/// </summary>
		///
		public static readonly Country USA = new Country("US",
				"United States of America");
	
		private readonly String code;
		private readonly String name;
	
		/// <summary>
		/// Constructs a Country using  the supplied parameters.
		/// </summary>
		///
		/// <param name="code_0">a c</param>
		/// <param name="name_1">a name</param>
		public Country(String code_0, String name_1) {
			this.code = code_0;
			this.name = name_1;
		}
	
		/// <summary>
		/// Returns the country c.
		/// </summary>
		///
		/// <returns>the c</returns>
		public String Code {
		/// <summary>
		/// Returns the country c.
		/// </summary>
		///
		/// <returns>the c</returns>
		  get {
				return this.code;
			}
		}
		
	
		/// <summary>
		/// Returns the name.
		/// </summary>
		///
		/// <returns>the name</returns>
		public String Name {
		/// <summary>
		/// Returns the name.
		/// </summary>
		///
		/// <returns>the name</returns>
		  get {
				return this.name;
			}
		}
		
	
		/// <summary>
		/// Returns the c value.
		/// </summary>
		///
		/// <returns>the c value</returns>
		public virtual String CodeValue {
		/// <summary>
		/// Returns the c value.
		/// </summary>
		///
		/// <returns>the c value</returns>
		  get {
				// arguably we could use code here, but code is an optional attribute in the XML
				return this.name;
			}
		}
		
	
		/// <summary>
		/// Returns the csystem as an empty string.
		/// </summary>
		///
		/// <returns>the csystem as an empty string</returns>
		public virtual String CodeSystem {
		/// <summary>
		/// Returns the csystem as an empty string.
		/// </summary>
		///
		/// <returns>the csystem as an empty string</returns>
		  get {
				return "";
			}
		}

		public virtual String CodeSystemName {
            get { return null; }
        }
	
		/// <summary>
		/// Returns the country applicable for the country c.
		/// </summary>
		///
		/// <param name="countryCode">the country c</param>
		/// <returns>the country applicable for the country c</returns>
		public static Country ResolveCountry(String countryCode) {
			return (Country.CANADA.Code.Equals(countryCode)) ? Country.CANADA
					: null;
		}
	
		/// <summary>
		/// Returns the country applicable for the country name (Canada only!).
		/// </summary>
		///
		/// <param name="countryName">the country name</param>
		/// <returns>the country applicable for the country name (Canada only!)</returns>
		public static String ResolveCountryCode(String countryName) {
			return (Country.CANADA.Name.Equals(countryName,StringComparison.InvariantCultureIgnoreCase)) ? Country.CANADA.Code
					: null;
		}
	}}
