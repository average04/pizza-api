# Pizza API

## Overview

This API is built using the Clean Architecture pattern and follows a code-first approach with Entity Framework Core (EF Core). It is designed to be modular, maintainable, and scalable. The project leverages several powerful libraries to enhance its functionality and performance.

## Technologies & Libraries

- **.NET 8**
- **EF Core**: For database access using the code-first approach.
- **Serilog**: For logging.
- **MediatR**: For implementing the CQRS pattern.
- **FluentValidation**: For request validation.
- **EFCore.BulkExtensions**: For bulk operations.
- **Pomelo.EntityFrameworkCore.MySql**: For MySQL database integration.

## Project Structure

The API is organized into several layers, adhering to Clean Architecture principles:

- **Domain**: Contains the core entities, value objects, and domain logic.
- **Application**: Contains the business logic, including commands, queries, and handlers. This layer also includes interfaces and abstractions.
- **Infrastructure**: Handles data access, logging, external service integrations, and other cross-cutting concerns. This layer also contains the implementation of repositories and other data-related services.
- **WebAPI**: The entry point of the application, containing controllers, middlewares, and configuration settings.

## Getting Started

### Prerequisites

- .NET 8 SDK
- MySQL Server (for database)

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/your-repo/my-api.git
   cd my-api
2. Restore dependencies:
   ```bash
   dotnet restore
3. Set up the database:
   - Update the connection string in appsettings.json.
   - Apply migrations:
      ```bash
      dotnet ef database update
4. Run the application:
     ```bash
      dotnet run

### Logging
Serilog is configured to log important events, errors, and diagnostics. Logs are written to the console, and you can easily configure it to write to files, databases, or other sinks.

### Validation
All incoming requests are validated using FluentValidation. Custom validators are created for each request model to ensure data integrity and provide clear error messages.
