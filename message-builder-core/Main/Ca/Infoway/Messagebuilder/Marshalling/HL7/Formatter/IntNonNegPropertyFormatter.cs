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
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// INT.NONNEG - Integer (Non-negative)
	/// Represents a INT.NONNEG object as an element:
	/// &lt;element-name value="1234"&gt;&lt;/element-name&gt;
	/// If an object is null, value is replaced by a nullFlavor.
	/// </summary>
	/// <remarks>
	/// INT.NONNEG - Integer (Non-negative)
	/// Represents a INT.NONNEG object as an element:
	/// &lt;element-name value="1234"&gt;&lt;/element-name&gt;
	/// If an object is null, value is replaced by a nullFlavor. So the element would look
	/// like this:
	/// &lt;element-name nullFlavor="something" /&gt;
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-INT
	/// The INT.NONNEG variant defined by CeRx cannot contain negative values. CeRx also defines
	/// a maximum length of 10, which is not enforced by this class.
	/// </remarks>
	[DataTypeHandler("INT.NONNEG")]
	internal class IntNonNegPropertyFormatter : AbstractValueNullFlavorPropertyFormatter<Int32?>
	{
		protected override string GetValue(Int32? integer, FormatContext context, BareANY bareAny)
		{
			Validate(integer, context, bareAny);
			return integer.ToString();
		}

		private void Validate(Int32? integer, FormatContext context, BareANY bareAny)
		{
			if (integer.Value < 0)
			{
				RecordNotNegativeError(integer, context.GetPropertyPath(), context.GetModelToXmlResult());
			}
		}

		private void RecordNotNegativeError(Int32? integer, string propertyPath, ModelToXmlResult modelToXmlResult)
		{
			modelToXmlResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "The attribute \"value\" must not be negative for INT.NONNEG."
				, propertyPath));
		}
	}
}
