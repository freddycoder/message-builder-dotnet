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
using ILOG.J2CsMapping.Collections.Generics;

namespace Ca.Infoway.Messagebuilder.Xml
{
	public class CodedTypeEvaluator
	{
		private CodedTypeEvaluator()
		{
		}

		/// <summary>This checks if a given type is a coded type.</summary>
		/// <remarks>This checks if a given type is a coded type. This also works for collection types (e.g. LIST is a coded type).</remarks>
		/// <param name="type"></param>
		/// <returns>whether the type is a coded type</returns>
		public static bool IsCodedType(string type)
		{
			if (StringUtils.IsBlank(type))
			{
				return false;
			}
			Hl7TypeName parsedType = Hl7TypeName.Parse(type);
			Hl7TypeName typeToCheck = parsedType;
			if (IsCollectionType(typeToCheck))
			{
				IList<Hl7TypeName> parsedTypeParameters = parsedType.Parameters;
				if (parsedTypeParameters.Count == 1)
				{
					typeToCheck = parsedTypeParameters[0];
				}
			}
			IList<Hl7TypeName> parameters = typeToCheck.Parameters;
			if (parameters.Count == 1)
			{
				typeToCheck = parameters[0];
			}
			string rootType = typeToCheck.RootName;
			// FIXME - CDA - TM - SC (for R1) is not a coded type (though it likely should be modified to be one)
			return Arrays.AsList("CD", "CV", "CE", "CO", "SC", "CS", "PQR").Contains(rootType);
		}

		public static string GetR2CodedType(string type)
		{
			string r2Type = type;
			if (IsCodedType(type))
			{
				if ("CD".Equals(type) || "CV".Equals(type) || "CE".Equals(type) || "SC".Equals(type) || "CS".Equals(type))
				{
					r2Type = type + "_R2";
				}
			}
			return r2Type;
		}

		private static bool IsCollectionType(Hl7TypeName typeToCheck)
		{
			return Arrays.AsList("LIST", "SET", "BAG", "COLLECTION").Contains(typeToCheck.RootName);
		}
	}
}
