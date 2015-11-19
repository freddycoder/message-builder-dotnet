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
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Basic
{
	[System.Serializable]
	public class X_DistanceObservationUnitsOfMeasure : EnumPattern, x_DistanceObservationUnitsOfMeasure
	{
		static X_DistanceObservationUnitsOfMeasure()
		{
		}

		private const long serialVersionUID = 3134130558551921271L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DistanceObservationUnitsOfMeasure MILE = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DistanceObservationUnitsOfMeasure
			("MILE", "[mi_us]");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DistanceObservationUnitsOfMeasure YARD = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DistanceObservationUnitsOfMeasure
			("YARD", "[yd_i]");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DistanceObservationUnitsOfMeasure DEGREE = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DistanceObservationUnitsOfMeasure
			("DEGREE", "deg");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DistanceObservationUnitsOfMeasure KILOMETER = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DistanceObservationUnitsOfMeasure
			("KILOMETER", "km");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DistanceObservationUnitsOfMeasure METER = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DistanceObservationUnitsOfMeasure
			("METER", "m");

		private readonly string codeValue;

		private X_DistanceObservationUnitsOfMeasure(string name, string codeValue) : base(name)
		{
			this.codeValue = codeValue;
		}

		public virtual string CodeValue
		{
			get
			{
				return this.codeValue;
			}
		}

		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_UNIFORM_UNIT_OF_MEASURE.Root;
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystemName
		{
			get
			{
				return null;
			}
		}
	}
}
