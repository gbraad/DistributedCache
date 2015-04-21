Small test of using AppFabric to store serialized objects

```powershell
  Import-Module DistributedCacheAdministration
  Use-CacheCluster
  Remove-Cache -CacheName session
  New-Cache -CacheName session -Eviction None
```

