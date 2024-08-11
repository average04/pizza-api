# Pizza API

## Overview

This API is built using the Clean Architecture pattern and follows a code-first approach with Entity Framework Core (EF Core). It is designed to be modular, maintainable, and scalable. The project leverages several powerful libraries to enhance its functionality and performance.

## Key Features

- **Code-First Approach:** The database schema is generated and managed using Entity Framework Core, with migrations created based on the code-first model.
- **Clean Architecture:** The API is structured to promote separation of concerns, making it easier to manage and scale the application.
- **Serilog:** Provides structured logging throughout the application, enabling better traceability and debugging.
- **MediatR:** Facilitates the implementation of the CQRS (Command Query Responsibility Segregation) pattern by mediating messages such as commands and queries between components.
- **FluentValidation:** Ensures that incoming requests are validated consistently and clearly, improving the robustness of the API.
- **EFCore.BulkExtensions:** Optimizes bulk operations within the database, enhancing performance when handling large datasets.

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
