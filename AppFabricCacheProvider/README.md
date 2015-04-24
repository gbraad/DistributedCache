Create the cache
```powershell
Import-Module DistributedCacheAdministration
Use-CacheCluster
Remove-Cache -CacheName session
New-Cache -CacheName session -Eviction None
```

Grant access to the cache cluster
```powershell
Grant-CacheAllowedClientAccount -Account "[domain]\[username]"
```
