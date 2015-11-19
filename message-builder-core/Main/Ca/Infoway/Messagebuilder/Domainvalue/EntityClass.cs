using Ca.Infoway.Messagebuilder;

namespace Ca.Infoway.Messagebuilder.Domainvalue
{
	/// <summary>Classifies the Entity class and all of its subclasses.</summary>
	/// <remarks>
	/// Classifies the Entity class and all of its subclasses.
	/// The terminology is hierarchical. At the top is this
	/// HL7-defined domain of high-level categories (such as
	/// represented by the Entity subclasses). Each of these terms
	/// must be harmonized and is specializable.
	/// </remarks>
	public interface EntityClass : Code
	{
	}
}
