param($installPath, $toolsPath, $package, $project)
$project.Object.References.Add("System.Configuration")|out-null
$project.Object.References.Add("System.Data")|out-null