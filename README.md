# Dakar Rally 

Simulation of fameous Dakar Rally.

## Technologies

* ASP.NET Core 5
* [Entity Framework Core 5](https://docs.microsoft.com/en-us/ef/core/)
* Decouplied in-process of sending of messages from handling messages.

## Getting Started

The easiest way to get started is:

 1. You have Microsoft SQL Server installed on your mashine
 2. Install the latest [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
 3. Clone the repo
 4. Click "F5"
![image](https://user-images.githubusercontent.com/43738975/117586394-2bf8f700-b118-11eb-8613-31815e295182.png)

### Database Configuration

The template is configured to use an  by default. This ensures that all users will be able to run the solution without needing to set up additional infrastructure (e.g. SQL Server).

If you would like to use SQL Server, you will need to update **WebUI/appsettings.json** as follows:

```json
  "UseInMemoryDatabase": false,
```

Verify that the **DefaultConnection** connection string within **appsettings.json** points to a valid SQL Server instance. 

When you run the application the database will be automatically created (if necessary) and the latest migrations will be applied.

## Overview

### Domain

This will contain all entities, enums, types and logic specific to the domain layer.

### Application

This layer contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers. For example, if the application need to access a RaceRepository service, a new interface would be added to application and an implementation would be created within infrastructure.

### Infrastructure

This layer contains classes for accessing external resources. These classes should be based on interfaces defined within the application layer.

### WebUI

This layer is Web Api written in ASP.NET Core 5. This layer depends on both the Application and Infrastructure layers, however, the dependency on Infrastructure is only to support dependency injection. Therefore only *Startup.cs* should reference Infrastructure.

### Api Examples

By runing the application Api Documentation presented by Swagger will open. 

![image](https://user-images.githubusercontent.com/43738975/117586620-99f1ee00-b119-11eb-9f8f-47a3e1b126d5.png)

In current version you will need to have database in SQL server to fully test the Api, in near future you will be able to test it in certain scope with just in-memory database.

Api examples 1: Create Race

In Swagger go to Races endpoints, go to CreateRace endpoint

![image](https://user-images.githubusercontent.com/43738975/117586854-146f3d80-b11b-11eb-8d06-850b80c59d22.png)

Click Try it out and enter the only parameter for this endpoint, the year of the race.

![image](https://user-images.githubusercontent.com/43738975/117586895-61531400-b11b-11eb-9cc2-b482adecde24.png)

Click Execute and you will get response in the form of race object you just created.

![image](https://user-images.githubusercontent.com/43738975/117586936-9f503800-b11b-11eb-9128-d9ae485dae60.png)



