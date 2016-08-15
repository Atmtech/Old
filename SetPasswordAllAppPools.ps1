Import-Module WebAdministration
#$applicationPools = Get-ChildItem IIS:\AppPools | where { $_.processModel.userName -eq "Atmtech\WebApplicationSql" }
$applicationPools = Get-ChildItem IIS:\AppPools

foreach($pool in $applicationPools)
{
$name = "IIS:\AppPools\" + $pool.name
    $version =  (Get-ItemProperty $name managedRuntimeVersion).Value
    
    if ($version -eq "v4.0")
    {
        $pool.processModel.userName = "Atmtech\WebApplicationSql"
        $pool.processModel.password = "Crevette01@"
        $pool.processModel.identityType = 3
        $pool | Set-Item
    }
    
}