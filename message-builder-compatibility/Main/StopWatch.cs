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
 * Last modified: $LastChangedDate: 2011-05-17 11:48:36 -0400 (Tue, 17 May 2011) $
 * Revision:      $LastChangedRevision: 2666 $
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ca.Infoway.Messagebuilder
{

    public class StopWatch
    {
        private long startTime = 0;
        private long stopTime = 0;
        private bool running = false;


        public void Start()
        {
            this.startTime = DateTime.Now.Ticks;
            this.running = true;
        }


        public void Stop()
        {
            this.stopTime = DateTime.Now.Ticks;
            this.running = false;
        }


        //elaspsed time in milliseconds
        public long GetElapsedTime()
        {
            long elapsed;
            if (running)
            {
                elapsed = (DateTime.Now.Ticks - startTime) / 10000;
            }
            else
            {
                elapsed = (stopTime - startTime) / 10000;
            }
            return elapsed;
        }


        //elaspsed time in seconds
        public long GetElapsedTimeSecs()
        {
            return GetElapsedTime() / 1000;
        }

        public long GetTime()
        {
            return GetElapsedTime();
        }
    }
}
