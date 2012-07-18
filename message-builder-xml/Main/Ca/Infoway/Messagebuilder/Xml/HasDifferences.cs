using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Xml
{
	public interface HasDifferences : Named
	{
		IList<Difference> Differences
		{
			get;
		}

		void AddDifference(Difference difference);
	}
}
