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
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	/// <summary>CE (R2)</summary>
	[DataTypeHandler("CE")]
	internal class CeR2ElementParser : CvR2ElementParser
	{
		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new CE_R2Impl<Code>();
		}

		protected override BareANY DoCreateR2DataTypeInstance(ParseContext context)
		{
			return CodedTypeR2Helper.CreateCEInstance(context.GetExpectedReturnType());
		}

		protected override bool TranslationAllowed()
		{
			return true;
		}

		protected override CodedTypeR2<Code> ParseTranslation(XmlElement translationElement, ParseContext newContext, XmlToModelResult
			 result)
		{
			BareANY anyResult = new CdR2ElementParser().Parse(newContext, translationElement, result);
			CodedTypeR2<Code> translation = anyResult == null ? null : (CodedTypeR2<Code>)anyResult.BareValue;
			if (translation != null)
			{
				translation.NullFlavorForTranslationOnly = anyResult == null ? null : anyResult.NullFlavor;
			}
			return translation;
		}
	}
}
