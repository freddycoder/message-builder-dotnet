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
