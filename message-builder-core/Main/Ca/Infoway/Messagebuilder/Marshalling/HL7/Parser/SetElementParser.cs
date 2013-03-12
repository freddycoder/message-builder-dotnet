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
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Platform;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[DataTypeHandler(new string[] { "SET" })]
	internal class SetElementParser : SetOrListElementParser
	{
		protected override BareANY WrapWithHl7DataType(string type, string subType, ICollection<BareANY> collection)
		{
			try
			{
				CollectionHelper result = (CollectionHelper)GenericDataTypeFactory.Create(type);
				foreach (BareANY bareANY in collection)
				{
					result.Add(bareANY);
				}
				return (BareANY)result;
			}
			catch (MarshallingException)
			{
				return null;
			}
		}

		protected override ICollection<BareANY> GetCollectionType(ParseContext context)
		{
			return new LinkedSet<BareANY>();
		}
	}
}
