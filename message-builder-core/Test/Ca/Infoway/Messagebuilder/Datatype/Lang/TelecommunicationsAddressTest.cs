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
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Datatype.Lang
{
	[TestFixture]
	public class TelecommunicationsAddressTest
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestAddressUseOrdering()
		{
			TelecommunicationAddress address = new TelecommunicationAddress();
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.WORKPLACE);
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.EMERGENCY_CONTACT);
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.ANSWERING_MACHINE);
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.DIRECT);
			IEnumerator<Ca.Infoway.Messagebuilder.Domainvalue.TelecommunicationAddressUse> i = address.AddressUses.GetEnumerator();
			i.MoveNext();
			//for sharpen .NET mapping
			Assert.AreEqual(i.Current.CodeValue, Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.ANSWERING_MACHINE
				.CodeValue);
			i.MoveNext();
			//for sharpen .NET mapping
			Assert.AreEqual(i.Current.CodeValue, Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.DIRECT.CodeValue
				);
			i.MoveNext();
			//for sharpen .NET mapping
			Assert.AreEqual(i.Current.CodeValue, Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.EMERGENCY_CONTACT
				.CodeValue);
			i.MoveNext();
			//for sharpen .NET mapping
			Assert.AreEqual(i.Current.CodeValue, Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.WORKPLACE.CodeValue
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestToString()
		{
			AssertToStringAsExpected(null, null, string.Empty);
			AssertToStringAsExpected(null, "monkey", "monkey");
			AssertToStringAsExpected(Ca.Infoway.Messagebuilder.Domainvalue.Basic.URLScheme.MAILTO, null, "mailto:");
			AssertToStringAsExpected(Ca.Infoway.Messagebuilder.Domainvalue.Basic.URLScheme.MAILTO, "address@host", "mailto:address@host"
				);
			AssertToStringAsExpected(Ca.Infoway.Messagebuilder.Domainvalue.Basic.URLScheme.FAX, null, "fax:");
			AssertToStringAsExpected(Ca.Infoway.Messagebuilder.Domainvalue.Basic.URLScheme.FAX, "1234", "fax:1234");
			AssertToStringAsExpected(Ca.Infoway.Messagebuilder.Domainvalue.Basic.URLScheme.FILE, null, "file://");
			AssertToStringAsExpected(Ca.Infoway.Messagebuilder.Domainvalue.Basic.URLScheme.FILE, "c:/monkey", "file://c:/monkey");
			AssertToStringAsExpected(Ca.Infoway.Messagebuilder.Domainvalue.Basic.URLScheme.FTP, null, "ftp://");
			AssertToStringAsExpected(Ca.Infoway.Messagebuilder.Domainvalue.Basic.URLScheme.FTP, "somehost", "ftp://somehost");
			AssertToStringAsExpected(Ca.Infoway.Messagebuilder.Domainvalue.Basic.URLScheme.HTTP, null, "http://");
			AssertToStringAsExpected(Ca.Infoway.Messagebuilder.Domainvalue.Basic.URLScheme.HTTP, "somehost", "http://somehost");
			AssertToStringAsExpected(Ca.Infoway.Messagebuilder.Domainvalue.Basic.URLScheme.HTTPS, null, "https://");
			AssertToStringAsExpected(Ca.Infoway.Messagebuilder.Domainvalue.Basic.URLScheme.HTTPS, "somehost", "https://somehost");
			AssertToStringAsExpected(Ca.Infoway.Messagebuilder.Domainvalue.Basic.URLScheme.NFS, null, "nfs://");
			AssertToStringAsExpected(Ca.Infoway.Messagebuilder.Domainvalue.Basic.URLScheme.NFS, "somehost", "nfs://somehost");
			AssertToStringAsExpected(Ca.Infoway.Messagebuilder.Domainvalue.Basic.URLScheme.TEL, null, "tel:");
			AssertToStringAsExpected(Ca.Infoway.Messagebuilder.Domainvalue.Basic.URLScheme.TEL, "1234", "tel:1234");
		}

		/// <exception cref="System.Exception"></exception>
		public virtual void AssertToStringAsExpected(Ca.Infoway.Messagebuilder.Domainvalue.URLScheme urlScheme, string address, string
			 expectedValue)
		{
			TelecommunicationAddress telecommunicationAddress = new TelecommunicationAddress();
			telecommunicationAddress.UrlScheme = urlScheme;
			telecommunicationAddress.Address = address;
			Assert.AreEqual(expectedValue, telecommunicationAddress.ToString(), "value");
		}
	}
}
