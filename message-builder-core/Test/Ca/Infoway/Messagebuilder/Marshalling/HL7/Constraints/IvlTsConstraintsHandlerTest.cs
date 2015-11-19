using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Constraints;
using Ca.Infoway.Messagebuilder.Xml;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Constraints
{
	[TestFixture]
	public class IvlTsConstraintsHandlerTest
	{
		private IvlTsConstraintsHandler constraintsHandler = new IvlTsConstraintsHandler();

		private IList<Hl7Error> errors;

		private sealed class _ErrorLogger_51 : ErrorLogger
		{
			public _ErrorLogger_51(IvlTsConstraintsHandlerTest _enclosing)
			{
				this._enclosing = _enclosing;
			}

			public void LogError(Hl7ErrorCode errorCode, ErrorLevel errorLevel, string message)
			{
				this._enclosing.errors.Add(new Hl7Error(errorCode, errorLevel, message, string.Empty));
			}

			private readonly IvlTsConstraintsHandlerTest _enclosing;
		}

		private ErrorLogger errorLogger;

		[NUnit.Framework.SetUp]
		public virtual void SetUp()
		{
			//NUnit does not allocate a new instance for each test method. Need to do this in setUp.
			errors = new List<Hl7Error>();
		}

		[Test]
		public virtual void TestNullCases()
		{
			this.constraintsHandler.HandleConstraints(null, null, this.errorLogger);
			Assert.IsTrue(this.errors.IsEmpty());
			DateInterval dateInterval = new DateInterval();
			this.constraintsHandler.HandleConstraints(null, dateInterval, this.errorLogger);
			Assert.IsTrue(this.errors.IsEmpty());
			this.constraintsHandler.HandleConstraints(null, dateInterval, this.errorLogger);
			Assert.IsTrue(this.errors.IsEmpty());
			ConstrainedDatatype constraints = new ConstrainedDatatype();
			this.constraintsHandler.HandleConstraints(constraints, null, this.errorLogger);
			Assert.IsTrue(this.errors.IsEmpty());
			this.constraintsHandler.HandleConstraints(constraints, dateInterval, this.errorLogger);
			Assert.IsTrue(this.errors.IsEmpty());
			dateInterval.Interval = CreateLowHighInterval(true, true);
			this.constraintsHandler.HandleConstraints(constraints, dateInterval, this.errorLogger);
			Assert.IsTrue(this.errors.IsEmpty());
		}

		[Test]
		public virtual void TestPassingConstraintsLowHigh()
		{
			DateInterval dateInterval = new DateInterval(CreateLowHighInterval(true, true));
			ConstrainedDatatype constraints = CreateLowHighConstraints();
			this.constraintsHandler.HandleConstraints(constraints, dateInterval, this.errorLogger);
			Assert.IsTrue(this.errors.IsEmpty());
		}

		[Test]
		public virtual void TestMissingLowFailingConstraint()
		{
			DateInterval dateInterval = new DateInterval(CreateLowHighInterval(false, true));
			ConstrainedDatatype constraints = CreateLowHighConstraints();
			this.constraintsHandler.HandleConstraints(constraints, dateInterval, this.errorLogger);
			Assert.IsFalse(this.errors.IsEmpty());
			Assert.AreEqual(1, this.errors.Count);
			Assert.AreEqual(Hl7ErrorCode.CDA_MANDATORY_CONSTRAINT_MISSING, this.errors[0].GetHl7ErrorCode());
			Assert.IsTrue(this.errors[0].GetMessage().Contains("low"));
			Interval<PlatformDate> originalInterval = CreateLowHighInterval(false, true);
			Assert.AreEqual(originalInterval.Low, dateInterval.Interval.Low);
			Assert.AreEqual(originalInterval.High, dateInterval.Interval.High);
		}

		[Test]
		public virtual void TestMissingHighFailingConstraint()
		{
			DateInterval dateInterval = new DateInterval(CreateLowHighInterval(true, false));
			ConstrainedDatatype constraints = CreateLowHighConstraints();
			this.constraintsHandler.HandleConstraints(constraints, dateInterval, this.errorLogger);
			Assert.IsFalse(this.errors.IsEmpty());
			Assert.AreEqual(1, this.errors.Count);
			Assert.AreEqual(Hl7ErrorCode.CDA_MANDATORY_CONSTRAINT_MISSING, this.errors[0].GetHl7ErrorCode());
			Assert.IsTrue(this.errors[0].GetMessage().Contains("high"));
			Interval<PlatformDate> originalInterval = CreateLowHighInterval(true, false);
			Assert.AreEqual(originalInterval.Low, dateInterval.Interval.Low);
			Assert.AreEqual(originalInterval.High, dateInterval.Interval.High);
		}

		private ConstrainedDatatype CreateLowHighConstraints()
		{
			ConstrainedDatatype constraints = new ConstrainedDatatype("MessagePart.relationshipName", "IVL<TS>");
			constraints.SetRestriction();
			Relationship lowConstraint = new Relationship("low", null, Cardinality.Create("1"));
			Relationship highConstraint = new Relationship("high", null, Cardinality.Create("1"));
			constraints.Relationships.Add(lowConstraint);
			constraints.Relationships.Add(highConstraint);
			return constraints;
		}

		[Test]
		public virtual void TestPassingSimpleValueConstraints()
		{
			DateInterval dateInterval = new DateInterval(CreateSimpleValueInterval());
			ConstrainedDatatype constraints = CreateSimpleValueConstraints();
			this.constraintsHandler.HandleConstraints(constraints, dateInterval, this.errorLogger);
			Assert.IsTrue(this.errors.IsEmpty());
		}

		[Test]
		public virtual void TestMissingSimpleValueConstraints()
		{
			DateInterval dateInterval = new DateInterval(CreateLowHighInterval(true, true));
			ConstrainedDatatype constraints = CreateSimpleValueConstraints();
			this.constraintsHandler.HandleConstraints(constraints, dateInterval, this.errorLogger);
			Assert.IsFalse(this.errors.IsEmpty());
			Assert.AreEqual(3, this.errors.Count);
			Assert.AreEqual(Hl7ErrorCode.CDA_PROHIBITED_CONSTRAINT, this.errors[0].GetHl7ErrorCode());
			Assert.IsTrue(this.errors[0].GetMessage().Contains("Property low"));
			Assert.AreEqual(Hl7ErrorCode.CDA_PROHIBITED_CONSTRAINT, this.errors[1].GetHl7ErrorCode());
			Assert.IsTrue(this.errors[1].GetMessage().Contains("Property high"));
			Assert.AreEqual(Hl7ErrorCode.CDA_MANDATORY_CONSTRAINT_MISSING, this.errors[2].GetHl7ErrorCode());
			Assert.IsTrue(this.errors[2].GetMessage().Contains("Property value"));
		}

		private Interval<PlatformDate> CreateLowHighInterval(bool hasLow, bool hasHigh)
		{
			PlatformDate low = hasLow ? DateUtil.GetDate(2010, 2, 22) : null;
			PlatformDate high = hasHigh ? DateUtil.GetDate(2013, 7, 11) : null;
			return IntervalFactory.CreateLowHigh(low, high);
		}

		private Interval<PlatformDate> CreateSimpleValueInterval()
		{
			PlatformDate value = DateUtil.GetDate(2013, 11, 7);
			return IntervalFactory.CreateSimple(value);
		}

		private ConstrainedDatatype CreateSimpleValueConstraints()
		{
			ConstrainedDatatype constraints = new ConstrainedDatatype("MessagePart.relationshipName", "IVL<TS>");
			constraints.SetRestriction();
			Relationship simpleValueConstraint = new Relationship("value", null, Cardinality.Create("1"));
			Relationship lowConstraint = new Relationship("low", null, Cardinality.Create("0"));
			Relationship highConstraint = new Relationship("high", null, Cardinality.Create("0"));
			constraints.Relationships.Add(simpleValueConstraint);
			constraints.Relationships.Add(lowConstraint);
			constraints.Relationships.Add(highConstraint);
			return constraints;
		}

		public IvlTsConstraintsHandlerTest()
		{
			errorLogger = new _ErrorLogger_51(this);
		}
	}
}
