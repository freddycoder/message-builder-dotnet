/**
 * Copyright 2012 Canada Health Infoway, Inc.
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
 * Last modified: $LastChangedDate: 2011-05-17 11:48:36 -0400 (Tue, 17 May 2011) $
 * Revision:      $LastChangedRevision: 2666 $
 */


using System;
using System.IO;
using NUnit;

namespace Platform.SimpleXml
{
	[NUnit.Framework.TestFixture]
	public class PersisterTest
	{
		[NUnit.Framework.Test]
		public void ShouldReadSimpleXml() {
			
			byte[] a = System.Text.Encoding.GetEncoding("iso-8859-1").GetBytes("<mockElement name=\"fred\"></mockElement>");
			MemoryStream stream = new MemoryStream(a);			
			
			MockElement o = (MockElement) new Persister().Read(typeof(MockElement), stream);
			NUnit.Framework.Assert.IsNotNull(o, "object");
			NUnit.Framework.Assert.AreEqual(o.Name, "fred", "name");
		}

		[NUnit.Framework.Test]
		public void ShouldReadSimpleXmlWithNestedElement() {
			
			byte[] a = System.Text.Encoding.GetEncoding("iso-8859-1").GetBytes("<mockElement><test /></mockElement>");
			MemoryStream stream = new MemoryStream(a);			
			
			MockElement o = (MockElement) new Persister().Read(typeof(MockElement), stream);
			NUnit.Framework.Assert.IsNotNull(o, "object");
			NUnit.Framework.Assert.IsNotNull(o.Test, "myTest");
		}
	}
}
