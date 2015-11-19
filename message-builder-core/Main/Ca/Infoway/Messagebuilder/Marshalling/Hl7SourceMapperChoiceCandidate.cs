using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Error;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class Hl7SourceMapperChoiceCandidate
	{
		private readonly object parsedBean;

		private readonly IList<Hl7Error> storedErrors = new List<Hl7Error>();

		internal Hl7SourceMapperChoiceCandidate(object parsedBean)
		{
			this.parsedBean = parsedBean;
		}

		internal virtual object GetParsedBean()
		{
			return this.parsedBean;
		}

		internal virtual IList<Hl7Error> GetStoredErrors()
		{
			return this.storedErrors;
		}

		internal virtual void AddError(Hl7Error error)
		{
			this.storedErrors.Add(error);
		}

		internal virtual bool IsAcceptableChoiceCandidate(int currentErrorLevel)
		{
			// to be acceptable can't have any templateId errors in the first two levels past choice
			// to be acceptable can't have any missing mandatory associations in the first level past choice
			// to be acceptable can't have any invalid association cardinality errors in the first two levels past choice
			foreach (Hl7Error hl7Error in this.storedErrors)
			{
				if (hl7Error.GetErrorDepth() - currentErrorLevel == 0)
				{
					// a "missing" error actually appears to be one level higher (we never get to the missing node)
					if (hl7Error.GetHl7ErrorCode() == Hl7ErrorCode.MANDATORY_ASSOCIATION_NOT_PROVIDED)
					{
						return false;
					}
				}
				if (hl7Error.GetErrorDepth() - currentErrorLevel <= 1)
				{
					// actually a depth of two, as the error is reported one level higher
					if (hl7Error.GetHl7ErrorCode() == Hl7ErrorCode.NUMBER_OF_ASSOCIATIONS_INCORRECT_FOR_CARDINALITY)
					{
						return false;
					}
				}
				if (hl7Error.GetErrorDepth() - currentErrorLevel <= 2)
				{
					if (hl7Error.GetHl7ErrorCode() == Hl7ErrorCode.CDA_TEMPLATEID_FIXED_CONSTRAINT_MISSING)
					{
						return false;
					}
				}
			}
			return true;
		}

		internal virtual bool HasTemplateIdMatch(int currentErrorLevel)
		{
			// to be a match must have correct template id fixed constraint within the first two levels past choice
			foreach (Hl7Error hl7Error in this.storedErrors)
			{
				if (hl7Error.GetErrorDepth() - currentErrorLevel <= 2)
				{
					if (hl7Error.GetHl7ErrorCode() == Hl7ErrorCode.CDA_TEMPLATEID_FIXED_CONSTRAINT_MATCH)
					{
						return true;
					}
				}
			}
			return false;
		}
	}
}
