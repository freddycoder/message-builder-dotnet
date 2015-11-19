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
 
namespace Ca.Infoway.Messagebuilder.Util.Telephone {
	
	using Ca.Infoway.Messagebuilder;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Runtime.CompilerServices;
	using System.Text;
	
	
	public class Telephone {
	
		private static readonly String EXTENSION_DELIMITER = ";ext=";
		private static readonly String DELIMITER = "-";
		private static readonly String PREFIX = "+1-";
	
		private String areaCode;
		private TelephoneLocalNumber phoneNumber;
		private String extension;
	
		public Telephone() {
			this.phoneNumber = new TelephoneLocalNumber();
		}
	
		public Telephone(String areaCode_0, TelephoneLocalNumber phoneNumber_1) {
			this.phoneNumber = new TelephoneLocalNumber();
			this.areaCode = areaCode_0;
			this.phoneNumber = phoneNumber_1;
		}
	
		
		public String AreaCode {
		  get {
				return this.areaCode;
			}
		  set {
				this.areaCode = value;
			}
		}
		
	
		
		public String Extension {
		  get {
				return this.extension;
			}
		  set {
				this.extension = value;
			}
		}
		
	
		
		public TelephoneLocalNumber PhoneNumber {
		  get {
				return this.phoneNumber;
			}
		  set {
				this.phoneNumber = value;
			}
		}
		
	
		
		public String Hl7FormattedPhoneNumber {
		  get {
				StringBuilder builder = new StringBuilder();
				if (Ca.Infoway.Messagebuilder.StringUtils.IsNotBlank(this.areaCode)) {
					builder.Append(PREFIX).Append(this.areaCode).Append(DELIMITER);
				}
				if (this.phoneNumber != null
						&& Ca.Infoway.Messagebuilder.StringUtils.IsNotBlank(this.phoneNumber.FormattedTelephoneNumber)) {
					builder.Append(this.phoneNumber.FormattedTelephoneNumber);
				}
				if (Ca.Infoway.Messagebuilder.StringUtils.IsNotBlank(this.extension)) {
					builder.Append(EXTENSION_DELIMITER).Append(this.extension);
				}
				return builder.ToString();
			}
		}
		
	
	}
}
