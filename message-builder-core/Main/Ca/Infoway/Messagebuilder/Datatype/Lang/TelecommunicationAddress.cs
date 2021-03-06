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


/// ---------------------------------------------------------------------------------------------------
///  This file was automatically generated by J2CS Translator (http://j2cstranslator.sourceforge.net/). 
///  Version 1.0.0                                                                                      
/// ---------------------------------------------------------------------------------------------------
 
namespace Ca.Infoway.Messagebuilder.Datatype.Lang {
	
	using Ca.Infoway.Messagebuilder.Domainvalue;
	using Ca.Infoway.Messagebuilder.Platform;
    using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Runtime.CompilerServices;
	using System.Text;
	
	/// <summary>
	/// A class to represent CeRx's notion of a telecommunication address, such as a phone
	/// number, fax, email or http address.
	/// There are several parts to an tel address, but HL7 has dumped all the relevant 
	/// information into a single text field. Urp.
	/// The first part is the URL scheme. This is something like tel: or http:. CeRx limits 
	/// these based on the subclass of TEL (TEL.PHONEMAIL or TEL.URI).
	/// There are some number of uses for each address. CeRx limits this to three, which is
	/// not enforced by this class. For the TEL.URI subclass, use is not permitted at all.
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-TEL
	/// </summary>
	///
    public class TelecommunicationAddress : IEquatable<TelecommunicationAddress>
    {
	
		public sealed class AddressUsesComparator : IComparer<TelecommunicationAddressUse> {
			public int Compare(TelecommunicationAddressUse o1,
					TelecommunicationAddressUse o2) {
				return String.CompareOrdinal(o1.CodeValue, o2.CodeValue);
			}

            public AddressUsesComparator() {
			}
		}

        private static readonly AddressUsesComparator ADDRESS_USE_COMPARATOR = new AddressUsesComparator();
	
		private static readonly String SEPARATOR = ":";
		private static readonly String SLASHES = "//";
	
		private static readonly IList<String> URL_SCHEMES_REQUIRING_SLASHES = new List<String>();
		// add an ordering to the usage list for predictable ordering
        private List<TelecommunicationAddressUse> addressUses = new List<TelecommunicationAddressUse>();
        private IDictionary<PlatformDate, SetOperator> useablePeriods = new Dictionary<PlatformDate, SetOperator>();
	
		private URLScheme urlScheme;
		private String address;
	
		/// <summary>
		/// Constructs an empty telecom address.
		/// </summary>
		///
		public TelecommunicationAddress() {
        }
	
		/// <summary>
		/// Constructs a telecom address with a given scheme, address, and uses.
		/// </summary>
		///
		/// <param name="scheme">the url scheme for the telecom address (ftp, fax, etc.)</param>
		/// <param name="address_0">the actual "address" (phone number, etc) of the telecom address</param>
		/// <param name="uses">which uses are applicable to the given telecom address</param>
		public TelecommunicationAddress(URLScheme scheme, String address_0,
				params TelecommunicationAddressUse[] uses) {
            this.addressUses = new List<TelecommunicationAddressUse>();
			this.urlScheme = scheme;
			this.address = address_0;
			foreach (TelecommunicationAddressUse use in uses) {
				this.addressUses.Add(use);
                this.addressUses.Sort(ADDRESS_USE_COMPARATOR);
			}
		}
	
		/// <summary>
		/// Adds an address usage to a telecom address.
		/// </summary>
		///
		/// <param name="addressUse">an address usage</param>
		public void AddAddressUse(TelecommunicationAddressUse addressUse) {
			if (addressUse != null) {
				this.addressUses.Add(addressUse);
                this.addressUses.Sort(ADDRESS_USE_COMPARATOR);
			}
		}
	
