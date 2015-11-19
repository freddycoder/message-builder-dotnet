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
 * Author:        $LastChangedBy: jmis $
 * Last modified: $LastChangedDate: 2015-05-27 08:43:37 -0400 (Wed, 27 May 2015) $
 * Revision:      $LastChangedRevision: 9535 $
 */
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Xml
{
	/// <summary>A base class for types that support choices.</summary>
	/// <remarks>A base class for types that support choices.</remarks>
	/// <author>Intelliware Development</author>
	public abstract class ChoiceSupport
	{
		/// <summary>Find a specific choice based on some matching strategy defined by the predicate.</summary>
		/// <remarks>Find a specific choice based on some matching strategy defined by the predicate.</remarks>
		/// <param name="predicate">- a class that determines the matching strategy of the choice.</param>
		/// <returns>the selected choice.</returns>
		public virtual Relationship FindChoiceOption(Ca.Infoway.Messagebuilder.Xml.Predicate<Relationship> predicate)
		{
			return FindChoiceOption(predicate, Choices);
		}

		public virtual IList<string> GetAllBottomMostOptionNames()
		{
			return GetAllBottomMostOptionNames(Choices, new List<string>());
		}

		private IList<string> GetAllBottomMostOptionNames(IList<Relationship> optionRelationships, IList<string> optionsResult)
		{
			foreach (Relationship option in optionRelationships)
			{
				if (option.Choice)
				{
					// ignore this option since it is itself a choice, but add in its options
					GetAllBottomMostOptionNames(option.Choices, optionsResult);
				}
				else
				{
					optionsResult.Add(option.Name);
				}
			}
			return optionsResult;
		}

		private static Relationship FindChoiceOption(Ca.Infoway.Messagebuilder.Xml.Predicate<Relationship> predicate, IList<Relationship
			> choices)
		{
			Relationship result = null;
			foreach (Relationship option in choices)
			{
				if (option.Choice)
				{
					result = option.FindChoiceOption(predicate);
				}
				else
				{
					if (predicate.Apply(option))
					{
						result = option;
					}
				}
				if (result != null)
				{
					break;
				}
			}
			return result;
		}

		/// <summary>Get the list of choices.</summary>
		/// <remarks>Get the list of choices.</remarks>
		/// <returns>the list of choices.</returns>
		public abstract IList<Relationship> Choices
		{
			get;
		}

		/// <summary>Get a flag indicating whether or not the relationship or argument is a choice association.</summary>
		/// <remarks>Get a flag indicating whether or not the relationship or argument is a choice association.</remarks>
		/// <returns>true if the relationship or argument is a choice association; false otherwise</returns>
		public virtual bool Choice
		{
			get
			{
				return !CollUtils.IsEmpty(Choices);
			}
		}

		/// <summary>
		/// A convenience utility to create a predicate that finds a specific choice based
		/// on the name of the XML element.
		/// </summary>
		/// <remarks>
		/// A convenience utility to create a predicate that finds a specific choice based
		/// on the name of the XML element.
		/// </remarks>
		/// <param name="relationshipName">- the name of the XML element on the incoming message</param>
		/// <returns>the corresponding choice.</returns>
		public static Ca.Infoway.Messagebuilder.Xml.Predicate<Relationship> ChoiceOptionNamePredicate(string relationshipName)
		{
			return new ChoiceSupport.ChoiceOptionNamePredicateClass(relationshipName);
		}

		internal class ChoiceOptionNamePredicateClass : Ca.Infoway.Messagebuilder.Xml.Predicate<Relationship>
		{
			private readonly string relationshipName;

			public ChoiceOptionNamePredicateClass(string relationshipName)
			{
				this.relationshipName = relationshipName;
			}

			public virtual bool Apply(Relationship option)
			{
				return option.Name.Equals(relationshipName);
			}
		}

		/// <summary>
		/// A convenience utility to create a predicate that finds a specific choice based
		/// on the part type (or part types).
		/// </summary>
		/// <remarks>
		/// A convenience utility to create a predicate that finds a specific choice based
		/// on the part type (or part types).
		/// </remarks>
		/// <param name="relationshipTypes">- the part types (typically taken from a part type mapping)</param>
		/// <returns>the corresponding choice.</returns>
		public static Ca.Infoway.Messagebuilder.Xml.Predicate<Relationship> ChoiceOptionTypePredicate(string[] relationshipTypes)
		{
			return new ChoiceSupport.ChoiceOptionTypePredicateClass(relationshipTypes);
		}

		internal class ChoiceOptionTypePredicateClass : Ca.Infoway.Messagebuilder.Xml.Predicate<Relationship>
		{
			private readonly string[] relationshipTypes;

			internal ChoiceOptionTypePredicateClass(string[] relationshipTypes)
			{
				this.relationshipTypes = relationshipTypes;
			}

			public virtual bool Apply(Relationship option)
			{
				bool result = false;
				foreach (string relationshipType in relationshipTypes)
				{
					if (StringUtils.Equals(option.Type, relationshipType) || MessagePartVersionSuffixHelper.MatchesDisregardingVersionSuffix(
						option.Type, relationshipType))
					{
						result = true;
						break;
					}
				}
				return result;
			}
		}
	}
}
