using System;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Xml;
using Ca.Infoway.Messagebuilder.Xml.Service;
using log4net;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class PathBuilder
	{
		private readonly ILog log = log4net.LogManager.GetLogger(typeof(Ca.Infoway.Messagebuilder.Marshalling.PathBuilder));

		private readonly MessageDefinitionService service;

		private readonly VersionNumber version;

		internal PathBuilder(MessageDefinitionService service, VersionNumber version)
		{
			this.service = service;
			this.version = version;
		}

		internal virtual IList<TypeName> FindPathTo(TypeName start, TypeName end)
		{
			ValidateHasType(end, "end");
			ValidateHasType(start, "start");
			IList<TypeName> results = new List<TypeName>();
			if (ObjectUtils.Equals(start, end) || FindPathTo(start, end, results))
			{
			}
			else
			{
				// expected
				this.log.Error("PathBuilder: Could not find a type path from start to end (" + start + ", " + end + "). Using end type only."
					);
			}
			results.Add(end);
			return results;
		}

		private void ValidateHasType(TypeName typeName, string position)
		{
			if (typeName == null || typeName.Name == null)
			{
				throw new InvalidOperationException("Cannot determine a type path when type is null (for " + position + ")");
			}
		}

		private bool FindPathTo(TypeName start, TypeName end, IList<TypeName> results)
		{
			IList<SpecializationChild> childs = GetMessagePart(start).SpecializationChilds;
			foreach (SpecializationChild child in childs)
			{
				TypeName childTypeName = new TypeName(child.Name);
				if (ObjectUtils.Equals(childTypeName, end))
				{
					results.Add(start);
					return true;
				}
				else
				{
					if (FindPathTo(childTypeName, end, results))
					{
						results.Insert(0, start);
						return true;
					}
				}
			}
			return false;
		}

		private MessagePart GetMessagePart(TypeName typeName)
		{
			return this.service.GetMessagePart(this.version, typeName.Name);
		}
	}
}
