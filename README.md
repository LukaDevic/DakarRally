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

The template is configured to use an in-memory database by default. This ensures that all users will be able to run the solution without needing to set up additional infrastructure (e.g. SQL Server).

If you would like to use SQL Server, you will need to update **WebUI/appsettings.json** as follows:

```json
  "UseInMemoryDatabase": false,
```

Verify that the **DefaultConnection** connection string within **appsettings.json** points to a valid SQL Server instance. 

When you run the application the database will be automatically created (if necessary) and the latest migrations will be applied.
