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
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal abstract class StructuralAttributeRenderer
	{
		protected readonly Relationship relationship;

		public StructuralAttributeRenderer(Relationship relationship)
		{
			this.relationship = relationship;
		}

		public virtual void Render(StringBuilder builder, string propertyPath, Hl7Errors errors)
		{
			if (this.relationship.Fixed)
			{
				FormatFixedValue(builder, relationship);
			}
			else
			{
				object value = GetValue();
				if (value != null)
				{
					FormatValue(builder, relationship, value);
				}
				else
				{
					if (this.relationship.Conformance == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY)
					{
						string errorMessage = "Relationship " + this.relationship.Name + " is mandatory (and not a fixed value), but no value is specified";
						Hl7Error error = new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, errorMessage, propertyPath);
						errors.AddHl7Error(error);
					}
				}
			}
		}

		protected abstract object GetValue();

		private void FormatValue(StringBuilder builder, Relationship relationship, object value)
		{
			builder.Append(" ").Append(relationship.Name).Append("=\"").Append(XmlStringEscape.Escape(ValueAsString(value, relationship
				))).Append("\"");
		}

		private string ValueAsString(object value, Relationship relationship)
		{
			string type = relationship.Type;
			if (type == null)
			{
				throw new MarshallingException("Relationship " + relationship.Name + " has no type information");
			}
			else
			{
				if ("CS".Equals(type))
				{
					return ((Code)value).CodeValue;
				}
				else
				{
					if ("BL".Equals(type))
					{
						return true.Equals(value) ? "true" : "false";
					}
					else
					{
						throw new MarshallingException("Cannot handle structural attribute string of type " + type + " (" + relationship.Name + ")"
							);
					}
				}
			}
		}

		private void FormatFixedValue(StringBuilder builder, Relationship relationship)
		{
			builder.Append(" ").Append(relationship.Name).Append("=\"").Append(XmlStringEscape.Escape(relationship.FixedValue)).Append
				("\"");
		}
	}
}
