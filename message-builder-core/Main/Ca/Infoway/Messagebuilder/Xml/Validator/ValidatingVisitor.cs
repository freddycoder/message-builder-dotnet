using System;
using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Util.Xml;
using Ca.Infoway.Messagebuilder.Xml;
using Ca.Infoway.Messagebuilder.Xml.Validator;
using Ca.Infoway.Messagebuilder.Xml.Visitor;

namespace Ca.Infoway.Messagebuilder.Xml.Validator
{
	public class ValidatingVisitor : MessageVisitor
	{
		private static readonly string ITS_VERSION_VALUE = "XML_1.0";

		private static readonly string ITS_VERSION = "ITSVersion";

		private static readonly string HL7_NAMESPACE = "urn:hl7-org:v3";

		private readonly XmlToModelResult result = new XmlToModelResult();

		private readonly VersionNumber version;

		public ValidatingVisitor(VersionNumber version)
		{
			this.version = version;
		}

		public virtual MessageValidatorResult GetResult()
		{
			MessageValidatorResult validatorResult = new MessageValidatorResult();
			validatorResult.GetHl7Errors().AddAll(this.result.GetHl7Errors());
			return validatorResult;
		}

		public virtual void VisitAssociation(XmlElement @base, string xmlName, IList<XmlElement> elements, Relationship relationship
			)
		{
			if (relationship == null)
			{
			}
			else
			{
				// shouldn't happen
				if (CollUtils.IsEmpty(elements) && relationship.Mandatory)
				{
					this.result.AddHl7Error(Hl7Error.CreateMissingMandatoryAssociationError(xmlName, @base));
				}
				else
				{
					if (CollUtils.IsEmpty(elements) && relationship.Conformance == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED)
					{
						this.result.AddHl7Error(Hl7Error.CreateMissingPopulatedAssociationError(xmlName, @base));
					}
					else
					{
						if (!relationship.Cardinality.Contains(elements.Count))
						{
							this.result.AddHl7Error(Hl7Error.CreateWrongNumberOfAssociationsError(xmlName, @base, elements.Count, relationship.Cardinality));
						}
						else
						{
							if (relationship.Conformance == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.IGNORED && ConformanceLevelUtil.IsIgnoredNotAllowed())
							{
								this.result.AddHl7Error(Hl7Error.CreateIgnoredAsNotAllowedConformanceLevelRelationshipError(xmlName, @base));
							}
							else
							{
								if (relationship.Conformance == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.NOT_ALLOWED)
								{
									this.result.AddHl7Error(Hl7Error.CreateNotAllowedConformanceLevelRelationshipError(xmlName, @base));
								}
							}
						}
					}
				}
			}
			if (relationship.Cardinality.Single && elements.Count == 1)
			{
				CheckForInvalidNullFlavor(elements[0], relationship);
			}
		}

		private void CheckForInvalidNullFlavor(XmlElement element, Relationship relationship)
		{
			NullFlavorHelper nullFlavorHelper = new NullFlavorHelper(relationship.Conformance, element, this.result, true);
			if (nullFlavorHelper.HasValidNullFlavorAttribute())
			{
				nullFlavorHelper.ParseNullNode();
			}
		}

		public virtual void VisitRoot(XmlElement documentElement, Interaction interaction)
		{
			if (interaction == null)
			{
				this.result.AddHl7Error(Hl7Error.CreateUnknownInteractionError(documentElement == null ? "unknown" : NodeUtil.GetLocalOrTagName
					(documentElement), documentElement));
			}
			else
			{
				if (!documentElement.HasAttribute(ITS_VERSION))
				{
					this.result.AddHl7Error(Hl7Error.CreateMissingMandatoryAttributeError(ITS_VERSION, documentElement));
				}
				else
				{
					if (!StringUtils.Equals(ITS_VERSION_VALUE, documentElement.GetAttribute(ITS_VERSION)))
					{
						this.result.AddHl7Error(Hl7Error.CreateInvalidFixedValueAttributeError(documentElement.GetAttributeNode(ITS_VERSION), ITS_VERSION_VALUE
							));
					}
				}
				if (StringUtils.IsBlank(documentElement.NamespaceURI) || !HL7_NAMESPACE.Equals(documentElement.NamespaceURI))
				{
					this.result.AddHl7Error(Hl7Error.CreateMissingNamespace(HL7_NAMESPACE, documentElement));
				}
			}
		}

		private bool IsHl7Attribute(XmlAttribute attr)
		{
			return HL7_NAMESPACE.Equals(attr.NamespaceURI) || StringUtils.IsBlank(attr.NamespaceURI);
		}

