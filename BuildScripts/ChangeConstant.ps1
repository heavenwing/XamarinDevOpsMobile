Param(
    [string]$buildSymbol
)

$content = Get-Content(".\src\XamarinDevOpsDemo\Helpers\Constants.cs")
$content[0] = "#define " + $buildSymbol
$content[1] = ""
$content[2] = ""
$content | Out-File -Encoding utf8 ".\src\XamarinDevOpsDemo\Helpers\Constants.cs"