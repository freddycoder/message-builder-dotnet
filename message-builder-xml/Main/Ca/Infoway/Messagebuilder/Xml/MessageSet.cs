using System;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Xml;
using Platform.SimpleXml;

namespace Ca.Infoway.Messagebuilder.Xml
{
	/// <summary>A representation of an entire message set.</summary>
	/// <remarks>A representation of an entire message set.</remarks>
	/// <author>Intelliware Development</author>
	[RootAttribute]
	public class MessageSet : MessagePartResolver
	{
		[XmlAttributeAttribute(Required = false)]
		private string version;

		[XmlAttributeAttribute(Required = false)]
		private string component;

		[ElementListAttribute(Name = "remixHistory", Required = false, Inline = true, Entry = "remixHistoryEntry")]
		private IList<MessageSetHistory> remixHistory = new List<MessageSetHistory>();

		[ElementMapAttribute(Name = "packageLocation", Key = "name", Required = false, Inline = true, Attribute = true, Entry = "packageEntry"
			)]
		private IDictionary<string, PackageLocation> packageLocations = new SortedList<string, PackageLocation>();

		[ElementMapAttribute(Name = "interaction", Key = "name", Required = false, Inline = true, Attribute = true)]
		private IDictionary<string, Interaction> interactions = new SortedList<string, Interaction>();

		/// <summary>Get the version code that this message set represents.</summary>
		/// <remarks>Get the version code that this message set represents.</remarks>
		/// <returns>- the version code.</returns>
		/// <summary>Set the version code.</summary>
		/// <remarks>Set the version code.</remarks>
		/// <value>- the new version code.</value>
		public virtual string Version
		{
			get
			{
				return this.version;
			}
			set
			{
				string version = value;
				this.version = version;
			}
		}

		/// <summary>
		/// Get a map of all the interactions defined in the message set, keyed by
		/// interaction id.
		/// </summary>
		/// <remarks>
		/// Get a map of all the interactions defined in the message set, keyed by
		/// interaction id.
		/// </remarks>
		/// <returns>- the map of all interactions.</returns>
		/// <summary>Set the interactions.</summary>
		/// <remarks>Set the interactions.</remarks>
		/// <value>- the new value</value>
		public virtual IDictionary<string, Interaction> Interactions
		{
			get
			{
				return this.interactions;
			}
			set
			{
				IDictionary<string, Interaction> interactions = value;
				this.interactions = interactions;
			}
		}

		/// <summary>Get a map of all package locations, keyed by package location id.</summary>
		/// <remarks>Get a map of all package locations, keyed by package location id.</remarks>
		/// <returns>- the map</returns>
		/// <summary>Set the package locations.</summary>
		/// <remarks>Set the package locations.</remarks>
		/// <value>- the new value.</value>
		public virtual IDictionary<string, PackageLocation> PackageLocations
		{
			get
			{
				return this.packageLocations;
			}
			set
			{
				IDictionary<string, PackageLocation> packageLocations = value;
				this.packageLocations = packageLocations;
			}
		}

		/// <summary>Get a part by part type name.</summary>
		/// <remarks>Get a part by part type name.</remarks>
		/// <param name="type">- the message part type name</param>
		/// <returns>- the message part</returns>
		public virtual MessagePart GetMessagePart(string type)
		{
			MessagePart messagePart = null;
			if (type != null)
			{
				string packageLocationName = type.Contains(".") ? StringUtils.SubstringBefore(type, ".") : type;
				PackageLocation location = PackageLocations.SafeGet(packageLocationName);
				if (location == null)
				{
					messagePart = null;
				}
				else
				{
					if (type.Contains("."))
					{
						messagePart = location.MessageParts.SafeGet(type);
					}
					else
					{
						if (StringUtils.IsNotBlank(location.RootType))
						{
							messagePart = location.MessageParts.SafeGet(location.RootType);
						}
					}
				}
			}
			return messagePart;
		}

		/// <summary>Add a message part.</summary>
		/// <remarks>Add a message part.</remarks>
		/// <param name="part">- the message part to add</param>
		public virtual void AddMessagePart(MessagePart part)
		{
			TypeName name = new TypeName(part.Name);
			string packageName = name.RootName.Name;
			PackageLocation location = this.packageLocations.SafeGet(packageName);
			if (location == null)
			{
				throw new ArgumentException("No package location exists: " + packageName);
			}
			else
			{
				location.MessageParts[part.Name] = part;
			}
		}

		/// <summary>Get a collection of all message parts defined by the message set.</summary>
		/// <remarks>Get a collection of all message parts defined by the message set.</remarks>
		/// <returns>the message parts</returns>
		public virtual ICollection<MessagePart> AllMessageParts
		{
			get
			{
				IList<MessagePart> result = new List<MessagePart>();
				foreach (PackageLocation packageLocation in this.packageLocations.Values)
				{
					result.AddAll(packageLocation.MessageParts.Values);
				}
				return result;
			}
		}

		/// <summary>Get a package location root type.</summary>
		/// <remarks>Get a package location root type.</remarks>
		/// <param name="packageLocation">- the package location key</param>
		/// <returns>the package location</returns>
		public virtual string GetPackageLocationRootType(string packageLocation)
		{
			if (this.packageLocations.ContainsKey(packageLocation))
			{
				return this.packageLocations.SafeGet(packageLocation).RootType;
			}
			else
			{
				return null;
			}
		}

		/// <summary>Get the component.</summary>
		/// <remarks>Get the component.</remarks>
		/// <returns>the component</returns>
		/// <summary>Set the component.</summary>
		/// <remarks>Set the component.</remarks>
		/// <value>- the new value</value>
		public virtual string Component
		{
			get
			{
				return this.component;
			}
			set
			{
				string component = value;
				this.component = component;
			}
		}

		/// <summary>Get the remixHistory.</summary>
		/// <remarks>Get the remixHistory.</remarks>
		/// <returns>the remixHistory</returns>
		/// <summary>Set the remixHistory.</summary>
		/// <remarks>Set the remixHistory.</remarks>
		/// <value>- the new value</value>
		public virtual IList<MessageSetHistory> RemixHistory
		{
			get
			{
				return remixHistory;
			}
			set
			{
				IList<MessageSetHistory> remixHistory = value;
				this.remixHistory = remixHistory;
			}
		}
	}
}
