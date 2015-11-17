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
 * Author:        $LastChangedBy: jroberts $
 * Last modified: $LastChangedDate: 2015-01-30 14:20:12 -0500 (Fri, 30 Jan 2015) $
 * Revision:      $LastChangedRevision: 9162 $
 */

/// ---------------------------------------------------------------------------------------------------
///  This file was automatically generated by J2CS Translator (http://j2cstranslator.sourceforge.net/).
///  Version 1.0.0
/// ---------------------------------------------------------------------------------------------------

namespace Ca.Infoway.Messagebuilder.Terminology.Proxy {

       using Ca.Infoway.Messagebuilder;
       using Ca.Infoway.Messagebuilder.Terminology.Domainvalue;
       using System;
       using System.Collections;
       using System.Collections.Generic;
       //using System.ComponentModel;
       using System.Runtime.CompilerServices;
       using System.Runtime.Serialization;

       /// <summary>
       /// A CodeImpl that also contains a VocabularyDomain type. For example, the type might be
       /// AdministrableDrugForm.
       /// </summary>
       ///
       [Serializable]
       public class TypedCode : Code, Displayable, Sortable, Active, Common {

               private readonly Type type;
               private readonly ICollection<Type> interfaceTypes;
               private readonly String code;
               private readonly String codeSystemOid;
               private readonly String codeSystemName;
               private readonly Int32? ordinal;
               private readonly IDictionary<String, String> displayTextMap;
               private readonly Boolean? active;
               private readonly Boolean? common;

               /// <summary>
               /// Instantiates a new typed c.
               /// </summary>
               ///
               /* @SuppressWarnings("unchecked")*/
               public TypedCode() : this(null, null, null, null, null, null, null, null, null) {
               }

               public TypedCode(Type type_0, ICollection<Type> interfaceTypes_1, String code_2,
                               String codeSystemOid_3, String codeSystemName_4, IDictionary<String, String> displayTextMap_5,
                               Int32? sortValue, Boolean? active_6, Boolean? common_7) {
                       this.type = type_0;
                       this.interfaceTypes = null != interfaceTypes_1 ? interfaceTypes_1 :
                new ILOG.J2CsMapping.Collections.Generics.SortedSet<Type>();

                       this.code = code_2;
                       this.codeSystemOid = codeSystemOid_3;
                       this.codeSystemName = codeSystemName_4;
                       this.displayTextMap = displayTextMap_5;
                       this.ordinal = sortValue;
                       this.active = active_6;
                       this.common = common_7;
               }

               /// <summary>
               /// {@inheritDoc}
               /// </summary>
               ///
               public virtual String CodeValue {
               /// <summary>
               /// {@inheritDoc}
               /// </summary>
               ///
                 get {
                               return code;
                       }
               }


               /// <summary>
               /// {@inheritDoc}
               /// </summary>
               ///
               public virtual String CodeSystem {
               /// <summary>
               /// {@inheritDoc}
               /// </summary>
               ///
                 get {
                              return codeSystemOid;
                       }
               }

               /// <summary>
               /// {@inheritDoc}
               /// </summary>
               ///
               public virtual String CodeSystemName
               {
                   /// <summary>
                   /// {@inheritDoc}
                   /// </summary>
                   ///
                   get
                   {
                       return codeSystemName;
                   }
               }

               /// <summary>
               /// {@inheritDoc}
               /// </summary>
               ///
               public virtual String GetDisplayText(String language) {
                       if (displayTextMap.ContainsKey(language)) {
                               return (String) ((System.String)ILOG.J2CsMapping.Collections.Generics.Collections.Get(displayTextMap,language));
                       } else {
                               return CodeValue;
                       }
               }

               /// <summary>
               /// {@inheritDoc}
               /// </summary>
               ///
               public override  System.String ToString() {
                       return CodeValue;
               }

               //CP: TODO: Move these methods up to the CodeImpl class.
               /// <summary>
               /// {@inheritDoc}
               /// </summary>
               ///
               public override bool Equals(Object that) {
                       if (!type.IsInstanceOfType(that)) {
                               return false;
                       }

                       EqualsBuilder equalsBuilder = new EqualsBuilder();
                       equalsBuilder.Append(this.CodeValue, ((Code) that).CodeValue);
                       equalsBuilder.Append(this.CodeSystem, ((Code) that)
                                       .CodeSystem);

                       return equalsBuilder.IsEquals();
               }

               /// <summary>
               /// {@inheritDoc}
               /// </summary>
               ///
               public override int GetHashCode() {
                       return new HashCodeBuilder().Append(this.CodeValue).Append(
                                       this.CodeSystem).Append(this.type).ToHashCode();
               }

                public Int32? GetSortValue() {
                    return ordinal;
                }

                public bool IsActive() {
                    return active.Value;
                }

                public bool IsCommon() {
                    return common.Value;
                }

       }
}