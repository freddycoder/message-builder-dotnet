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
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	/// <summary>
	/// TN (R2) - TrivialName
	/// Parses a TN element into a TrivialName.
	/// </summary>
	/// <remarks>
	/// TN (R2) - TrivialName
	/// Parses a TN element into a TrivialName. The element looks like this:
	/// This is a trivial name
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-TN
	/// </remarks>
	[DataTypeHandler("TN")]
	internal class TnR2ElementParser : AbstractNameR2ElementParser<TrivialName>
	{
		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new TNImpl();
		}

		protected override TrivialName CreateEntityName()
		{
			return new TrivialName();
		}
	}
}
