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

    /// <summary>
    /// CR (R2) data type
    /// </summary>
    [Serializable]
    public class CodeRole
    {
        /// <summary>
        /// The name code
        /// </summary>
        public virtual CodedTypeR2<Code> Name
        {
            get;
            set;
        }

        /// <summary>
        /// The value code
        /// </summary>
        public virtual CodedTypeR2<Code> Value
        {
            get;
            set;
        }

        /// <summary>
        /// Whether the type is inverted or not
        /// </summary>
        public bool Inverted
        {
            get;
            set;
        }

        /// <summary>
        /// Constructs an empty CR
        /// </summary>
        public CodeRole()
        {
        }

        /// <summary>
        /// Constructs a CR with default inverted value
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public CodeRole(CodedTypeR2<Code> name, CodedTypeR2<Code> value) :
            this(name, value, false)
        {
        }

        /// <summary>
        /// Constructs a CR with all fields
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="inverted"></param>
        public CodeRole(CodedTypeR2<Code> name, CodedTypeR2<Code> value, bool inverted)
        {
            Name = name;
            Value = value;
            Inverted = inverted;
        }

        /// <summary>
        /// Generates a hash code for this object
        /// </summary>
        /// <returns>the hashcode</returns>
        public override int GetHashCode()
        {
            return new HashCodeBuilder()
                    .Append(Name)
                    .Append(Value)
                    .Append(Inverted)
                    .ToHashCode();
        }

        /// <summary>
        /// Compares the supplied object with this object to see if they are equal.
        /// </summary>
        /// <param name="obj">the object to compare</param>
        /// <returns>whether the objects are equal</returns>
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
                return Equals((CodeRole)obj);
            }
        }

        private bool Equals(CodeRole that)
        {
            return new EqualsBuilder()
                    .Append(this.Name, that.Name)
                    .Append(this.Value, that.Value)
                    .Append(this.Inverted, that.Inverted)
                    .IsEquals();
        }
    }
}