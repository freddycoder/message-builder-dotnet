using System;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Resolver;
using Ca.Infoway.Messagebuilder.Util.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	public class CodeLookupUtils
	{
		public virtual Code GetCorrespondingCode(string code, string codeSystem, Type expectedReturnType, XmlElement element, string
			 type, XmlToModelResult xmlToModelResult)
		{
			return GetCorrespondingCode(code, codeSystem, expectedReturnType, element, type, xmlToModelResult, false, false);
		}

		public virtual Code GetCorrespondingCode(string code, string codeSystem, Type expectedReturnType, XmlElement element, string
			 type, XmlToModelResult xmlToModelResult, bool relaxCodeSystemCheck, bool relaxCodeCheck)
		{
			Type codeType = GetReturnTypeAsCodeType(expectedReturnType);
			if (StandardDataType.CS.Type.Equals(type))
			{
				if (codeSystem != null)
				{
					xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "CS should not include the 'codeSystem' property. ("
						 + XmlDescriber.DescribeSingleElement(element) + ")", element));
				}
			}
			else
			{
				if (StringUtils.IsNotBlank(code) && StringUtils.IsBlank(codeSystem))
				{
					if (!relaxCodeSystemCheck)
					{
						xmlToModelResult.AddHl7Error(CreateMissingCodeSystemError(element, codeType, code));
					}
				}
			}
			Code result = GetCode(codeType, code, codeSystem);
			// if a code is specified and there is no matching enum value for it,
			// something is seriously wrong
			if (StringUtils.IsNotBlank(code) && result == null && !relaxCodeCheck)
			{
				xmlToModelResult.AddHl7Error(CreateInvalidCodeError(element, codeType, code));
			}
			if (result == null && IsInterface(codeType))
			{
				//MBR-335: In some cases we have fixed values that are not part of the generated API and that have
				//values that do not conform to the expected return type. In this case, just fake up a value as
				//it will be discarded later in HL7SourceMapper. See PolicyActivity.GuarantorPerformerAssignedEntity
				//in ccda r1_1 message set for an example. i.e. GUAR is not a valid RoleClass
				if (relaxCodeCheck)
				{
					result = WrapFixedCodeValue(code, codeSystem, codeType);
				}
				else
				{
					// the following code will preserve the codeSystem even if the actual code can not be found
					if (!StringUtils.IsEmpty(codeSystem))
					{
						result = FullCodeWrapper.Wrap(codeType, null, codeSystem);
					}
				}
			}
			return result;
		}

		private Code WrapFixedCodeValue(string code, string codeSystem, Type returnType)
		{
			Type codeType = (Type)returnType;
			Code trivialCode = new TrivialCodeResolver().Lookup<Code>(codeType, code);
			return FullCodeWrapper.Wrap(codeType, trivialCode, codeSystem);
		}

		private Code GetCode(Type expectedReturnType, string codeValue, string codeSystem)
		{
			CodeResolver resolver = null;
			Type returnType = null;
			if (typeof(ANY<object>).Equals(expectedReturnType))
			{
				// if the underlying datatype is an ANY, then we don't have enough information to figure out the domaintype; have to assume generic Code
				returnType = typeof(Code);
				resolver = new TrivialCodeResolver();
			}
			else
			{
				returnType = GetReturnTypeAsCodeType(expectedReturnType);
				resolver = CodeResolverRegistry.GetResolver(returnType);
			}
			return (StringUtils.IsBlank(codeSystem) ? resolver.Lookup<Code>(returnType, codeValue) : resolver.Lookup<Code>(returnType
				, codeValue, codeSystem));
		}

		private Type GetReturnTypeAsCodeType(Type type)
		{
			if (type is Type)
			{
				return (Type)type;
			}
			else
			{
				if (Generics.IsCollectionParameterizedType(type))
				{
					// this case should only happen if the original property was inlined
					return (Type)Generics.GetParameterType(type);
				}
				else
				{
					// this used to throw an exception, but now we can often have no domain types for coded types
					return typeof(Code);
				}
			}
		}

		private Hl7Error CreateInvalidCodeError(XmlNode node, Type type, string code)
		{
			string message = "The code, \"" + code + "\", in element <" + NodeUtil.GetLocalOrTagName(node) + "> is not a valid value for domain type \""
				 + ClassUtils.GetShortClassName(type) + "\"";
			return new Hl7Error(Hl7ErrorCode.VALUE_NOT_IN_CODE_SYSTEM, message, (XmlElement)node);
		}

		private Hl7Error CreateMissingCodeSystemError(XmlNode node, Type type, string code)
		{
			return new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "CodeSystem is mandatory when providing a code value", (XmlElement)node
				);
		}

		private bool IsInterface(Type codeType)
		{
			return codeType.IsInterface;
		}
	}
}
