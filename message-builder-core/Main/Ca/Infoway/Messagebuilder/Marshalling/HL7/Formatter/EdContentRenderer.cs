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
using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Platform;
using Ca.Infoway.Messagebuilder.Util.Text;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	public class EdContentRenderer
	{
		public virtual void RenderContent(EncapsulatedData encapsulatedData, StringBuilder buffer, int indentLevel, FormatContext
			 context, bool hasReferenceOrThumbnailOrDocument)
		{
			bool hasContent = (encapsulatedData.Content != null);
			if (hasReferenceOrThumbnailOrDocument && hasContent)
			{
				Indenter.IndentBuffer(buffer, indentLevel);
			}
			if (hasContent)
			{
				string textContent = encapsulatedData.Content;
				if (EdRepresentation.B64.Equals(encapsulatedData.Representation))
				{
					ValidateBase64Encoded("content", textContent, context);
				}
				buffer.Append(textContent);
			}
			if (hasReferenceOrThumbnailOrDocument && hasContent)
			{
				buffer.Append(SystemUtils.LINE_SEPARATOR);
			}
		}

		public virtual void ValidateBase64Encoded(string property, string stringToCheck, FormatContext context)
		{
			try
			{
				Base64.DecodeBase64String(stringToCheck);
			}
			catch (Exception)
			{
				RecordError("The ED property '" + property + "' does not appear to be Base64 encoded.", context);
			}
		}

		private void RecordError(string message, FormatContext context)
		{
			context.GetModelToXmlResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, message, context.GetPropertyPath()));
		}
	}
}
