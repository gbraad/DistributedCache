```powershell
Import-Module DistributedCacheAdministration
Use-CacheCluster
Remove-Cache -CacheName session
New-Cache -CacheName session -Eviction None
```
