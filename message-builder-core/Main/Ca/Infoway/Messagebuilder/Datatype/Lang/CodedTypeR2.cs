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


namespace Ca.Infoway.Messagebuilder.Datatype.Lang
{
    using System;
    using System.Collections.Generic;
    using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
    using Ca.Infoway.Messagebuilder.Domainvalue;

    /// <summary>
    /// Java datatype backing the R2 coded types.   
    /// </summary>
    /// <typeparam name="T">the underlying code type</typeparam>
    public class CodedTypeR2<T> where T : Code
    {
        private string codeSystemName;
        private string displayName;
        private IList<CodeRole> qualifier = new List<CodeRole>();
        private IList<CodedTypeR2<Code>> translation = new List<CodedTypeR2<Code>>();

        public virtual T Code
        {
            get;
            set;
        }
        public virtual string CodeSystemName
        {
            get
            {
                // If the code happens to contain a code system name, we should always treat it as
                // correct and authoritative. However, if the code resolver we are using hasn't
                // provided a value and we happen to have one from another source (e.g., an 
                // incoming document), we can use that as a backup.
                if (Code != null && Code.CodeSystemName != null)
                {
                    return Code.CodeSystemName;
                }
                return this.codeSystemName;
            }
            set { this.codeSystemName = value; }
        }
        public virtual string CodeSystemVersion
        {
            get;
            set;
        }
        public virtual string DisplayName
        {
            get
            {
                // If the code happens to contain a display name, we should always treat it as
                // correct and authoritative. However, if the code resolver we are using hasn't
                // provided a value and we happen to have one from another source (e.g., an 
                // incoming document), we can use that as a backup.
                if (Code != null && Code is Describable)
                {
                    Describable describableCode = (Describable) Code;
                    String englishDescription = describableCode.Description;
                    if (englishDescription != null)
                    {
                        return englishDescription;
                    }
                }
                return this.displayName;
            }
            set { this.displayName = value; }
        }
        public virtual NullFlavor NullFlavorForTranslationOnly
        {
            get;
            set;
        }
        public virtual EncapsulatedData OriginalText
        {
            get;
            set;
        }
        public virtual IList<CodeRole> Qualifier
        {
            get { return this.qualifier; }
            set { this.qualifier = value; }
        }
        public virtual IList<CodedTypeR2<Code>> Translation
        {
            get { return this.translation; }
            set { this.translation = value; }
        }
        public virtual string SimpleValue // SC only
        {
            get;
            set;
        }
        public virtual SetOperator Operator // SCXM<CD> only
        {
            get;
            set;
        }
        public virtual BigDecimal Value //PQR only
        {
            get;
            set;
        }
        public virtual Interval<PlatformDate> ValidTime // HXIT_CE only
        {
            get;
            set;
        }
        public virtual Int32? Qty // BXIT_CD only
        {
            get;
            set;
        }

        public CodedTypeR2() {
        }

        public CodedTypeR2(T code) {
            Code = code;
        }

        public virtual string GetCodeValue()
        {
            return Code == null ? null : Code.CodeValue;
        }
        public virtual string GetCodeSystem()
        {
            return Code == null ? null : Code.CodeSystem;
        }
        public virtual bool IsEmpty()
        {
		    return Code == null
			    && this.codeSystemName == null
			    && CodeSystemVersion == null
			    && this.displayName == null
			    && Operator == null
			    && SimpleValue == null
			    && OriginalText == null
			    && Value == null
			    && (this.translation == null || this.translation.IsEmpty())
			    && (this.qualifier == null || this.qualifier.IsEmpty())
			    && ValidTime == null
			    && Qty == null
			    && NullFlavorForTranslationOnly == null
			    ;
        }
        public override int GetHashCode()
        {
            return new HashCodeBuilder()
		            .Append(Code)
		            .Append(this.codeSystemName)
		            .Append(CodeSystemVersion)
		            .Append(this.displayName)
		            .Append(OriginalText)
		            .Append(this.qualifier)
		            .Append(this.translation)
		            .Append(SimpleValue)
		            .Append(Operator)
		            .Append(Value)
		            .Append(ValidTime)
		            .Append(Qty)
		            .Append(NullFlavorForTranslationOnly)
                    .ToHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            else if (obj.GetType() != GetType())
            {
                return false;
            }
            else
            {
                return equals((CodedTypeR2<T>)obj);
            }
        }

        private bool equals(CodedTypeR2<T> that) {
            return new EqualsBuilder()
                .Append(this.Code, that.Code)
                .Append(this.codeSystemName, that.codeSystemName)
                .Append(this.CodeSystemVersion, that.CodeSystemVersion)
		        .Append(this.displayName, that.displayName)
		        .Append(this.OriginalText, that.OriginalText)
		        .Append(this.qualifier, that.qualifier)
		        .Append(this.translation, that.translation)
		        .Append(this.SimpleValue, that.SimpleValue)
		        .Append(this.Operator, that.Operator)
		        .Append(this.Value, that.Value)
		        .Append(this.ValidTime, that.ValidTime)
		        .Append(this.Qty, that.Qty)
		        .Append(this.NullFlavorForTranslationOnly, that.NullFlavorForTranslationOnly)
                .IsEquals();
        }
    }
}