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
 
namespace Ca.Infoway.Messagebuilder.Datatype.Impl {
	
	using Ca.Infoway.Messagebuilder.Datatype;
	using Ca.Infoway.Messagebuilder.Datatype.Lang;
	using Ca.Infoway.Messagebuilder.Domainvalue;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Runtime.CompilerServices;
	
	/// <summary>
	/// Parenthetic Set Expression (SXPR) specializes SXCM. Backed by the   datatype ParentheticSetExpr.
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-SXPR
	/// Definition: A set-component that is itself made up of set-components that are
	/// evaluated as one value.
	/// There must be at least 2 component elements.
	/// </summary>
	///
	/// <param name="T"> the underlying   datatype</param>
	public class SXPRImpl<T> : ANYImpl<ParentheticSetExpr<T>>, 		SXPR<T> {
	
		/// <summary>
		/// Constructs an empty SXPR. 
		/// </summary>
		///
		/* @SuppressWarnings("unchecked")*/
		public SXPRImpl() : this((ParentheticSetExpr<T>)null) {
		}
	
		/// <summary>
		/// Constructs an SXPR with the given initial value.
		/// </summary>
		///
		/// <param name="defaultValue">the initial value</param>
		public SXPRImpl(ParentheticSetExpr<T> defaultValue) : base(typeof(ParentheticSetExpr<T>), defaultValue, null, Ca.Infoway.Messagebuilder.Datatype.StandardDataType.SXPR) {
		}
	
		/// <summary>
		/// Constructs an SXPR with the supplied null flavor.  
		/// </summary>
		///
		/// <param name="nullFlavor">a null flavor</param>
		public SXPRImpl(NullFlavor nullFlavor) : base(typeof(ParentheticSetExpr<T>), null, nullFlavor, Ca.Infoway.Messagebuilder.Datatype.StandardDataType.SXPR) {
		}
	
	}
}
