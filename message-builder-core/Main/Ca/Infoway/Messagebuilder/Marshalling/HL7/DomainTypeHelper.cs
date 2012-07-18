using System;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7
{
	public class DomainTypeHelper
	{
		public static Type GetReturnType(Relationship relationship)
		{
			string domainType = relationship.DomainType;
			if (ClassUtils.GetShortClassName(typeof(HealthcareProviderRoleType)).EqualsIgnoreCase(domainType))
			{
				domainType = ClassUtils.GetShortClassName(typeof(HealthcareProviderRoleType));
			}
			else
			{
				if (ClassUtils.GetShortClassName(typeof(OtherIDsRoleCode)).Equals(domainType))
				{
					domainType = ClassUtils.GetShortClassName(typeof(OtherIdentifierRoleType));
				}
			}
			if (StringUtils.IsNotBlank(domainType))
			{
				try
				{
					return (Type)Ca.Infoway.Messagebuilder.Runtime.GetType(ClassUtils.GetPackageName(typeof(Ca.Infoway.Messagebuilder.Domainvalue.ActCode
						)) + "." + domainType);
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
			Type code1 = GetReturnType(relationship1);
			Type code2 = GetReturnType(relationship2);
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
	}
}
