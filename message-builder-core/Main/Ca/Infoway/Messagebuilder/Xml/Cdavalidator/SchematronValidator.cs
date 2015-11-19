/**
 * Copyright 2013 Canada Health Infoway, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *        http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 * Author:        $LastChangedBy: gng $
 * Last modified: $LastChangedDate: 2015-11-19 18:20:12 -0500 (Fri, 30 Jan 2015) $
 * Revision:      $LastChangedRevision: 9755 $
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Util.Xml;
using log4net;
using NMatrix.Schematron;
using NMatrix.Schematron.Formatters;

namespace Ca.Infoway.Messagebuilder.Xml.Cdavalidator {

	public class SchematronValidator {

        private class ValidationFormatter : FormatterBase {

            private readonly Hl7Errors validationResults;

            internal ValidationFormatter(Hl7Errors validationResults) {
                this.validationResults = validationResults;
            }

            public override void Format(Test source, XPathNavigator context, StringBuilder output) {
                string location = FormattingUtils.GetFullNodePosition(context.Clone(), String.Empty, source);
                validationResults.AddHl7Error(new Hl7Error(Hl7ErrorCode.SCHEMATRON, source.Message, location));
            }
        }

        private static readonly ILog LOG = LogManager.GetLogger(typeof(SchematronValidator));

        private bool initiated = false;
        private NMatrix.Schematron.Validator validator;

		public SchematronValidator(IList<SchematronContext> contexts) {
            if (!contexts.IsEmpty()) {
                NMatrix.Schematron.Schema sch = new NMatrix.Schematron.Schema();
                sch.Title = "CDA Validation Schema";
                sch.NsManager = new XmlNamespaceManager(new XmlDocument().NameTable);
                sch.NsManager.AddNamespace("cda", "urn:hl7-org:v3");
                sch.NsManager.AddNamespace("voc", "http://www.lantanagroup.com/voc");

                Phase phase = sch.CreatePhase("CDAValidation");
                sch.Phases.Add(phase);
                foreach (SchematronContext context in contexts) {
                    Pattern pattern = phase.CreatePattern(context.Context);
                    Rule rule = pattern.CreateRule(context.Context);
                    rule.SetContext(sch.NsManager);
                    foreach (SchematronRule schematronRule in context.Rules) {
                        try {
                            Assert assert = rule.CreateAssert(schematronRule.Test, schematronRule.Description);
                            assert.SetContext(sch.NsManager);
                            rule.Asserts.Add(assert);
                        } catch (XPathException e) {
                            LOG.Error("Failed to evaluate expression: " + schematronRule.Test);
                            LOG.Error(e.Message);
                        } catch (InvalidExpressionException e) {
                            LOG.Error("Failed to evaluate expression: " + schematronRule.Test);
                            LOG.Error(e.Message);
                        }
                    }
                    pattern.Rules.Add(rule);
                    sch.Patterns.Add(pattern);
                    phase.Patterns.Add(pattern);
                }
                validator = new NMatrix.Schematron.Validator();
                validator.AddSchema(sch);
                validator.Phase = phase.Id;
                initiated = true;
            }
		}

		public virtual void Validate(string xml, Hl7Errors validationResults) {
            if (initiated) {
                Validate(new DocumentFactory().CreateFromString(xml), validationResults);
            }
		}

		public virtual void Validate(XmlDocument document, Hl7Errors validationResults) {
            if (initiated) {
                try {
                    validator.Formatter = new ValidationFormatter(validationResults);
                    validator.ValidateSchematron(document);
                } catch (ValidationException e) {
                    //Do nothing
                } catch (Exception e) {
                    validationResults.AddHl7Error(new Hl7Error(Hl7ErrorCode.SYNTAX_ERROR, e.Message, (String)null));
                }
            }
        }
	}
}
