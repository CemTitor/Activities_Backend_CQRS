# ActivitiesCQRS

If you want

- [ ] You can change your "PORT" from "Properties/launchSettings.json"

For example: 
http://localhost:7216 ---> to ----> http://localhost:5200

- [ ] You can change your "DATABASE PARAMETER" from "appsettings.json" and "appsettings.Development.json"
For example: 


`{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "ActivityDb": "Server=localhost;Database=ActivityCqrsDB;Port=5432;User Id=postgres;Password=123456"
  }
}`

to

`{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "ActivityDb": "Server=localhost;Database=AnotherActivityCqrsDB;Port=6524;User Id=postgres;Password=654321"
  }
}`
