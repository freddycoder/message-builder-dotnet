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
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.CodeRegistry;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue.Util;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Resolver;
using Ca.Infoway.Messagebuilder.Xml;
using ILOG.J2CsMapping.Text;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class NonStructuralHl7AttributeRenderer
	{
		internal static object GetFixedValue(Relationship relationship, VersionNumber version, bool isR2, Hl7Errors errors, string
			 propertyPath)
		{
			string fixedValue = relationship.FixedValue;
			if (StringUtils.Equals("BL", relationship.Type))
			{
				return true.ToString().EqualsIgnoreCase(fixedValue);
			}
			else
			{
				if (StringUtils.Equals("INT.POS", relationship.Type))
				{
					return System.Convert.ToInt32(fixedValue);
				}
				else
				{
					if (StringUtils.Equals("ST", relationship.Type))
					{
						return fixedValue;
					}
					else
					{
						if (relationship.CodedType)
						{
							Type codeType = DomainTypeHelper.GetReturnType(relationship, version, CodeTypeRegistry.GetInstance());
							if (codeType == null)
							{
								codeType = typeof(Code);
							}
							Code code = CodeResolverRegistry.Lookup(codeType, fixedValue);
							if (code == null)
							{
								string message = System.String.Format("Fixed code lookup could not find match for {0}.{1}", relationship.DomainType, fixedValue
									);
								errors.AddHl7Error(new Hl7Error(Hl7ErrorCode.VALUE_NOT_IN_CODE_SYSTEM, ErrorLevel.WARNING, message, propertyPath));
							}
							//Fixup for .NET
							if (isR2)
							{
								return code == null ? null : new CodedTypeR2<Code>(code);
							}
							else
							{
								return code;
							}
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
}
