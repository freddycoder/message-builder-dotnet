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


using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Domainvalue.Util;
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Basic
{
	[System.Serializable]
	public class X_DocumentMediaType : EnumPattern, x_DocumentMediaType, Describable
	{
		static X_DocumentMediaType()
		{
		}

		private const long serialVersionUID = 3563081021150491143L;

		/// <summary>For any plain text.</summary>
		/// <remarks>For any plain text.</remarks>
		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType PLAIN_TEXT = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType
			("PLAIN_TEXT", "text/plain");

		/// <summary>For marked-up text according to the Hypertext Mark-up Language.</summary>
		/// <remarks>
		/// For marked-up text according to the Hypertext Mark-up Language. HTML markup
		/// is sufficient for typographically marking-up most written-text documents.
		/// HTML is platform independent and widely deployed.
		/// </remarks>
		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType HTML_TEXT = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType
			("HTML_TEXT", "text/html");

		/// <summary>
		/// The Portable Document Format is recommended for written text that is completely
		/// laid out and read-only.
		/// </summary>
		/// <remarks>
		/// The Portable Document Format is recommended for written text that is completely
		/// laid out and read-only. PDF is a platform independent, widely deployed, and open
		/// specification with freely available creation and rendering tools.
		/// </remarks>
		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType PDF = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType
			("PDF", "application/pdf");

		/// <summary>For structured character based data.</summary>
		/// <remarks>
		/// For structured character based data. There is a risk that general SGML/XML is too
		/// powerful to allow a sharing of general SGML/XML documents between different
		/// applications.
		/// </remarks>
		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType XML_TEXT = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType
			("XML_TEXT", "text/xml");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType HL7_CDA = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType
			("HL7_CDA", "multipart/x-hl7-cda-level-one");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType DICOM = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType
			("DICOM", "application/dicom");

		private readonly string mimeType;

		private X_DocumentMediaType(string name, string mimeType) : base(name)
		{
			this.mimeType = mimeType;
		}

		/// <summary>Returns the mime type.</summary>
		/// <remarks>Returns the mime type.</remarks>
		/// <returns>the mime type</returns>
		public virtual string MimeType
		{
			get
			{
				return this.mimeType;
			}
		}

		/// <summary>Obtains the media type registered for the supplied mime type.</summary>
		/// <remarks>
		/// Obtains the media type registered for the supplied mime type.
		/// Returns null if no media type could be found.
		/// </remarks>
		/// <param name="mimeType">the mimetype to match</param>
		/// <returns>the applicable X_DocumentMediaType</returns>
		public static Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType Get(string mimeType)
		{
			Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType result = null;
			foreach (Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType X_DocumentMediaType in EnumPattern.Values<Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType
				>())
			{
				if (X_DocumentMediaType.MimeType.Equals(mimeType))
				{
					result = X_DocumentMediaType;
					break;
				}
			}
			return result;
		}

		/// <summary>Returns the media type code system.</summary>
		/// <remarks>Returns the media type code system.</remarks>
		/// <returns>the media type code system</returns>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_DOCUMENT_MEDIA_TYPES.Root;
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystemName
		{
			get
			{
				return null;
			}
		}

		/// <summary>Returns the code value.</summary>
		/// <remarks>Returns the code value.</remarks>
		/// <returns>the code value</returns>
		public virtual string CodeValue
		{
			get
			{
				return this.mimeType;
			}
		}

		/// <summary>Returns the description of the media type.</summary>
		/// <remarks>Returns the description of the media type.</remarks>
		/// <returns>the description</returns>
		public virtual string Description
		{
			get
			{
				return DescribableUtil.GetDefaultDescription(this);
			}
		}
	}
}
