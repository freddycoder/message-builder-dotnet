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
using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Util.Iterator;
using ILOG.J2CsMapping.Collections.Generics;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	public class Mapping
	{
		internal class PartTypeMapping
		{
			private readonly string type;

			private readonly string name;

			internal PartTypeMapping(string name, string type)
			{
				this.name = name;
				this.type = type;
			}

			public virtual string Type
			{
				get
				{
					return this.type;
				}
			}

			public virtual string GetName()
			{
				return this.name;
			}

			public virtual Mapping.PartTypeMapping Skip(string first)
			{
				if (this.name.StartsWith(first + "/"))
				{
					return new Mapping.PartTypeMapping(StringUtils.SubstringAfter(name, first + "/"), type);
				}
				else
				{
					throw new InvalidOperationException("mapping does not start with " + first);
				}
			}
		}

		private readonly string mapping;

		private readonly IList<Mapping.PartTypeMapping> mappings;

		internal Mapping(string mapping, IList<Mapping.PartTypeMapping> mappings)
		{
			this.mapping = mapping;
			this.mappings = mappings;
		}

		public virtual bool IsCompound()
		{
			return this.mapping.Contains("/");
		}

		internal static IList<Mapping> From(IList<string> mappings, Hl7MapByPartTypeAttribute[] exceptions)
		{
			IList<Mapping> result = new List<Mapping>();
			foreach (string mapping in EmptyIterable<object>.NullSafeIterable<string>(mappings))
			{
				result.Add(new Mapping(mapping, ExtractPartTypeMappings(exceptions)));
			}
			return result;
		}

		private static IList<Mapping.PartTypeMapping> ExtractPartTypeMappings(Hl7MapByPartTypeAttribute[] exceptions)
		{
			IList<Mapping.PartTypeMapping> mappings = new List<Mapping.PartTypeMapping>();
			if (exceptions != null)
			{
				foreach (Hl7MapByPartTypeAttribute nameValuePair in exceptions)
				{
					mappings.Add(new Mapping.PartTypeMapping(nameValuePair.Name, nameValuePair.Type));
				}
			}
			return mappings;
		}

		public static IList<Mapping> From(BeanProperty property)
		{
			Hl7XmlMappingAttribute mapping = property.GetAnnotation<Hl7XmlMappingAttribute>();
			Hl7MapByPartTypeAttribute[] exceptions = MappingHelper.GetAllHl7MapByPartType(property);
			return From(mapping, exceptions);
		}

		private static IList<Mapping> From(Hl7XmlMappingAttribute mapping, Hl7MapByPartTypeAttribute[] exceptions)
		{
			return mapping == null ? CollUtils.EmptyList<Mapping>() : From(Arrays.AsList(mapping.Value), exceptions);
		}

		public override string ToString()
		{
			return this.mapping;
		}

		public virtual string First()
		{
			return IsCompound() ? StringUtils.SubstringBefore(this.mapping, "/") : this.mapping;
		}

		public virtual Mapping Rest()
		{
			return IsCompound() ? new Mapping(StringUtils.SubstringAfter(this.mapping, "/"), ExtractMatchingMappings(this.mappings, First
				())) : null;
		}

		public virtual Mapping FirstPart()
		{
			return new Mapping(First(), this.mappings);
		}

		private static IList<Mapping.PartTypeMapping> ExtractMatchingMappings(IList<Mapping.PartTypeMapping> mappings, string first
			)
		{
			IList<Mapping.PartTypeMapping> result = new List<Mapping.PartTypeMapping>();
			foreach (Mapping.PartTypeMapping partTypeMapping in mappings)
			{
				if (partTypeMapping.GetName().StartsWith(first + "/"))
				{
					result.Add(partTypeMapping.Skip(first));
				}
			}
			return result;
		}

		public virtual string GetName()
		{
			return this.mapping;
		}

		public virtual IList<NamedAndTyped> GetAllTypes()
		{
			return GetAllTypes(this.mapping);
		}

		private IList<NamedAndTyped> GetAllTypes(string suppliedMapping)
		{
			IList<NamedAndTyped> types = new List<NamedAndTyped>();
			if (HasPartTypeMappings())
			{
				foreach (Mapping.PartTypeMapping map in this.mappings)
				{
					if (StringUtils.Equals(suppliedMapping, map.GetName()))
					{
						types.Add(new RelationshipMap.Key(suppliedMapping, map.Type));
					}
				}
			}
			else
			{
				types.Add(new RelationshipMap.Key(suppliedMapping));
			}
			return types;
		}

		public virtual IList<NamedAndTyped> GetAllTypesIncludingAttribute()
		{
			IList<NamedAndTyped> results = GetAllTypes();
			if (results.IsEmpty() && IsCompound())
			{
				// this mapping is likely for an attribute; back the mapping up one step to find type matches
				int lastSlash = this.mapping.LastIndexOf('/');
				string newMapping = Ca.Infoway.Messagebuilder.StringUtils.Substring(this.mapping, 0, lastSlash);
				results = GetAllTypes(newMapping);
			}
			return results;
		}

		public virtual bool HasPartTypeMappings()
		{
			return CollUtils.IsNotEmpty(this.mappings);
		}
	}
}
