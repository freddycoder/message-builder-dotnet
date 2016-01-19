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


using System;
using System.Collections.Generic;
using System.Text;

namespace Platform.SimpleXml
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public class ElementAttribute : BaseAttribute
    {
        /// <summary>
        /// The name of the XML tag for the element. Can be null, in which case the
        /// name will be extracted from the data type (class name, or name specified
        /// by its [Root] attribute).
        /// </summary>
        private String  name;
		
		private bool data;

        //
        // Note the following are just to have the full list of arguments. The current
        // serialization handling of them is described below.
        //

        /// <summary>
        /// Whether required. Note that this value is currently ignored by the serialization
        /// </summary>
        private bool    required;

        /// <summary>
        /// Gets or sets the name of the entity
        /// </summary>
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Gets or sets whether entity is required
        /// </summary>
        public bool Required
        {
            get { return required; }
            set { required = value; }
        }
		
        public bool Data
        {
            get { return data; }
            set { data = value; }
        }
    }
}
