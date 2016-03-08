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
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Xml;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Xml
{
	[TestFixture]
	public class RelationshipTest
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldSortRelationships()
		{
			Relationship relationship1 = CreateRelationship(true, "attribute", 5, null);
			Relationship relationship2 = CreateRelationship(true, "another attribute", 11, null);
			Relationship relationship3 = CreateRelationship(false, "early association", 3, "A");
			Relationship relationship4 = CreateRelationship(false, "late association a", 9, "ZZ");
			Relationship relationship5 = CreateRelationship(false, "late association b", 6, "ZZ");
			Relationship relationship6 = CreateRelationship(false, "underscores association a", 12, "ZZZ_____");
			Relationship relationship7 = CreateRelationship(false, "underscores association b", 15, "ZZZA____");
			List<Relationship> list = new List<Relationship>();
			list.Add(relationship7);
			list.Add(relationship6);
			list.Add(relationship5);
			list.Add(relationship3);
			list.Add(relationship4);
			list.Add(relationship1);
			list.Add(relationship2);
			//		Collections.shuffle(list);	// just to make it interesting  // TM - removed for translation purposes
			list.Sort();
			Assert.IsTrue(relationship1 == list[0]);
			Assert.IsTrue(relationship2 == list[1]);
			Assert.IsTrue(relationship3 == list[2]);
			Assert.IsTrue(relationship4 == list[3]);
			Assert.IsTrue(relationship5 == list[4]);
			Assert.IsTrue(relationship6 == list[5]);
			Assert.IsTrue(relationship7 == list[6]);
		}

		private Relationship CreateRelationship(bool isAttribute, string name, int sortKey, string associationSortKey)
		{
			Relationship result = new Relationship();
			result.Name = name;
			result.SortOrder = sortKey;
			if (isAttribute)
			{
				result.Type = "CS";
				result.FixedValue = "FIXED";
			}
			else
			{
				// faking out the dumb isAttribute() algorithm
				result.Type = "PORX_MT010101CA.EntryPoint";
				result.AssociationSortKey = associationSortKey;
			}
			return result;
		}
	}
}
