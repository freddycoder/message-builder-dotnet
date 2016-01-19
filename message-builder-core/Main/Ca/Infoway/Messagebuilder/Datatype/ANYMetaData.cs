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


using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using System;

namespace Ca.Infoway.Messagebuilder.Datatype
{
	public interface ANYMetaData
	{
        /// <summary>
        /// Returns the ST's language.
        /// </summary>
        ///
        /// <returns>the language of the ST</returns>
        String Language
        {
            /// <summary>
            /// Returns the ST's language.
            /// </summary>
            ///
            /// <returns>the language of the ST</returns>
            get;
            /// <summary>
            /// Sets the language of the ST.
            /// </summary>
            ///
            /// <param name="language_0">a language</param>
            set;
        }

        /// <summary>
        /// Returns the display name.
        /// </summary>
        ///
        /// <returns>the display name</returns>
        String DisplayName
        {
            /// <summary>
            /// Returns the display name.
            /// </summary>
            ///
            /// <returns>the display name</returns>
            get;
            /// <summary>
            /// Sets the display name.
            /// </summary>
            ///
            /// <param name="displayName_0">the display name</param>
            set;
        }

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
            /// <param name="originalText_0">the original text</param>
            set;
        }

        /// <summary>
        /// Returns the translations for this CD.
        /// </summary>
        ///
        /// <returns>the translations for this CD</returns>
        IList<CD> Translations
        {
            /// <summary>
            /// Returns the translations for this CD.
            /// </summary>
            ///
            /// <returns>the translations for this CD</returns>
            get;
        }

        Boolean IsCdata
        {
            /// <summary>
            /// Returns whether the text should be considered CDATA.
            /// </summary>
            ///
            /// <returns>whether the text should be considered CDATA</returns>
            get;
            set;
        }

        SetOperator Operator
        {
            get;
            set;
        }

        bool Unsorted
        {
            get;
            set;
        }
	}
}
