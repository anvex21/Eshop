# EShop .NET Project

## Description
This is a simple EShop backend built with .NET 8, Entity Framework Core, and SQL Server.  
It manages Clients, Addresses, Countries, Products, Sales with RESTful APIs.  
Includes basic CRUD operations and sorting/filtering where applicable.

---

## Features
- Manage Clients, Products, Sales, Addresses, Countries
- Sorting on price for Products and Sales
- Validation on input models
- Use of repository and service layers
- Swagger/OpenAPI support for API testing

---

## Requirements
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server (Express or full)
- IDE: Visual Studio 2022, Rider or VS Code with C# extension

---

## Getting Started

1. **Clone the repo:**

   ```bash
   git clone https://github.com/anvex21/eshop.git
   cd eshop

2. **Update connection string**
  Edit appsettings.json to set your SQL Server connection string, e.g.:
  ```bash
  "ConnectionStrings": {
      "DefaultConnection": "Your-connection-string-here"
  }
  ```

3. **Apply migrations and update database**
  ```bash
  dotnet ef database update
  ```

4. Run the application using F5

5. Use Swagger UI to test endpoints.

---

Project Structure:

Contracts — DTOs and service/repository interfaces

Entities — Database entities

Repository — EF Core repository implementations

Services — Business logic layer

Controllers — API endpoints

