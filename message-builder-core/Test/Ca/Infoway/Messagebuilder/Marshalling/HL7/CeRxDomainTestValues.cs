using Ca.Infoway.Messagebuilder.Marshalling.HL7;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7
{
	public class CeRxDomainTestValues
	{
		public class URLSchemeImpl : Ca.Infoway.Messagebuilder.Domainvalue.URLScheme
		{
			private readonly string codeValue;

			public URLSchemeImpl(string codeValue)
			{
				this.codeValue = codeValue;
			}

			public virtual string CodeValue
			{
				get
				{
					return codeValue;
				}
			}

			public virtual string CodeSystem
			{
				get
				{
					return string.Empty;
				}
			}
		}

		public class TelecommunicationUsageTypeImpl : Ca.Infoway.Messagebuilder.Domainvalue.TelecommunicationAddressUse
		{
			private readonly string codeValue;

			public TelecommunicationUsageTypeImpl(string codeValue)
			{
				this.codeValue = codeValue;
			}

			public virtual string CodeValue
			{
				get
				{
					return codeValue;
				}
			}

			public virtual string CodeSystem
			{
				get
				{
					return string.Empty;
				}
			}
		}

		public class UnitImpl : Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive
		{
			private readonly string codeValue;

			public UnitImpl(string codeValue)
			{
				this.codeValue = codeValue;
			}

			public virtual string CodeValue
			{
				get
				{
					return codeValue;
				}
			}

			public virtual string CodeSystem
			{
				get
				{
					return string.Empty;
				}
			}
		}

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.URLScheme TELEPHONE = new CeRxDomainTestValues.URLSchemeImpl
			("tel");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.URLScheme FAX = new CeRxDomainTestValues.URLSchemeImpl("fax"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.URLScheme MAILTO = new CeRxDomainTestValues.URLSchemeImpl("mailto"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.URLScheme FILE = new CeRxDomainTestValues.URLSchemeImpl("file"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.URLScheme FTP = new CeRxDomainTestValues.URLSchemeImpl("ftp"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.URLScheme HTTP = new CeRxDomainTestValues.URLSchemeImpl("http"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.URLScheme HTTPS = new CeRxDomainTestValues.URLSchemeImpl("https"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.URLScheme MLLP = new CeRxDomainTestValues.URLSchemeImpl("mllp"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.URLScheme MODEM = new CeRxDomainTestValues.URLSchemeImpl("modem"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.URLScheme TELNET = new CeRxDomainTestValues.URLSchemeImpl("telnet"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.URLScheme NFS = new CeRxDomainTestValues.URLSchemeImpl("nfs"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.TelecommunicationAddressUse HOME_ADDRESS = new CeRxDomainTestValues.TelecommunicationUsageTypeImpl
			("H");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.TelecommunicationAddressUse WORK_PLACE = new CeRxDomainTestValues.TelecommunicationUsageTypeImpl
			("WP");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.TelecommunicationAddressUse TEMPORARY_ADDRESS = new CeRxDomainTestValues.TelecommunicationUsageTypeImpl
			("TMP");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.TelecommunicationAddressUse PAGER = new CeRxDomainTestValues.TelecommunicationUsageTypeImpl
			("PG");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.TelecommunicationAddressUse MOBILE_CONTACT = new CeRxDomainTestValues.TelecommunicationUsageTypeImpl
			("MC");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.TelecommunicationAddressUse EMERGENCY_CONTACT = new CeRxDomainTestValues.TelecommunicationUsageTypeImpl
			("EC");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.TelecommunicationAddressUse VACATION_HOME = new CeRxDomainTestValues.TelecommunicationUsageTypeImpl
			("HV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.TelecommunicationAddressUse PUBLIC = new CeRxDomainTestValues.TelecommunicationUsageTypeImpl
			("PUB");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.TelecommunicationAddressUse PRIMARY_HOME = new CeRxDomainTestValues.TelecommunicationUsageTypeImpl
			("HP");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.TelecommunicationAddressUse DIRECT = new CeRxDomainTestValues.TelecommunicationUsageTypeImpl
			("DIR");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.TelecommunicationAddressUse BAD_ADDRESS = new CeRxDomainTestValues.TelecommunicationUsageTypeImpl
			("BAD");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.TelecommunicationAddressUse ANSWERING_SERVICE = new CeRxDomainTestValues.TelecommunicationUsageTypeImpl
			("AS");

		public static Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive CENTIMETRE = new CeRxDomainTestValues.UnitImpl
			("cm");

		public static Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive ENZYME_UNIT_MICROMOLES_MINUTE_PER_LITRE = 
			new CeRxDomainTestValues.UnitImpl("U/l");

		public static Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive FLUID_OUNCE = new CeRxDomainTestValues.UnitImpl
			("[foz_br]");

		public static Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive KILOGRAM = new CeRxDomainTestValues.UnitImpl
			("kg");

		public static Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive MILLIMETER = new CeRxDomainTestValues.UnitImpl
			("mm");

		public static Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive MILLIGRAM = new CeRxDomainTestValues.UnitImpl
			("mg");
	}
}
