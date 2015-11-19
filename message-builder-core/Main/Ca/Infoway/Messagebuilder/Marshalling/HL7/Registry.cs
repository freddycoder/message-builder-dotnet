using System;
using System.Collections.Generic;
using System.Reflection;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using ILOG.J2CsMapping.Collections.Generics;
using log4net;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7
{
	public abstract class Registry<T>
	{
		private readonly IDictionary<string, T> registryMap = Ca.Infoway.Messagebuilder.CollUtils.SynchronizedMap(new Dictionary<
			string, T>());

		private readonly ILog log = log4net.LogManager.GetLogger(typeof(Ca.Infoway.Messagebuilder.Marshalling.HL7.Registry<object
			>));

		public Registry()
		{
			RegisterAll();
		}

		protected virtual void Register(Type c)
		{
			try
			{
				T instance = (T)System.Activator.CreateInstance(c);
				Register(instance);
			}
			catch (ArgumentException e)
			{
				this.log.Warn("Could not register an instance of " + c.FullName + ": " + e);
			}
			catch (MemberAccessException e)
			{
				this.log.Warn("Could not register an instance of " + c.FullName + ": " + e);
			}
			catch (Exception e)
			{
				this.log.Warn("Could not register an instance of " + c.FullName + ": " + e);
			}
		}

		protected virtual void Register(T instance)
		{
			try
			{
				IList<string> keys = GetRegistrationKey((Type)instance.GetType());
				foreach (string key in keys)
				{
					PutInstance(key, instance);
				}
			}
			catch (ArgumentException e)
			{
				this.log.Warn("Could not register an instance of " + instance.GetType().FullName + ": " + e);
			}
			catch (MemberAccessException e)
			{
				this.log.Warn("Could not register an instance of " + instance.GetType().FullName + ": " + e);
			}
		}

		private void PutInstance(string key, T instance)
		{
			IDictionary<string, T> map = GetRegistryMap();
			if (map.ContainsKey(key))
			{
				this.log.Warn("Not registering an instance of " + instance.GetType().FullName + " with type \"" + key + "\" because an instance of "
					 + map.SafeGet(key).GetType() + " has already been registered");
			}
			else
			{
				map[key] = instance;
				this.log.Debug("An instance of " + instance.GetType().FullName + " was registered as type \"" + key + "\"");
			}
		}

		/// <exception cref="System.ArgumentException"></exception>
		/// <exception cref="System.MemberAccessException"></exception>
		public virtual IList<string> GetRegistrationKey(Type c)
		{
			if (c.IsAnnotationPresent(typeof(DataTypeHandler)))
			{
				return GetRegistrationKeyFromAnnotation(c);
			}
			else
			{
				throw new InvalidOperationException("Registered class " + c + " does not contain a @DataTypeHandler annotation");
			}
		}

		private IList<string> GetRegistrationKeyFromAnnotation(Type c)
		{
			DataTypeHandler handler = c.GetAnnotation<DataTypeHandler>();
			return Arrays.AsList(handler.Value);
		}

		public virtual T Get(Typed typed)
		{
			return Get(typed.Type);
		}

		public virtual T Get(string name)
		{
			T result = this.registryMap.SafeGet(name);
			if (result == null)
			{
				result = this.registryMap.SafeGet(Hl7DataTypeName.GetTypeWithoutParameters(name));
			}
			if (result == null)
			{
				result = this.registryMap.SafeGet(Hl7DataTypeName.Unqualify(name));
			}
			if (result == null)
			{
				result = this.registryMap.SafeGet(Hl7DataTypeName.GetTypeWithoutParameters(Hl7DataTypeName.Unqualify(name)));
			}
			return result;
		}

		protected abstract void RegisterAll();

		private IDictionary<string, T> GetRegistryMap()
		{
			return this.registryMap;
		}

		public virtual IDictionary<string, T> GetProtectedRegistryMap()
		{
			return Ca.Infoway.Messagebuilder.CollUtils.CreateUnmodifiableDictionary(this.registryMap);
		}
	}
}
