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
using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[DataTypeHandler("PIVLTSCDAR1")]
	internal class PivlTsCdaElementParser : ElementParser
	{
		private PivlTsElementParser r1Parser = new PivlTsElementParser();

		private PivlTsDateTimeElementParser r1ParserFrequency = new PivlTsDateTimeElementParser();

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		public virtual BareANY Parse(ParseContext context, IList<XmlNode> nodes, XmlToModelResult xmlToModelResult)
		{
			ParseContext newContext = ConvertContext(context);
			BareANY parseResult = this.r1Parser.Parse(newContext, nodes, xmlToModelResult);
			if (parseResult.BareValue == null && !parseResult.HasNullFlavor())
			{
				parseResult = this.r1ParserFrequency.Parse(newContext, nodes, xmlToModelResult);
			}
			return ConvertDataType(parseResult);
		}

		private BareANY ConvertDataType(BareANY dataType)
		{
			object bareValue = dataType.BareValue;
			PeriodicIntervalTime pivlR1 = (bareValue is PeriodicIntervalTime ? (PeriodicIntervalTime)bareValue : null);
			PeriodicIntervalTimeR2 pivlR2 = (pivlR1 == null ? null : ConvertPivl(pivlR1));
			BareANY result = new PIVLTSCDAR1Impl(pivlR2);
			result.DataType = dataType.DataType;
			result.NullFlavor = dataType.NullFlavor;
			return result;
		}

		private PeriodicIntervalTimeR2 ConvertPivl(PeriodicIntervalTime pivlR1)
		{
			return PeriodicIntervalTimeR2.CreateFromPivlR1(pivlR1);
		}

		private ParseContext ConvertContext(ParseContext ParseContext)
		{
			return ParseContextImpl.Create("PIVL<TS>", ParseContext);
		}
	}
}
