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
 * Author:        $LastChangedBy: sdoxsee $
 * Last modified: $LastChangedDate: 2011-12-22 11:21:35 -0500 (Thu, 22 Dec 2011) $
 * Revision:      $LastChangedRevision: 3179 $
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Ca.Infoway.Messagebuilder
{
	
    public class BigDecimal : System.Object, IComparable<BigDecimal>
    {
		
		public static BigDecimal ZERO = new BigDecimal("0");		
		public static BigDecimal ONE = new BigDecimal("1");
        public static BigDecimal TEN = new BigDecimal("10");
		
		private decimal value;
		
		public BigDecimal(double doubleValue) { value = (decimal) doubleValue; }
        public BigDecimal(long lvalue) { value = lvalue; }
        public BigDecimal(decimal dvalue) { value = dvalue; }
        public BigDecimal(String s) { value = Decimal.Parse(s); }

        public static BigDecimal Parse(String s) { return new BigDecimal(s); }


        public int CompareTo(BigDecimal that)
        {
            return value < that.value ? -1 : value > that.value ? 1 : 0;
        }

        public BigDecimal Add(BigDecimal that)
        {
            return new BigDecimal(value + that.value);
        }

        public BigDecimal Subtract(BigDecimal that)
        {
            return new BigDecimal(value - that.value);
        }

        public BigDecimal Multiply(BigDecimal that)
        {
            return new BigDecimal(value * that.value);
        }

        public BigDecimal Divide(BigDecimal that)
        {
            return new BigDecimal(value / that.value);
        }

        public long LongValue { get { return (long)value; } }
        public int Value { get { return (int)value; } }

        public static implicit operator decimal(BigDecimal that)
        {
            return that.value;
        }
		
		public int Scale() {
			string asString = ToString();
			int index = asString.IndexOf(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);
			if (index!=-1) {
				return asString.Length - index - 1;
			} else {
				return 0;
			}
		}

		public BigDecimal SetScale(int newScale, MidpointRounding mode) {
			value = Decimal.Round(value, newScale, mode);
			return this;
		}

		public BigDecimal SetScale(int newScale) {
			value = Decimal.Round(value, newScale);
			return this;
		}
		
		public int Precision() {
			string asString = ToString();
			return asString.IndexOf(".")!=-1 ? asString.Length - 1 : asString.Length;
		}

		public override String ToString() {
			return Convert.ToString(value);
		}
		
		public String ToPlainString() {
			return ToString();
		}
		
		public override bool Equals(Object obj) {
			if (obj == null) {
				return false;
			} else if (GetType() != obj.GetType()) {
				return false;
			} else {
				BigDecimal that = (BigDecimal) obj;
				return this.value == that.value;
			}
		}

		public override int GetHashCode() {
			return value.GetHashCode();
		}
		
		public static BigDecimal operator +(BigDecimal left, BigDecimal right) {
			return left.Add(right);
		}
		
		public static BigDecimal operator *(BigDecimal left, BigDecimal right) {
			return left.Multiply(right);
		}

		public static BigDecimal operator -(BigDecimal left, BigDecimal right) {
			return left.Subtract(right);
		}

		public static BigDecimal operator /(BigDecimal left, BigDecimal right) {
			return left.Divide(right);
		}
		
		public static bool operator !=(BigDecimal left, BigDecimal right) {
			if (((object) left)!=null) {
				return ((object) right)==null || left.CompareTo(right) != 0;
				
			} else if (((object) right)!=null) {
				return ((object) left)==null || right.CompareTo(left) != 0;
			}
			return ((object) left)!=right;
		}
		
		public static bool operator <(BigDecimal left, BigDecimal right) {
			return left.CompareTo(right) < 0;
		}

		public static bool operator ==(BigDecimal left, BigDecimal right) {
			if (((object) left)!=null) {
				return ((object) right)!=null && left.CompareTo(right) == 0;
				
			} else if (((object) right)!=null) {
				return ((object) left)!=null && right.CompareTo(left) == 0;
			}
			return ((object) left)==right;
		}
		
		public static bool operator >(BigDecimal left, BigDecimal right) {
			return left.CompareTo(right) > 0;
		}
		
    }
}

