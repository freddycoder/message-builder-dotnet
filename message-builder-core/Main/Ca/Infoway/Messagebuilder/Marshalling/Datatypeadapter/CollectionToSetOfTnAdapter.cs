using System;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Marshalling.Datatypeadapter;
using Ca.Infoway.Messagebuilder.Platform;

namespace Ca.Infoway.Messagebuilder.Marshalling.Datatypeadapter
{
	public class CollectionToSetOfTnAdapter : DataTypeAdapter
	{
		public virtual bool CanAdapt(Type fromDataType, string toDataTypeName)
		{
			if (typeof(COLLECTION<object>).IsAssignableFrom(fromDataType) && StandardDataType.SET.Equals(StandardDataType.GetByTypeName
				(toDataTypeName)) && ContainerOfTn(toDataTypeName))
			{
				return true;
			}
			return false;
		}

		private bool ContainerOfTn(string fromDataTypeName)
		{
			bool containerOfTn = false;
			IList<Hl7TypeName> parameters = Hl7TypeName.Parse(fromDataTypeName).Parameters;
			if (parameters != null && !parameters.IsEmpty())
			{
				foreach (Hl7TypeName parameter in parameters)
				{
					if (StandardDataType.TN.RootType.Equals(parameter.RootName))
					{
						containerOfTn = true;
					}
				}
			}
			return containerOfTn;
		}

		public virtual bool CanAdapt(string fromDataTypeName, Type toDateType)
		{
			return false;
		}

		public virtual BareANY Adapt(BareANY any)
		{
			ICollection<object> collection = ((COLLECTION<object>)any).RawCollection();
			SETImpl<ANY<object>, object> adaptedSet = new SETImpl<ANY<object>, object>(typeof(TNImpl));
			if (any.HasNullFlavor())
			{
				NullFlavor nullFlavor = any.NullFlavor;
				adaptedSet.NullFlavor = nullFlavor;
			}
			else
			{
				adaptedSet.RawSet().AddAll(ToSetOfTrivialName(collection));
			}
			return (ANY<object>)adaptedSet;
		}

		private ICollection<object> ToSetOfTrivialName(ICollection<object> collection)
		{
			ICollection<object> set = new LinkedSet<object>();
			foreach (object element in collection)
			{
				set.Add(new TrivialName(element.ToString()));
			}
			return set;
		}
	}
}
