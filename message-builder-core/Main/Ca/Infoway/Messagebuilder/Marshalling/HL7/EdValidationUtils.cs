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


using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Util.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7
{
	public class EdValidationUtils
	{
		private const int ONE_MEGABYTE_SIZE = 1048576;

		public static readonly string REPRESENTATION_TXT = "TXT";

		public static readonly string REPRESENTATION_B64 = "B64";

		public static readonly string ATTRIBUTE_COMPRESSION = "compression";

		public static readonly string ATTRIBUTE_LANGUAGE = "language";

		public static readonly string ATTRIBUTE_REPRESENTATION = "representation";

		public static readonly string ATTRIBUTE_MEDIA_TYPE = "mediaType";

		public static readonly string ELEMENT_REFERENCE = "reference";

		public static readonly string ATTRIBUTE_VALUE = "value";

		public static readonly string CERX_ENGLISH = "eng";

		public static readonly string CERX_FRENCH = "fre";

		// for newer format of "reference" usage
		public virtual void DoValidate(EncapsulatedData ed, string specializationType, Hl7BaseVersion baseVersion, string type, string
			 propertyPath, Hl7Errors errors)
		{
			Compression compression = ed.Compression;
			bool hasCompression = (compression != null);
			int contentSize = (ed.HasContent() ? 1 : 0);
			string representation = (ed.Representation == null ? null : ed.Representation.Name);
			bool hasReference = (ed.ReferenceObj != null);
			DoValidate(specializationType, compression, hasCompression, ed.MediaType, ed.Language, representation, hasReference, ed.HasContent
				(), contentSize, baseVersion, type, null, propertyPath, errors);
		}

		public virtual void DoValidate(string specializationType, Compression compression, bool hasCompression, x_DocumentMediaType
			 mediaType, string language, string representation, bool hasReference, bool hasContent, int contentSize, Hl7BaseVersion 
			baseVersion, string type, XmlElement element, string propertyPath, Hl7Errors errors)
		{
			// specializationType - must be provided for ED.DOCORREF *except* for CeRx; must be ED.DOC or ED.DOCREF
			if (StandardDataType.ED_DOC_OR_REF.Type.Equals(type) && !Hl7BaseVersion.CERX.Equals(baseVersion))
			{
				if (StringUtils.IsBlank(specializationType) || StandardDataType.ED.Type.Equals(specializationType))
				{
					// must specify
					type = (!hasContent ? StandardDataType.ED_DOC_REF.Type : StandardDataType.ED_DOC.Type);
					CreateError("Must specify specializationType for ED.DOC_OR_REF types. Value will be treated as " + type + ".", element, propertyPath
						, errors);
				}
				else
				{
					if (!(StandardDataType.ED_DOC.Type.Equals(specializationType) || StandardDataType.ED_DOC_REF.Type.Equals(specializationType
						)))
					{
						// must be doc or docref; default to something suitable 
						type = (!hasContent ? StandardDataType.ED_DOC_REF.Type : StandardDataType.ED_DOC.Type);
						CreateError("Invalid specializationType: " + specializationType + ". The specializationType must be ED.DOC or ED.DOCREF for ED.DOC_OR_REF types. Value will be treated as "
							 + type + ".", element, propertyPath, errors);
					}
					else
					{
						type = specializationType;
					}
				}
			}
			// compression - required, must be DF or GZ
			//             - only GZ for CeRx (ED.DOCORREF), and only allowed if content present
			//             - not permitted for ED.REF
			if (hasCompression)
			{
				if (StandardDataType.ED_REF.Type.Equals(type))
				{
					// not allowed
					CreateError("Compression not allowed for ED.REF types.", element, propertyPath, errors);
				}
				else
				{
					if (Hl7BaseVersion.CERX.Equals(baseVersion) && (compression == null || !Compression.GZIP.CompressionType.Equals(compression
						.CompressionType)))
					{
						// only GZ allowed in this case
						CreateError("Only GZ compression allowed for CeRx ED.DOCORREF type.", element, propertyPath, errors);
					}
					else
					{
						if (compression == null || (!Compression.GZIP.CompressionType.Equals(compression.CompressionType) && !Compression.DEFLATE
							.CompressionType.Equals(compression.CompressionType)))
						{
							// only DF or GZ
							CreateError("Compression must be DF or GZ.", element, propertyPath, errors);
						}
					}
				}
			}
			// mediatype - mandatory; value from x_DocumentMediaType
			//           - ED.DOC/ED.DOCREF/MR2007, ED.DOCORREF/ED.REF/CeRx: restricted to "text/plain", "text/html", "text/xml", "application/pdf"
			if (mediaType == null)
			{
				// must be provided, and must be acceptable value
				CreateError("MediaType must be provided and must be a value from x_DocumentMediaType.", element, propertyPath, errors);
			}
			// language - required, 2-2
			//          - "eng" or "fre" (CeRx)
			if (StringUtils.IsNotBlank(language))
			{
				if (Hl7BaseVersion.CERX.Equals(baseVersion))
				{
					if (!CERX_ENGLISH.EqualsIgnoreCase(language) && !CERX_FRENCH.EqualsIgnoreCase(language))
					{
						// incorrect language for CeRx
						CreateError("The language attribute must be one of 'eng' or 'fre'.", element, propertyPath, errors);
					}
				}
				else
				{
					if (language.Length != 5 || (language[2] != '-'))
					{
						// needs to be a language code (yes, the above check isn't perfect, but it should be fine for most cases)
						CreateError("The language attribute must be a 2-letter language code, followed by a hyphen, followed by a 2-letter country code."
							, element, propertyPath, errors);
					}
				}
			}
			// representation - TXT or B64; vague on if this is mandatory or not; not permitted for CeRx
			if (StringUtils.IsNotBlank(representation))
			{
				if (!REPRESENTATION_TXT.EqualsIgnoreCase(representation) && !REPRESENTATION_B64.EqualsIgnoreCase(representation))
				{
					// error
					CreateError("The representation attribute must be one of 'TXT' or 'B64'.", element, propertyPath, errors);
				}
			}
			// reference - required; must be TEL.URI (mandatory for ED.DOCREF)
			//           - CeRx: only allowed (and mandatory?) if content not present; must be FTP, HTTP, HTTPS  (ED.REF, ED.DOCORREF) 
			if (!hasReference)
			{
				if (StandardDataType.ED_DOC_REF.Type.Equals(type) || StandardDataType.ED_REF.Type.Equals(type))
				{
					// mandatory case
					CreateError("Reference is mandatory.", element, propertyPath, errors);
				}
			}
			if (element != null && element.HasAttribute(ELEMENT_REFERENCE))
			{
				CreateError("Reference is not allowed as an attribute; it should be in a <reference> element having a value attribute containing the actual reference."
					, element, propertyPath, errors);
			}
			// content - max 1 MB after compression and base64 encoding; compressed or pdf must be b64-encoded; any checks done on this??
			//         - mandatory for ED.DOC, ED.DOCORREF/CeRx (if no ref provided)
			//         - not permitted for ED.DOCREF/ED.REF
			if (hasContent && contentSize > 0)
			{
				if (StandardDataType.ED_DOC_REF.Type.Equals(type) || StandardDataType.ED_REF.Type.Equals(type))
				{
					// not permitted
					CreateError("Content is not permitted for " + type + ".", element, propertyPath, errors);
				}
				if (contentSize > ONE_MEGABYTE_SIZE)
				{
					// too large
					CreateError("Content must be less than 1 MB.", element, propertyPath, errors);
				}
			}
			else
			{
				if (StandardDataType.ED_DOC.Type.Equals(type))
				{
					// must be provided
					CreateError("Content must be provided for " + type + ".", element, propertyPath, errors);
				}
			}
			if (Hl7BaseVersion.CERX.Equals(baseVersion) && StandardDataType.ED_DOC_OR_REF.Type.Equals(type))
			{
				if (hasReference && hasContent)
				{
					// can't provide both
					CreateError("Cannot provide both content and reference.", element, propertyPath, errors);
				}
				else
				{
					if (!hasReference && !hasContent)
					{
						// must provide one
						CreateError("Must provide one and only one of content or reference.", element, propertyPath, errors);
					}
				}
			}
		}

		private void CreateError(string errorMessage, XmlElement element, string propertyPath, Hl7Errors errors)
		{
			Hl7Error error = null;
			if (element != null)
			{
				error = new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, errorMessage + " (" + XmlDescriber.DescribeSingleElement(element) + ")"
					, element);
			}
			else
			{
				// assuming this has a property path
				error = new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, errorMessage, propertyPath);
			}
			errors.AddHl7Error(error);
		}
	}
}
