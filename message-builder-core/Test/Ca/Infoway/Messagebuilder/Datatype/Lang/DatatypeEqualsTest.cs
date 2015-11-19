using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Domainvalue;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Datatype.Lang
{
	[TestFixture]
	public class DatatypeEqualsTest
	{
		[Test]
		public virtual void TestTrivialNameEquals()
		{
			TrivialName trivialName1 = new TrivialName("aName");
			trivialName1.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.PHONETIC);
			TrivialName trivialName2 = new TrivialName("aName");
			trivialName2.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.PHONETIC);
			Assert.AreEqual(trivialName1, trivialName2);
		}

		[Test]
		public virtual void TestTelecomAddressEquals()
		{
			TelecommunicationAddress telecomAddress1 = new TelecommunicationAddress();
			telecomAddress1.Address = "192.168.0.27";
			telecomAddress1.UrlScheme = Ca.Infoway.Messagebuilder.Domainvalue.Basic.URLScheme.HTTP;
			telecomAddress1.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.ANSWERING_MACHINE);
			TelecommunicationAddress telecomAddress2 = new TelecommunicationAddress();
			telecomAddress2.Address = "192.168.0.27";
			telecomAddress2.UrlScheme = Ca.Infoway.Messagebuilder.Domainvalue.Basic.URLScheme.HTTP;
			telecomAddress2.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.ANSWERING_MACHINE);
			Assert.AreEqual(telecomAddress1, telecomAddress2);
		}

		[Test]
		public virtual void TestPhysicalQuantityEquals()
		{
			PhysicalQuantity pq1 = new PhysicalQuantity(new BigDecimal(1.5), Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.CENTIMETRE);
			PhysicalQuantity pq2 = new PhysicalQuantity(new BigDecimal(1.5), Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.CENTIMETRE);
			Assert.AreEqual(pq1, pq2);
		}

		[Test]
		public virtual void TestOrganizationNameEquals()
		{
			OrganizationName orgName1 = new OrganizationName();
			orgName1.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			orgName1.AddNamePart(new EntityNamePart("aName", OrganizationNamePartType.PREFIX, Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNamePartQualifier
				.LEGALSTATUS));
			OrganizationName orgName2 = new OrganizationName();
			orgName2.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			orgName2.AddNamePart(new EntityNamePart("aName", OrganizationNamePartType.PREFIX, Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNamePartQualifier
				.LEGALSTATUS));
			Assert.AreEqual(orgName1, orgName2);
		}

		[Test]
		public virtual void TestPersonNameEquals()
		{
			PersonName personName1 = new PersonName();
			personName1.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			personName1.AddNamePart(new EntityNamePart("aName", PersonNamePartType.FAMILY, Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNamePartQualifier
				.INITIAL));
			PersonName personName2 = new PersonName();
			personName2.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			personName2.AddNamePart(new EntityNamePart("aName", PersonNamePartType.FAMILY, Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNamePartQualifier
				.INITIAL));
			Assert.AreEqual(personName1, personName2);
		}

		[Test]
		public virtual void TestPostalAddressEquals()
		{
			PostalAddress address1 = new PostalAddress();
			address1.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.CARE_OF, "careOfPlace"));
			address1.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.CITY, "aCity"));
			address1.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse.HOME);
			address1.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse.TEMPORARY);
			PostalAddress address2 = new PostalAddress();
			address2.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.CARE_OF, "careOfPlace"));
			address2.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.CITY, "aCity"));
			address2.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse.HOME);
			address2.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse.TEMPORARY);
			Assert.AreEqual(address1, address2);
		}

		[Test]
		public virtual void TestIdentiferEquals()
		{
			Identifier id1 = new Identifier("aRoot", "anExtension", "aVersion");
			Identifier id2 = new Identifier("aRoot", "anExtension", "aVersion");
			Assert.AreEqual(id1, id2);
		}

		[Test]
		public virtual void TestDateEquals()
		{
			PlatformDate date1 = new PlatformDate(12345);
			PlatformDate date2 = new PlatformDate(12345);
			Assert.AreEqual(date1, date2);
		}

		[Test]
		public virtual void TestMoneyEquals()
		{
			Money money1 = new Money(new BigDecimal(3.21), Ca.Infoway.Messagebuilder.Domainvalue.Basic.Currency.CANADIAN_DOLLAR);
			Money money2 = new Money(new BigDecimal(3.21), Ca.Infoway.Messagebuilder.Domainvalue.Basic.Currency.CANADIAN_DOLLAR);
			Assert.AreEqual(money1, money2);
		}

		[Test]
		public virtual void TestRatioEquals()
		{
			PhysicalQuantity pq1a = new PhysicalQuantity(new BigDecimal(1.5), Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.CENTIMETRE);
			PhysicalQuantity pq1b = new PhysicalQuantity(new BigDecimal(1.46), Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.CUBIC_MILIMETER);
			Ratio<PhysicalQuantity, PhysicalQuantity> ratio1 = new Ratio<PhysicalQuantity, PhysicalQuantity>(pq1a, pq1b);
			PhysicalQuantity pq2a = new PhysicalQuantity(new BigDecimal(1.5), Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.CENTIMETRE);
			PhysicalQuantity pq2b = new PhysicalQuantity(new BigDecimal(1.46), Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.CUBIC_MILIMETER);
			Ratio<PhysicalQuantity, PhysicalQuantity> ratio2 = new Ratio<PhysicalQuantity, PhysicalQuantity>(pq2a, pq2b);
			Assert.AreEqual(ratio1, ratio2);
		}

		[Test]
		public virtual void TestIntervalEquals()
		{
			Interval<PlatformDate> interval1 = IntervalFactory.CreateLowHigh(new PlatformDate(1234), new PlatformDate(5678));
			Interval<PlatformDate> interval2 = IntervalFactory.CreateLowHigh(new PlatformDate(1234), new PlatformDate(5678));
			Assert.AreEqual(interval1, interval2);
		}

		[Test]
		public virtual void TestPivlEquals()
		{
			PeriodicIntervalTime pivl1 = PeriodicIntervalTime.CreatePeriodPhase(new DateDiff(new PhysicalQuantity(new BigDecimal(4), 
				Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive.DAY)), IntervalFactory.CreateLowHigh(new PlatformDate
				(1234), new PlatformDate(5678)));
			PeriodicIntervalTime pivl2 = PeriodicIntervalTime.CreatePeriodPhase(new DateDiff(new PhysicalQuantity(new BigDecimal(4), 
				Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive.DAY)), IntervalFactory.CreateLowHigh(new PlatformDate
				(1234), new PlatformDate(5678)));
			Assert.AreEqual(pivl1, pivl2);
			pivl1 = PeriodicIntervalTime.CreateFrequency(5, new PhysicalQuantity(new BigDecimal(4), Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.DAY));
			pivl2 = PeriodicIntervalTime.CreateFrequency(5, new PhysicalQuantity(new BigDecimal(4), Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.DAY));
			Assert.AreEqual(pivl1, pivl2);
		}

		[Test]
		public virtual void TestGtsEquals()
		{
			PeriodicIntervalTime pivl1 = PeriodicIntervalTime.CreatePeriodPhase(new DateDiff(new PhysicalQuantity(new BigDecimal(4), 
				Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive.DAY)), IntervalFactory.CreateLowHigh(new PlatformDate
				(1234), new PlatformDate(5678)));
			GeneralTimingSpecification gts1 = new GeneralTimingSpecification(IntervalFactory.CreateLowHigh(new PlatformDate(2222), new 
				PlatformDate(3333)), pivl1);
			PeriodicIntervalTime pivl2 = PeriodicIntervalTime.CreatePeriodPhase(new DateDiff(new PhysicalQuantity(new BigDecimal(4), 
				Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive.DAY)), IntervalFactory.CreateLowHigh(new PlatformDate
				(1234), new PlatformDate(5678)));
			GeneralTimingSpecification gts2 = new GeneralTimingSpecification(IntervalFactory.CreateLowHigh(new PlatformDate(2222), new 
				PlatformDate(3333)), pivl2);
			Assert.AreEqual(gts1, gts2);
		}

		[Test]
		public virtual void TestCodedStringEquals()
		{
			CodedString<ActStatus> cs1 = new CodedString<ActStatus>("111", Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActStatus
				.CANCELLED, "222", "333", "444");
			CodedString<ActStatus> cs2 = new CodedString<ActStatus>("111", Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActStatus
				.CANCELLED, "222", "333", "444");
			Assert.AreEqual(cs1, cs2);
		}
	}
}
