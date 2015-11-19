using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Platform;
using Ca.Infoway.Messagebuilder.Xml;
using log4net;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	/// <summary>A class that helps to instantiate instances of message builder beans.</summary>
	/// <remarks>A class that helps to instantiate instances of message builder beans.</remarks>
	/// <author>Intelliware Development</author>
	public class Instantiator
	{
		private static Ca.Infoway.Messagebuilder.Marshalling.Instantiator instance;

		/// <summary>Static accessor.</summary>
		/// <remarks>
		/// Static accessor.   This class is implemented as a singleton, and the
		/// static accessor provides access to the single instance.
		/// </remarks>
		/// <returns>- the instance</returns>
		public static Ca.Infoway.Messagebuilder.Marshalling.Instantiator GetInstance()
		{
			if (instance == null)
			{
				InitializeInstance();
			}
			return instance;
		}

		private static void InitializeInstance()
		{
			Ca.Infoway.Messagebuilder.Marshalling.Instantiator factory = new Ca.Infoway.Messagebuilder.Marshalling.Instantiator();
			instance = factory;
		}

		private readonly ILog log = log4net.LogManager.GetLogger(typeof(Ca.Infoway.Messagebuilder.Marshalling.Instantiator));

		private Instantiator()
		{
		}

		/// <summary>Instantiate a bean that models the part under question.</summary>
		/// <remarks>Instantiate a bean that models the part under question.</remarks>
		/// <param name="version">- the version code</param>
		/// <param name="type">- the part type</param>
		/// <returns>an instance of a bean that represents the part type</returns>
		public virtual object InstantiateMessagePartBean(VersionNumber version, string type, Interaction interaction)
		{
			try
			{
				Type partClass = MessageBeanRegistry.GetInstance().GetMessagePartClass(version, type);
				if (partClass == null)
				{
					throw CreateMarshallingException("Did not find", version, type);
				}
				else
				{
					if (!ClassUtil.IsGeneric(partClass))
					{
						this.log.Debug("Instantiating bean: " + partClass.FullName);
						return System.Activator.CreateInstance(partClass);
					}
					else
					{
						this.log.Debug("Instantiating parameterized bean: " + partClass.FullName);
						return GenericClassUtil.Instantiate(partClass, CreateParameterMap(interaction, version));
					}
				}
			}
			catch (MemberAccessException e)
			{
				throw CreateMarshallingException("Error instantiating", version, type, e);
			}
			catch (Exception e)
			{
				throw CreateMarshallingException("Error instantiating", version, type, e);
			}
		}

		private IDictionary<string, Type> CreateParameterMap(Interaction interaction, VersionNumber version)
		{
			IDictionary<string, Type> map = new Dictionary<string, Type>();
			CreateParameterMap(version, map, interaction.Arguments);
			return map;
		}

		private void CreateParameterMap(VersionNumber version, IDictionary<string, Type> map, IList<Argument> arguments)
		{
			foreach (Argument argument in arguments)
			{
				map[TemplateVariableNameUtil.Transform(argument.TemplateParameterName)] = MessageBeanRegistry.GetInstance().GetMessagePartClass
					(version, argument.Name);
				CreateParameterMap(version, map, argument.Arguments);
			}
		}

		private MarshallingException CreateMarshallingException(string errorPrefix, VersionNumber version, string type)
		{
			return CreateMarshallingException(errorPrefix, version, type, null);
		}

		private MarshallingException CreateMarshallingException(string errorPrefix, VersionNumber version, string type, Exception
			 e)
		{
			StringBuilder builder = new StringBuilder();
			builder.Append(errorPrefix);
			builder.Append(" Bean for Hl7 Part Type:");
			builder.Append(type);
			builder.Append(" for version ");
			builder.Append(version == null ? null : version.VersionLiteral);
			log.Debug(builder.ToString());
			if (e == null)
			{
				return new MarshallingException(builder.ToString());
			}
			else
			{
				return new MarshallingException(builder.ToString(), e);
			}
		}
	}
}
