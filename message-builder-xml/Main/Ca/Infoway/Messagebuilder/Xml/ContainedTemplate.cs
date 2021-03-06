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


using Platform.SimpleXml;

namespace Ca.Infoway.Messagebuilder.Xml
{
	/// <summary>A message part relationship (either an attribute or an association).</summary>
	/// <remarks>
	/// A message part relationship (either an attribute or an association).
	/// Fundamentally, we think of there being four types of relationships:
	/// 
	/// Attributes
	/// Simple associations
	/// Choice associations
	/// Template associations
	/// 
	/// </remarks>
	/// <author>Intelliware Development</author>
	[RootAttribute]
	public class ContainedTemplate
	{
		[XmlAttributeAttribute]
		private string templateOid;

		[XmlAttributeAttribute(Required = false)]
		private string cardinality;

		/// <summary>Default constructor.</summary>
		/// <remarks>Default constructor.</remarks>
		public ContainedTemplate()
		{
		}

        /// <summary>Standard constructor.</summary>
        /// <remarks>Standard constructor.</remarks>
        /// <param name="templateOid">- the OID of the template</param>
        /// <param name="cardinality">- the cardinality.</param>
        public ContainedTemplate(string templateOid, Ca.Infoway.Messagebuilder.Xml.Cardinality cardinality)
		{
			this.templateOid = templateOid;
			this.cardinality = cardinality.ToString();
		}

		public virtual string TemplateOid
		{
			get
			{
				return templateOid;
			}
			set
			{
				string templateOid = value;
				this.templateOid = templateOid;
			}
		}

		/// <summary>Get the cardinality.</summary>
		/// <remarks>Get the cardinality.</remarks>
		/// <returns>the cardinality</returns>
		/// <summary>Set the cardinality.</summary>
		/// <remarks>Set the cardinality.</remarks>
		/// <value>- the new value</value>
		public virtual Ca.Infoway.Messagebuilder.Xml.Cardinality Cardinality
		{
			get
			{
				Ca.Infoway.Messagebuilder.Xml.Cardinality temp = Ca.Infoway.Messagebuilder.Xml.Cardinality.Create(this.cardinality);
				if (temp != null)
				{
					return temp;
				}
				else
				{
					return Ca.Infoway.Messagebuilder.Xml.Cardinality.Create("0-1");
				}
			}
			set
			{
				Ca.Infoway.Messagebuilder.Xml.Cardinality cardinality = value;
				this.cardinality = cardinality == null ? null : cardinality.ToString();
			}
		}

		public virtual string RawCardinality
		{
			get
			{
				return this.cardinality;
			}
		}
	}
}
