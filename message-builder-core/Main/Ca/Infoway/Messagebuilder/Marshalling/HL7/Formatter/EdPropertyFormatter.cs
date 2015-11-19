using System;
using System.Collections.Generic;
using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Constraints;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// ED - Encapsulated Data
	/// ED.DOCORREF - Encapsulated Data (Document or Reference)
	/// (etc.)
	/// Represents a String as an element:
	/// &lt;element-name mediaType="text/plain"&gt;This is some
	/// text.&lt;/element-name&gt;
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-ED
	/// </summary>
	[DataTypeHandler("ED")]
	public class EdPropertyFormatter : AbstractNullFlavorPropertyFormatter<EncapsulatedData>
	{
		private AbstractNullFlavorPropertyFormatter<TelecommunicationAddress> telFormatter;

		private readonly EdConstraintsHandler constraintsHandler = new EdConstraintsHandler();

		private EdContentRenderer edContentRenderer = new EdContentRenderer();

		private EdValidationUtils edValidationUtils = new EdValidationUtils();

		private readonly bool isR2;

		public EdPropertyFormatter() : this(new TelUriPropertyFormatter(), false)
		{
		}

		public EdPropertyFormatter(AbstractNullFlavorPropertyFormatter<TelecommunicationAddress> telFormatter, bool isR2)
		{
			// R1
			this.isR2 = isR2;
			this.telFormatter = telFormatter;
		}

		protected override string FormatNonNullValue(FormatContext context, EncapsulatedData data, int indentLevel)
		{
			throw new NotSupportedException("ED uses formatNonNullDataType() method instead.");
		}

		protected override string FormatNonNullDataType(FormatContext context, BareANY dataType, int indentLevel)
		{
			EncapsulatedData encapsulatedData = ExtractBareValue(dataType);
			HandleConstraints(encapsulatedData, context.GetConstraints(), context.GetPropertyPath(), context.GetModelToXmlResult());
			IDictionary<string, string> attributes = CreateAttributes(encapsulatedData, context);
			bool hasContent = HasContent(encapsulatedData);
			bool hasReferenceOrThumbnailOrDocument = HasReferenceOrThumbnailOrDocument(encapsulatedData);
			if (!this.isR2)
			{
				AddSpecializationType(encapsulatedData, attributes, context.Type, dataType.DataType, context.GetVersion());
				Validate(context, dataType, encapsulatedData);
			}
			StringBuilder buffer = new StringBuilder();
			buffer.Append(CreateElement(context, attributes, indentLevel, !hasContent, hasReferenceOrThumbnailOrDocument));
			if (hasContent)
			{
				WriteReference(encapsulatedData, buffer, indentLevel + 1, context);
				WriteThumbnail(encapsulatedData, buffer, indentLevel + 1, context);
				this.edContentRenderer.RenderContent(encapsulatedData, buffer, indentLevel + 1, context, hasReferenceOrThumbnailOrDocument
					);
				buffer.Append(CreateElementClosure(context, hasReferenceOrThumbnailOrDocument ? indentLevel : 0, true));
			}
			return buffer.ToString();
		}

		private void HandleConstraints(EncapsulatedData ed, ConstrainedDatatype constraints, string propertyPath, Hl7Errors errors
			)
		{
			ErrorLogger logger = new _ErrorLogger_117(errors, propertyPath);
			this.constraintsHandler.HandleConstraints(constraints, ed, logger);
		}

		private sealed class _ErrorLogger_117 : ErrorLogger
		{
			public _ErrorLogger_117(Hl7Errors errors, string propertyPath)
			{
				this.errors = errors;
				this.propertyPath = propertyPath;
			}

			public void LogError(Hl7ErrorCode errorCode, ErrorLevel errorLevel, string errorMessage)
			{
				errors.AddHl7Error(new Hl7Error(errorCode, errorLevel, errorMessage, propertyPath));
			}

			private readonly Hl7Errors errors;

			private readonly string propertyPath;
		}

		private bool HasContent(EncapsulatedData encapsulatedData)
		{
			return HasReferenceOrThumbnailOrDocument(encapsulatedData) || encapsulatedData.HasContent();
		}

		private bool HasReferenceOrThumbnailOrDocument(EncapsulatedData encapsulatedData)
		{
			return encapsulatedData.ReferenceObj != null || encapsulatedData.Thumbnail != null || encapsulatedData.HasContent();
		}

		private void WriteReference(EncapsulatedData encapsulatedData, StringBuilder buffer, int indentLevel, FormatContext context
			)
		{
			if (encapsulatedData.ReferenceObj != null)
			{
				TEL tel = new TELImpl(encapsulatedData.ReferenceObj);
				FormatContext newContext = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(isR2 ? "TEL" : "TEL.URI"
					, "reference", context);
				string formattedReference = this.telFormatter.Format(newContext, tel, indentLevel);
				if (StringUtils.IsNotBlank(formattedReference))
				{
					buffer.Append(formattedReference);
				}
			}
		}

		private void WriteThumbnail(EncapsulatedData encapsulatedData, StringBuilder buffer, int indentLevel, FormatContext context
			)
		{
			EncapsulatedData thumbnail = encapsulatedData.Thumbnail;
			if (thumbnail != null)
			{
				if (thumbnail.Thumbnail != null)
				{
					RecordError("For ED types, the thumbnail property itself cannot also have a thumbnail", context);
				}
				ED<EncapsulatedData> thumbnailWrapper = new EDImpl<EncapsulatedData>(thumbnail);
				FormatContext newContext = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl("ED", "thumbnail", context
					);
				string formattedThumbnail = this.Format(newContext, thumbnailWrapper, indentLevel);
				if (StringUtils.IsNotBlank(formattedThumbnail))
				{
					buffer.Append(formattedThumbnail);
				}
			}
		}

		private IDictionary<string, string> CreateAttributes(EncapsulatedData encapsulatedData, FormatContext context)
		{
			IDictionary<string, string> attributes = new Dictionary<string, string>();
			if (encapsulatedData.Representation != null)
			{
				attributes["representation"] = encapsulatedData.Representation.ToString();
			}
			if (encapsulatedData.MediaType != null)
			{
				attributes["mediaType"] = encapsulatedData.MediaType.CodeValue;
			}
			if (encapsulatedData.Language != null)
			{
				attributes["language"] = encapsulatedData.Language;
			}
			if (encapsulatedData.Compression != null)
			{
				attributes["compression"] = encapsulatedData.Compression.CompressionType;
			}
			if (encapsulatedData.IntegrityCheck != null)
			{
				this.edContentRenderer.ValidateBase64Encoded("integrityCheck", encapsulatedData.IntegrityCheck, context);
				attributes["integrityCheck"] = encapsulatedData.IntegrityCheck;
			}
			if (encapsulatedData.IntegrityCheckAlgorithm != null)
			{
				attributes["integrityCheckAlgorithm"] = System.Text.RegularExpressions.Regex.Replace(encapsulatedData.IntegrityCheckAlgorithm
					.ToString(), "_", "-");
			}
			return attributes;
		}

		private void RecordError(string message, FormatContext context)
		{
			context.GetModelToXmlResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, message, context.GetPropertyPath()));
		}

		private void Validate(FormatContext context, BareANY dataType, EncapsulatedData encapsulatedData)
		{
			string type = context.Type;
			string specializationType = dataType.DataType == null ? null : dataType.DataType.Type;
			Hl7BaseVersion baseVersion = context.GetVersion().GetBaseVersion();
			Hl7Errors errors = context.GetModelToXmlResult();
			this.edValidationUtils.DoValidate(encapsulatedData, specializationType, baseVersion, type, context.GetPropertyPath(), errors
				);
		}

		private void AddSpecializationType(EncapsulatedData ed, IDictionary<string, string> attributes, string type, StandardDataType
			 specializationType, VersionNumber version)
		{
			if (StandardDataType.ED_DOC_OR_REF.Type.Equals(type) && !Hl7BaseVersion.CERX.Equals(version.GetBaseVersion()))
			{
				if (specializationType == StandardDataType.ED_DOC || specializationType == StandardDataType.ED_DOC_REF)
				{
					AddSpecializationType(attributes, specializationType.Type);
				}
				else
				{
					// best guess: check content to decide on DOC or DOC_REF (CDA/R1 will get ST, though clients may not want it)
					AddSpecializationType(attributes, ed.HasContent() ? StandardDataType.ED_DOC.Type : StandardDataType.ED_DOC_REF.Type);
				}
			}
		}
	}
}