		/// <summary>
		/// Returns all address uses for this telecom address.
		/// </summary>
		///
		/// <returns>all address uses</returns>
		public ICollection<TelecommunicationAddressUse> AddressUses {
		/// <summary>
		/// Returns all address uses for this telecom address.
		/// </summary>
		///
		/// <returns>all address uses</returns>
		  get {
				return this.addressUses;
			}
		}
		
	
		/// <summary>
		/// Sets a url scheme on the telecom address.
		/// </summary>
		///
		/// <param name="urlScheme_0">a url scheme</param>
		public URLScheme UrlScheme {
		/// <summary>
		/// Returns the telecom address usrl scheme.
		/// </summary>
		///
		/// <returns>the url scheme</returns>
		  get {
				return this.urlScheme;
			}
		/// <summary>
		/// Sets a url scheme on the telecom address.
		/// </summary>
		///
		/// <param name="urlScheme_0">a url scheme</param>
		  set {
				this.urlScheme = value;
			}
		}
		
	
		/// <summary>
		/// Sets the address.
		/// </summary>
		///
		/// <param name="address_0">the address</param>
		public String Address {
		/// <summary>
		/// Returns the actual address (phone number, etc) of this telecom address.
		/// </summary>
		///
		/// <returns>the address of this telecom address</returns>
		  get {
				return this.address;
			}
		/// <summary>
		/// Sets the address.
		/// </summary>
		///
		/// <param name="address_0">the address</param>
		  set {
				this.address = value;
			}
		}

        // Added for R2 usage only

        /// <summary>
        /// Useable periods or the given telecom address. The periods will be sorted internally.
        /// </summary>
        public IDictionary<PlatformDate, SetOperator> UseablePeriods {
            get {
                return this.useablePeriods;
            }
        }

        /// <summary>
        /// Convenience method for adding a period and inclusive operator.
        /// </summary>
        /// <param name="periodInTime"></param>
        /// <param name="setOperator"></param>
        /// <returns>whether the added period replaced an existing period</returns>
        public bool AddUseablePeriod(PlatformDate periodInTime, SetOperator setOperator) {
            // leave it up to the user to worry about a given time replacing an existing one
            SetOperator previousValue = UseablePeriods.ContainsKey(periodInTime) ? UseablePeriods[periodInTime] : null;
            UseablePeriods.Add(periodInTime, setOperator == null ? SetOperator.INCLUDE : setOperator);
            return previousValue != null;
        }
	
		/// <summary>
		/// Formats the telecom address into a string.
		/// </summary>
		///
		/// <returns>the formatted telecom address</returns>
		public override  System.String ToString() {
			StringBuilder buffer = new StringBuilder();
			if (this.urlScheme != null) {
				buffer.Append(urlScheme.CodeValue);
				buffer.Append(SEPARATOR);
				if (URL_SCHEMES_REQUIRING_SLASHES.Contains(this.urlScheme.CodeValue)) {
					buffer.Append(SLASHES);
				}
			}
			if (this.address != null) {
				buffer.Append(this.address);
			}
			return buffer.ToString();
		}
	
		static TelecommunicationAddress() {
			URL_SCHEMES_REQUIRING_SLASHES.Add("file");
			URL_SCHEMES_REQUIRING_SLASHES.Add("ftp");
			URL_SCHEMES_REQUIRING_SLASHES.Add("http");
			URL_SCHEMES_REQUIRING_SLASHES.Add("https");
			//URL_SCHEMES_REQUIRING_SLASHES.Add("mailto");
			URL_SCHEMES_REQUIRING_SLASHES.Add("nfs");
		}

        public override int GetHashCode()
        {
            return new HashCodeBuilder()
		            .Append(this.address)
		            .Append((IList<TelecommunicationAddressUse>)this.addressUses)
		            .Append(this.urlScheme)
                    .Append(UseablePeriods)
                    .ToHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            else if (obj.GetType() != GetType())
            {
                return false;
            } else {
                return Equals((TelecommunicationAddress) obj);
            }
        }

        public bool Equals(TelecommunicationAddress that)
        {
            return new EqualsBuilder()
                    .Append(this.address, that.address)
                    .Append((IList<TelecommunicationAddressUse>)this.addressUses, (IList<TelecommunicationAddressUse>)that.addressUses)
                    .Append(this.urlScheme, that.urlScheme)
                    .Append(this.UseablePeriods, that.UseablePeriods)
                    .IsEquals();
        }
	
	}
}
