# Dakar Rally 

Simulation of fameous Dakar Rally.

## Technologies

* ASP.NET Core 5
* [Entity Framework Core 5](https://docs.microsoft.com/en-us/ef/core/)
* Decoupled in-process of sending of messages from handling messages.

## Getting Started

The easiest way to get started is:

 1. You have Microsoft SQL Server installed on your mashine
 2. Install the latest [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
 3. Clone the repo
 4. Click "F5"
![image](https://user-images.githubusercontent.com/43738975/117586394-2bf8f700-b118-11eb-8613-31815e295182.png)

### Database Configuration

The template is configured to use an In Memory Database by default. This ensures that all users will be able to run the solution without needing to set up additional infrastructure (e.g. SQL Server). if this option is used In Memory Database is seeded with one Race with Id = 1 and some sample vehicles. With them you can update, delete vehicles, start the race, get race status etc. For detail explanation of api usage see Api Examples section bellow.

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

### Api examples 1: Create Race

In Swagger go to Races endpoints, go to CreateRace endpoint

![image](https://user-images.githubusercontent.com/43738975/117586854-146f3d80-b11b-11eb-8d06-850b80c59d22.png)

Click Try it out and enter the only parameter for this endpoint, the year of the race.

![image](https://user-images.githubusercontent.com/43738975/117586895-61531400-b11b-11eb-9cc2-b482adecde24.png)

Click Execute and you will get response in the form of race object you just created.

![image](https://user-images.githubusercontent.com/43738975/117586936-9f503800-b11b-11eb-9128-d9ae485dae60.png)


### Api examples 2: Add Vehicle to Race

In Swagger go to Vehicles endpoints, go to AddVehicle endpoint

![image](https://user-images.githubusercontent.com/43738975/117586996-f48c4980-b11b-11eb-8ff0-51d97a02d377.png)

Click Try it out and enter parameters for this endpoint, the race id, teamName,
vehicleType , current vehicleTypes are 0 = Motorbike, 1 = Car, 2 = Truck, 
then vehicleSubType, current options are 0 = Sport, 1 = Terrain, 2 = Cross.

![image](https://user-images.githubusercontent.com/43738975/117587039-31f0d700-b11c-11eb-8d4c-012958df4a5b.png)

Click Execute and you will get response in the form of race object you previously created but now which contain vehicle you created.

![image](https://user-images.githubusercontent.com/43738975/117587165-eb4fac80-b11c-11eb-99b4-e0247c638a59.png)

Besides this you can update, delete specific vehicle, get vehicles by parameters in the mentioned endpoints.

### Api examples 3: Start Race

In Swagger go to Races endpoints, go to StartRace endpoint

![image](https://user-images.githubusercontent.com/43738975/117587270-4a152600-b11d-11eb-958b-91e9f6bfba20.png)

Click Try it out and enter the race id parameter.
Click Execute and you will get response in the form of leaderboard object which contain result of the race, all the vehicles that partcipated ordered by first that reached the finish line. First vehicle that finished the race is the one that has reached the Race length in property "distanceCoverdInKm" in fewest hours which can be seen in property "finishedRaceInHours". Vehicles that suffered heavy malfunction havent finished the race and have stoped at point where havy melfunction occured.

![image](https://user-images.githubusercontent.com/43738975/117587502-92811380-b11e-11eb-93a8-281779339a06.png)
![image](https://user-images.githubusercontent.com/43738975/117587517-a2005c80-b11e-11eb-8cbd-892f80ed61a1.png)

After this you can access Leaderboards/GetLeaderboardByType endpoint, and get Vehicle Statistic endpoints.

### Api examples 4: Create Race

In Swagger go to Races endpoints, go to GetRaceStatus endpoint

![image](https://user-images.githubusercontent.com/43738975/117587631-3e2a6380-b11f-11eb-9d50-4ef462bce562.png)

Click Try it out and enter the only parameter for this endpoint, the race id.
Click Execute and you will get response in the form of race status object which presents some of the just finished race statistics.
Race statuses are 0 = Pending, 1 = Running, 2 = Finished.

![image](https://user-images.githubusercontent.com/43738975/117587690-6d40d500-b11f-11eb-9842-1c7bfbd4e80a.png)
