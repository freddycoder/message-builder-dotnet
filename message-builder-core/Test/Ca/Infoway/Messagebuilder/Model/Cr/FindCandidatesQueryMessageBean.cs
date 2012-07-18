using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Model.Cr;
using Ca.Infoway.Messagebuilder.Model.Mock;

namespace Ca.Infoway.Messagebuilder.Model.Cr
{
	/// <summary>
	/// Find Candidates Query
	/// This interaction sends a query to a Person Registry requesting a list of
	/// candidates that match a particular set of person demographics.
	/// </summary>
	/// <author>administrator</author>
	[System.Serializable]
	[Hl7PartTypeMappingAttribute("PRPA_IN101103CA")]
	public class FindCandidatesQueryMessageBean : NewQueryMessageBean<QueryControlActEventBean<FindCandidatesCriteria>>
	{
		private const long serialVersionUID = 8365557396616384144L;
	}
}
