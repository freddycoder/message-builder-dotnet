using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Util.Xml;
using ILOG.J2CsMapping.Text;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7
{
	public class TelValidationUtils
	{
		private const int MAX_USES = 3;

		private const int MAX_VALUE_LENGTH_EMAIL = 50;

		private const int MAX_VALUE_LENGTH_URI = 255;

		private const int MAX_VALUE_LENGTH_PHONE_MR2009 = 40;

		private const int MAX_VALUE_LENGTH_PHONE_MR2007_CERX = 25;

		private static readonly ICollection<string> ALLOWABLE_TELECOM_USES = new HashSet<string>();

		private static readonly IDictionary<string, ICollection<string>> ALLOWABLE_SCHEMES_BY_TYPE = new Dictionary<string, ICollection
			<string>>();

		private static readonly ICollection<string> ALLOWABLE_PHONE_SCHEMES = new HashSet<string>();

		private static readonly ICollection<string> ALLOWABLE_EMAIL_SCHEMES = new HashSet<string>();

		private static readonly ICollection<string> ALLOWABLE_URI_SCHEMES = new HashSet<string>();

		static TelValidationUtils()
		{
			ALLOWABLE_TELECOM_USES.Add("WP");
			ALLOWABLE_TELECOM_USES.Add("TMP");
			ALLOWABLE_TELECOM_USES.Add("MC");
			ALLOWABLE_TELECOM_USES.Add("PG");
			// n/a for email
			ALLOWABLE_TELECOM_USES.Add("H");
			ALLOWABLE_TELECOM_USES.Add("EC");
			ALLOWABLE_TELECOM_USES.Add("CONF");
			// n/a for MR2007 or CeRx
			ALLOWABLE_TELECOM_USES.Add("DIR");
			// n/a for CeRx
			ALLOWABLE_PHONE_SCHEMES.Add("fax");
			ALLOWABLE_PHONE_SCHEMES.Add("tel");
			ALLOWABLE_EMAIL_SCHEMES.Add("mailto");
			ALLOWABLE_URI_SCHEMES.Add("file");
			ALLOWABLE_URI_SCHEMES.Add("ftp");
			ALLOWABLE_URI_SCHEMES.Add("http");
			ALLOWABLE_URI_SCHEMES.Add("https");
			ALLOWABLE_URI_SCHEMES.Add("mailto");
			ALLOWABLE_URI_SCHEMES.Add("nfs");
			ALLOWABLE_SCHEMES_BY_TYPE["TEL.PHONE"] = ALLOWABLE_PHONE_SCHEMES;
			ALLOWABLE_SCHEMES_BY_TYPE["TEL.EMAIL"] = ALLOWABLE_EMAIL_SCHEMES;
			ALLOWABLE_SCHEMES_BY_TYPE["TEL.URI"] = ALLOWABLE_URI_SCHEMES;
		}

		public virtual void ValidateTelecommunicationAddress(TelecommunicationAddress telecomAddress, string type, string specializationType
			, VersionNumber version, XmlElement element, string propertyPath, Hl7Errors errors)
		{
			string actualType = DetermineActualType(telecomAddress, type, specializationType, version, element, propertyPath, errors, 
				true);
			ValidateTelecomAddressUses(telecomAddress, actualType, version, element, propertyPath, errors);
			ValidateTelecomAddressScheme(telecomAddress, actualType, version.GetBaseVersion(), element, propertyPath, errors);
			ValidateTelecomAddressValue(telecomAddress, actualType, version, element, propertyPath, errors);
		}

		public virtual string DetermineActualType(TelecommunicationAddress telecomAddress, string type, string specializationType
			, VersionNumber version, XmlElement element, string propertyPath, Hl7Errors errors, bool logErrors)
		{
			string actualType = type;
			bool isTelAll = StandardDataType.TEL_ALL.Type.Equals(type);
			bool isTelPhonemail = StandardDataType.TEL_PHONEMAIL.Type.Equals(type);
			if (isTelAll || isTelPhonemail)
			{
				if (IsCeRxOrNewfoundland(version))
				{
					Ca.Infoway.Messagebuilder.Domainvalue.URLScheme urlScheme = telecomAddress.UrlScheme;
					if ("mailto".Equals(urlScheme == null ? null : urlScheme.CodeValue))
					{
						actualType = "TEL.EMAIL";
					}
					else
					{
						actualType = "TEL.PHONE";
					}
				}
				else
				{
					if (StringUtils.IsBlank(specializationType))
					{
						if (logErrors)
						{
							string errorMessage = System.String.Format("No specialization type provided. Specialization type of TEL.PHONE/TEL.EMAIL{0} must be specified for abstract data type {1}. Assuming TEL.PHONE"
								, isTelAll ? "/TEL.URI" : string.Empty, type);
							CreateError(errorMessage, element, propertyPath, errors);
						}
						actualType = "TEL.PHONE";
					}
					else
					{
						if (!StandardDataType.TEL_PHONE.Type.Equals(specializationType) && !StandardDataType.TEL_EMAIL.Type.Equals(specializationType
							) && !(StandardDataType.TEL_URI.Type.Equals(specializationType) && isTelAll))
						{
							if (logErrors)
							{
								string errorMessage = System.String.Format("Invalid specialization type provided. Specialization type of TEL.PHONE/TEL.EMAIL{0} must be specified for abstract data type {1}. Assuming TEL.PHONE"
									, isTelAll ? "/TEL.URI" : string.Empty, type);
								CreateError(errorMessage, element, propertyPath, errors);
							}
							actualType = "TEL.PHONE";
						}
						else
						{
							actualType = specializationType;
						}
					}
				}
			}
			return actualType;
		}

		private void ValidateTelecomAddressValue(TelecommunicationAddress telecomAddress, string type, VersionNumber version, XmlElement
			 element, string propertyPath, Hl7Errors errors)
		{
			Hl7BaseVersion baseVersion = version.GetBaseVersion();
			string address = telecomAddress.Address;
			int schemePlusAddressLength = telecomAddress.ToString().Length;
			if (StringUtils.IsBlank(address))
			{
				CreateError("TelecomAddress must have a value for the actual address", element, propertyPath, errors);
			}
			else
			{
				if (StandardDataType.TEL_EMAIL.Type.Equals(type) && schemePlusAddressLength > MAX_VALUE_LENGTH_EMAIL)
				{
					CreateMaxLengthError(schemePlusAddressLength, MAX_VALUE_LENGTH_EMAIL, type, baseVersion, element, propertyPath, errors);
				}
				else
				{
					if (StandardDataType.TEL_URI.Type.Equals(type) && schemePlusAddressLength > MAX_VALUE_LENGTH_URI)
					{
						CreateMaxLengthError(schemePlusAddressLength, MAX_VALUE_LENGTH_URI, type, baseVersion, element, propertyPath, errors);
					}
					else
					{
						if (StandardDataType.TEL_PHONE.Type.Equals(type))
						{
							if (IsMr2007(baseVersion) || IsCeRxOrNewfoundland(version))
							{
								if (schemePlusAddressLength > MAX_VALUE_LENGTH_PHONE_MR2007_CERX)
								{
									CreateMaxLengthError(schemePlusAddressLength, MAX_VALUE_LENGTH_PHONE_MR2007_CERX, type, baseVersion, element, propertyPath
										, errors);
								}
							}
							else
							{
								if (schemePlusAddressLength > MAX_VALUE_LENGTH_PHONE_MR2009)
								{
									CreateMaxLengthError(schemePlusAddressLength, MAX_VALUE_LENGTH_PHONE_MR2009, type, baseVersion, element, propertyPath, errors
										);
								}
							}
						}
					}
				}
			}
		}

		private void CreateMaxLengthError(int addressLength, int maxLength, string type, Hl7BaseVersion baseVersion, XmlElement element
			, string propertyPath, Hl7Errors errors)
		{
			CreateError(type + " value (scheme + address) limited to a length of " + maxLength + " for " + baseVersion + " (length was "
				 + addressLength + ")", element, propertyPath, errors);
		}

		private void ValidateTelecomAddressScheme(TelecommunicationAddress telecomAddress, string type, Hl7BaseVersion baseVersion
			, XmlElement element, string propertyPath, Hl7Errors errors)
		{
			Ca.Infoway.Messagebuilder.Domainvalue.URLScheme urlScheme = telecomAddress.UrlScheme;
			string urlSchemeValue = (urlScheme == null ? null : urlScheme.CodeValue.ToLower());
			if (urlScheme == null)
			{
				CreateError("TelecomAddress must have a valid URL scheme (e.g. 'http://')", element, propertyPath, errors);
			}
			else
			{
				if (StandardDataType.TEL.Type.Equals(type))
				{
					// any known scheme should be ok here
					ICollection<ICollection<string>> values = ALLOWABLE_SCHEMES_BY_TYPE.Values;
					foreach (ICollection<string> set in values)
					{
						if (set.Contains(urlSchemeValue))
						{
							return;
						}
					}
					// we're good here
					CreateError("TelecomAddressScheme " + urlScheme.CodeValue + " is not valid for " + type, element, propertyPath, errors);
				}
				else
				{
					ICollection<string> allowableSchemes = ALLOWABLE_SCHEMES_BY_TYPE.SafeGet(type);
					if (allowableSchemes == null || !allowableSchemes.Contains(urlSchemeValue))
					{
						CreateError("TelecomAddressScheme " + urlScheme.CodeValue + " is not valid for " + type, element, propertyPath, errors);
					}
				}
			}
		}

		private void ValidateTelecomAddressUses(TelecommunicationAddress telecomAddress, string type, VersionNumber version, XmlElement
			 element, string propertyPath, Hl7Errors errors)
		{
			int numUses = telecomAddress.AddressUses.Count;
			bool isUri = StandardDataType.TEL_URI.Type.Equals(type);
			if (isUri && numUses > 0)
			{
				// error if > 0 and URI
				CreateError("TelecomAddressUses are not allowed for TEL.URI", element, propertyPath, errors);
			}
			else
			{
				if (numUses > MAX_USES)
				{
					// error if more than 3 uses
					CreateError("A maximum of 3 TelecomAddressUses are allowed (number found: " + numUses + ")", element, propertyPath, errors
						);
				}
			}
			if (!isUri)
			{
				foreach (Ca.Infoway.Messagebuilder.Domainvalue.TelecommunicationAddressUse telecomAddressUse in telecomAddress.AddressUses)
				{
					if (!IsAllowableUse(type, telecomAddressUse, version))
					{
						CreateError("TelecomAddressUse is not valid: " + (telecomAddressUse == null ? "null" : telecomAddressUse.CodeValue), element
							, propertyPath, errors);
					}
				}
			}
		}

		public virtual bool IsAllowableUse(string dataType, Ca.Infoway.Messagebuilder.Domainvalue.TelecommunicationAddressUse telecomAddressUse
			, VersionNumber version)
		{
			Hl7BaseVersion baseVersion = version.GetBaseVersion();
			return !StandardDataType.TEL_URI.Type.Equals(dataType) && telecomAddressUse != null && telecomAddressUse.CodeValue != null
				 && ALLOWABLE_TELECOM_USES.Contains(telecomAddressUse.CodeValue != null ? telecomAddressUse.CodeValue.ToUpper() : null) 
				&& !(StandardDataType.TEL_EMAIL.Type.Equals(dataType) && IsPgConfDir(telecomAddressUse)) && !(IsMr2007(baseVersion) && IsConf
				(telecomAddressUse)) && !(IsCeRxOrNewfoundland(version) && IsConfOrDir(telecomAddressUse));
		}

		private bool IsMr2007(Hl7BaseVersion baseVersion)
		{
			return baseVersion == Hl7BaseVersion.MR2007;
		}

		private bool IsCeRxOrNewfoundland(VersionNumber version)
		{
			return version.GetBaseVersion() == Hl7BaseVersion.CERX || "NEWFOUNDLAND".Equals(version.VersionLiteral);
		}

		private bool IsConfOrDir(Ca.Infoway.Messagebuilder.Domainvalue.TelecommunicationAddressUse telecomAddressUse)
		{
			return IsConf(telecomAddressUse) || Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.DIRECT.CodeValue
				.Equals(telecomAddressUse.CodeValue);
		}

		private bool IsConf(Ca.Infoway.Messagebuilder.Domainvalue.TelecommunicationAddressUse telecomAddressUse)
		{
			return Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.CONFIDENTIAL.CodeValue.Equals(telecomAddressUse
				.CodeValue);
		}

		private bool IsPgConfDir(Ca.Infoway.Messagebuilder.Domainvalue.TelecommunicationAddressUse telecomAddressUse)
		{
			return Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.PAGER.CodeValue.Equals(telecomAddressUse.CodeValue
				) || IsConfOrDir(telecomAddressUse);
		}

		private void CreateError(string errorMessage, XmlElement element, string propertyPath, Hl7Errors errors)
		{
			Hl7Error error = null;
			if (element != null)
			{
				error = new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, errorMessage + " (" + XmlDescriber.DescribeSingleElement(element) + ")"
					, element);
			}
			else
			{
				// assuming this has a property path
				error = new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, errorMessage, propertyPath);
			}
			errors.AddHl7Error(error);
		}
	}
}
