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
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Basic
{
	[System.Serializable]
	public class X_HeightOrWeightObservationUnitsOfMeasure : EnumPattern, x_HeightOrWeightObservationUnitsOfMeasure
	{
		static X_HeightOrWeightObservationUnitsOfMeasure()
		{
		}

		private const long serialVersionUID = 3134130558551921271L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_HeightOrWeightObservationUnitsOfMeasure FOOT = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_HeightOrWeightObservationUnitsOfMeasure
			("FOOT", "[ft_i]");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_HeightOrWeightObservationUnitsOfMeasure INCH = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_HeightOrWeightObservationUnitsOfMeasure
			("INCH", "[in_i]");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_HeightOrWeightObservationUnitsOfMeasure POUND = new 
			Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_HeightOrWeightObservationUnitsOfMeasure("POUND", "[lb_av]");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_HeightOrWeightObservationUnitsOfMeasure OUNCE = new 
			Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_HeightOrWeightObservationUnitsOfMeasure("OUNCE", "[oz_av]");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_HeightOrWeightObservationUnitsOfMeasure YARD = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_HeightOrWeightObservationUnitsOfMeasure
			("YARD", "[yd_i]");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_HeightOrWeightObservationUnitsOfMeasure CENTIMETER = 
			new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_HeightOrWeightObservationUnitsOfMeasure("CENTIMETER", "cm");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_HeightOrWeightObservationUnitsOfMeasure GRAM = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_HeightOrWeightObservationUnitsOfMeasure
			("GRAM", "g");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_HeightOrWeightObservationUnitsOfMeasure KILOGRAM = new 
			Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_HeightOrWeightObservationUnitsOfMeasure("KILOGRAM", "kg");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_HeightOrWeightObservationUnitsOfMeasure METER = new 
			Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_HeightOrWeightObservationUnitsOfMeasure("METER", "m");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_HeightOrWeightObservationUnitsOfMeasure MILLIMETER = 
			new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_HeightOrWeightObservationUnitsOfMeasure("MILLIMETER", "mm");

		private readonly string codeValue;

		private X_HeightOrWeightObservationUnitsOfMeasure(string name, string codeValue) : base(name)
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
