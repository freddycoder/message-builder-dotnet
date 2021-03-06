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
 * Author:        $LastChangedBy: jmis $
 * Last modified: $LastChangedDate: 2015-05-27 08:43:37 -0400 (Wed, 27 May 2015) $
 * Revision:      $LastChangedRevision: 9535 $
 */

/// ---------------------------------------------------------------------------------------------------
///  This file was automatically generated by J2CS Translator (http://j2cstranslator.sourceforge.net/). 
///  Version 1.0.0                                                                                      
/// ---------------------------------------------------------------------------------------------------
 
namespace Ca.Infoway.Messagebuilder.Terminology.Codeset {
	
	using Ca.Infoway.Messagebuilder;
	using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Resolver;
	using Ca.Infoway.Messagebuilder.Terminology;
	using Ca.Infoway.Messagebuilder.Terminology.Codeset.Dao;
	using Ca.Infoway.Messagebuilder.Terminology.Codeset.Domain;
	using Ca.Infoway.Messagebuilder.Terminology.Proxy;
	using ILOG.J2CsMapping.Collections.Generics;
	using System;
	using System.Collections;
	using System.Collections.Generic;
//	using System.ComponentModel;
	using System.Runtime.CompilerServices;
	
	/// <summary>
	/// Knows how to provide database-backed Codes.
	/// </summary>
	///
	public class DatabaseCodeResolver : CodeResolver {
	
		private readonly CodeSetDao dao;
		private readonly TypedCodeFactory codeFactory;
        private readonly String version;
	
		/// <summary>
		/// Instantiates a new database c resolver.
		/// </summary>
		///
		/// <param name="dao_0">the dao</param>
		/// <param name="codeFactory_1">the c factory</param>
		public DatabaseCodeResolver(CodeSetDao dao_0, TypedCodeFactory codeFactory_1, String version_2) {
			this.dao = dao_0;
			this.codeFactory = codeFactory_1;
            this.version = version_2;
		}

        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        ///
        public virtual T Lookup<T>(Type type, String code) where T : Code {
            return Lookup<T>(type, code, true);
        }
	
		/// <summary>
		/// {@inheritDoc}
		/// </summary>
		///
		public virtual T Lookup<T>(Type type, String code, bool ignoreCase)  where T : Code {
			IList<ValueSetEntry> codedValues = dao.SelectValueSetsByCode(type, code, this.version, ignoreCase);
			return ((codedValues.Count==0)) ?  default(T)/* was: null */ : this.CreateCode<T>(type, codedValues[0]);
		}

        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        ///
        public virtual T Lookup<T>(Type type, String code, String codeSystemOid) where T : Code {
            return Lookup<T>(type, code, codeSystemOid, true);
        }

		/// <summary>
		/// {@inheritDoc}
		/// </summary>
		///
		public virtual T Lookup<T>(Type type, String code, String codeSystemOid, bool ignoreCase)  where T : Code {
            // RM 15390 (and others) - TM: The lookup won't work if no code system is provided.
            // An argument could be made that if this method is called then we should expect the code system to be valid,
            // but let's err on the side of caution and do our best to find a matching code.
            if (StringUtils.IsBlank(codeSystemOid))
            {
                return this.Lookup<T>(type, code, ignoreCase);
            }
            else
            {
                ValueSetEntry valueSet = this.dao.FindValueByCodeSystem(type, code, codeSystemOid, this.version, ignoreCase);
                return (valueSet == null) ? default(T)/* was: null */ : this.CreateCode<T>(type, valueSet);
            }
		}
	
		/// <summary>
		/// {@inheritDoc}
		/// </summary>
		///
        [Obsolete]
		public virtual ICollection<T> Lookup<T>(Type type)  where T : Code {
			IList<ValueSetEntry> values = dao
					.SelectValueSetsByVocabularyDomain(type, this.version);
			return this.ConvertValuesToCodes<T>(type, values);
		}
	
		private ICollection<T> ConvertValuesToCodes<T>(Type type,
				IList<ValueSetEntry> values)  where T : Code {
			IList<T> result = new List<T>();
			/* foreach */
			foreach (ValueSetEntry valueSet  in  values) {
				ILOG.J2CsMapping.Collections.Generics.Collections.Add(result,this.CreateCode<T>(type, valueSet));
			}
			return result;
		}
	
		internal  T CreateCode<T>(Type type, ValueSetEntry value_ren)  where T : Code {
			return this.CreateCode<T>(type, value_ren.CodedValue,
					GetImplementedTypes(value_ren));
		}

        private ILOG.J2CsMapping.Collections.Generics.ISet<Type> GetImplementedTypes(ValueSetEntry value_ren)
        {
            ILOG.J2CsMapping.Collections.Generics.ISet<Type> typeList = new HashedSet<Type>();
			ICollection<VocabularyDomain> vocabularyDomains = value_ren.ValueSet.VocabularyDomains;
			/* foreach */
			foreach (VocabularyDomain vocabularyDomain  in  vocabularyDomains) {
                Type typeAsClass = vocabularyDomain.GetTypeAsClass(this.version);
                if (typeAsClass != null) {
                    typeList.Add(typeAsClass);
                }
			}
			return typeList;
		}
	
		private T CreateCode<T>(Type type, CodedValue value_ren,
                ILOG.J2CsMapping.Collections.Generics.ISet<Type> implementedTypes) where T : Code
        {
            IDictionary<String, String> displayTextMap = new Dictionary<String, String>();
            displayTextMap.AddAll(value_ren.Descriptions);
            return type.Cast<T>(this.codeFactory.Create(type, implementedTypes, value_ren.Code, value_ren.CodeSystem.Oid,
                value_ren.CodeSystem.Name, displayTextMap, 1, true, true));
		}
    }
}
