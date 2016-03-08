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


using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class TsFullDateWithTimePropertyFormatterTest
	{
		private TsFullDateWithTimePropertyFormatter formatter = new TsFullDateWithTimePropertyFormatter();

		[Test]
		public virtual void ShouldProduceResultWithFullDateSpecializationType()
		{
			ModelToXmlResult result = new ModelToXmlResult();
			PlatformDate date = DateUtil.GetDate(1999, 3, 23);
			TS ts = new TSImpl(date);
			ts.DataType = StandardDataType.TS_FULLDATE;
			FormatContext context = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(result, null, "tsValue"
				, "TS.FULLDATEWITHTIME", null, null, false, SpecificationVersion.R02_04_02, null, null, null, false);
			string xmlOutput = this.formatter.Format(context, ts);
			Assert.IsTrue(result.GetHl7Errors().IsEmpty(), "no errors");
			Assert.AreEqual("<tsValue specializationType=\"TS.FULLDATE\" value=\"19990423\" xsi:type=\"TS\"/>", xmlOutput.Trim(), "output as expected"
				);
		}

		[Test]
		public virtual void ShouldProduceResultWithFullDateTimeSpecializationType()
		{
			ModelToXmlResult result = new ModelToXmlResult();
			PlatformDate date = DateUtil.GetDate(1999, 3, 23, 1, 2, 3, 0);
			TS ts = new TSImpl(date);
			ts.DataType = StandardDataType.TS_FULLDATETIME;
			FormatContext context = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(result, null, "tsValue"
				, "TS.FULLDATEWITHTIME", null, null, false, SpecificationVersion.R02_04_02, null, null, null, false);
			string xmlOutput = this.formatter.Format(context, ts);
			// avoid having to assess the timezone
			Assert.IsTrue(result.GetHl7Errors().IsEmpty(), "no errors");
			Assert.IsTrue(xmlOutput.Trim().StartsWith("<tsValue specializationType=\"TS.FULLDATETIME\" value=\"19990423010203.0000"));
			Assert.IsTrue(xmlOutput.Trim().EndsWith("\" xsi:type=\"TS\"/>"));
		}

		[Test]
		public virtual void ShouldProduceResultWithMissingSpecializationTypeError()
		{
			ModelToXmlResult result = new ModelToXmlResult();
			PlatformDate date = DateUtil.GetDate(1999, 3, 23, 1, 2, 3, 0);
			TS ts = new TSImpl(date);
			FormatContext context = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(result, null, "tsValue"
				, "TS.FULLDATEWITHTIME", null, null, false, SpecificationVersion.R02_04_02, null, null, null, false);
			string xmlOutput = this.formatter.Format(context, ts);
			Assert.AreEqual(1, result.GetHl7Errors().Count, "1 error");
			Assert.AreEqual("No specializationType provided. Value should be one of TS.FULLDATE / TS.FULLDATETIME / TS.FULLDATEPARTTIME. TS.FULLDATETIME will be assumed."
				, result.GetHl7Errors()[0].GetMessage());
			// avoid having to assess the timezone
			Assert.IsTrue(xmlOutput.Trim().StartsWith("<tsValue specializationType=\"TS.FULLDATETIME\" value=\"19990423010203.0000"));
			Assert.IsTrue(xmlOutput.Trim().EndsWith("\" xsi:type=\"TS\"/>"));
		}

		[Test]
		public virtual void ShouldProduceResultWithInvalidSpecializationTypeError()
		{
			ModelToXmlResult result = new ModelToXmlResult();
			PlatformDate date = DateUtil.GetDate(1999, 3, 23, 1, 2, 3, 0);
			TS ts = new TSImpl(date);
			ts.DataType = StandardDataType.TS_DATETIME;
			FormatContext context = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(result, null, "tsValue"
				, "TS.FULLDATEWITHTIME", null, null, false, SpecificationVersion.R02_04_02, null, null, null, false);
			string xmlOutput = this.formatter.Format(context, ts);
			Assert.AreEqual(1, result.GetHl7Errors().Count, "1 error");
			Assert.AreEqual("Invalid specializationType: TS.DATETIME. Value should be one of TS.FULLDATE / TS.FULLDATETIME / TS.FULLDATEPARTTIME. TS.FULLDATETIME will be assumed."
				, result.GetHl7Errors()[0].GetMessage());
			// avoid having to assess the timezone
			Assert.IsTrue(xmlOutput.Trim().StartsWith("<tsValue specializationType=\"TS.FULLDATETIME\" value=\"19990423010203.0000"));
			Assert.IsTrue(xmlOutput.Trim().EndsWith("\" xsi:type=\"TS\"/>"));
		}

		[Test]
		public virtual void ShouldProduceResultWithNoErrorsWhenNullFlavorSupplied()
		{
			// writing test based on RM16399
			ModelToXmlResult result = new ModelToXmlResult();
			TS ts = new TSImpl(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.ASKED_BUT_UNKNOWN);
			FormatContext context = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(result, null, "tsValue"
				, "TS.FULLDATEWITHTIME", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, false, SpecificationVersion.R02_04_02
				, null, null, null, false);
			string xmlOutput = this.formatter.Format(context, ts);
			Assert.IsTrue(result.IsValid());
			Assert.AreEqual("<tsValue nullFlavor=\"ASKU\"/>", xmlOutput.Trim());
		}
	}
}
