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
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Basic
{
	[System.Serializable]
	public class X_DrugUnitsOfMeasure : EnumPattern, x_DrugUnitsOfMeasure
	{
		static X_DrugUnitsOfMeasure()
		{
		}

		private const long serialVersionUID = 3134130558551921271L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure PERCENT = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure
			("PERCENT", "%");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure CUP = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure
			("CUP", "[cup_us]");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure FLUID_OUNCE = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure
			("FLUID_OUNCE", "[foz_br]");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure GALLON = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure
			("GALLON", "[gal_br]");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure POUND = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure
			("POUND", "[lb_av]");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure OUNCE = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure
			("OUNCE", "[oz_av]");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure PINT = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure
			("PINT", "[pt_br]");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure QUART = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure
			("QUART", "[qt_br]");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure SQUARE_FOOT = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure
			("SQUARE_FOOT", "[sft_i]");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure SQUARE_INCH = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure
			("SQUARE_INCH", "[sin_i]");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure SQUARE_YARD = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure
			("SQUARE_YARD", "[syd_i]");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure TABLESPOON = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure
			("TABLESPOON", "[tbs_us]");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure TEASPOON = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure
			("TEASPOON", "[tsp_us]");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure SQUARE_CENTIMETRE = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure
			("SQUARE_CENTIMETRE", "cm2");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure CUBIC_CENTIMETER = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure
			("CUBIC_CENTIMETER", "cm3");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure GRAM = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure
			("GRAM", "g");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure INTERNATIONAL_UNIT = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure
			("INTERNATIONAL_UNIT", "iU");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure KILOGRAM = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure
			("KILOGRAM", "kg");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure LITRE = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure
			("LITRE", "l");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure SQUARE_METRE = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure
			("SQUARE_METRE", "m2");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure MILLIEQUIVALENT = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure
			("MILLIEQUIVALENT", "meq");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure MILLIGRAM = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure
			("MILLIGRAM", "mg");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure MILLILITRE = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure
			("MILLILITRE", "ml");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure SQUARE_MILLIMETRE = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure
			("SQUARE_MILLIMETRE", "mm2");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure CUBIC_MILIMETER = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure
			("CUBIC_MILIMETER", "mm3");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure MILLIMOLE = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure
			("MILLIMOLE", "mmol");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure MOLE = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure
			("MOLE", "mol");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure MILLIUNIT = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure
			("MILLIUNIT", "mU");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure NANOGRAM = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure
			("NANOGRAM", "ng");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure NANOLITRE = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure
			("NANOLITRE", "nl");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure UNIT = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure
			("UNIT", "U");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure MICROGRAM = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure
			("MICROGRAM", "ug");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure MICROLITRE = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure
			("MICROLITRE", "ul");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure MICROMOLE = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure
			("MICROMOLE", "umol");

		private readonly string codeValue;

		private X_DrugUnitsOfMeasure(string name, string codeValue) : base(name)
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
	}
}
