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
using System.Xml;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[DataTypeHandler("URG<PQ>")]
	internal class UrgPqElementParser : UrgElementParser<PQ, PhysicalQuantity>
	{
		protected override ElementParser GetIvlParser()
		{
			return new IvlPqElementParser(true);
		}

		protected override UncertainRange<PhysicalQuantity> ParseNonNullNode(ParseContext context, XmlNode node, BareANY result, 
			Type expectedReturnType, XmlToModelResult xmlToModelResult)
		{
			// TM - RM20416: grab any original text (pre-adopted from R2 datatype)
			((ANYMetaData)result).OriginalText = GetOriginalText((XmlElement)node);
			return base.ParseNonNullNode(context, node, result, expectedReturnType, xmlToModelResult);
		}
	}
}
