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
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hello_World
{
    public enum DomainChoice { CR, IMM, LAB, DRUG, VAL, UNKNOWN };
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Console.WriteLine("Program Main()");
                DomainChoice domainChosen = DomainChoiceFor(args[0]);
                HelloWorldApp app = null;
                switch (domainChosen)
                {
                    case DomainChoice.CR:
                        app = new FindCandidatesQueryApp();
                        break;
                    case DomainChoice.IMM:
                        app = new ImmunizationQueryApp();
                        break;
                    case DomainChoice.LAB:
                        app = new LabResultsQueryApp();
                        break;
                    case DomainChoice.DRUG:
                        app = new DrugPrescriptionQueryApp();
                        break;
                    case DomainChoice.VAL:
                        new MessageValidator().Run(args);
                        break;
                }
                if (app != null)
                {
                    app.Run(args);
                }
            }
            Console.WriteLine("Done");
        }

        static DomainChoice DomainChoiceFor(string value)
        {
            
            if (value.Equals("CR"))
            {
                return DomainChoice.CR;
            }
            else if (value.Equals("IMM"))
            {
                return DomainChoice.IMM;
            }
            else if (value.Equals("LAB"))
            {
                return DomainChoice.LAB;
            }
            else if (value.Equals("DRUG"))
            {
                return DomainChoice.DRUG;
            }
            else if (value.Equals("VAL"))
            {
                return DomainChoice.VAL;
            }
            else
            {
                Console.Out.WriteLine("Unknown Domain Choice argument. Choose one of: CR, IMM, LAB, DRUG, VAL");
                return DomainChoice.UNKNOWN;
            }
        }

    }
}
