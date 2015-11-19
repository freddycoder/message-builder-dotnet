using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	/// <summary>CS - Coded Simple (R2 datatype variant)</summary>
	[DataTypeHandler("CS")]
	internal class CsR2PropertyFormatter : AbstractCodedTypeR2PropertyFormatter
	{
		protected override bool CodeValueAllowed()
		{
			return true;
		}

		protected override bool CodeSystemAllowed()
		{
			// Technically, CS does not allow for a codeSystem. However, we don't want to log an error just because a Code also has a CodeSystem with it (most common case)  
			return true;
		}

		protected override bool CodeSystemNameAllowed()
		{
			// Technically, CS does not allow for a codeSystemName. However, we don't want to log an error just because a Code also has a CodeSystem with it (most common case)  
			return true;
		}

		protected override bool DisplayNameAllowed()
		{
			// Technically, CS does not allow for a codeSystemName. However, we don't want to log an error just because a Code also has a CodeSystem with it (most common case)  
			return true;
		}

		protected override void HandleCodeSystem(CodedTypeR2<Code> codedType, IDictionary<string, string> result, FormatContext context
			)
		{
			// codes will usually have a codeSystem even if we don't intend to render it in the message
			if (!"CS".Equals(context.Type))
			{
				base.HandleCodeSystem(codedType, result, context);
			}
		}

		protected override void HandleCodeSystemName(CodedTypeR2<Code> codedType, IDictionary<string, string> result, FormatContext
			 context)
		{
			// codes will usually have a codeSystem even if we don't intend to render it in the message
			if (!"CS".Equals(context.Type))
			{
				base.HandleCodeSystemName(codedType, result, context);
			}
		}

		protected override void HandleDisplayName(CodedTypeR2<Code> codedType, IDictionary<string, string> result, FormatContext 
			context)
		{
			// codes will usually have a codeSystem even if we don't intend to render it in the message
			if (!"CS".Equals(context.Type))
			{
				base.HandleDisplayName(codedType, result, context);
			}
		}
	}
}
