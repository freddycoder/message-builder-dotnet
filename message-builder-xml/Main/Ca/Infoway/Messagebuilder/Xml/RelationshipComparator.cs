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
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Xml
{
	public class RelationshipComparator : IComparer<RelationshipComparable>
	{
		public virtual int Compare(RelationshipComparable o1, RelationshipComparable o2)
		{
			CompareToBuilder builder = new CompareToBuilder();
			builder.Append(o1.Association, o2.Association);
			if (o1.Attribute)
			{
				builder.Append(o1.SortOrder, o2.SortOrder);
			}
			if (o1.Association)
			{
				if (StringUtils.IsBlank(o1.AssociationSortKey) && StringUtils.IsBlank(o2.AssociationSortKey))
				{
					// assume this is a legacy NFLD test; otherwise, associationSortKey should never be blank for an association
					builder.Append(o1.SortOrder, o2.SortOrder);
				}
				else
				{
					builder.Append(o1.AssociationSortKey, o2.AssociationSortKey);
				}
				builder.Append(o1.Name, o2.Name);
			}
			return builder.ToComparison();
		}
	}
}
