using Ca.Infoway.Messagebuilder;

namespace Ca.Infoway.Messagebuilder.Domainvalue
{
	/// <summary>
	/// EntityDeterminer in natural language grammar is the class
	/// of words that comprises articles, demonstrative pronouns,
	/// and quantifiers.
	/// </summary>
	/// <remarks>
	/// EntityDeterminer in natural language grammar is the class
	/// of words that comprises articles, demonstrative pronouns,
	/// and quantifiers. In the RIM, determiner is a structural code
	/// in the Entity class to distinguish whether any given Entity
	/// object stands for some, any one, or a specific thing.
	/// </remarks>
	public interface EntityDeterminer : Code
	{
	}
}
