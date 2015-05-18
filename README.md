C# .NET Distributed Caching example
===================================


Small test of using AppFabric or Redis to store serialized objects


After this you can run
```powershell
  DistributedCacheCLI.exe
```

This will:
  * insert 1,000 objects,
  * read them again,
  * After two minutes the objects will have expired.


Installation
------------

To install this simple DistributedCache client, run the following command in the Package Manager Console
```powershell
Install-Package DistributedCache.Shared
Install-Package DistributedCache.AppFabric
```


Usage
-----

```cs
using DistributedCache;

var cacheHelper = new AppFabricCache<string>();
cacheHelper.Set("key", "value", new TimeSpan(0, 0, 2, 0));
var cachedstring = cacheHelper.Get("key");
```


Authors
-------

| [!["Gerard Braad"](http://gravatar.com/avatar/e466994eea3c2a1672564e45aca844d0.png?s=60)](http://gbraad.nl "Gerard Braad <me@gbraad.nl>") |
|---|
| [@gbraad](https://twitter.com/gbraad)  |
