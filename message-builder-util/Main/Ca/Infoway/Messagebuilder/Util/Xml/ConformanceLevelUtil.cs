using Ca.Infoway.Messagebuilder;

namespace Ca.Infoway.Messagebuilder.Util.Xml
{
	public class ConformanceLevelUtil
	{
		public static readonly string ASSOCIATION_IS_IGNORED_AND_CAN_NOT_BE_USED = "Association is ignored and can not be used: ({0})";

		public static readonly string ASSOCIATION_IS_IGNORED_AND_WILL_NOT_BE_USED = "Association is ignored and will not be used: ({0})";

		public static readonly string ATTRIBUTE_IS_IGNORED_AND_CAN_NOT_BE_USED = "Attribute is ignored and can not be used: ({0})";

		public static readonly string ATTRIBUTE_IS_IGNORED_AND_WILL_NOT_BE_USED = "Attribute is ignored and will not be used: ({0})";

		public static readonly string ASSOCIATION_IS_NOT_ALLOWED = "Association is not allowed: ({0})";

		public static readonly string ATTRIBUTE_IS_NOT_ALLOWED = "Attribute is not allowed: ({0})";

		public static readonly string IGNORED_AS_NOT_ALLOWED = "ignored.as.not.allowed";

		public static bool IsIgnoredNotAllowed()
		{
			return true.ToString().EqualsIgnoreCase(Runtime.GetProperty(IGNORED_AS_NOT_ALLOWED));
		}
	}
}
