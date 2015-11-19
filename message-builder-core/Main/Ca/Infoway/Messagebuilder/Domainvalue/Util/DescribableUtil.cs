using Ca.Infoway.Messagebuilder;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Util
{
	/// <summary>Determine a standard description of an object.</summary>
	/// <remarks>
	/// Determine a standard description of an object.
	/// This class is ideally designed for enums, which typically have names like
	/// MY_INTERESTING_VALUE.  This utility will convert the description to
	/// "My interesting value".
	/// </remarks>
	/// <author>BC Holmes</author>
	public class DescribableUtil
	{
		/// <summary>Gets the default description.</summary>
		/// <remarks>Gets the default description.</remarks>
		/// <param name="object">the object</param>
		/// <returns>the default description</returns>
		public static string GetDefaultDescription(object @object)
		{
			if (@object == null || StringUtils.IsBlank(@object.ToString()))
			{
				return string.Empty;
			}
			else
			{
				string temp = @object.ToString().Replace('_', ' ').ToLower();
				return Ca.Infoway.Messagebuilder.StringUtils.Substring(temp, 0, 1).ToUpper() + Ca.Infoway.Messagebuilder.StringUtils.Substring
					(temp, 1);
			}
		}

		/// <summary>Gets the code description.</summary>
		/// <remarks>Gets the code description.</remarks>
		/// <param name="code">the code</param>
		/// <returns>the code description</returns>
		public static string GetCodeDescription(Code code)
		{
			return WordUtils.CapitalizeFully(code.CodeValue.Replace('_', ' '));
		}
	}
}
