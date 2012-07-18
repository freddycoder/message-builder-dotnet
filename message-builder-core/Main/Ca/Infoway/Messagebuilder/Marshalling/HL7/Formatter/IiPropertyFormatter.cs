using System.Collections.Generic;
using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Util.Text;
using ILOG.J2CsMapping.Collections.Generics;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[DataTypeHandler("II")]
	internal class IiPropertyFormatter : AbstractAttributePropertyFormatter<Identifier>
	{
		private static ICollection<StandardDataType> abstractIiTypes = new HashSet<StandardDataType>(Arrays.AsList(StandardDataType
			.II, StandardDataType.II_BUS_AND_VER));

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		internal override string FormatNonNullDataType(FormatContext context, BareANY bareAny, int indentLevel)
		{
			IIImpl ii = (IIImpl)bareAny;
			StringBuilder builder = new StringBuilder();
			if (StringUtils.IsBlank(ii.Value.Root))
			{
				Indenter.IndentBuilder(builder, indentLevel);
				builder.Append("<!-- WARNING: ").Append("Property root on oid property ").Append(context.GetElementName()).Append(" cannot be null: "
					).Append(ii).Append(" -->");
				builder.Append(SystemUtils.LINE_SEPARATOR);
			}
			builder.Append(base.FormatNonNullDataType(context, ii, indentLevel));
			return builder.ToString();
		}

		/// <summary>
		/// II - Installer Identifier
		/// II has two attributes: root, extension
		/// CeRx standards claim that both attributes are required, although extension
		/// is sometimes unused.
		/// </summary>
		/// <remarks>
		/// II - Installer Identifier
		/// II has two attributes: root, extension
		/// CeRx standards claim that both attributes are required, although extension
		/// is sometimes unused.
		/// The HL7 standard also defines the assigningAuthorityName attribute, but that
		/// has been left out of the CeRx implementation.
		/// According to CeRx: Root has a limit of 100 characters, extension of 20
		/// characters. These limits are not currently enforced by this class.
		/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-II
		/// </remarks>
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		internal override IDictionary<string, string> GetAttributeNameValuePairs(FormatContext context, Identifier ii, BareANY bareAny
			)
		{
			VersionNumber version = context.GetVersion();
			IDictionary<string, string> result = new Dictionary<string, string>();
			result["root"] = ii.Root == null ? StringUtils.EMPTY : ii.Root;
			string type = context.Type;
			if (IsSpecializationTypeAllowed(version, type))
			{
				StandardDataType dataType = bareAny.DataType;
				if (!abstractIiTypes.Contains(dataType))
				{
					// only set a specialization type if we have a concrete II type supplied
					type = dataType.Type;
					result["specializationType"] = type;
				}
			}
			if (StringUtils.IsNotBlank(ii.Extension))
			{
				result["extension"] = ii.Extension;
			}
			if (StringUtils.Equals(StandardDataType.II_BUS.Type, type))
			{
				result["use"] = "BUS";
			}
			else
			{
				if (StringUtils.Equals(StandardDataType.II_VER.Type, type))
				{
					result["use"] = "VER";
				}
				else
				{
					if (StringUtils.Equals(StandardDataType.II_PUBLIC.Type, type))
					{
						result["displayable"] = "true";
						if (version != null)
						{
							if (!SpecificationVersion.IsVersion(SpecificationVersion.V01R04_3, version) && !SpecificationVersion.IsVersion(SpecificationVersion
								.V02R01, version) && !SpecificationVersion.IsVersion(SpecificationVersion.V02R02, version) && !SpecificationVersion.IsVersion
								(SpecificationVersion.NEWFOUNDLAND, version))
							{
								result["use"] = "BUS";
							}
						}
					}
				}
			}
			return result;
		}

		private bool IsSpecializationTypeAllowed(VersionNumber version, string type)
		{
			return !SpecificationVersion.IsVersion(SpecificationVersion.V01R04_3, version) && !(SpecificationVersion.IsVersion(SpecificationVersion
				.V02R02_AB, version) && StandardDataType.II.Type.Equals(type)) && (StandardDataType.II.Type.Equals(type) || StandardDataType
				.II_BUS_AND_VER.Type.Equals(type));
		}
	}
}