		public virtual void VisitStructuralAttribute(XmlElement @base, XmlAttribute attr, Relationship relationship)
		{
			if (relationship == null && !IsHl7Attribute(attr))
			{
			}
			else
			{
				// ignore
				if (attr != null && "nullFlavor".Equals(attr.Name))
				{
				}
				else
				{
					// ignore
					if (relationship == null)
					{
						this.result.AddHl7Error(Hl7Error.CreateUnknownStructuralAttributeError(@base, attr));
					}
					else
					{
						if (attr != null && relationship.HasFixedValue())
						{
							ValidateFixedValue(attr, relationship.FixedValue);
						}
						else
						{
							if (attr != null)
							{
								ValidateStructuralAttributeValue(@base, attr, relationship);
							}
							else
							{
								if (relationship.Fixed)
								{
								}
								else
								{
									// also implies isMandatory()
									// various people suggest that fixed values can be left out
									if (relationship.Mandatory)
									{
										this.result.AddHl7Error(Hl7Error.CreateMissingMandatoryAttributeError(relationship.Name, @base));
									}
									else
									{
										if (relationship.Conformance == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.IGNORED && ConformanceLevelUtil.IsIgnoredNotAllowed())
										{
											this.result.AddHl7Error(Hl7Error.CreateIgnoredAsNotAllowedConformanceLevelRelationshipError(relationship.Name, @base));
										}
										else
										{
											if (relationship.Conformance == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.NOT_ALLOWED)
											{
												this.result.AddHl7Error(Hl7Error.CreateNotAllowedConformanceLevelRelationshipError(relationship.Name, @base));
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}

		private void ValidateStructuralAttributeValue(XmlElement @base, XmlAttribute attr, Relationship relationship)
		{
			if (StandardDataType.BL == StandardDataType.GetByTypeName((Typed)relationship))
			{
				new BlElementParser().ParseBooleanValue(this.result, attr.Value, @base, attr);
			}
			else
			{
				if (StandardDataType.CS == StandardDataType.GetByTypeName((Typed)relationship))
				{
					new CsElementParser().ParseCodedSimpleValue(attr.Value, (Type)DomainTypeHelper.GetReturnType(relationship), @base, this.result
						, attr);
				}
				else
				{
					this.result.AddHl7Error(Hl7Error.CreateUnknownStructuralTypeError(relationship.Type, relationship.Name, @base, attr));
				}
			}
		}

		private void ValidateFixedValue(XmlAttribute attr, string fixedValue)
		{
			if (!StringUtils.Equals(fixedValue, attr.Value))
			{
				this.result.AddHl7Error(Hl7Error.CreateInvalidFixedValueAttributeError(attr, fixedValue));
			}
		}

		public virtual void VisitNonStructuralAttribute(XmlElement @base, IList<XmlElement> elements, Relationship relationship)
		{
			if (relationship == null && !elements.IsEmpty())
			{
				this.result.AddHl7Error(Hl7Error.CreateUnknownChildElementError(elements[0]));
			}
			else
			{
				if (relationship != null)
				{
					if (CollUtils.IsEmpty(elements) && relationship.Mandatory)
					{
						this.result.AddHl7Error(Hl7Error.CreateMissingMandatoryAttributeError(relationship.Name, @base));
					}
					else
					{
						if (CollUtils.IsEmpty(elements) && relationship.Populated)
						{
							this.result.AddHl7Error(Hl7Error.CreateMissingPopulatedAttributeError(relationship.Name, @base));
						}
						else
						{
							if (relationship.Conformance == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.IGNORED && ConformanceLevelUtil.IsIgnoredNotAllowed())
							{
								this.result.AddHl7Error(Hl7Error.CreateIgnoredAsNotAllowedConformanceLevelRelationshipError(relationship.Name, @base));
							}
							else
							{
								if (relationship.Conformance == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.NOT_ALLOWED)
								{
									this.result.AddHl7Error(Hl7Error.CreateNotAllowedConformanceLevelRelationshipError(relationship.Name, @base));
								}
								else
								{
									try
									{
										ElementParser parser = ParserRegistry.GetInstance().Get((Typed)relationship);
										if (parser != null)
										{
											BareANY value = parser.Parse(ParseContextImpl.Create(relationship, this.version), ToNodeList(elements), this.result);
											ValidateNonstructuralFixedValue(relationship, value, elements);
										}
										else
										{
											this.result.AddHl7Error(new Hl7Error(Hl7ErrorCode.SYNTAX_ERROR, "Cannot find a parser for type " + relationship.Type, CollUtils
												.IsEmpty(elements) ? null : elements[0]));
										}
									}
									catch (XmlToModelTransformationException e)
									{
										this.result.AddHl7Error(new Hl7Error(Hl7ErrorCode.SYNTAX_ERROR, e.Message, CollUtils.IsEmpty(elements) ? null : elements[
											0]));
									}
								}
							}
						}
					}
				}
			}
		}

		private void ValidateNonstructuralFixedValue(Relationship relationship, BareANY value, IList<XmlElement> elements)
		{
			if (relationship.HasFixedValue())
			{
				bool valid = false;
				bool valueProvided = (value != null && value.BareValue != null);
				if (valueProvided)
				{
					if ("BL".Equals(relationship.Type) && value is BL)
					{
						string valueAsString = ((BL)value).Value.ToString();
						valid = relationship.FixedValue.EqualsIgnoreCase(valueAsString);
					}
					else
					{
						if ("INT.POS".Equals(relationship.Type) && value is INT)
						{
							string valueAsString = ((INT)value).Value.ToString();
							valid = relationship.FixedValue.EqualsIgnoreCase(valueAsString);
						}
						else
						{
							if (relationship.CodedType && value is CD)
							{
								Code code = ((CD)value).Value;
								valid = (code.CodeValue != null && StringUtils.Equals(relationship.FixedValue, code.CodeValue));
							}
							else
							{
								this.result.AddHl7Error(new Hl7Error(Hl7ErrorCode.SYNTAX_ERROR, "Non-structural fixed-value attribute '" + relationship.Name
									 + "' was of unexpected type '" + relationship.Type + "'", CollUtils.IsEmpty(elements) ? null : elements[0]));
							}
						}
					}
				}
				else
				{
					valid = !relationship.Fixed;
				}
				if (!valid)
				{
					this.result.AddHl7Error(new Hl7Error(Hl7ErrorCode.MANDATORY_FIELD_NOT_PROVIDED, "Fixed-value attribute '" + relationship.
						Name + "' must have value '" + relationship.FixedValue + "'", CollUtils.IsEmpty(elements) ? null : elements[0]));
				}
			}
		}

		private IList<XmlNode> ToNodeList(IList<XmlElement> elementList)
		{
			IList<XmlNode> result = new List<XmlNode>();
			foreach (XmlNode node in elementList)
			{
				result.Add(node);
			}
			return result;
		}
	}
}
