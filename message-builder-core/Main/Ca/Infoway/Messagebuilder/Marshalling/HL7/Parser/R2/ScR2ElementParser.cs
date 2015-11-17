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
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	/// <summary>SC (R2)</summary>
	[DataTypeHandler("SC")]
	internal class ScR2ElementParser : CsR2ElementParser
	{
		protected override BareANY DoCreateR2DataTypeInstance(ParseContext context)
		{
			return CodedTypeR2Helper.CreateSCInstance(context.GetExpectedReturnType());
		}

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new SC_R2Impl<Code>();
		}

		protected override bool CodeSystemAllowed()
		{
			return true;
		}

		protected override bool CodeSystemNameAllowed()
		{
			return true;
		}

		protected override bool CodeSystemVersionAllowed()
		{
			return true;
		}

		protected override bool DisplayNameAllowed()
		{
			return true;
		}

		protected override bool SimpleValueAllowed()
		{
			return true;
		}
	}
}
