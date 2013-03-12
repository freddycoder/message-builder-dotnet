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
 
namespace Ca.Infoway.Messagebuilder.Terminology {
	
	using Ca.Infoway.Messagebuilder;
	using Ca.Infoway.Messagebuilder.Domainvalue;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Reflection;
	using System.Runtime.CompilerServices;
	
	/// <summary>
	/// A c resolver to look up cs for c types registered against enums.
	/// </summary>
	///
	internal class EnumPatternCodeResolver : CodeResolverImpl {
	
		/// <summary>
		/// {@inheritDoc}
		/// </summary>
		///
		public override T Lookup<T>(Type type, String code) /* where T : Code */ {
			if (code == null) {
				return  default(T)/* was: null */;
			} else if (!type.IsInterface) {
				return (T) LookupClass<T>(type, code);
			} else {
				return  default(T)/* was: null */;
			}
		}
	
		/// <summary>
		/// {@inheritDoc}enum pattern c resolver doesn't understand c system
		/// </summary>
		///
		public override T Lookup<T>(Type type, String code, String codeSystemOid) /* where T : Code */ {
			return this.Lookup<T>(type, code);
		}
	
		/// <summary>
		/// Lookup.
		/// enum pattern c resolver doesn't understand null flavor
		/// </summary>
		///
		/// <param name="T"> the generic type</param>
		/// <param name="type">the type</param>
		/// <param name="nullFlavor">the null flavor</param>
		/// <returns>the t</returns>
		public T Lookup<T>(Type type, NullFlavor nullFlavor)  where T : Code {
			return  default(T)/* was: null */;
		}
	
		/* @SuppressWarnings("unchecked")*/
		private static T LookupClass<T>(Type type, String code)  where T : Code {
			FieldInfo[] fields = type.GetFields();
			T result =  default(T)/* was: null */;
			for (int i = 0, length = (fields == null) ? 0 : fields.Length; i < length; i++) {
				if (IsPseudoEnumConstant(type, fields[i])) {
					Code obj0 = GetValue(fields[i]);
					if (obj0.CodeValue.Equals(code)) {
						result = (T) obj0;
						break;
					}
				}
			}
			return result;
		}
	
		private static Code GetValue(FieldInfo field) {
			try {
				return (Code) field.GetValue(null);
			} catch (ArgumentException e) {
				return null;
			} catch (MemberAccessException e_0) {
				return null;
			}
		}
	
		private static bool IsPseudoEnumConstant(Type type,
				FieldInfo field) {
			if (!ILOG.J2CsMapping.Reflect.IlrModifier.IsPublic(new ILOG.J2CsMapping.Reflect.IlrModifier(field).GetModifiers())) {
				return false;
			} else if (!ILOG.J2CsMapping.Reflect.IlrModifier.IsStatic(new ILOG.J2CsMapping.Reflect.IlrModifier(field).GetModifiers())) {
				return false;
			} else if (!type.IsAssignableFrom(field.FieldType)) {
				return false;
			} else {
				return true;
			}
		}
	}
}
