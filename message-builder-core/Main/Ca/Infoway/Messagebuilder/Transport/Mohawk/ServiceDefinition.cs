using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;

namespace Ca.Infoway.Messagebuilder.Transport.Mohawk
{
	/// <summary>A registry for service definitions.</summary>
	/// <remarks>
	/// A registry for service definitions. The registry is keyed by intertcation id.
	/// A service definition contains a path and an action (i.e. submit).
	/// </remarks>
	/// <author>Intelliware Development</author>
	public class ServiceDefinition
	{
		private readonly string path;

		private readonly string action;

		internal ServiceDefinition(string path, string action)
		{
			this.path = path;
			this.action = action;
		}

		/// <summary>Gets the path of this service definition.</summary>
		/// <remarks>Gets the path of this service definition.</remarks>
		/// <returns>the path of this service</returns>
		public virtual string GetPath()
		{
			return this.path;
		}

		/// <summary>Gets the action of this service definition.</summary>
		/// <remarks>Gets the action of this service definition.</remarks>
		/// <returns>the action of this service</returns>
		public virtual string GetAction()
		{
			return this.action;
		}

		private static readonly string SUBMIT = "submit";

		private static IDictionary<string, Ca.Infoway.Messagebuilder.Transport.Mohawk.ServiceDefinition> actions = Ca.Infoway.Messagebuilder.CollUtils.SynchronizedMap
			(new Dictionary<string, Ca.Infoway.Messagebuilder.Transport.Mohawk.ServiceDefinition>());

		static ServiceDefinition()
		{
			//		Client Registry
			//		Find candidates - PRPA_IN101103CA/PRPA_IN101104CA
			actions["PRPA_IN101103CA"] = new Ca.Infoway.Messagebuilder.Transport.Mohawk.ServiceDefinition(string.Empty, SUBMIT);
			//		Get client demographics - PRPA_IN101101CA/PRPA_IN101102CA
			actions["PRPA_IN101101CA"] = new Ca.Infoway.Messagebuilder.Transport.Mohawk.ServiceDefinition(string.Empty, SUBMIT);
			//
			//		Provider Registry
			//		Provider details query - PRPM_IN306010CA/PRPM_IN306011CA
			actions["PRPM_IN306010CA"] = new Ca.Infoway.Messagebuilder.Transport.Mohawk.ServiceDefinition(string.Empty, SUBMIT);
			//
			//		Lab
			//		Query Laboratory Test Results - POLB_IN354000CA/POLB_IN364000CA
			actions["POLB_IN354000CA"] = new Ca.Infoway.Messagebuilder.Transport.Mohawk.ServiceDefinition(string.Empty, SUBMIT);
			//
			//		Allergy
			//		Add allergy - REPC_IN000012CA/REPC_IN000013CA/REPC_IN000014CA
			actions["REPC_IN000012CA"] = new Ca.Infoway.Messagebuilder.Transport.Mohawk.ServiceDefinition(string.Empty, SUBMIT);
			//		Update allergy - REPC_IN000020CA/REPC_IN000021CA/REPC_IN000022CA
			actions["REPC_IN000020CA"] = new Ca.Infoway.Messagebuilder.Transport.Mohawk.ServiceDefinition(string.Empty, SUBMIT);
			//		Patient allergy/intolerance query - REPC_IN000015CA/REPC_IN000016CA
			actions["REPC_IN000015CA"] = new Ca.Infoway.Messagebuilder.Transport.Mohawk.ServiceDefinition(string.Empty, SUBMIT);
			//
			//		Immunization
			//		Immunization Event Record Request -
			//		POIZ_IN010020CA/POIZ_IN010030CA/POIZ_IN010040CA
			actions["POIZ_IN010020CA"] = new Ca.Infoway.Messagebuilder.Transport.Mohawk.ServiceDefinition(string.Empty, SUBMIT);
			//
			//		Infrastructure
			//		Add patient note - COMT_IN300001CA/COMT_IN300002CA/COMT_IN300003CA
			actions["COMT_IN300001CA"] = new Ca.Infoway.Messagebuilder.Transport.Mohawk.ServiceDefinition(string.Empty, SUBMIT);
			//		Query patient notes - COMT_IN300201CA/COMT_IN300202CA
			actions["COMT_IN300201CA"] = new Ca.Infoway.Messagebuilder.Transport.Mohawk.ServiceDefinition(string.Empty, SUBMIT);
			//		Add record note - COMT_IN301001CA/COMT_IN301002CA/COMT_IN301003CA
			actions["COMT_IN301001CA"] = new Ca.Infoway.Messagebuilder.Transport.Mohawk.ServiceDefinition(string.Empty, SUBMIT);
			//
			//		Professional Services
			//		List Patient Professional Services - REPC_IN000041CA/REPC_IN000042CA
			actions["REPC_IN000041CA"] = new Ca.Infoway.Messagebuilder.Transport.Mohawk.ServiceDefinition(string.Empty, SUBMIT);
			//		Record Patient Professional Service - REPC_IN000044CA/REPC_IN000045CA/REPC_IN000046CA			
			actions["REPC_IN000044CA"] = new Ca.Infoway.Messagebuilder.Transport.Mohawk.ServiceDefinition(string.Empty, SUBMIT);
		}

		/// <summary>Obtains a service based on a name/interaction id.</summary>
		/// <remarks>Obtains a service based on a name/interaction id. If a service could not be found then returns null.</remarks>
		/// <param name="name">the name/interaction id to lookup the service under</param>
		/// <returns>the service definition for the given name/interaction id</returns>
		public static Ca.Infoway.Messagebuilder.Transport.Mohawk.ServiceDefinition GetService(string name)
		{
			return actions.SafeGet(name);
		}
	}
}
