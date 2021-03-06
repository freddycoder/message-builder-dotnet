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
 
namespace Ca.Infoway.Messagebuilder.Datatype.Lang {
	
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Runtime.CompilerServices;
	
	/// <summary>
	/// Parenthetic Set Expression (SXPR) specializes SXCM
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-SXPR
	/// Definition: A set-component that is itself made up of set-components that are
	/// evaluated as one value.
	/// There must be at least 2 component elements.
	/// </summary>
	///
	/// <param name="T"> the underlying   datatype</param>
	public class ParentheticSetExpr<T> : SetComponent<T> {
	
		public static readonly String COMPONENT = "comp";
	
		private IList<SetComponent<T>> components;
	
		/// <summary>
		/// Constructs an empty ParentheticSetExpr.
		/// </summary>
		///
		public ParentheticSetExpr() {
			this.components = new List<SetComponent<T>>();
		}
	
		/// <summary>
		/// Constructs a ParentheticSetExpr given ths supplied parameters.
		/// </summary>
		///
		/// <param name="components_0">a list of SetComponents</param>
		public ParentheticSetExpr(IList<SetComponent<T>> components_0) {
			this.components = new List<SetComponent<T>>();
			this.components = components_0;
		}
	
		/// <summary>
		/// Constructs a ParentheticSetExpr given ths supplied parameters.
		/// </summary>
		///
		/// <param name="component1">a list of SetComponents</param>
		/// <param name="component2">a list of SetComponents</param>
		public ParentheticSetExpr(SetComponent<T> component1,
				SetComponent<T> component2) {
			this.components = new List<SetComponent<T>>();
			ILOG.J2CsMapping.Collections.Generics.Collections.Add(this.components,component1);
			ILOG.J2CsMapping.Collections.Generics.Collections.Add(this.components,component2);
		}
	
		/// <summary>
		/// Obtains the list of SetComponents.
		/// </summary>
		///
		/// <returns>the list of SetComponents</returns>
		public IList<SetComponent<T>> Components {
		/// <summary>
		/// Obtains the list of SetComponents.
		/// </summary>
		///
		/// <returns>the list of SetComponents</returns>
		  get {
				return components;
			}
		}
		
	}
}
