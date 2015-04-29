Create the cache
```powershell
Import-Module DistributedCacheAdministration
Use-CacheCluster
Remove-Cache -CacheName session
New-Cache -CacheName session -Eviction None

Get-CacheAllowedClientAccounts
Grant-CacheAllowedClientAccount -Account "[domain]\[username]"

Start-CacheCluster
```
