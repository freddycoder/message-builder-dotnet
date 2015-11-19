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
