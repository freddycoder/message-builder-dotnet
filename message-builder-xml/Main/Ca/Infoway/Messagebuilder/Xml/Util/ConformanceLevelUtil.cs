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
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Xml.Util
{
	public class ConformanceLevelUtil
	{
		public static readonly string ASSOCIATION_IS_IGNORED_AND_CANNOT_BE_USED = "Association is ignored and cannot be used: ({0})";

		public static readonly string ASSOCIATION_IS_IGNORED_AND_WILL_NOT_BE_USED = "Association is ignored and will not be used: ({0})";

		public static readonly string ATTRIBUTE_IS_IGNORED_AND_CANNOT_BE_USED = "Attribute is ignored and cannot be used: ({0})";

		public static readonly string ATTRIBUTE_IS_IGNORED_AND_WILL_NOT_BE_USED = "Attribute is ignored and will not be used: ({0})";

		public static readonly string ASSOCIATION_IS_NOT_ALLOWED = "Association is not allowed: ({0})";

		public static readonly string ATTRIBUTE_IS_NOT_ALLOWED = "Attribute is not allowed: ({0})";

		public static readonly string IGNORED_AS_NOT_ALLOWED = "ignored.as.not.allowed";

		public static bool IsIgnoredNotAllowed()
		{
			return Ca.Infoway.Messagebuilder.BooleanUtils.ValueOf(Runtime.GetProperty(IGNORED_AS_NOT_ALLOWED));
		}

		/// <summary>Get a flag indicating whether or not the relationship is mandatory or populated.</summary>
		/// <remarks>Get a flag indicating whether or not the relationship is mandatory or populated.</remarks>
		/// <returns>true if the relationship is mandatory or populated; false otherwise.</returns>
		public static bool IsMandatoryOrPopulated(Relationship relationship)
		{
			return IsMandatory(relationship) || IsPopulated(relationship);
		}

		/// <summary>Get a flag indicating whether or not the relationship is mandatory.</summary>
		/// <remarks>Get a flag indicating whether or not the relationship is mandatory.</remarks>
		/// <returns>true if the relationship is mandatory; false otherwise.</returns>
		public static bool IsMandatory(Relationship relationship)
		{
			return IsMandatory(relationship.Conformance, relationship.Cardinality);
		}

		/// <summary>Get a flag indicating whether or not the relationship is mandatory.</summary>
		/// <remarks>Get a flag indicating whether or not the relationship is mandatory.</remarks>
		/// <returns>true if the relationship is mandatory; false otherwise.</returns>
		public static bool IsMandatory(Ca.Infoway.Messagebuilder.Xml.ConformanceLevel conformanceLevel, Cardinality cardinality)
		{
			return Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY.Equals(conformanceLevel);
		}

		/// <summary>Get a flag indicating whether or not the relationship is populated.</summary>
		/// <remarks>Get a flag indicating whether or not the relationship is populated.</remarks>
		/// <returns>true if the relationship is populated; false otherwise.</returns>
		public static bool IsPopulated(Relationship relationship)
		{
			return IsPopulated(relationship.Conformance, relationship.Cardinality);
		}

		/// <summary>Get a flag indicating whether or not the relationship is populated.</summary>
		/// <remarks>Get a flag indicating whether or not the relationship is populated.</remarks>
		/// <returns>true if the relationship is populated; false otherwise.</returns>
		public static bool IsPopulated(Ca.Infoway.Messagebuilder.Xml.ConformanceLevel conformanceLevel, Cardinality cardinality)
		{
			// - this *almost* matches what MB was doing prior to a Remixer change to BaseMifProcessorImpl
			// - IGNORED and NOT_ALLOWED with a min cardinality > 0 (a very strange state!) will behave differently than before the Remixer change 
			// - populated should eventually be removed as a conformance altogether
			return Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED.Equals(conformanceLevel) || (Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.REQUIRED.Equals(conformanceLevel) && cardinality.Mandatory);
		}

		/// <summary>Get a flag indicating whether or not the relationship is required.</summary>
		/// <remarks>Get a flag indicating whether or not the relationship is required.</remarks>
		/// <returns>true if the relationship is required; false otherwise.</returns>
		public static bool IsRequired(Relationship relationship)
		{
			return IsRequired(relationship.Conformance, relationship.Cardinality);
		}

		/// <summary>Get a flag indicating whether or not the relationship is required.</summary>
		/// <remarks>Get a flag indicating whether or not the relationship is required.</remarks>
		/// <returns>true if the relationship is required; false otherwise.</returns>
		public static bool IsRequired(Ca.Infoway.Messagebuilder.Xml.ConformanceLevel conformanceLevel, Cardinality cardinality)
		{
			return Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.REQUIRED.Equals(conformanceLevel) && !cardinality.Mandatory;
		}

		/// <summary>Get a flag indicating whether or not the relationship is optional.</summary>
		/// <remarks>Get a flag indicating whether or not the relationship is optional.</remarks>
		/// <returns>true if the relationship is optional; false otherwise.</returns>
		public static bool IsOptional(Relationship relationship)
		{
			return IsOptional(relationship.Conformance, relationship.Cardinality);
		}

		/// <summary>Get a flag indicating whether or not the relationship is optional.</summary>
		/// <remarks>Get a flag indicating whether or not the relationship is optional.</remarks>
		/// <returns>true if the relationship is optional; false otherwise.</returns>
		public static bool IsOptional(Ca.Infoway.Messagebuilder.Xml.ConformanceLevel conformanceLevel, Cardinality cardinality)
		{
			return Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL.Equals(conformanceLevel);
		}

		/// <summary>Get a flag indicating whether or not the relationship is ignored.</summary>
		/// <remarks>Get a flag indicating whether or not the relationship is ignored.</remarks>
		/// <returns>true if the relationship is ignored; false otherwise.</returns>
		public static bool IsIgnored(Relationship relationship)
		{
			return IsIgnored(relationship.Conformance, relationship.Cardinality);
		}

		/// <summary>Get a flag indicating whether or not the relationship is ignored.</summary>
		/// <remarks>Get a flag indicating whether or not the relationship is ignored.</remarks>
		/// <returns>true if the relationship is ignored; false otherwise.</returns>
		public static bool IsIgnored(Ca.Infoway.Messagebuilder.Xml.ConformanceLevel conformanceLevel, Cardinality cardinality)
		{
			return Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.IGNORED.Equals(conformanceLevel);
		}

		/// <summary>Get a flag indicating whether or not the relationship is not allowed.</summary>
		/// <remarks>Get a flag indicating whether or not the relationship is not allowed.</remarks>
		/// <returns>true if the relationship is not allowed; false otherwise.</returns>
		public static bool IsNotAllowed(Relationship relationship)
		{
			return IsNotAllowed(relationship.Conformance, relationship.Cardinality);
		}

		/// <summary>Get a flag indicating whether or not the relationship is not allowed.</summary>
		/// <remarks>Get a flag indicating whether or not the relationship is not allowed.</remarks>
		/// <returns>true if the relationship is not allowed; false otherwise.</returns>
		public static bool IsNotAllowed(Ca.Infoway.Messagebuilder.Xml.ConformanceLevel conformanceLevel, Cardinality cardinality)
		{
			return Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.NOT_ALLOWED.Equals(conformanceLevel);
		}
	}
}
