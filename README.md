# Ticket Purchase

A Simple CRUD project where Customer can do booking tickets as well as canceling tickets. They can also modify if needed.
## Installation

1) Clone the project
```bash
 https://github.com/fa93/DotnetProjects.git
```
2) Run the file with extension ` .Sln ` on Visual Studio
3) Create a databse 
4) Set the `DefaultConnection` in `appsettings.json` file 
```bash
"ConnectionStrings": {
    "DefaultConnection": ""
  },
```

5) Now, Add and Update the migrations by running the following command on ``` Package Manager Console ```
```bash
  dotnet ef migrations add anyNameTable --project TicketPurchase.Web --context BookingDbContext -o Data/Migrations
  dotnet ef database update --project TicketPurchase.Web --context BookingDbContext 
```
⚠️ Must install ` Microsoft Visual Studio `, ` Microsoft SQL Server` and `SQL Server Management Studio` on your device


## Tech Stack

**Backend:** ASP.NET Core 6, Entity Framework core

**Server:**  Microsoft SQL Server

**Logger:** Serilog

**Dependency Injection:** Autofac

**Design Patterns:** Repository & Unit of Work

**Architecture:** Layered Architecture (UI, Business Logic & Data Access Layer)

**Others:** AutoMapper

