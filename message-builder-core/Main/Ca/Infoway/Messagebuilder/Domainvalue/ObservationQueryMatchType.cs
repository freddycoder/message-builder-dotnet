using Ca.Infoway.Messagebuilder.Domainvalue;

namespace Ca.Infoway.Messagebuilder.Domainvalue
{
	/// <summary>
	/// Probabability Match Code.
	/// An observation related to a query response.
	/// </summary>
	/// <remarks>
	/// Probabability Match Code.
	/// An observation related to a query response. Example: The degree of match
	/// or match weight returned by a matching algorithm in a response to a query.
	/// Rationale/Use
	/// Supports confident identification of objects from a query response.
	/// </remarks>
	public interface ObservationQueryMatchType : ObservationType
	{
	}
}
