using Ca.Infoway.Messagebuilder;

namespace Ca.Infoway.Messagebuilder.Domainvalue
{
	/// <summary>
	/// A code that specifies how an ActRelationship or
	/// Participation contributes to the context of an Act, and
	/// whether it may be propagated to descendent Acts whose
	/// association allows such propagation (see also attributes
	/// Participation.contextControlCode,
	/// ActRelationship.contextControlCode,
	/// ActRelationship.contextConductionInd).
	/// </summary>
	/// <remarks>
	/// A code that specifies how an ActRelationship or
	/// Participation contributes to the context of an Act, and
	/// whether it may be propagated to descendent Acts whose
	/// association allows such propagation (see also attributes
	/// Participation.contextControlCode,
	/// ActRelationship.contextControlCode,
	/// ActRelationship.contextConductionInd).
	/// </remarks>
	public interface ContextControl : Code
	{
	}
}
