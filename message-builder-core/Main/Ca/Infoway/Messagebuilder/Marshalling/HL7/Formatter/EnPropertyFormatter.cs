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
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// EN - EntityName
	/// Represents an EN object as an element:
	/// &lt;element-name&gt;This is a trivial name&lt;/element-name&gt;
	/// This class makes a decision on which formatter to use based on the actual type of the object.
	/// </summary>
	/// <remarks>
	/// EN - EntityName
	/// Represents an EN object as an element:
	/// &lt;element-name&gt;This is a trivial name&lt;/element-name&gt;
	/// This class makes a decision on which formatter to use based on the actual type of the object.
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-EN
	/// </remarks>
	[DataTypeHandler("EN")]
	internal class EnPropertyFormatter : AbstractEntityNamePropertyFormatter<EntityName>
	{
		private readonly OnPropertyFormatter onPropertyFormatter = new OnPropertyFormatter();

		private readonly PnPropertyFormatter pnPropertyFormatter = new PnPropertyFormatter();

		private readonly TnPropertyFormatter tnPropertyFormatter = new TnPropertyFormatter();

		protected override string FormatNonNullValue(FormatContext context, EntityName value, int indentLevel)
		{
			// this code is delegating to the appropriate formatter based on the type of the
			// object set as the value; specializationType needs to also be set, but we can infer it
			// (note that this is a bit different from how other formatters treat abstract types)
			if (value == null || value.GetType().IsAssignableFrom(typeof(EntityName)))
			{
				return base.FormatNonNullValue(context, value, indentLevel);
			}
			else
			{
				if (value.GetType().IsAssignableFrom(typeof(TrivialName)))
				{
					context = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl("TN", true, context);
					return this.tnPropertyFormatter.Format(context, new TNImpl((TrivialName)value), indentLevel);
				}
				else
				{
					if (value.GetType().IsAssignableFrom(typeof(PersonName)))
					{
						context = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl("PN", true, context);
						return this.pnPropertyFormatter.Format(context, new PNImpl((PersonName)value), indentLevel);
					}
					else
					{
						if (value.GetType().IsAssignableFrom(typeof(OrganizationName)))
						{
							context = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl("ON", true, context);
							return this.onPropertyFormatter.Format(context, new ONImpl((OrganizationName)value), indentLevel);
						}
						else
						{
							throw new ArgumentException("EN can not handle values of type " + value.GetType());
						}
					}
				}
			}
		}
	}
}
