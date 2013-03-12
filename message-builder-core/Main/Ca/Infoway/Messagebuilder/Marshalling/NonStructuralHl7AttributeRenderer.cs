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
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Terminology;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class NonStructuralHl7AttributeRenderer
	{
		internal static object GetFixedValue(Relationship relationship, VersionNumber version)
		{
			if (StringUtils.Equals("BL", relationship.Type))
			{
				return true.ToString().EqualsIgnoreCase(relationship.FixedValue);
			}
			else
			{
				if (StringUtils.Equals("INT.POS", relationship.Type))
				{
					return System.Convert.ToInt32(relationship.FixedValue);
				}
				else
				{
					if (relationship.CodedType)
					{
						return CodeResolverRegistry.Lookup(DomainTypeHelper.GetReturnType(relationship, version), relationship.FixedValue);
					}
					else
					{
						throw new MarshallingException("Cannot handle a fixed relationship of type: " + relationship.Type);
					}
				}
			}
		}
	}
}
