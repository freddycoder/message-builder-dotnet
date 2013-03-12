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
 * Last modified: $LastChangedDate: 2011-09-21 11:11:24 -0400 (Wed, 21 Sep 2011) $
 * Revision:      $LastChangedRevision: 3001 $
 */

/// ---------------------------------------------------------------------------------------------------
///  This file was automatically generated by J2CS Translator (http://j2cstranslator.sourceforge.net/). 
///  Version 1.0.0                                                                                      
/// ---------------------------------------------------------------------------------------------------
 
namespace Ca.Infoway.Messagebuilder.Datatype.Lang {

    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Domainvalue.Basic;
    using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Runtime.CompilerServices;
	
	/// <summary>
	///   datatype for HL7 encapsulated string.
	/// </summary>
	///
	public class EncapsulatedString : EncapsulatedData {
	
		private readonly String text;
	
		/// <summary>
		/// Constructs an EcapsulatedString from the given text. 
		/// </summary>
		///
		/// <param name="text_0">the initial text</param>
		public EncapsulatedString(String text_0) {
			this.text = text_0;
		}
	
		/// <summary>
		/// Returns this encapsulated string's content as a string.
		/// </summary>
		///
		/// <returns>the content as a string</returns>
		public String ContentAsString {
		/// <summary>
		/// Returns this encapsulated string's content as a string.
		/// </summary>
		///
		/// <returns>the content as a string</returns>
		  get {
				return this.text;
			}
		}
		
	
		/// <summary>
		/// Returns the content as an array of bytes.
		/// </summary>
		///
		/// <returns>the content as an array of bytes</returns>
		public override byte[] Content {
		/// <summary>
		/// Returns the content as an array of bytes.
		/// </summary>
		///
		/// <returns>the content as an array of bytes</returns>
		  get {
				return (this.text == null) ? null : ILOG.J2CsMapping.Util.StringUtil.GetBytes(this.text);
			}
		}
		
	
		/// <summary>
		/// Returns this object's media type. In this case, it is always plain text.
		/// </summary>
		///
		/// <returns>the media type</returns>
		public override x_DocumentMediaType MediaType {
		/// <summary>
		/// Returns this object's media type. In this case, it is always plain text.
		/// </summary>
		///
		/// <returns>the media type</returns>
		  get {
				return X_DocumentMediaType.PLAIN_TEXT;
			}
		}
		
	}
}
