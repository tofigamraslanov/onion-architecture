# Onion Architecture In ASP.NET Core With CQRS and MediatR Pattern

A clean, scalable implementation of Onion Architecture in ASP.NET Core 6.0, demonstrating CQRS pattern using MediatR, Entity Framework Core, and best practices for building maintainable enterprise applications.

## 📋 Table of Contents

- [Overview](#overview)
- [Architecture](#architecture)
- [Features](#features)
- [Tech Stack](#tech-stack)
- [Getting Started](#getting-started)
- [API Endpoints](#api-endpoints)
- [Design Patterns](#design-patterns)
- [License](#license)

## 🎯 Overview

The Onion Architecture, introduced by Jeffrey Palermo, overcomes the issues of traditional layered architecture with great ease. The key principle is that the **Domain Layer** (Entities and Validation Rules) is at the Core of the entire application, providing higher flexibility and lower coupling. All outer layers depend only on the Core Layers, never the reverse.

![Onion Architecture](https://miro.medium.com/max/1400/1*0Pg6_UsaKiiEqUV3kf2HXg.png)

## 🏗️ Architecture

### Core Layers (Domain & Application)

**Domain Layer** - The heart of the application
- Contains enterprise-level business logic and entities
- Completely independent with no external dependencies
- Defines common types that can be shared across the entire enterprise
- Contains `BaseEntity` and domain entities like `Product`

**Application Layer** - Application-specific business logic
- Contains application-specific interfaces and types
- Defines CQRS commands, queries, and their handlers
- Implements the MediatR pattern for request/response handling
- Depends only on the Domain Layer

### Outer Layers

**Infrastructure Layer** - Technical implementation details
- Implements interfaces defined in the Application Layer
- Contains `Persistence` project with Entity Framework Core
- Database context, migrations, and data access logic
- Can be easily swapped without affecting core business logic

**Presentation Layer** - User-facing interface
- `WebApi` project providing REST API endpoints
- API versioning support
- Swagger/OpenAPI documentation
- Controllers that mediate between HTTP and application logic

### Dependency Inversion Principle (DIP)

This architecture follows DIP by:
- Defining interfaces in the Application Layer (e.g., `IApplicationDbContext`)
- Implementing these interfaces in outer layers (e.g., `ApplicationDbContext` in Infrastructure)
- Injecting dependencies at runtime through Dependency Injection
- Allowing easy swapping of implementations without changing core logic

## ✨ Features

- ✅ **Clean Onion Architecture** - Proper separation of concerns
- ✅ **CQRS Pattern** - Command Query Responsibility Segregation
- ✅ **MediatR** - In-process messaging for decoupled communication
- ✅ **Entity Framework Core** - Code-first database approach
- ✅ **Repository Pattern** - Data access abstraction via DbContext
- ✅ **API Versioning** - Support for multiple API versions
- ✅ **Swagger UI** - Interactive API documentation
- ✅ **Dependency Injection** - Built-in .NET DI container
- ✅ **CRUD Operations** - Complete Create, Read, Update, Delete functionality
- ✅ **Inverted Dependencies** - Core layers independent of infrastructure

## 🛠️ Tech Stack

- **.NET 6.0** - Latest LTS version of .NET
- **ASP.NET Core 6.0 WebApi** - Web framework
- **Entity Framework Core 6.0** - ORM for data access
- **MediatR 10.0** - Mediator pattern implementation
- **Swagger/Swashbuckle** - API documentation
- **Microsoft.AspNetCore.Mvc.Versioning** - API versioning
- **SQL Server** - Database (via EF Core)

##  Getting Started

### Prerequisites

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/sql-server) (LocalDB, Express, or any edition)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/tofigamraslanov/onion-architecture.git
   cd onion-architecture
   ```

2. **Update the connection string**
   
   Edit `Presentation/WebApi/appsettings.json` and update the connection string:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=OnionArchitectureDb;Trusted_Connection=True;"
   }
   ```

3. **Apply database migrations**
   ```bash
   cd Presentation/WebApi
   dotnet ef database update
   ```

4. **Run the application**
   ```bash
   dotnet run
   ```

5. **Access Swagger UI**
   
   Navigate to: `https://localhost:<port>/swagger`

### Using Visual Studio

1. Open `OnionArchitecture.sln`
2. Set `WebApi` as the startup project
3. Update the connection string in `appsettings.json`
4. Open Package Manager Console:
   ```
   Update-Database
   ```
5. Press F5 to run

## 🌐 API Endpoints

### Product API (v1)

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/v1/Product/GetAll` | Get all products |
| GET | `/api/v1/Product/GetById/{id}` | Get product by ID |
| POST | `/api/v1/Product/Create` | Create a new product |
| PUT | `/api/v1/Product/Update` | Update an existing product |
| DELETE | `/api/v1/Product/Delete/{id}` | Delete a product by ID |

### Sample Request (Create Product)

```json
POST /api/v1/Product/Create
Content-Type: application/json

{
  "name": "Sample Product",
  "barcode": "1234567890",
  "description": "This is a sample product",
  "rate": 99.99
}
```

### Sample Response

```json
{
  "id": 1,
  "name": "Sample Product",
  "barcode": "1234567890",
  "description": "This is a sample product",
  "rate": 99.99
}
```

## 🎨 Design Patterns

### CQRS (Command Query Responsibility Segregation)

Separates read and write operations:
- **Commands**: Modify state (Create, Update, Delete)
- **Queries**: Read state without modification (GetAll, GetById)

### Mediator Pattern (via MediatR)

- Reduces coupling between components
- Handlers process requests independently
- Easy to add new features without modifying existing code

### Repository Pattern

- Abstracted via `IApplicationDbContext` interface
- `DbContext` acts as a Unit of Work
- `DbSet<T>` provides repository functionality per entity

### Dependency Injection

- Constructor injection throughout the application
- Services registered in `DependencyInjection.cs` files
- Promotes loose coupling and testability

## 📚 Learning Resources

- [Onion Architecture](https://jeffreypalermo.com/2008/07/the-onion-architecture-part-1/)
- [CQRS Pattern](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs)
- [MediatR Documentation](https://github.com/jbogard/MediatR)
- [Clean Architecture by Robert C. Martin](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)

## 📄 License

This project is licensed under the MIT License - see the LICENSE file for details.

## 🤝 Contributing

Contributions, issues, and feature requests are welcome! Feel free to check the issues page.

## 👨‍💻 Author

**Tofig Amraslanov**
- GitHub: [@tofigamraslanov](https://github.com/tofigamraslanov)

---

⭐ If you found this project helpful, please give it a star!
