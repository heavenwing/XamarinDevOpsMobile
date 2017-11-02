Param(
    [string]$appId,
    [string]$appName
)

$xmlManifest = [xml](Get-Content -Encoding UTF8 ".\src\XamarinDevOpsDemo.Android\Properties\AndroidManifest.xml")

$xmlManifest.manifest.package = $appId
#$xmlManifest.manifest.application.SetAttribute("label", "http://schemas.android.com/apk/res/android", $appName)

$xmlManifest.Save(".\src\XamarinDevOpsDemo.Android\Properties\AndroidManifest.xml")

$xmlRes = [xml](Get-Content -Encoding UTF8 ".\src\XamarinDevOpsDemo.Android\Resources\values\strings.xml")

$app_name = $xmlRes.SelectNodes("resources/string[1]")
$app_name.set_InnerText($appName)

$xmlRes.Save(".\src\XamarinDevOpsDemo.Android\Resources\values\strings.xml")