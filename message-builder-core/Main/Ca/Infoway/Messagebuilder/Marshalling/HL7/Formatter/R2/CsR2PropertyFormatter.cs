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
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	/// <summary>CS - Coded Simple (R2 datatype variant)</summary>
	[DataTypeHandler("CS")]
	internal class CsR2PropertyFormatter : AbstractCodedTypeR2PropertyFormatter
	{
		protected override bool CodeValueAllowed()
		{
			return true;
		}

		protected override bool CodeSystemAllowed()
		{
			// Technically, CS does not allow for a codeSystem. However, we don't want to log an error just because a Code also has a CodeSystem with it (most common case)  
			return true;
		}

		protected override bool CodeSystemNameAllowed()
		{
			// Technically, CS does not allow for a codeSystemName. However, we don't want to log an error just because a Code also has a CodeSystem with it (most common case)  
			return true;
		}

		protected override bool DisplayNameAllowed()
		{
			// Technically, CS does not allow for a codeSystemName. However, we don't want to log an error just because a Code also has a CodeSystem with it (most common case)  
			return true;
		}

		protected override void HandleCodeSystem(CodedTypeR2<Code> codedType, IDictionary<string, string> result, FormatContext context
			)
		{
			// codes will usually have a codeSystem even if we don't intend to render it in the message
			if (!"CS".Equals(context.Type))
			{
				base.HandleCodeSystem(codedType, result, context);
			}
		}

		protected override void HandleCodeSystemName(CodedTypeR2<Code> codedType, IDictionary<string, string> result, FormatContext
			 context)
		{
			// codes will usually have a codeSystem even if we don't intend to render it in the message
			if (!"CS".Equals(context.Type))
			{
				base.HandleCodeSystemName(codedType, result, context);
			}
		}

		protected override void HandleDisplayName(CodedTypeR2<Code> codedType, IDictionary<string, string> result, FormatContext 
			context)
		{
			// codes will usually have a codeSystem even if we don't intend to render it in the message
			if (!"CS".Equals(context.Type))
			{
				base.HandleDisplayName(codedType, result, context);
			}
		}
	}
}
