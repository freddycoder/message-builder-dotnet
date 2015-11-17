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
 * Author:        $LastChangedBy: tmcgrady $
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Basemodel;
using Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Consultationnote;
using Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged;
using Ca.Infoway.Messagebuilder.Platform;

namespace Hello_World_CDA {

    public class ConsultationNoteAccessor {

        /*
         * This class shows how to walk through a MB CDA Document object (ConsultationNote, in this case) and
         * access various fields. 
         * 
         */

        public void ProcessConsultationNote(ConsultationNote consultationNote) {
            Console.WriteLine("\n\nWriting out various values from ConsultationNote objects:\n");

            Console.WriteLine("Title: " + consultationNote.Title);
            Console.WriteLine("Template Id: " + consultationNote.TemplateId);
            RenderAuthor(consultationNote.Author.Count == 0 ? null : consultationNote.Author[0]);
            RenderPatient(consultationNote.RecordTarget.Count == 0 ? null : consultationNote.RecordTarget[0].PatientRole);

            RenderSections(consultationNote);

        }

        private void RenderSections(ConsultationNote consultationNote) {
            if (consultationNote.Component != null) {
                Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Consultationnote.Component2 component = consultationNote.Component;
                if (component.HasComponent2ChoiceAsNonXMLBody()) {
                    // not much to render in this case
                    NonXMLBody nonXmlBody = component.Component2ChoiceAsNonXMLBody;
                    Console.WriteLine("Non-XML Body Text: ");
                    RenderText(nonXmlBody.Text);
                } else if (component.HasComponent2ChoiceAsStructuredBody()) {
                    Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Consultationnote.StructuredBody structuredBody = component.Component2ChoiceAsStructuredBody;
                    foreach (IComponent3Choice section in structuredBody.Component) {
                        RenderSection(section);
                    }
                }
            }

        }

        private void RenderSection(IComponent3Choice section) {
            // At some point in every CDA document we get to this...
            // We have a section that could one of any number of section types (in this case one of 28 sections(!)).
            // There is no "good" way to model this that would allow us to avoid having to query each section to see what it is.
            // Fortunately, MB can *usually* merge many similar sections into a single model class, so in many cases this code can be reused for some/all document types.

            if (section is AllergiesSectionentriesOptionalComponent3) {
                AllergiesSectionentriesOptionalComponent3 optionalAllergies = (AllergiesSectionentriesOptionalComponent3)section;
                Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Allergiessectionentriesoptional.Section allergies = optionalAllergies.Section;
                ProcessOptionalAlergies(allergies);

            } else if (section is AllergiesSectionentriesRequiredComponent3) {
                // no required allergies section for this sample CDA document
                AllergiesSectionentriesRequiredComponent3 optionalAllergies = (AllergiesSectionentriesRequiredComponent3)section;
                Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Allergiessectionentriesrequired.Section allergies = optionalAllergies.Section;
                ProcessRequiredAlergies(allergies);

            } else if (section is AssessmentAndPlanSectionComponent3) {
                // etc.

            } else if (section is AssessmentSectionComponent3) {
            } else if (section is ChiefComplaintAndReasonForVisitSectionComponent3) {
            } else if (section is ChiefComplaintSectionComponent3) {

            } else if (section is FamilyHistorySectionComponent3) {
                FamilyHistorySectionComponent3 familyHistory = (FamilyHistorySectionComponent3)section;
                Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Familyhistorysection.Section familyHistorySection = familyHistory.Section;
                ProcessFamilyHistory(familyHistorySection);

            } else if (section is GeneralStatusSectionComponent3) {
            } else if (section is HistoryOfPastIllnessSectionComponent3) {
            } else if (section is HistoryOfPresentIllnessSectionComponent3) {
            } else if (section is ImmunizationsSectionentriesOptionalComponent3) {
            } else if (section is ImmunizationsSectionentriesRequiredComponent3) {
            } else if (section is MedicationsSectionentriesOptionalComponent3) {
            } else if (section is MedicationsSectionentriesRequiredComponent3) {
            } else if (section is PhysicalExamSectionComponent3) {
            } else if (section is PlanOfCareSectionComponent3) {
            } else if (section is ProblemSectionentriesOptionalComponent3) {
            } else if (section is ProblemSectionentriesRequiredComponent3) {
            } else if (section is ProceduresSectionentriesOptionalComponent3) {
            } else if (section is ProceduresSectionentriesRequiredComponent3) {
            } else if (section is ReasonForReferralSectionComponent3) {
            } else if (section is ReasonForVisitSectionComponent3) {
            } else if (section is ResultsSectionentriesOptionalComponent3) {
            } else if (section is ResultsSectionentriesRequiredComponent3) {
            } else if (section is ReviewOfSystemsSectionComponent3) {
            } else if (section is SocialHistorySectionComponent3) {
            } else if (section is VitalSignsSectionentriesOptionalComponent3) {
            } else if (section is VitalSignsSectionentriesRequiredComponent3) {
            } else {
                if (section != null) {
                    Console.WriteLine("Unexpected section type encountered: " + section.GetType());
                }
            }

        }

        private void ProcessFamilyHistory(Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Familyhistorysection.Section familyHistory) {
            Console.WriteLine(familyHistory.Title);
            Console.WriteLine("Text: ");
            RenderText(familyHistory.Text);
        }

        private void ProcessRequiredAlergies(Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Allergiessectionentriesrequired.Section allergies) {
            // TODO fill in as appropriate
        }

        private void ProcessOptionalAlergies(Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Allergiessectionentriesoptional.Section allergies) {
            Console.WriteLine(allergies.Title);
            Console.WriteLine("Text: ");
            RenderText(allergies.Text);
        }

        private void RenderAuthor(Author_2 author_2) {
            if (author_2 == null) return;

            IList<Identifier> ids = author_2.AssignedAuthor.Id;
            Console.WriteLine("Author id: " + (ids.Count == 0 ? "(none)" : ids[0].ToString()));

            IList<PostalAddress> addrs = author_2.AssignedAuthor.Addr;
            Console.WriteLine("Author address: " + (addrs.Count == 0 ? "(none)" : RenderAddress(addrs[0])));
        }

        private void RenderPatient(Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged.PatientRole patientRole) {
            if (patientRole == null) return;

            Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged.Patient patient = patientRole.Patient;
            if (patient != null) {
                Console.WriteLine("Patient Name: " + (patient.Name.Count == 0 ? "(none)" : RenderName(patient.Name[0])));
                Console.WriteLine("Patient Birth Date: " + (patient.Name.Count == 0 ? "(none)" : RenderDate(patient.BirthTime)));
            }
        }

        private void RenderText(EncapsulatedData text) {
            if (text == null) {
                Console.WriteLine("(none)");
            } else {
                Console.WriteLine(text.Content);
            }
        }

        private string RenderName(PersonName personName) {
            return NameFormatter.SimpleNameFormatter.Format(personName);
        }

        private string RenderDate(MbDate birthTime) {
            string result = "";
            if (birthTime != null && birthTime.Value != null) {
                PlatformDate date = birthTime.Value;
                string dateFormat = "yyyyMMdd hh:mm:ss";
                if (date is DateWithPattern) {
                    dateFormat = ((DateWithPattern)date).DatePattern;
                }
                result = DateFormatUtil.Format(date, dateFormat);
            }
            return result;
        }

        private string RenderAddress(PostalAddress postalAddress) {
		    string result = "";
		    if (postalAddress != null) {
			    foreach (PostalAddressPart postalAddressPart in postalAddress.Parts) {
				    result += (" " + postalAddressPart.Value);
			    }
		    }
		    return result;
	    }
    }

}
