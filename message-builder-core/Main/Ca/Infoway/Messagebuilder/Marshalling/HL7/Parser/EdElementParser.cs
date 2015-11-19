using System;
using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Constraints;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Util.Xml;
using Ca.Infoway.Messagebuilder.Xml;
using Platform.Xml.Sax;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	/// <summary>
	/// ED (R2)- Encapsulated Data
	/// Parses a ED element into an Encapsulated Data:
	/// This is some text.
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-ED
	/// </summary>
	[DataTypeHandler("ED")]
	public class EdElementParser : AbstractSingleElementParser<EncapsulatedData>
	{
		private readonly AbstractSingleElementParser<TelecommunicationAddress> telParser;

		private readonly EdConstraintsHandler constraintsHandler = new EdConstraintsHandler();

		private readonly EdValidationUtils edValidationUtils = new EdValidationUtils();

		private readonly bool isR2;

		public EdElementParser() : this(new TelElementParser(true), false)
		{
		}

		public EdElementParser(AbstractSingleElementParser<TelecommunicationAddress> telParser, bool isR2)
		{
			// R1
			this.isR2 = isR2;
			this.telParser = telParser;
		}

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new EDImpl<EncapsulatedData>();
		}

		protected override EncapsulatedData ParseNonNullNode(ParseContext context, XmlNode node, BareANY bareAny, Type expectedReturnType
			, XmlToModelResult result)
		{
			XmlElement element = (XmlElement)node;
			EncapsulatedData ed = new EncapsulatedData();
			if (!this.isR2 && element.HasAttribute("compression"))
			{
				ed = new CompressedData();
			}
			HandleRepresentation(ed, element, context, result);
			HandleMediaType(ed, element, result);
			HandleLanguage(ed, element, result);
			HandleCompression(ed, element, result);
			HandleIntegrityCheck(ed, element, context, result);
			HandleIntegrityCheckAlgorithm(ed, element, context, result);
			ValidateInnerNodes(element, result);
			HandleContent(ed, element, result, context);
			HandleReference(ed, element, result, context);
			HandleThumbnail(ed, element, result, context);
			HandleConstraints(ed, context.GetConstraints(), element, result);
			if (!this.isR2)
			{
				Validate(ed, element, context, result);
			}
			if (ed.IsEmpty())
			{
				ed = null;
			}
			return ed;
		}

		private void Validate(EncapsulatedData ed, XmlElement element, ParseContext context, XmlToModelResult xmlToModelResult)
		{
			int contentSize = (ed.HasContent() ? 1 : 0);
			// TODO - determine content size
			this.edValidationUtils.DoValidate(element.HasAttribute(AbstractElementParser.SPECIALIZATION_TYPE) ? element.GetAttribute(
				AbstractElementParser.SPECIALIZATION_TYPE) : null, ed.Compression, element.HasAttribute("compression"), ed.MediaType, ed
				.Language, element.HasAttribute("representation") ? element.GetAttribute("representation") : null, !GetNamedElements("reference"
				, element).IsEmpty() || (!this.isR2 && element.HasAttribute("reference")), ed.HasContent(), contentSize, context.GetVersion
				().GetBaseVersion(), context.Type, element, null, xmlToModelResult);
		}

		private void HandleConstraints(EncapsulatedData ed, ConstrainedDatatype constraints, XmlElement element, Hl7Errors errors
			)
		{
			ErrorLogger logger = new _ErrorLogger_144(errors, element);
			this.constraintsHandler.HandleConstraints(constraints, ed, logger);
		}

		private sealed class _ErrorLogger_144 : ErrorLogger
		{
			public _ErrorLogger_144(Hl7Errors errors, XmlElement element)
			{
				this.errors = errors;
				this.element = element;
			}

			public void LogError(Hl7ErrorCode errorCode, ErrorLevel errorLevel, string errorMessage)
			{
				errors.AddHl7Error(new Hl7Error(errorCode, errorLevel, errorMessage, element));
			}

			private readonly Hl7Errors errors;

			private readonly XmlElement element;
		}

		private void HandleContent(EncapsulatedData ed, XmlElement element, XmlToModelResult result, ParseContext context)
		{
			IList<XmlNode> allContentNodes = DetermineAllContentNodes(element);
			foreach (XmlNode node in allContentNodes)
			{
				try
				{
					ed.AddContent(node);
				}
				catch (TransformerException e)
				{
					result.GetHl7Errors().Add(new Hl7Error(Hl7ErrorCode.INTERNAL_ERROR, "An error occurred trying to parse ED content. Some or all of the content may not have been processed: "
						 + e.Message, element));
				}
			}
			ed.TrimContent();
		}

		private void ValidateInnerNodes(XmlElement element, Hl7Errors errors)
		{
			// should come in the following order (ignoring empty text nodes)
			// at most one reference
			// at most one thumbnail
			int referenceCount = 0;
			int thumbnailCount = 0;
			int contentCount = 0;
			bool nodesOutOfOrder = false;
			XmlNodeList childNodes = element.ChildNodes;
			foreach (XmlNode node in new XmlNodeListIterable(childNodes))
			{
				if ("reference".Equals(node.Name))
				{
					if (thumbnailCount > 0 || contentCount > 0)
					{
						nodesOutOfOrder = true;
					}
					referenceCount++;
				}
				else
				{
					if ("thumbnail".Equals(node.Name))
					{
						if (contentCount > 0)
						{
							nodesOutOfOrder = true;
						}
						thumbnailCount++;
					}
					else
					{
						if (!IsEmptyTextNode(node) && !IsComment(node))
						{
							// MBG-193 - we need not to count comments as content, regardless of where they occur in the element.
							contentCount++;
						}
					}
				}
			}
			if (referenceCount > 1)
			{
				RecordError("ED types only allow a single reference. Found: " + referenceCount, element, errors);
			}
			if (thumbnailCount > 1)
			{
				RecordError("ED types only allow a single thumbnail. Found: " + thumbnailCount, element, errors);
			}
			if (nodesOutOfOrder)
			{
				RecordError("ED properties appear to be out of order. If provided, order must be (reference element, thumbnail element, content)."
					, element, errors);
			}
		}

		private IList<XmlNode> DetermineAllContentNodes(XmlElement element)
		{
			// skip reference element, thumbnail element, blank text nodes
			IList<XmlNode> contentNodes = new List<XmlNode>();
			XmlNodeList childNodes = element.ChildNodes;
			foreach (XmlNode node in new XmlNodeListIterable(childNodes))
			{
				if ("reference".Equals(node.Name) || "thumbnail".Equals(node.Name))
				{
					// content only starts after last reference/thumbnail
					contentNodes.Clear();
				}
				else
				{
					contentNodes.Add(node);
				}
			}
			return contentNodes;
		}

		private bool IsEmptyTextNode(XmlNode node)
		{
			return IsTextNode(node) && StringUtils.IsBlank(node.Value);
		}

		private bool IsTextNode(XmlNode contentNode)
		{
			return contentNode.Name.Equals("#text") || contentNode.Name.Equals("#whitespace");
		}

		//.NET
		private bool IsComment(XmlNode node)
		{
			return node.Name.Equals("#comment");
		}

		private void HandleIntegrityCheckAlgorithm(EncapsulatedData ed, XmlElement element, ParseContext context, XmlToModelResult
			 result)
		{
			if (element.HasAttribute("integrityCheckAlgorithm"))
			{
				string icaString = element.GetAttribute("integrityCheckAlgorithm");
				try
				{
					IntegrityCheckAlgorithm ica = EnumPattern.ValueOf<IntegrityCheckAlgorithm>(icaString);
					if (!StringUtils.IsBlank(icaString) && ica == null)
					{
						//Invalid enum value
						throw new ArgumentException();
					}
					ed.IntegrityCheckAlgorithm = ica;
				}
				catch (Exception)
				{
					RecordError("Unknown value for integrityCheckAlgorithm: " + icaString, element, result);
				}
			}
		}

		private void HandleIntegrityCheck(EncapsulatedData ed, XmlElement element, ParseContext context, XmlToModelResult result)
		{
			if (element.HasAttribute("integrityCheck"))
			{
				string icString = element.GetAttribute("integrityCheck");
				ed.IntegrityCheck = icString;
			}
		}

		private void HandleReference(EncapsulatedData ed, XmlElement element, XmlToModelResult xmlToModelResult, ParseContext context
			)
		{
			IList<XmlElement> references = GetNamedElements("reference", element);
			if (references.IsEmpty() && !this.isR2)
			{
				if (element.HasAttribute("reference"))
				{
					references.Add(element);
				}
			}
			if (!references.IsEmpty())
			{
				XmlElement referenceElement = references[0];
				ParseContext newContext = ParseContextImpl.Create(this.isR2 ? "TEL" : "TEL.URI", context);
				BareANY parsedRef = this.telParser.Parse(newContext, referenceElement, xmlToModelResult);
				if (parsedRef != null && parsedRef.BareValue != null)
				{
					ed.ReferenceObj = (TelecommunicationAddress)parsedRef.BareValue;
				}
			}
		}

		private void HandleRepresentation(EncapsulatedData ed, XmlElement element, ParseContext context, XmlToModelResult result)
		{
			if (element.HasAttribute("representation"))
			{
				string representationString = element.GetAttribute("representation");
				try
				{
					EdRepresentation representation = EnumPattern.ValueOf<EdRepresentation>(representationString);
					if (!StringUtils.IsBlank(representationString) && representation == null)
					{
						//Invalid enum value
						throw new ArgumentException();
					}
					ed.Representation = representation;
				}
				catch (Exception)
				{
					RecordError("Unknown value for representation: " + representationString, element, result);
				}
			}
		}

		private void HandleThumbnail(EncapsulatedData ed, XmlElement element, XmlToModelResult xmlToModelResult, ParseContext context
			)
		{
			IList<XmlElement> thumbnails = GetNamedElements("thumbnail", element);
			if (!thumbnails.IsEmpty())
			{
				XmlElement thumbnailElement = thumbnails[0];
				ParseContext newContext = ParseContextImpl.Create("ED", context);
				BareANY parsedThumbnail = this.Parse(newContext, thumbnailElement, xmlToModelResult);
				EncapsulatedData edThumbnail = (EncapsulatedData)parsedThumbnail.BareValue;
				ed.Thumbnail = edThumbnail;
				if (edThumbnail.Thumbnail != null)
				{
					RecordError("ED thumbnail properties should not themselves also have a thumbnail." + thumbnails.Count, element, xmlToModelResult
						);
				}
			}
		}

		private void HandleLanguage(EncapsulatedData ed, XmlElement element, XmlToModelResult xmlToModelResult)
		{
			if (element.HasAttribute("language"))
			{
				ed.Language = element.GetAttribute("language");
			}
		}

		private void HandleCompression(EncapsulatedData ed, XmlElement element, XmlToModelResult xmlToModelResult)
		{
			if (element.HasAttribute("compression"))
			{
				ed.Compression = Compression.Get(element.GetAttribute("compression"));
			}
		}

		private void HandleMediaType(EncapsulatedData ed, XmlElement element, XmlToModelResult xmlToModelResult)
		{
			if (element.HasAttribute("mediaType"))
			{
				ed.MediaType = Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.Get(element.GetAttribute("mediaType"));
			}
		}

		private void RecordError(string message, XmlElement element, Hl7Errors errors)
		{
			errors.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, message, element));
		}
	}
}
