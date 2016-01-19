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
using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Domainvalue.Util;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Util
{
	public class DomainTypeHelper
	{
		public static Type GetReturnType(Relationship relationship, VersionNumber version, CodeTypeHandler codeTypeHandler)
		{
			return GetReturnType(relationship.DomainType, version, codeTypeHandler);
		}

		public static Type GetReturnType(string domainType, VersionNumber version, CodeTypeHandler codeTypeHandler)
		{
			return GetReturnType(domainType, version.VersionLiteral, codeTypeHandler);
		}

		public static Type GetReturnType(string domainType, string version, CodeTypeHandler codeTypeHandler)
		{
			string sanitizedDomainType = Sanitize(domainType);
			Type type = GetReturnType(domainType);
			if (type == null)
			{
				// try to obtain the domain interface from the appropriate generated API
				type = codeTypeHandler.GetCodeType(sanitizedDomainType, version);
			}
			return type;
		}

		private static Type GetReturnType(string sanitizedDomainType)
		{
			// these might be legacy problems with the NFLD API (not released; for testing only)
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
					string packageName = ClassUtils.GetPackageName(typeof(OtherIdentifierRoleType));
					//.NET need to get namespace for domainvalue
					return (Type)Ca.Infoway.Messagebuilder.Runtime.GetType(packageName + "." + sanitizedDomainType);
				}
				catch (TypeLoadException)
				{
				}
			}
			// this is an expected result
			return null;
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
				// TM - could also try walking up each code's hierarchy looking for a compatible domain type
				//    - this only affects one group of types in MR2009, so I'll leave this as an enhancement
				if (code1 != code2)
				{
				}
			}
			// the following code was causing more noise than signal; should be logged properly if later deemed necessary to report
			//			if (StringUtils.isBlank(relationship1.getDomainType())) {
			//				System.out.println("WARNING: relationship seems to be missing a domainType (" + relationship1.getParentType() + "." + relationship1.getName() + ")");
			//			}
			//			if (StringUtils.isBlank(relationship2.getDomainType())) {
			//				System.out.println("WARNING: relationship seems to be missing a domainType (" + relationship2.getParentType() + "." + relationship2.getName() + ")");
			//			}
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
