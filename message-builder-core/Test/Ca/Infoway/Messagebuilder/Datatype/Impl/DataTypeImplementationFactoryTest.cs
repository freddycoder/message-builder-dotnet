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


using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Lang;
using ILOG.J2CsMapping.Text;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Datatype.Impl
{
	[TestFixture]
	public class DataTypeImplementationFactoryTest
	{
		private static readonly ICollection<StandardDataType> CDA_R2_TYPES = new HashSet<StandardDataType>();

		private static readonly StandardDataType[] DATA_TYPES = EnumPattern.Values<StandardDataType>().ToArray(new StandardDataType
			[0]);

		static DataTypeImplementationFactoryTest()
		{
			CDA_R2_TYPES.Add(StandardDataType.CD);
			CDA_R2_TYPES.Add(StandardDataType.CV);
			CDA_R2_TYPES.Add(StandardDataType.CE);
			CDA_R2_TYPES.Add(StandardDataType.CO);
			CDA_R2_TYPES.Add(StandardDataType.SC);
			CDA_R2_TYPES.Add(StandardDataType.CS);
			CDA_R2_TYPES.Add(StandardDataType.PQR);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void MakeSureDataTypeHasAnImplemenation()
		{
			foreach (StandardDataType type in DATA_TYPES)
			{
				if (type != StandardDataType.COLLECTION && type != StandardDataType.BAG)
				{
					if (type.Coded && CDA_R2_TYPES.Contains(type))
					{
						Assert.IsNotNull(DataTypeImplementationFactory.GetImplementation(type.Type, true), System.String.Format("no implementation for: {0}"
							, type.Type));
					}
					Assert.IsNotNull(DataTypeImplementationFactory.GetImplementation(type.Type, false), System.String.Format("no implementation for: {0}"
						, type.Type));
				}
			}
		}
	}
}
