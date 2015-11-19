using System;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Util
{
	public interface CodeTypeHandler
	{
		Type GetCodeType(string domainType, string version);
	}
}
