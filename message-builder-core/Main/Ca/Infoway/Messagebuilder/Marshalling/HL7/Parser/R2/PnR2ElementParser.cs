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
	/// PN (R2) - Personal Name
	/// Parses a PN element into a PersonName.
	/// </summary>
	/// <remarks>
	/// PN (R2) - Personal Name
	/// Parses a PN element into a PersonName. The element looks like this:
	/// 
	/// Mr.
	/// John
	/// Jimmy
	/// Smith
	/// Sr.
	/// 
	/// If an object is null, value is replaced by a nullFlavor. So the element would look
	/// like this:
	/// 
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-PN
	/// </remarks>
	[DataTypeHandler("PN")]
	internal class PnR2ElementParser : AbstractNameR2ElementParser<PersonName>
	{
		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new PNImpl();
		}

		protected override PersonName CreateEntityName()
		{
			return new PersonName();
		}
	}
}
