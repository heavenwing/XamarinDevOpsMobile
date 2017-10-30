Param(
    [string]$codeVersion,
    [string]$buildNumber
)

$content = Get-Content(".\src\XamarinDevOpsDemo\Properties\AssemblyInfo.cs")
$content = $content.Replace("__CODEVERSION__" , $codeVersion)
$content = $content.Replace("__BUILDNUMBER__" , $buildNumber)
$content | Out-File ".\src\XamarinDevOpsDemo\Properties\AssemblyInfo.cs"
    
