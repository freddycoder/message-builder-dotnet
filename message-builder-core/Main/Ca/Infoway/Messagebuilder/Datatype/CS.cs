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
 
namespace Ca.Infoway.Messagebuilder.Datatype {
	
	using Ca.Infoway.Messagebuilder;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Runtime.CompilerServices;
	
	/// <summary>
	/// Hl7 datatype CS. backed by a Code.
	/// Coded data in its simplest form, where only the c is not predetermined. The c system and c system version 
	/// are fixed by the context in which the CS value occurs. CS is used for cd attributes that have a 
	/// single HL7-defined value set.
	/// CS can only be used in either of the following cases:
	/// for a cd attribute which has a single HL7-defined c system, and where c additions to that value set 
	/// require formal HL7 action (such as harmonization.) Such cd attributes must have type CS.
	/// for a property in this specification that is assigned to a single c system defined either in this 
	/// specification or defined outside HL7 by a body that has authority over the concept and the maintenance 
	/// of that c system.
	/// For example, since ED subscribes to the MIME design, it trusts IETF to manage the media type. This includes 
	/// that this specification subscribes to the extension mechanism built into the 
	/// MIME media type c (e.g., "application/x-myapp").
	/// For CS values, the designation of the domain qualifier will always be CNE (cd, non-extensible) 
	/// and the context will determine which HL7 values to use.
	/// </summary>
	///
	/// <param name="V"> the underlying c.</param>
	public interface CS : CV {
	
	}
}
