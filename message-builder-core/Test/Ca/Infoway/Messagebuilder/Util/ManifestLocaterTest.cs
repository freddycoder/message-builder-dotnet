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
using System.Collections.Generic;
using System.Reflection;
using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Marshalling;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Util
{
	[TestFixture]
	public class ManifestLocaterTest
	{

        [NUnit.Framework.SetUp]
        public virtual void SetUp()
        {
           Assembly.LoadFrom("../../TestResource/message-builder-release-mock-mr2009.dll");
        }

        [Test]
		public virtual void TestLoadVersions()
		{
            Dictionary<Assembly, string[]> manifestsWithVersionAttribute = new ManifestLocater().GetAssembliesWithVersionAttribute(typeof(MbtModelVersionNumberAttribute));
			Assert.AreEqual(1, manifestsWithVersionAttribute.Keys.Count);
			IEnumerator<Assembly> iterator = manifestsWithVersionAttribute.Keys.GetEnumerator();
			iterator.MoveNext();
			Assembly assembly = iterator.Current;
			string[] versions = manifestsWithVersionAttribute[assembly];
			Assert.AreEqual(1, versions.Length);
			Assert.AreEqual(MockVersionNumber.MOCK_MR2009.VersionLiteral, versions[0]);
		}
	}
}
