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
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Basic
{
	/// <summary>PostalAdressUse enum.</summary>
	/// <remarks>
	/// PostalAdressUse enum.
	/// From http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#domain-PostalAddressUse
	/// </remarks>
	/// <author>Intelliware Development</author>
	[System.Serializable]
	public class X_BasicPostalAddressUse : EnumPattern, x_BasicPostalAddressUse
	{
		static X_BasicPostalAddressUse()
		{
		}

		private const long serialVersionUID = -4205269283911237833L;

		/// <summary>
		/// A communication address at a home, attempted contacts for business purposes
		/// might intrude privacy and chances are one will contact family or other household
		/// members instead of the person one wishes to call.
		/// </summary>
		/// <remarks>
		/// A communication address at a home, attempted contacts for business purposes
		/// might intrude privacy and chances are one will contact family or other household
		/// members instead of the person one wishes to call. Typically used with urgent
		/// cases, or if no other contacts are available.
		/// </remarks>
		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse HOME = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse
			("HOME", "H");

		/// <summary>An office address.</summary>
		/// <remarks>
		/// An office address. First choice for business related contacts during
		/// business hours.
		/// </remarks>
		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse WORK_PLACE = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse
			("WORK_PLACE", "WP");

		/// <summary>
		/// Indicates a work place address or telecommunication address that
		/// reaches the individual or organization directly without intermediaries.
		/// </summary>
		/// <remarks>
		/// Indicates a work place address or telecommunication address that
		/// reaches the individual or organization directly without intermediaries.
		/// For phones, often referred to as a 'private line'.
		/// </remarks>
		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse DIRECT = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse
			("DIRECT", "DIR");

		/// <summary>Indicates a confidential address</summary>
		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse CONFIDENTIAL = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse
			("CONFIDENTIAL", "CONF");

		/// <summary>A temporary address, may be good for visit or mailing.</summary>
		/// <remarks>
		/// A temporary address, may be good for visit or mailing. Note that an address
		/// history can provide more detailed information.
		/// </remarks>
		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse TEMPORARY = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse
			("TEMPORARY", "TMP");

		/// <summary>Used primarily to visit an address.</summary>
		/// <remarks>Used primarily to visit an address.</remarks>
		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse PHYSICAL = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse
			("PHYSICAL", "PHYS");

		/// <summary>Used to send mail.</summary>
		/// <remarks>Used to send mail.</remarks>
		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse POSTAL = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse
			("POSTAL", "PST");

		private readonly string codeValue;

		private X_BasicPostalAddressUse(string name, string codeValue) : base(name)
		{
			this.codeValue = codeValue;
		}

		/// <summary>Returns the code system for this postal address enum.</summary>
		/// <remarks>Returns the code system for this postal address enum.</remarks>
		/// <returns>the code system for this postal address enum</returns>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_POSTAL_ADDRESS_USE.Root;
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

		/// <summary>Returns the code value for this enum.</summary>
		/// <remarks>Returns the code value for this enum.</remarks>
		/// <returns>the code value</returns>
		public virtual string CodeValue
		{
			get
			{
				return this.codeValue;
			}
		}
	}
}
