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
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using Ca.Infoway.Messagebuilder.Xml;
using Platform.SimpleXml;

namespace Ca.Infoway.Messagebuilder.Xml
{
	/// <summary>Specification of cardinality and fixed value constraints on fields inside a standard datatype.</summary>
	/// <remarks>
	/// Specification of cardinality and fixed value constraints on fields inside a standard datatype.
	/// Only used in the context of CDA documents
	/// </remarks>
	/// <author>Intelliware Development</author>
	[RootAttribute]
	public class SchematronRule
	{
        //Due to the fact that the .NET port of simple xml does not support the Text attribute, these are strings instead of objects

		[ElementAttribute]
		private string test;

		[ElementAttribute(Required = false)]
		private string description;

		/// <summary>Default constructor.</summary>
		/// <remarks>Default constructor.</remarks>
		public SchematronRule()
		{
		}

		public SchematronRule(string test, string description)
		{
            this.test = test;
			if (description != null)
			{
                this.description = description;
			}
		}

		public virtual string Test
		{
			get
			{
				return test;
			}
			set
			{
				this.test = value;
			}
		}

		public virtual string Description
		{
			get
			{
				return description;
			}
			set
			{
				this.description = value;
			}
		}
	}
}
