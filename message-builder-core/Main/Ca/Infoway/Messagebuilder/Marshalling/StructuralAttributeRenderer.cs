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
using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Xml;
using Ca.Infoway.Messagebuilder.Xml.Util;

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
			Relationship r = this.relationship;
			if (r.HasFixedValue())
			{
				FormatFixedValue(builder, r);
			}
			else
			{
				object value = GetValue();
				// structural attributes should never have a conformance of populated, and should never have a nullFlavor (no need to check these cases)
				if (value == null && ConformanceLevelUtil.IsMandatory(r) && r.HasDefaultValue())
				{
					FormatDefaultValue(builder, r);
				}
				else
				{
					if (value != null)
					{
						FormatValue(builder, r, value);
					}
					else
					{
						if (ConformanceLevelUtil.IsMandatory(this.relationship))
						{
							string errorMessage = "Relationship " + r.Name + " is mandatory (and not a fixed or default value), but no value is specified";
							Hl7Error error = new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, errorMessage, propertyPath);
							errors.AddHl7Error(error);
						}
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
					if (CodedTypeR2Helper.IsCodedTypeR2(value))
					{
						return CodedTypeR2Helper.GetCodeValue(value);
					}
					else
					{
						if (value is Code)
						{
							return ((Code)value).CodeValue;
						}
						else
						{
							throw new MarshallingException("Encountered value \"" + value + "\" of type " + value.GetType().FullName + " when Code was expected ("
								 + relationship.Name + ")");
						}
					}
				}
				else
				{
					if ("BL".Equals(type))
					{
						return true.Equals(value) ? "true" : "false";
					}
					else
					{
						if ("ST".Equals(type))
						{
							return (string)value;
						}
						else
						{
							throw new MarshallingException("Cannot handle structural attribute string of type " + type + " (" + relationship.Name + ")"
								);
						}
					}
				}
			}
		}

		private void FormatFixedValue(StringBuilder builder, Relationship relationship)
		{
			// suppress rendering of required or optional fixed values
			if (ConformanceLevelUtil.IsMandatory(relationship) || ConformanceLevelUtil.IsPopulated(relationship))
			{
				builder.Append(" ").Append(relationship.Name).Append("=\"").Append(XmlStringEscape.Escape(relationship.FixedValue)).Append
					("\"");
			}
		}

		private void FormatDefaultValue(StringBuilder builder, Relationship relationship)
		{
			// suppress rendering of required or optional fixed values
			if (ConformanceLevelUtil.IsMandatory(relationship) || ConformanceLevelUtil.IsPopulated(relationship))
			{
				builder.Append(" ").Append(relationship.Name).Append("=\"").Append(XmlStringEscape.Escape(relationship.DefaultValue)).Append
					("\"");
			}
		}
	}
}
