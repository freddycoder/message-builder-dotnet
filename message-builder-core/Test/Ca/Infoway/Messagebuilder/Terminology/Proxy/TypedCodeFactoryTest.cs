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
