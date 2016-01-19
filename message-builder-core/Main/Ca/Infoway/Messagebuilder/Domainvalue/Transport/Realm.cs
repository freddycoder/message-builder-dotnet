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


using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Transport
{
	/// <summary>The Enum Realm.</summary>
	/// <remarks>
	/// The Enum Realm.
	/// Coded concepts representing Binding Realms (used for Context Binding of
	/// terminology in HL7 models) and/or Namespace Realms (used to help ensure
	/// unique identification of HL7 artifacts). This code system is partitioned
	/// into three sections: Affiliate realms, Binding realms and Namespace realms.
	/// All affiliate realm codes may automatically be used as both binding realms
	/// and namespace realms.  Furthermore, affiliate realms are the only realms
	/// that have authority over the creation of binding realms.  (Note that
	/// 'affiliate' includes the idea of both international affiliates and the HL7
	/// International organization.)  All other codes must be associated with an
	/// owning affiliate realm and must appear as a specialization of _BindingRealm
	/// or _NamespaceRealm.  For affiliates whose concepts align with nations, the
	/// country codes from ISO 3166-1 2-character alpha are used for the code when
	/// possible so these codes should not be used for other realm types.  It is
	/// recommended that binding realm and namespace codes submitted by affiliates
	/// use the realm code as a prefix to avoid possible collisions with ISO codes.
	/// However, tooling does not currently support namepace realm codes greater
	/// than 2 characters.
	/// </remarks>
	[System.Serializable]
	public class Realm : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.Realm
	{
		static Realm()
		{
		}

		private const long serialVersionUID = 349005342052736851L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm ARGENTINA = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("ARGENTINA", "AR");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm AUSTRIA = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("AUSTRIA", "AT");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm AUSTRALIA = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("AUSTRALIA", "AU");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm BRAZIL = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("BRAZIL", "BR");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm CANADA = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("CANADA", "CA");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm SWITZERLAND = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("SWITZERLAND", "CH");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm CHILE = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("CHILE", "CL");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm CHINA = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("CHINA", "CN");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm COLUMBIA = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("COLUMBIA", "CO");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm CZECH_REPUBLIC = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("CZECH_REPUBLIC", "CZ");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm GERMANY = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("GERMANY", "DE");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm DENMARK = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("DENMARK", "DK");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm SPAIN = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("SPAIN", "ES");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm FINLAND = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("FINLAND", "FI");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm FRANCE = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("FRANCE", "FR");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm GREECE = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("GREECE", "GR");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm CROATIA = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("CROATIA", "HR");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm IRELAND = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("IRELAND", "IE");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm INDIA = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("INDIA", "IN");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm ITALY = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("ITALY", "IT");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm JAPAN = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("JAPAN", "JP");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm KOREA = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("KOREA", "KR");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm LITHUANIA = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("LITHUANIA", "LT");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm MEXICO = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("MEXICO", "MX");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm THE_NETHERLANDS = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("THE_NETHERLANDS", "NL");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm NEW_ZEALAND = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("NEW_ZEALAND", "NZ");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm ROMANIA = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("ROMANIA", "RO");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm RUSSIAN_FEDERATION = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("RUSSIAN_FEDERATION", "RU");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm SWEDEN = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("SWEDEN", "SE");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm SINGAPORE = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("SINGAPORE", "SG");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm SOUTHERN_AFRICA = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("SOUTHERN_AFRICA", "SOA");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm TURKEY = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("TURKEY", "TR");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm TAIWAN = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("TAIWAN", "TW");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm UNITED_KINGDOM = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("UNITED_KINGDOM", "UK");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm UNITED_STATES_OF_AMERICA = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("UNITED_STATES_OF_AMERICA", "US");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm UNIVERSAL = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("UNIVERSAL", "UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm URUGUAY = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("URUGUAY", "UY");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm UNCLASSIFIED_REALM = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("UNCLASSIFIED_REALM", "C1");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm GREAT_BRITAIN = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("GREAT_BRITAIN", "GB");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm REPRESENTATIVE_REALM = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("REPRESENTATIVE_REALM", "R1");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm EXAMPLE_REALM = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("EXAMPLE_REALM", "X1");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm LOCALIZED_VERSION = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("LOCALIZED_VERSION", "ZZ");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm ALBERTA = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("ALBERTA", "AB");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm BRITISH_COLUMBIA = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("BRITISH_COLUMBIA", "BC");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm MANITOBA = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("MANITOBA", "MB");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm NEW_BRUNSWICK = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("NEW_BRUNSWICK", "NB");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm NEWFOUNDLAND_AND_LABRADOR = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("NEWFOUNDLAND_AND_LABRADOR", "NL");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm NORTHWEST_TERRITORIES = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("NORTHWEST_TERRITORIES", "NT");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm NUNAVUT = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("NUNAVUT", "NU");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm NOVA_SCOTIA = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("NOVA_SCOTIA", "NS");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm ONTARIO = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("ONTARIO", "ON");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm PRINCE_EDWARD_ISLAND = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("PRINCE_EDWARD_ISLAND", "PE");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm QUEBEC = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("QUEBEC", "QC");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm SASKATCHEWAN = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("SASKATCHEWAN", "SK");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm YUKON_TERRITORY = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.Realm
			("YUKON_TERRITORY", "YT");

		private readonly string codeValue;

		private Realm(string name, string codeValue) : base(name)
		{
			// Extra-normative codes used for Canadian jurisdictions
			// Note conflict with normative code "NL" for The Netherlands.
			this.codeValue = codeValue;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeValue
		{
			get
			{
				return this.codeValue;
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_HL7_REALM.Root;
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystemName
		{
			get
			{
				return null;
			}
		}
	}
}
