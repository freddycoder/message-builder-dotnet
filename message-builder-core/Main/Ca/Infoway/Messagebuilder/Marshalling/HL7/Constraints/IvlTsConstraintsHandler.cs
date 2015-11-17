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
