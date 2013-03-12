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
 * Last modified: $LastChangedDate: 2011-05-17 11:48:36 -0400 (Tue, 17 May 2011) $
 * Revision:      $LastChangedRevision: 2666 $
 */

/// ---------------------------------------------------------------------------------------------------
///  This file was automatically generated by J2CS Translator (http://j2cstranslator.sourceforge.net/). 
///  Version 1.0.0                                                                                      
/// ---------------------------------------------------------------------------------------------------
 
namespace Ca.Infoway.Messagebuilder.Datatype {
	
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Runtime.CompilerServices;
	
	/// <summary>
	/// TEL HL7 datatype.
	/// Represents CeRx's notion of a telecommunication address, such as a phone
	/// number, fax, email or http address.
	/// There are several parts to an tel address, but HL7 has dumped all the relevant 
	/// information into a single text field. Urp.
	/// The first part is the URL scheme. This is something like tel: or http:. CeRx limits 
	/// these based on the subclass of TEL (TEL.PHONEMAIL or TEL.URI).
	/// There are some number of uses for each address. CeRx limits this to three, which is
	/// not enforced by this class. For the TEL.URI subclass, use is not permitted at all.
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-TEL
	/// </summary>
	///
	public interface TEL : URL {
	
		// TODO - Datatype - TM/AG - useablePeriod not currently supported
	
	}
}
