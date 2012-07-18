namespace Ca.Infoway.Messagebuilder.Xml
{
	/// <summary>An interface describing types that have documentation.</summary>
	/// <remarks>
	/// An interface describing types that have documentation.  MIFs often contain
	/// additional documentation that describe the purpose or meaning of types.
	/// </remarks>
	/// <author>Intelliware Development</author>
	public interface Documentable
	{
		/// <summary>Get the documentation.</summary>
		/// <remarks>Get the documentation.</remarks>
		/// <returns>the documentation.</returns>
		/// <summary>Set the documentation.</summary>
		/// <remarks>Set the documentation.</remarks>
		/// <value>- the new documentation value</value>
		Ca.Infoway.Messagebuilder.Xml.Documentation Documentation
		{
			get;
			set;
		}
	}
}
