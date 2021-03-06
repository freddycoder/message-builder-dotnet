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
	
	using Ca.Infoway.Messagebuilder.Datatype.Lang;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Runtime.CompilerServices;
	
	/// <summary>
	/// A class to represent CeRx's notion of a physical quantity. Backed by the   datatype PhysicalQuantity.
	/// There are two attributes of note: value (amount) and unit.
	/// The HL7 version of this class relies on the HL7 REAL, which is a
	/// re-implemented BigDecimal for all intents and purposes.
	/// </summary>
	///
	/// <seealso cref="<a href="http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-PQ">The HL7 Definition</a>"/>
    public interface PQ : QTY<PhysicalQuantity>, SetOperatorType
    {

        /// <summary>
        /// Returns the original text.
        /// </summary>
        ///
        /// <returns>the original text</returns>
        String OriginalText
        {
            /// <summary>
            /// Returns the original text.
            /// </summary>
            ///
            /// <returns>the original text</returns>
            get;
            /// <summary>
            /// Sets the original text.
            /// </summary>
            ///
            /// <param name="OriginalText">the original text</param>
            set;
        }

    }
}
