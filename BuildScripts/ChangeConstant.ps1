Param(
    [string]$buildSymbol
)

$content = Get-Content(".\src\XamarinDevOpsDemo\Tools\ConstantTools.cs")
$content[0] = "#define " + $buildSymbol
$content[1] = ""
$content[2] = ""
$content | Out-File -Encoding utf8 ".\src\XamarinDevOpsDemo\Tools\ConstantTools.cs"