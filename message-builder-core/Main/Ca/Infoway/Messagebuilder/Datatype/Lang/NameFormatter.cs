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
	
	using Ca.Infoway.Messagebuilder;
	using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
    using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Runtime.CompilerServices;
	using System.Text;
	
	/// <summary>
	/// An abstract formatter for PersonName. Contains an inner class implementation. 
	/// </summary>
	///
	public abstract class NameFormatter {
	
		/// <summary>
		/// A simple name formatter for formatting a PersonName.
		/// </summary>
		///
		internal class SimpleNameFormatterImpl : NameFormatter {
	
			/// <summary>
			/// Formats a PersonName into a string. Format of first name first, followed by all family names, all separated by a space. 
			/// </summary>
			///
			/// <param name="name">the PersonName to format</param>
			/// <returns>the formatted name</returns>
			public override String Format(PersonName name) {
				StringBuilder builder = new StringBuilder();
				EntityNamePart first = GetFirstGivenName(name);
				if (first != null) {
					Append(builder, first);
				}
				/* foreach */
				foreach (EntityNamePart part  in  FilterParts(name, PersonNamePartType.FAMILY)) {
					Append(builder, part);
				}
				return builder.ToString();
			}
	
			public void Append(StringBuilder builder, EntityNamePart first) {
				if (builder.Length > 0) {
					builder.Append(" ");
				}
				builder.Append(StringUtils.TrimToEmpty(first.Value));
			}
		}
	
		/// <summary>
		/// Formats a PersonName into a string.
		/// </summary>
		///
		/// <param name="name">the PersonName to format</param>
		/// <returns>the formatted name</returns>
		public abstract String Format(PersonName name);
	
		protected internal EntityNamePart GetFirstGivenName(PersonName name) {
			return GetFirstPart(name, PersonNamePartType.GIVEN);
		}
	
		private EntityNamePart GetFirstPart(PersonName name, PersonNamePartType type) {
			IList<EntityNamePart> parts = FilterParts(name, type);
			return (CollUtils.IsEmpty(parts)) ? null : parts[0];
		}
	
		protected internal IList<EntityNamePart> FilterParts(PersonName name, PersonNamePartType type) {
			IList<EntityNamePart> result = new List<EntityNamePart>();
			/* foreach */
            foreach (EntityNamePart part in Ca.Infoway.Messagebuilder.Util.Iterator.EmptyIterable<EntityNamePart>.NullSafeIterable((name == null) ? null : name.Parts))
            {
				if ((Object) part.Type == (Object) type) {
					ILOG.J2CsMapping.Collections.Generics.Collections.Add(result,part);
				}
			}
			return result;
		}
	
		/// <summary>
		/// Standard (static) access to SimpleName Formatter.
		/// </summary>
		///
		/// <returns>a simple name formatter</returns>
		public static NameFormatter SimpleNameFormatter {
		/// <summary>
		/// Standard (static) access to SimpleName Formatter.
		/// </summary>
		///
		/// <returns>a simple name formatter</returns>
		  get {
				return new NameFormatter.SimpleNameFormatterImpl();
			}
		}
		
	}
}