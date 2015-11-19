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
using System;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Platform;
using ILOG.J2CsMapping.Text;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7
{
	public class IiValidationUtils
	{
		public static readonly string II = "II";

		public static readonly string II_TOKEN = "II.TOKEN";

		public static readonly string II_BUS = "II.BUS";

		public static readonly string II_PUBLIC = "II.PUBLIC";

		public static readonly string II_OID = "II.OID";

		public static readonly string II_VER = "II.VER";

		public static readonly string II_BUS_AND_VER = "II.BUS_AND_VER";

		public static readonly string II_BUSVER = "II.BUSVER";

		public static readonly string II_PUBLICVER = "II.PUBLICVER";

		public static readonly ICollection<string> concreteIiTypes = new HashSet<string>();

		static IiValidationUtils()
		{
			concreteIiTypes.Add(II_TOKEN);
			concreteIiTypes.Add(II_BUS);
			concreteIiTypes.Add(II_PUBLIC);
			concreteIiTypes.Add(II_OID);
			concreteIiTypes.Add(II_VER);
			concreteIiTypes.Add(II_BUSVER);
			concreteIiTypes.Add(II_PUBLICVER);
		}

		private const int EXTENSION_MAX_LENGTH = 20;

		private const int ROOT_MAX_LENGTH = 200;

		private const int ROOT_MAX_LENGTH_CERX = 100;

		public virtual bool IsOid(string root)
		{
			return IsOid(root, false);
		}

		public virtual bool IsOid(string root, bool isR2)
		{
			if (StringUtils.IsBlank(root) || !root.Contains("."))
			{
				return false;
			}
			else
			{
				if (isR2 && !(root[0] == '0' || root[0] == '1' || root[0] == '2'))
				{
					return false;
				}
				else
				{
					bool oid = true;
					while (root.Contains("."))
					{
						string prefix = StringUtils.SubstringBefore(root, ".");
						oid &= (StringUtils.IsNotBlank(prefix) && StringUtils.IsNumeric(prefix));
						root = StringUtils.SubstringAfter(root, ".");
					}
					if (StringUtils.IsBlank(root))
					{
						oid = false;
					}
					else
					{
						oid &= StringUtils.IsNumeric(root);
					}
					return oid;
				}
			}
		}

		public virtual bool IsUuid(string root)
		{
			// avoid trying to create a UUID - if not a uuid, the call is expensive (especially for .NET)
			if (root == null || !(root.Length == 36 || root.Length == 32))
			{
				return false;
			}
			try
			{
				UUID.FromString(root);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public virtual bool IsRuid(string root)
		{
			bool result = StringUtils.IsBlank(root) ? false : char.IsLetter(root[0]);
			for (int i = 0; result && i < root.Length; i++)
			{
				char ch = root[i];
				result &= (char.IsLetterOrDigit(ch) || ch == '-');
			}
			return result;
		}

		public virtual int GetMaxRootLength(StandardDataType type, VersionNumber version)
		{
			return SpecificationVersion.IsVersion(type, version, Hl7BaseVersion.CERX) ? ROOT_MAX_LENGTH_CERX : ROOT_MAX_LENGTH;
		}

		public virtual bool IsRootLengthInvalid(string root, StandardDataType type, VersionNumber version)
		{
			return StringUtils.Length(root) > GetMaxRootLength(type, version);
		}

		public virtual int GetMaxExtensionLength()
		{
			return EXTENSION_MAX_LENGTH;
		}

		public virtual bool IsExtensionLengthInvalid(string extension)
		{
			return StringUtils.Length(extension) > GetMaxExtensionLength();
		}

		public virtual bool IsCerxOrMr2007(VersionNumber version, StandardDataType type)
		{
			return SpecificationVersion.IsVersion(type, version, Hl7BaseVersion.MR2007) || SpecificationVersion.IsVersion(type, version
				, Hl7BaseVersion.CERX);
		}

		public virtual bool IsSpecializationTypeRequired(VersionNumber version, string type, bool isCda)
		{
			StandardDataType standardDataType = StandardDataType.GetByTypeName(type);
			// AB does not treat II as abstract; for CeRx, II is concrete; Newfoundland is excepted to allow our legacy tests to pass
			return IsIiBusAndVer(type) || (IsII(type) && !(isCda || SpecificationVersion.IsVersion(standardDataType, version, Hl7BaseVersion
				.CERX) || "NEWFOUNDLAND".Equals(version == null ? null : version.VersionLiteral) || SpecificationVersion.IsExactVersion(
				SpecificationVersion.V02R02_AB, version)));
		}

		public virtual bool IsIiBusAndVer(string type)
		{
			return StandardDataType.II_BUS_AND_VER.Type.Equals(type);
		}

		public virtual bool IsIiBusOrIiVer(string type)
		{
			return StandardDataType.II_BUS.Type.Equals(type) || StandardDataType.II_VER.Type.Equals(type);
		}

		public virtual bool IsII(string type)
		{
			return StandardDataType.II.Type.Equals(type);
		}

		public virtual string GetInvalidOrMissingSpecializationTypeErrorMessage(string type)
		{
			string invalidOrMissing = StringUtils.IsBlank(type) ? "Missing" : "Invalid";
			return invalidOrMissing + " specializationType" + (StringUtils.IsBlank(type) ? string.Empty : (" (" + type + ")")) + ". Field being left as II without a specializationType.";
		}

		public virtual string GetInvalidSpecializationTypeForBusAndVerErrorMessage(string specializationType, string type)
		{
			return "Specialization type must be II.BUS or II.VER; " + type + " will be assumed. Invalid specialization type " + specializationType;
		}

		public virtual string GetMissingAttributeErrorMessage(string type, string attributeName, string attributeValue)
		{
			return System.String.Format("Data type " + type + " requires the attribute {0}=\"{1}\"", attributeName, XmlStringEscape.Escape
				(attributeValue));
		}

		public virtual string GetIncorrectAttributeValueErrorMessage(string type, string attributeName, string attributeValue)
		{
			return System.String.Format("Data type " + type + " expected the attribute {0}=\"{1}\"", attributeName, XmlStringEscape.Escape
				(attributeValue));
		}

		public virtual string GetRootMustBeUuidErrorMessage(string root)
		{
			return "root '" + root + "' should be a UUID.";
		}

		public virtual string GetRootMustBeUuidRuidOidErrorMessage(string root)
		{
			return "root '" + root + "' must conform to be either a UUID, RUID, or OID.";
		}

		public virtual string GetInvalidRootLengthErrorMessage(string root, StandardDataType type, VersionNumber version)
		{
			return "root '" + root + "' exceeds maximum allowed length of " + GetMaxRootLength(type, version) + ".";
		}

		public virtual string GetInvalidExtensionLengthErrorMessage(string extension)
		{
			return "extension '" + extension + "' exceeds maximum allowed length of " + GetMaxExtensionLength() + ".";
		}

		public virtual string GetRootMustBeAnOidErrorMessage(string root)
		{
			return "The oid, \"" + root + "\" does not appear to be a valid oid";
		}

		public virtual string GetShouldNotProvideSpecializationTypeErrorMessage(string typeFromContext)
		{
			return "A specializationType should not be specified for non-abstract type: " + typeFromContext;
		}
	}
}
