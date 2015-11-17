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
using Ca.Infoway.Messagebuilder.Codesystem;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Terminology.Proxy;
using ILOG.J2CsMapping.Collections.Generics;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Terminology.Proxy
{
	[TestFixture]
	public class TypedCodeFactoryTest
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldProduceResultThatImplementsAllInterfaces()
		{
			Code code = new TypedCodeFactory().Create(typeof(AcknowledgementDetailType), new HashSet<Type>(Arrays.AsList(typeof(AcknowledgementDetailType
				), typeof(ActIssuePriority))), "E", CodeSystem.VOCABULARY_ACKNOWLEDGEMENT_DETAIL_TYPE.Root, CodeSystem.VOCABULARY_ACKNOWLEDGEMENT_DETAIL_TYPE
				.Name, new Dictionary<string, string>(), 0, true, true);
			Assert.IsTrue(code is AcknowledgementDetailType, "AcknowledgementDetailType");
			Assert.IsTrue(code is ActIssuePriority, "ActIssuePriority");
		}
	}
}
