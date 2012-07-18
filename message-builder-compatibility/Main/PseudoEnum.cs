/**
 * Copyright 2012 Canada Health Infoway, Inc.
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
 * Last modified: $LastChangedDate: 2011-05-17 11:48:36 -0400 (Tue, 17 May 2011) $
 * Revision:      $LastChangedRevision: 2666 $
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Ca.Infoway.Messagebuilder
{
	public abstract class PseudoEnum<TClass, TEnum> where TClass : PseudoEnum<TClass, TEnum>
                                                    where TEnum : struct, IConvertible // Really should be 'enum'!
	{
        private static System.Collections.Generic.List<TEnum> evalues = new System.Collections.Generic.List<TEnum>(Enum.GetValues(typeof(TEnum)).Length);
        private static System.Collections.Generic.List<TClass> cvalues = new System.Collections.Generic.List<TClass>(Enum.GetValues(typeof(TEnum)).Length);

		private TEnum evalue;

		protected PseudoEnum(TEnum evalue)
		{
            if (evalues.Contains(evalue))
                throw new ArgumentException("Duplicate enum value");

            this.evalue = evalue;
            evalues.Add(evalue);
            cvalues.Add(this as TClass);
		}

        public TEnum EnumValue
        {
            get { return evalue; }
        }

        public String EnumName
        {
            get { return System.Enum.GetName(typeof(TEnum), evalue); }
        }

        public static IList<TClass> GetValues()
        {
            return cvalues;
        }

        public static IList<TEnum> GetEnumValues()
        {
            return evalues;
        }

		public static implicit operator TEnum (PseudoEnum<TClass, TEnum> pe) 
		{
			return pe.EnumValue;
		}
	}
}
