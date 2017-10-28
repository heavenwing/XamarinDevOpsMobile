Param(
    [string]$appId,
    [string]$platform,
    [string]$version
)

$Server = 'localhost:44361'
$Url = "https://${server}/api/Update"

$Body = @{
    AppId = $appId
    Platform = $platform
    Version = $version
}

Invoke-RestMethod -Method Post -Uri $url -Body (ConvertTo-Json $body) -ContentType "application/json"