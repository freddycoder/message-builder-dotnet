@REM
@REM Copyright 2013 Canada Health Infoway, Inc.
@REM
@REM Licensed under the Apache License, Version 2.0 (the "License");
@REM you may not use this file except in compliance with the License.
@REM You may obtain a copy of the License at
@REM
@REM        http://www.apache.org/licenses/LICENSE-2.0
@REM
@REM Unless required by applicable law or agreed to in writing, software
@REM distributed under the License is distributed on an "AS IS" BASIS,
@REM WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
@REM See the License for the specific language governing permissions and
@REM limitations under the License.
@REM
@REM Author:        $LastChangedBy: tmcgrady $
@REM Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
@REM Revision:      $LastChangedRevision: 2623 $
@REM

for /D %%d in (SetupCore\Release) do 7z a -tzip "mb-dotnet-core-1.2.9-setup.zip" ".\%%d\*"
for /D %%d in (SetupExamples\Release) do 7z a -tzip "mb-dotnet-ex-1.2.9-setup.zip" ".\%%d\*"
for /D %%d in (SetupTerminology\Release) do 7z a -tzip "mb-dotnet-term-1.2.9-setup.zip" ".\%%d\*"