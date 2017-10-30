Param(
    [string]$appId,
    [string]$appName
)

$xml = [xml](Get-Content -Encoding UTF8 ".\src\XamarinDevOpsDemo.Android\Properties\AndroidManifest.xml")

$xml.manifest.package = $appId
$xml.manifest.application.SetAttribute("label", "http://schemas.android.com/apk/res/android", $appName)

$xml.Save(".\src\XamarinDevOpsDemo.Android\Properties\AndroidManifest.xml")