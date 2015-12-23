Camunda C# REST Client (unofficial)
==========================
# [![Build status](https://ci.appveyor.com/api/projects/status/3x35eh4fcp2pxd95?svg=true)](https://ci.appveyor.com/project/salajlan76175/camundacsharpclient) [![NuGet version](https://badge.fury.io/nu/camunda.svg)](https://badge.fury.io/nu/camunda)
An unofficial c# client for Camunda engine REST API

----------

Installation
----------------
You could install client by using nuget package manager
```
PM> Install-Package camunda

```

Usage
--------
```
// create new camunda rest client
var client = new CamundaRestClient("http://localhost:8080/engine-rest");

// Authentication - Basic Authentication
client.Authenticator("username","password");

// use client to communicate with the engine
// as example get list of users in the engine
var usersList = client.User().list();

// usersList output
// demo -- Demo -- Demo -- demo@camunda.org
// john -- John -- Doe -- john@camunda.org
// mary -- Mary -- Anne -- mary@camunda.org
// peter -- Peter -- Meter -- peter@camunda.org

// let's sort users by id desc
var usersListSort = client.User().sortByNSortOrder(UserQueryModel.SortByValue.userId,"desc").list();
// usersListSort output
// peter -- Peter -- Meter -- peter@camunda.org
// mary -- Mary -- Anne -- mary@camunda.org
// john -- John -- Doe -- john@camunda.org
// demo -- Demo -- Demo -- demo@camunda.org

// what if we want a list of users that member of sales group
var usersSalesGroup = client.User().MemberOfGroup("sales").list();
// usersSalesGroup output
// demo -- Demo -- Demo -- demo@camunda.org
// john -- John -- Doe -- john@camunda.org

```
Authentication
--------------------
Camunda engine REST API Support only Basic authentication
```
client.Authenticator("username","password");
```
And we have adding support for NTLM authentication on our camunda engine, and if you have you can use
```
// as new NtlmAuthenticator()
client.Authenticator();
```

API References
--------------------
We have covered most of the References and their methods  

###Covered

 - User
 - Group
 - Process Instance
 - Process Definition
 - Task

### Limited
 - History

### TODO
All other References

License
----------
Copyright 2015 Sulaiman Alajlan

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.



----------
