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

/// ---------------------------------------------------------------------------------------------------
///  This file was automatically generated by J2CS Translator (http://j2cstranslator.sourceforge.net/). 
///  Version 1.0.0                                                                                      
/// ---------------------------------------------------------------------------------------------------
 
namespace Ca.Infoway.Messagebuilder.Datatype.Lang {
	
	using Ca.Infoway.Messagebuilder;
	using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
    using Ca.Infoway.Messagebuilder.Datatype.Nullflavor;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Domainvalue.Basic;
    using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Runtime.CompilerServices;
	
	/// <summary>
	/// A specialist Diff class for Dates.
	/// </summary>
	///
    public class DateDiff : Diff<Ca.Infoway.Messagebuilder.PlatformDate>, NullFlavorSupport, DiffWithQuantityAndUnit
    {

        // SS-20090407: Bug 10882 has been opened to allow this class to handle fractional units.

        // TODO SS-20080211: there is some overlap with DefaultTimeUnit here 
        public static readonly String YEAR = "a";
        public static readonly String MONTH = "mo";
        public static readonly String WEEK = "wk";
        public static readonly String SECOND = "s";
        public static readonly String MINUTE = "min";
        public static readonly String HOUR = "h";
        public static readonly String DAY = "d";
        private readonly Int32? value_ren;
        private readonly PhysicalQuantity quantity;

        /// <summary>
        /// Constructs a date diff from a given date.
        /// </summary>
        ///
        /// <param name="value">a date</param>
        public DateDiff(Ca.Infoway.Messagebuilder.PlatformDate value_ren)
            : base(value_ren)
        {
            this.value_ren = null;
            this.quantity = null;
        }

        /// <summary>
        /// Constructs a date diff from the given parameters.
        /// </summary>
        ///
        /// <param name="value">a value</param>
        /// <param name="unit">a unit</param>
        public DateDiff(int value_ren, Domainvalue.UnitsOfMeasureCaseSensitive unit)
            : this(new PhysicalQuantity(new BigDecimal(value_ren.ToString()), unit))
        {
        }

        /// <summary>
        /// Constructs a date diff from the given parameter.
        /// </summary>
        ///
        /// <param name="quantity_0">a physical quantity</param>
        public DateDiff(PhysicalQuantity quantity_0)
            : base(AsDate(quantity_0))
        {
            this.quantity = quantity_0;
            this.value_ren = System.Convert.ToInt32(quantity_0.Quantity);
        }

        /// <summary>
        /// Constructs a date diff with the given null flavor. 
        /// </summary>
        ///
        /// <param name="nullFlavor_0">a null flavor</param>
        public DateDiff(NullFlavor nullFlavor_0)
            : base(nullFlavor_0)
        {
            this.value_ren = null;
            this.quantity = null;
        }

        private static Ca.Infoway.Messagebuilder.PlatformDate AsDate(PhysicalQuantity physicalQuantity)
        {
            Domainvalue.UnitsOfMeasureCaseSensitive unit = (physicalQuantity == null) ? null
                    : physicalQuantity.Unit;
            BigDecimal value_ren = (physicalQuantity == null) ? null : physicalQuantity.Quantity;
            if (unit != null && unit is DateConverter)
            {
                return new Ca.Infoway.Messagebuilder.PlatformDate(((DateConverter)unit)
                                    .ToMilliseconds((value_ren == null) ? 0 : System.Convert.ToInt32(value_ren)));
            }
            else if (unit != null)
            {
                DefaultTimeUnit timeUnit = DefaultTimeUnit.Lookup(unit.CodeValue); // lookup will ignore case
                return (timeUnit == null) ? null : new Ca.Infoway.Messagebuilder.PlatformDate(timeUnit
                                    .ToMilliseconds(value_ren));
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns the units.
        /// </summary>
        ///
        /// <returns>the units</returns>
        public Domainvalue.UnitsOfMeasureCaseSensitive Unit
        {
            /// <summary>
            /// Returns the units.
            /// </summary>
            ///
            /// <returns>the units</returns>
            get
            {
                return (this.quantity == null) ? null : this.quantity.Unit;
            }
        }


        /// <summary>
        /// Strictly speaking, a DateDiff type uses a physical quantity to represent the 
        /// width attribute.  This method only returns an int.  
        /// Use <c>getValueAsPhysicalQuantity</c> instead.
        /// </summary>
        ///
        /// <returns>the unit value</returns>
        public Int32? UnitValue
        {
            /// <summary>
            /// Strictly speaking, a DateDiff type uses a physical quantity to represent the 
            /// width attribute.  This method only returns an int.  
            /// Use <c>getValueAsPhysicalQuantity</c> instead.
            /// </summary>
            ///
            /// <returns>the unit value</returns>
            get
            {
                return this.value_ren;
            }
        }


        /// <summary>
        /// Returns the date diff as a physical quantity.
        /// </summary>
        ///
        /// <returns>the date diff as a physical quantity.</returns>
        public PhysicalQuantity ValueAsPhysicalQuantity
        {
            /// <summary>
            /// Returns the date diff as a physical quantity.
            /// </summary>
            ///
            /// <returns>the date diff as a physical quantity.</returns>
            get
            {
                return this.quantity;
            }
        }


        /// <summary>
        /// Returns the string representation of this object.
        /// </summary>
        ///
        /// <returns>the string representation of this object.</returns>
        public override System.String ToString()
        {
            if (Unit != null && this.value_ren != null)
            {
                return "" + this.value_ren + Unit;
            }
            else
            {
                return base.ToString();
            }
        }

        public static DateDiff ConvertDiff<T>(Diff<T> inValue)
        {
            return inValue as DateDiff;
        }
    
        public override int GetHashCode()
        {
            return new HashCodeBuilder()
                    .AppendSuper(base.GetHashCode())
                    .Append(this.value_ren)
                    .Append(this.quantity)
                    .ToHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            else if (obj.GetType() != GetType())
            {
                return false;
            } else {
                return Equals((DateDiff) obj);
            }
        }
    
        private bool Equals(DateDiff that)
        {
            return new EqualsBuilder().AppendSuper(base.Equals(that))
                    .Append(this.value_ren, that.value_ren)
                    .Append(this.quantity, that.quantity)
                    .IsEquals();
        }
    }
}
