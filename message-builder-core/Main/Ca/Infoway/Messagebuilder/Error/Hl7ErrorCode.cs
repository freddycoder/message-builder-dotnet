using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Error
{
	/// <author>Intelliware Development</author>
	[System.Serializable]
	public class Hl7ErrorCode : EnumPattern
	{
		private const long serialVersionUID = 1L;

		public static readonly Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode UNSUPPORTED_INTERACTION = new Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode
			("UNSUPPORTED_INTERACTION");

		public static readonly Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode UNSUPPORTED_PROCESSING_ID = new Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode
			("UNSUPPORTED_PROCESSING_ID");

		public static readonly Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode UNSUPPORTED_VERSION_ID = new Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode
			("UNSUPPORTED_VERSION_ID");

		public static readonly Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode UNSUPPORTED_PROCESSING_MODE = new Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode
			("UNSUPPORTED_PROCESSING_MODE");

		public static readonly Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode UNSUPPORTED_TYPE_CHANGE = new Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode
			("UNSUPPORTED_TYPE_CHANGE");

		public static readonly Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode UNKNOWN_SENDER = new Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode
			("UNKNOWN_SENDER");

		public static readonly Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode UNRECOGNIZED_ATTENTION_LINE = new Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode
			("UNRECOGNIZED_ATTENTION_LINE");

		public static readonly Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode SYNTAX_ERROR = new Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode
			("SYNTAX_ERROR");

		public static readonly Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode MANDATORY_FIELD_NOT_PROVIDED = new Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode
			("MANDATORY_FIELD_NOT_PROVIDED");

		public static readonly Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode MANDATORY_ASSOCIATION_NOT_PROVIDED = new Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode
			("MANDATORY_ASSOCIATION_NOT_PROVIDED");

		public static readonly Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode REQUIRED_ATTRIBUTE_MISSING = new Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode
			("REQUIRED_ATTRIBUTE_MISSING");

		public static readonly Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode DATA_TYPE_ERROR = new Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode
			("DATA_TYPE_ERROR");

		public static readonly Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode VALUE_NOT_IN_CODE_SYSTEM = new Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode
			("VALUE_NOT_IN_CODE_SYSTEM");

		public static readonly Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode INVALID_CODE_SYSTEM_IN_CNE = new Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode
			("INVALID_CODE_SYSTEM_IN_CNE");

		public static readonly Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode NUMBER_OF_ASSOCIATIONS_INCORRECT_FOR_CARDINALITY = new 
			Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode("NUMBER_OF_ASSOCIATIONS_INCORRECT_FOR_CARDINALITY");

		public static readonly Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode NUMBER_OF_ASSOCIATIONS_EXCEEDS_LIMIT = new Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode
			("NUMBER_OF_ASSOCIATIONS_EXCEEDS_LIMIT");

		public static readonly Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode NUMBER_OF_ATTRIBUTES_EXCEEDS_LIMIT = new Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode
			("NUMBER_OF_ATTRIBUTES_EXCEEDS_LIMIT");

		public static readonly Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode INTERNAL_ERROR = new Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode
			("INTERNAL_ERROR");

		public static readonly Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode NO_STORAGE_SPACE_FOR_MESSAGE = new Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode
			("NO_STORAGE_SPACE_FOR_MESSAGE");

		public static readonly Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode MESSAGE_ROUTING_ERROR_DESTINATION_UNREACHABLE = new Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode
			("MESSAGE_ROUTING_ERROR_DESTINATION_UNREACHABLE");

		public static readonly Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode MESSAGE_ROUTING_ERROR_DESTINATION_UNKNOWN = new Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode
			("MESSAGE_ROUTING_ERROR_DESTINATION_UNKNOWN");

		public static readonly Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode MESSAGE_ROUTING_WARNING_DESTINATION_UNREACHABLE = new 
			Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode("MESSAGE_ROUTING_WARNING_DESTINATION_UNREACHABLE");

		public static readonly Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode TL7_SYSTEM_ERROR = new Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode
			("TL7_SYSTEM_ERROR");

		public static readonly Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode NOT_AUTHORIZED = new Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode
			("NOT_AUTHORIZED");

		public static readonly Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode IGNORED_CONFORMANCE_NOT_ALLOWED_IS_SET = new Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode
			("IGNORED_CONFORMANCE_NOT_ALLOWED_IS_SET");

		public static readonly Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode NOT_ALLOWED_CONFORMANCE_IS_SET = new Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode
			("NOT_ALLOWED_CONFORMANCE_IS_SET");

		public static readonly Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode ONLY_ONE_TYPE_OF_CONTENT_ALLOWED = new Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode
			("ONLY_ONE_TYPE_OF_CONTENT_ALLOWED");

		public static readonly Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode CDA_FIXED_CONSTRAINT_PROVIDED = new Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode
			("CDA_FIXED_CONSTRAINT_PROVIDED");

		public static readonly Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode CDA_FIXED_CONSTRAINT_MISSING = new Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode
			("CDA_FIXED_CONSTRAINT_MISSING");

		public static readonly Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode CDA_MANDATORY_CONSTRAINT_MISSING = new Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode
			("CDA_MANDATORY_CONSTRAINT_MISSING");

		public static readonly Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode CDA_PROHIBITED_CONSTRAINT = new Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode
			("CDA_PROHIBITED_CONSTRAINT");

		public static readonly Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode CDA_CARDINALITY_CONSTRAINT = new Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode
			("CDA_CARDINALITY_CONSTRAINT");

		public static readonly Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode CDA_TEMPLATEID_FIXED_CONSTRAINT_MISSING = new Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode
			("CDA_TEMPLATEID_FIXED_CONSTRAINT_MISSING");

		public static readonly Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode CDA_TEMPLATEID_FIXED_CONSTRAINT_MATCH = new Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode
			("CDA_TEMPLATEID_FIXED_CONSTRAINT_MATCH");

		public static readonly Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode CDA_UNSUPPORTED_CONSTRAINT = new Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode
			("CDA_UNSUPPORTED_CONSTRAINT");

		public static readonly Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode CDA_TEMPLATE_CHOSEN = new Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode
			("CDA_TEMPLATE_CHOSEN");

		public static readonly Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode CDA_NO_ACCEPTABLE_CHOICE_OPTION = new Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode
			("CDA_NO_ACCEPTABLE_CHOICE_OPTION");

		public static readonly Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode CDA_MULTIPLE_CHOICE_OPTIONS_FOUND = new Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode
			("CDA_MULTIPLE_CHOICE_OPTIONS_FOUND");

		public static readonly Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode UNEXPECTED_NAMESPACE = new Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode
			("UNEXPECTED_NAMESPACE");

		public static readonly Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode SCHEMATRON = new Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode
			("SCHEMATRON");

		public static readonly Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode CODE_MATCH_ONLY_WHEN_IGNORING_CASE = new Ca.Infoway.Messagebuilder.Error.Hl7ErrorCode
			("CODE_MATCH_ONLY_WHEN_IGNORING_CASE");

		private Hl7ErrorCode(string name) : base(name)
		{
		}
	}
}
