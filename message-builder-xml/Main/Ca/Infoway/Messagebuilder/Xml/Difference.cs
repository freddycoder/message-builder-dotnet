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
 * Last modified: $LastChangedDate: 2013-03-08 11:06:36 -0500 (Fri, 08 Mar 2013) $
 * Revision:      $LastChangedRevision: 6699 $
 */
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Xml;
using ILOG.J2CsMapping.Collections.Generics;
using Platform.SimpleXml;

namespace Ca.Infoway.Messagebuilder.Xml
{
	/// <summary>A class that models the differences noted during regen.</summary>
	/// <remarks>A class that models the differences noted during regen.</remarks>
	/// <author>Intelliware Development</author>
	[RootAttribute]
	[NamespaceAttribute(Prefix = "regen", Reference = "regen_ns")]
	public class Difference
	{
		[XmlAttributeAttribute]
		private DifferenceType type;

		[XmlAttributeAttribute(Required = false)]
		private DifferenceMatch matchConfidence;

		[XmlAttributeAttribute(Name = "isOk", Required = false)]
		private bool ok;

		[ElementListAttribute(Inline = true, Required = false)]
		private IList<DifferenceValue> differences = new List<DifferenceValue>();

		public Difference()
		{
		}

		public Difference(DifferenceType differenceType, bool ok, params DifferenceValue[] values)
		{
			this.type = differenceType;
			this.ok = ok;
			this.differences.AddAll(Arrays.AsList(values));
		}

		/// <summary>A field indicating what kind of difference is being reported.</summary>
		/// <remarks>A field indicating what kind of difference is being reported.</remarks>
		/// <returns>the  type of this difference</returns>
		public virtual DifferenceType Type
		{
			get
			{
				return this.type;
			}
		}

		public virtual void SetType(DifferenceType type)
		{
			this.type = type;
		}

		public virtual DifferenceMatch MatchConfidence
		{
			get
			{
				return this.matchConfidence;
			}
			set
			{
				DifferenceMatch matchConfidence = value;
				this.matchConfidence = matchConfidence;
			}
		}

		public virtual IList<DifferenceValue> Differences
		{
			get
			{
				return this.differences;
			}
			set
			{
				IList<DifferenceValue> differences = value;
				this.differences = differences;
			}
		}

		public virtual bool Ok
		{
			get
			{
				return this.ok;
			}
			set
			{
				bool ok = value;
				this.ok = ok;
			}
		}
	}
}
