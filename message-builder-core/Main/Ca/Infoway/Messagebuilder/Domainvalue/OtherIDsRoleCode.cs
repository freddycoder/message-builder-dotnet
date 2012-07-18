using Ca.Infoway.Messagebuilder;

namespace Ca.Infoway.Messagebuilder.Domainvalue
{
	/// <summary>Identifies the type of identifier being supplied (e.g.</summary>
	/// <remarks>
	/// Identifies the type of identifier being supplied (e.g. driver's license number).
	/// This domain type was used (but not really defined) in some client registry
	/// messages.  It was later renamed to OtherIdentifierRoleType.
	/// </remarks>
	/// <author>BC Holmes</author>
	/// <seealso cref="OtherIdentifierRoleType">OtherIdentifierRoleType</seealso>
	public interface OtherIDsRoleCode : Code
	{
	}
}
