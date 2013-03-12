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
using System;
using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7
{
	public class DomainTypeHelper
	{
		public static Type GetReturnType(Relationship relationship, VersionNumber version)
		{
			return GetReturnType(relationship.DomainType, version);
		}

		public static Type GetReturnType(string domainType, VersionNumber version)
		{
			Type type = GetReturnType(domainType);
			if (type == typeof(Code))
			{
				string sanitizedDomainType = Sanitize(domainType);
				Type codeType = MessageBeanRegistry.GetInstance().GetCodeType(sanitizedDomainType, version.VersionLiteral);
				if (codeType != null)
				{
					type = codeType;
				}
			}
			return type;
		}

		private static Type GetReturnType(string domainType)
		{
			string sanitizedDomainType = Sanitize(domainType);
			if (ClassUtils.GetShortClassName(typeof(HealthcareProviderRoleType)).EqualsIgnoreCase(sanitizedDomainType))
			{
				sanitizedDomainType = ClassUtils.GetShortClassName(typeof(HealthcareProviderRoleType));
			}
			else
			{
				if (ClassUtils.GetShortClassName(typeof(OtherIDsRoleCode)).Equals(sanitizedDomainType))
				{
					sanitizedDomainType = ClassUtils.GetShortClassName(typeof(OtherIdentifierRoleType));
				}
			}
			if (StringUtils.IsNotBlank(sanitizedDomainType))
			{
				try
				{
					return (Type)Ca.Infoway.Messagebuilder.Runtime.GetType(ClassUtils.GetPackageName(typeof(Ca.Infoway.Messagebuilder.Domainvalue.ActCode
						)) + "." + sanitizedDomainType);
				}
				catch (TypeLoadException)
				{
					return typeof(Code);
				}
			}
			else
			{
				return null;
			}
		}

		/// <summary>Returns a boolean indicating if the two relationships have compatible domain types.</summary>
		/// <remarks>Returns a boolean indicating if the two relationships have compatible domain types.</remarks>
		/// <param name="relationship1">the first relationship to compare</param>
		/// <param name="relationship2">the second relationship to compare</param>
		/// <returns>the string value of a compatible domain type, or null if not compatible or not a domain type</returns>
		public static bool IsCompatibleDomainType(Relationship relationship1, Relationship relationship2)
		{
			return GetCompatibleDomainType(relationship1, relationship2) != null;
		}

		/// <summary>Returns the more general of the two domain types, or null if no type is compatible or one of the relations does not have a domain type.
		/// 	</summary>
		/// <remarks>Returns the more general of the two domain types, or null if no type is compatible or one of the relations does not have a domain type.
		/// 	</remarks>
		/// <param name="relationship1">the first relationship to compare</param>
		/// <param name="relationship2">the second relationship to compare</param>
		/// <returns>the string value of a compatible domain type, or null if not compatible or not a domain type</returns>
		public static string GetCompatibleDomainType(Relationship relationship1, Relationship relationship2)
		{
			// null will be returned for relationships that do not have a domain type
			Type code1 = GetReturnType(relationship1.DomainType);
			Type code2 = GetReturnType(relationship2.DomainType);
			string result = null;
			if (code1 != null && code2 != null)
			{
				if (code1.IsAssignableFrom(code2))
				{
					result = relationship1.DomainType;
				}
				else
				{
					if (code2.IsAssignableFrom(code1))
					{
						result = relationship2.DomainType;
					}
				}
			}
			else
			{
				// TODO - TM - could also try walking up each code's hierarchy looking for a compatible domain type
				//           - this only affects one group of types in MR2009, so I'll leave this as an enhancement
				if (code1 != code2)
				{
					System.Console.Out.WriteLine("WARNING: one of the relationships seems to be missing a domainType");
				}
			}
			return result;
		}

		public static bool HasDomainType(Relationship relationship, string domainType)
		{
			return relationship != null && StringUtils.Equals(relationship.DomainType, domainType);
		}

		public static string Sanitize(string domainName)
		{
			if (domainName == null)
			{
				return null;
			}
			else
			{
				StringBuilder builder = new StringBuilder();
				bool capitalize = false;
				foreach (char c in domainName.ToCharArray())
				{
					if ("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789_".IndexOf(c) >= 0)
					{
						builder.Append(capitalize ? System.Char.ToUpper(c) : c);
						capitalize = false;
					}
					else
					{
						capitalize = true;
					}
				}
				return builder.ToString();
			}
		}
	}
}
