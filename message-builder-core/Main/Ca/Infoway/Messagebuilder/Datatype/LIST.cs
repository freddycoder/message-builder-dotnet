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
	
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Runtime.CompilerServices;
	
	/// <summary>
	/// HL7 datatype LIST. Backed by a   List.
	/// Used when multiple repetitions are allowed and order matters.
	/// </summary>
	///
	/// <param name="T"> the HL7 datatype held by the LIST</param>
	/// <param name="V"> the underlying   datatype held by the underlying   List</param>
    public interface LIST<T, V> : COLLECTION<T>  where T : ANY<V> {
	
		/// <summary>
		/// Returns the underlying   List containing values in the underlying   datatype.
		/// </summary>
		///
		/// <returns>the underlying   List containing values in the underlying   datatype</returns>
		IList<V> RawList();
		
		IList<U> RawList<U>() where U : V;
		
	}
}
