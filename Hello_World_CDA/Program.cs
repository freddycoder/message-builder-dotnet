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

namespace Hello_World_CDA {

    public enum DomainChoice { NOTE, VAL, UNKNOWN };

    class Program {

        static void Main(string[] args) {
             if (args.Length > 0) {
                 Console.WriteLine("Program Main()");
                 DomainChoice choice = DomainChoiceFor(args[0]);
                 switch (choice) {
                     case DomainChoice.NOTE:
                         new ConsultationNoteHelloWorldApp().Run(args);
                         break;
                     case DomainChoice.VAL:
                         new ProcedureNoteMessageValidator().Run(args);
                         break;
                 }
             }
             Console.WriteLine("Done");
        }

        static DomainChoice DomainChoiceFor(string value) {
            if (value.Equals("NOTE")) {
                return DomainChoice.NOTE;
            } else if (value.Equals("VAL")) {
                return DomainChoice.VAL;
            } else {
                Console.Out.WriteLine("Unknown Domain Choice argument. Choose one of: NOTE, VAL");
                return DomainChoice.UNKNOWN;
            }
        }
    }
}
