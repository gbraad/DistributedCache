AppFabric Cache example
=======================


Small test of using AppFabric to store serialized objects

Make sure a local cache instance is available.
```powershell
  Import-Module DistributedCacheAdministration
  Use-CacheCluster
  Remove-Cache -CacheName session
  New-Cache -CacheName session -Eviction None
```

After this you can run
```powershell
  CacheSpikeCLI.exe
```

This will:
  * insert 1,000 objects,
  * read them again,
  * After two minutes the objects will have expired.


Authors
-------

| [!["Gerard Braad"](http://gravatar.com/avatar/e466994eea3c2a1672564e45aca844d0.png?s=60)](http://gbraad.nl "Gerard Braad <me@gbraad.nl>") |
|---|
| [@gbraad](https://twitter.com/gbraad)  |
