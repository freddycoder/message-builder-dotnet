using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Constraints;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Constraints
{
	public class IvlTsConstraintsHandler
	{
		private readonly ConstraintsHandler constraintsHandler = new ConstraintsHandler();

		public IvlTsConstraintsHandler()
		{
		}

		public virtual void HandleConstraints(ConstrainedDatatype constraints, DateInterval dateInterval, ErrorLogger logger)
		{
			if (dateInterval == null || dateInterval.Interval == null || constraints == null)
			{
				return;
			}
			Interval<PlatformDate> interval = dateInterval.Interval;
			// only checking the following cardinality constraints:
			// low 1/0
			// high 1/0/0-1
			// value 1
			bool hasLow = (interval.Low != null || interval.LowNullFlavor != null);
			bool hasHigh = (interval.High != null || interval.HighNullFlavor != null);
			bool hasSimpleValue = (interval.Value != null);
			// a nullFlavor instead of a simpleValue would have been handled elsewhere 
			// these are just doing existency checks
			this.constraintsHandler.ValidateConstraint("low", hasLow ? "low" : null, constraints, logger);
			this.constraintsHandler.ValidateConstraint("high", hasHigh ? "high" : null, constraints, logger);
			this.constraintsHandler.ValidateConstraint("value", hasSimpleValue ? "value" : null, constraints, logger);
		}
	}
}
