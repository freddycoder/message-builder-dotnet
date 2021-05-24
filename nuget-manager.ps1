<#
     Copyright 2021 Frédéric Jacques
 
 Licensed under the Apache License, Version 2.0 (the "License");
 you may not use this file except in compliance with the License.
 You may obtain a copy of the License at
 
        http://www.apache.org/licenses/LICENSE-2.0
 
 Unless required by applicable law or agreed to in writing, software
 distributed under the License is distributed on an "AS IS" BASIS,
 WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 See the License for the specific language governing permissions and
 limitations under the License.
 
 Author:        $LastChangedBy: Frédéric Jacques
 Last modified: $LastChangedDate: 2021-01-23 12:24:12 -0500 (Sun, 23 May 2021)
 Revision:      $LastChangedRevision: 1
#>

param(
    [string] $includeSymbole,
    [string] $doPush,
    [string] $apiKey
)

$nugetSource = "https://api.nuget.org/v3/index.json";

if ("true" -eq $doPush) {
    & nuget SetApiKey $apiKey -Source $nugetSource
}

$projects = Get-ChildItem -Filter "message-builder-*";

foreach ($project in $projects)
{
    $csprojPath = $project.Name + "\" + $project.Name + ".csproj";
    $assemblyInfoPath = $project.Name + "\Properties\AssemblyInfo.cs";
    $nuspecPath = $project.Name + "\" + $project.Name + ".nuspec";

    $csproj = [xml] (Get-Content $csprojPath -Encoding utf8);
    $assemblyInfo = (Get-Content $assemblyInfoPath -Encoding utf8);

    if (Test-Path $nuspecPath) {
        $nuspec = [xml] (Get-Content $nuspecPath -Encoding utf8);
    }
    else {
        & Set-Location $project.Name;
        & nuget spec
        & Set-Location ..
    }

    $nuspec = [xml] (Get-Content $nuspecPath -Encoding utf8);
    
    $vendor = "Freddycoder.Ca.Infoway.";
    $projectPostfix = $project.Name -Split '-';
    $nugetId = $vendor;
    if ($projectPostfix.Length -eq 3) {
        $nugetId += (Get-Culture).TextInfo.ToTitleCase($projectPostfix[2]);
    }
    else {
        $nugetId += (Get-Culture).TextInfo.ToTitleCase($project.Name.Replace("message-builder-release-", "").Replace("-", "."));
    }

    $nuspec.package.metadata.id = $nugetId;
    $nuspec.package.metadata.version = "1.0.0-alpha";
    $nuspec.package.metadata.title = $nugetId;
    $nuspec.package.metadata.authors = "Frédéric Jacques";
    $nuspec.package.metadata.owners = "Frédéric Jacques";
    
    $parent_xpath = '/package/metadata'
    $nodes = $nuspec.SelectNodes($parent_xpath)
    $nodes | ForEach-Object {
        $child_node = $_.SelectSingleNode('//licenseUrl');
        if ($null -ne $child_node) {
            $_.RemoveChild($child_node) | Out-Null
        }
        $child_nodes = $_.SelectNodes('//license');
        foreach ($c in $child_nodes) {
            $_.RemoveChild($c) | Out-Null
        }
        $child_node = $_.SelectSingleNode('//iconUrl');
        if ($null -ne $child_node) {
            $_.RemoveChild($child_node) | Out-Null
        }
    }

    $newItemtoAdd = $nuspec.CreateElement('license')
    $expression = $nuspec.CreateAttribute("type");
    $expression.Value = "expression"
    $newItemtoAdd.PsBase.InnerText = 'Apache-2.0'
    $newItemtoAdd.Attributes.Append($expression) | Out-Null; 
    $nuspec.package.metadata.InsertAfter($newItemtoAdd, $nuspec.SelectSingleNode("/package/metadata/owners")) | Out-Null

    $nuspec.package.metadata.projectUrl = "https://github.com/freddycoder/message-builder-dotnet";

    $nuspec.package.metadata.description = "HL7v3 interactions. This is a dotnet core version of message-builder-donet. This is the result of the tool try-convert apply on this repo : https://github.com/CanadaHealthInfoway/message-builder-dotnet";

    $nuspec.package.metadata.releaseNotes = "Initial release of the package";

    $nuspec.package.metadata.copyright = "Copyright © Frédéric Jacques 2021";

    $nuspec.package.metadata.tags = "HL7 HL7v3";

    $parent_xpath = '/package/metadata'
    $nodes = $nuspec.SelectNodes($parent_xpath)
    $nodes | ForEach-Object {
        $child_nodes = $_.SelectNodes('//dependencies');
        foreach ($c in $child_nodes) {
            $_.RemoveChild($c) | Out-Null
        }
    }

    $newItemtoAdd = $nuspec.CreateElement('dependencies');
    $group = $nuspec.CreateElement('group');
    $targetFramework = $nuspec.CreateAttribute("targetFramework");
    $targetFramework.Value = "netstandard2.0";
    $group.Attributes.Append($targetFramework) | Out-Null;
    $newItemtoAdd.AppendChild($group) | Out-Null;
    $nuspec.package.metadata.InsertAfter($newItemtoAdd, $nuspec.SelectSingleNode("/package/metadata/tags")) | Out-Null

    $parent_xpath = '/package'
    $nodes = $nuspec.SelectNodes($parent_xpath)
    $nodes | ForEach-Object {
        $child_nodes = $_.SelectNodes('//files');
        foreach ($c in $child_nodes) {
            $_.RemoveChild($c) | Out-Null
        }
    }

    $files = $nuspec.CreateElement('files');

    $references = $csproj.Project.ItemGroup.Reference;

    $generatesnuspec = "false";

    foreach ($reference in $references) {
        if ($null -ne $reference.Include) {
            $file = $nuspec.CreateElement('file');
            
            $src = $nuspec.CreateAttribute("src");
            $src.Value = $reference.HintPath;
            $file.Attributes.Append($src) | Out-Null;

            $target = $nuspec.CreateAttribute("target");
            $target.Value = "lib\netstandard2.0";
            $file.Attributes.Append($target) | Out-Null;

            $files.AppendChild($file) | Out-Null;

            $generatesnuspec = "true";
        }
    }

    $nuspec.package.InsertAfter($files, $nuspec.SelectSingleNode("/package/metadata")) | Out-Null

    $parent_xpath = '/Project/PropertyGroup'
    $nodes = $csproj.SelectNodes($parent_xpath);
    $nodes | ForEach-Object {
        $child_node = $_.SelectSingleNode('//GeneratePackageOnBuild');
        if ($null -ne $child_node) {
            $_.RemoveChild($child_node) | Out-Null
        }
    }

    $parent_xpath = '/Project/PropertyGroup'
    $nodes = $csproj.SelectNodes($parent_xpath);
    $nodes | ForEach-Object {
        $child_node = $_.SelectSingleNode('//NoWarn');
        if ($null -ne $child_node -and $child_node.InnerText -eq "$$(NoWarn);NU5128") {
            $_.RemoveChild($child_node) | Out-Null
        }
        $child_node = $_.SelectSingleNode('//NoWarns');
        if ($null -ne $child_node -and $child_node.InnerText -eq "$$(NoWarn);NU5128") {
            $_.RemoveChild($child_node) | Out-Null
        }
    }

    $nowarns = $csproj.CreateElement('NoWarn');
    $nowarns.InnerText = "$$(NoWarn);NU5128".Replace("..", "$");
    $propertyGroup = $csproj.SelectSingleNode("/Project/PropertyGroup");
    $propertyGroup.InsertAfter($nowarns, $csproj.SelectSingleNode("/Project/PropertyGroup/GenerateAssemblyInfo")) | Out-Null

    $nuspec.Save($nuspecPath);
    $csproj.Save($csprojPath);

    & Set-Location $project.Name
    & nuget pack -OutputDirectory ..\Packages -Properties Configuration=Release

    if ("true" -eq $generatesnuspec -and "true" -eq $includeSymbole) {
        & nuget pack -OutputDirectory ..\Packages -Symbols -SymbolPackageFormat snupkg -Properties Configuration=Release
    }
    elseif ("true" -eq $includeSymbole) {
        & nuget pack -OutputDirectory ..\Packages -Symbols -Properties Configuration=Release
    }

    if ("true" -eq $doPush) {
        $packageFile = $nuspec.package.metadata.id + "." + $nuspec.package.metadata.version + ".nupkg";
        $symbolPackage = $nuspec.package.metadata.id + "." + $nuspec.package.metadata.version + ".snupkg";
        & nuget push ..\Packages\$packageFile -src $nugetSource -SkipDuplicate
        if ("true" -eq $includeSymbole) {
            if (Test-Path ..\Packages\$symbolPackage) {
                & nuget push ..\Packages\$symbolPackage -src $nugetSource -SkipDuplicate
            }
            else {
                $symbolPackage = $nuspec.package.metadata.id + "." + $nuspec.package.metadata.version + ".symbols.nupkg";
                & nuget push ..\Packages\$symbolPackage -src $nugetSource -SkipDuplicate
            }
        }
    }

    & Set-Location ..
}