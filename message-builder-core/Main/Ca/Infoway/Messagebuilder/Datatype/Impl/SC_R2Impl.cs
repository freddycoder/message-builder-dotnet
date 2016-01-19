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


namespace Ca.Infoway.Messagebuilder.Datatype.Impl
{
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;

    public class SC_R2Impl<T> : ANYImpl<CodedTypeR2<T>>, SC_R2<T> where T : Code
    {
        /// <summary>
        /// Constructs an empty CV.
        /// </summary>
        public SC_R2Impl() :
            this(null, null, StandardDataType.SC)
        {
        }

        /// <summary>
        /// Constructs a CV with the given value.
        /// </summary>
        /// <param name="defaultValue">an initial value</param>
        public SC_R2Impl(CodedTypeR2<T> defaultValue) :
            this(defaultValue, null, StandardDataType.SC)
        {
        }

        /// <summary>
        /// Constructs a CV with the given null flavor.
        /// </summary>
        /// <param name="nullFlavor">a null flavor</param>
        public SC_R2Impl(NullFlavor nullFlavor) :
            this(null, nullFlavor, StandardDataType.SC)
        {
        }

        /// <summary>
        /// Constructs a CV using the supplied parameters.
        /// </summary>
        /// <param name="value">an initial value</param>
        /// <param name="nullFlavor">a null flavor</param>
        /// <param name="dataType">an HL7 datatype</param>
        public SC_R2Impl(CodedTypeR2<T> value, NullFlavor nullFlavor, StandardDataType dataType) :
            base(value, nullFlavor, dataType)
        {
        }
    }
}