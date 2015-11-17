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
using System;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	/// <summary>
	/// INT (R2)
	/// Represents a INT object as an element:
	/// &lt;element-name value="1234"&gt;&lt;/element-name&gt;
	/// If an object is null, value is replaced by a nullFlavor.
	/// </summary>
	/// <remarks>
	/// INT (R2)
	/// Represents a INT object as an element:
	/// &lt;element-name value="1234"&gt;&lt;/element-name&gt;
	/// If an object is null, value is replaced by a nullFlavor. So the element would look
	/// like this:
	/// &lt;element-name nullFlavor="something" /&gt;
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-INT
	/// </remarks>
	[DataTypeHandler(new string[] { "INT", "SXCM<INT>" })]
	internal class IntR2PropertyFormatter : AbstractValueNullFlavorPropertyFormatter<Int32?>
	{
		private readonly SxcmR2PropertyFormatterHelper sxcmHelper = new SxcmR2PropertyFormatterHelper();

		protected override string GetValue(Int32? integer, FormatContext context, BareANY bareAny)
		{
			return integer.ToString();
		}

		protected override void AddOtherAttributesIfNecessary(Int32? integer, IDictionary<string, string> attributes, FormatContext
			 context, BareANY bareAny)
		{
			this.sxcmHelper.HandleOperator(attributes, context, (ANYMetaData)bareAny);
			// this is a hack to allow for a single known instance where the base model has extended a data type (INT, in this case) to have an extra property 
			if (bareAny is ANYMetaData && ((ANYMetaData)bareAny).Unsorted)
			{
				attributes["unsorted"] = "true";
			}
		}
	}
}
