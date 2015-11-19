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
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	/// <summary>
	/// TS (R2) - Timestamp
	/// Represents a TS object as an element:
	/// &lt;element-name value="yyyyMMddHHmmss"&gt;&lt;/element-name&gt;
	/// If an object is null, value is replaced by a nullFlavor.
	/// </summary>
	/// <remarks>
	/// TS (R2) - Timestamp
	/// Represents a TS object as an element:
	/// &lt;element-name value="yyyyMMddHHmmss"&gt;&lt;/element-name&gt;
	/// If an object is null, value is replaced by a nullFlavor. So the element would look
	/// like this:
	/// &lt;element-name nullFlavor="something" /&gt;
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-TS
	/// </remarks>
	[DataTypeHandler(new string[] { "TSCDAR1", "SXCMTSCDAR1" })]
	public class TsCdaElementParser : ElementParser
	{
		private readonly TsElementParser tsParser = new TsElementParser();

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		public virtual BareANY Parse(ParseContext context, IList<XmlNode> nodes, XmlToModelResult xmlToModelResult)
		{
			BareANY tsResult = this.tsParser.Parse(ConvertContext(context), nodes, xmlToModelResult);
			return ConvertDataType(context, tsResult);
		}

		private BareANY ConvertDataType(ParseContext context, BareANY dataType)
		{
			object bareValue = dataType.BareValue;
			PlatformDate date = (bareValue is PlatformDate ? (PlatformDate)bareValue : null);
			MbDate mbDate = (date == null ? null : new MbDate(date));
			if ("SXCMTSCDAR1".Equals(context.Type))
			{
				SXCMTSCDAR1 result = new SXCMTSCDAR1Impl();
				result.DataType = dataType.DataType;
				result.NullFlavor = dataType.NullFlavor;
				result.BareValue = mbDate;
				return result;
			}
			else
			{
				TSCDAR1 result = new TSCDAR1Impl();
				result.DataType = dataType.DataType;
				result.NullFlavor = dataType.NullFlavor;
				result.BareValue = mbDate;
				result.Operator = ((ANYMetaData)dataType).Operator;
				return result;
			}
		}

		private ParseContext ConvertContext(ParseContext parseContext)
		{
			return ParseContextImpl.Create("TS", parseContext);
		}
	}
}
