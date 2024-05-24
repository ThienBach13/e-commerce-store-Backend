# FullStack Project - Ecommerce Backend

![.NET Core](https://img.shields.io/badge/.NET%20Core-v.8-purple)
![EF Core](https://img.shields.io/badge/EF%20Core-v.8-cyan)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-v.16-drakblue)

This project involves developing a backend system for an Ecommerce platform. It includes designing and implementing a database schema, REST API endpoints, custom PostgreSQL functions, and a backend server using ASP.NET Core and Entity Framework.

## Table of Contents

- [FullStack Project](#fullstack-project---online-store-backend)
  - [Table of Contents](#table-of-contents)
  - [Technologies and Libraries](#technologies-and-libraries)
  - [Getting Started](#getting-started)
    - [Prerequisites](#prerequisites)
    - [Running project locally](#running-project-locally)
      - [Prerequisites](#prerequisites-1)
      - [Setup Instructions](#setup-instructions)
  - [Database Schema and ERD Design](#database-schema-design-and-erd-design)
  - [REST API Design](#rest-api-design)
  - [Backend Server with ASP.NET Core](#backend-server-with-aspnet-core)
  - [Unit Testing](#unit-testing)
  - [Repository Structure](#repository-structure)

## Technologies and Libraries

| Technology                                                                                                                                 | Purpose                                                                                        |
| ------------------------------------------------------------------------------------------------------------------------------------------ | ---------------------------------------------------------------------------------------------- |
| **[ASP.NET Core](https://dotnet.microsoft.com/en-us/apps/aspnet)**                                                                         | Core framework for building server-side logic, routing, middleware, and dependency management. |
| **[Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli#create-the-database)** | ORM for database operations, abstracts SQL queries, simplifying data manipulation.             |
| **[PostgreSQL](https://www.postgresql.org/)**                                                                                              | Relational database management system for storing all application data.                        |

| Library                                                                                                                                | Purpose                                                                                            |
| -------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------- |
| **[JWT Bearer Authentication](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer/9.0.0-preview.3.24172.13)** | Implements token-based authentication for securing API endpoints, requiring valid JWTs for access. |
| **[xUnit](https://www.nuget.org/packages/xunit)**                                                                                      | Framework for unit testing, ensuring components function correctly in isolation.                   |
| **[Moq](https://www.nuget.org/packages/Moq)**                                                                                          | Mocking library used with xUnit to simulate behavior of dependencies during testing.               |

## Getting Started

This is instructions to set up environment to run project on local machine.

### Prerequisites

Before begin, ensure these followings are installed:

- **PostgreSQL.**
- Or any SQL client that supports PostgreSQL.

### Running project locally

Follow these steps to run project on local machine.

#### Prerequisites

- .NET 8.0 SDK or later
- PostgreSQL server
- Git

#### Setup Instructions

1. **Clone the repository**:
   ```bash
   git clone https://github.com/ThienBach13/fs17_CSharp_FullStack
   ```
2. **Create the database**:
   ```bash
    dotnet tool install --global dotnet-ef
    dotnet add package Microsoft.EntityFrameworkCore.Design
    dotnet ef migrations add CreateDb
    dotnet ef database update
   ```
   > If there is Migrations folder already exists, delete it.
3. **Start the Backend**: Navigate to the API layer directory.
   ```bash
   dotnet watch run
   ```
4. **Swagger UI**: Open on any web browser.
   ```bash
   http://localhost:<YOUR_LOCALHOST>/swagger/index.html
   ```
   ![Swagger UI page](/document/Img/swagger.png)

## Database Schema and ERD Design

Detailed database schema definitions including constraints, and relationships.

![Database schema](/document/Img/ERD.png)

## REST API Design

The table below outlines the organizational structure of our repository regarding the API design documents. Each entity within our REST API is associated with a specific folder path that contains the design files, blueprints, and detailed documentation. This structure ensures that all information related to a particular entity is centralized, allowing for easy navigation and maintenance by developers and collaborators.

| Entity         | File name                                             | Description                                    |
| -------------- | ----------------------------------------------------- | ---------------------------------------------- |
| Users          | [UsersAPI](/document/docs/UsersAPI.md)                | Contains endpoints for managing user data.     |
| Products       | [ProductsAPI](/document/docs/ProductsAPI.md)          | Contains endpoints for managing product data.  |
| Categories     | [CategoriesAPI](/document/docs/CategoriesAPI.md)      | Contains endpoints for managing category data. |
| Orders         | [OrdersAPI](/document/docs/OrdersAPI.md)              | Contains endpoints for managing order data.    |
| Authentication | [Authentication](/document/docs/AuthenticationAPI.md) | Contains endpoints for managing authencation.  |

## Backend Server with ASP.NET Core

### Clean Architecture

- **Ecommerce.Core**: This layer includes classes and interfaces that define the basic entities like products, categories, users, and more.
- **Ecommerce.Service**: This layer contains services that handle business logic and operations, interacting with the Core layer.
- **Ecommerce.Controller**: This layer is responsible for handling incoming HTTP requests and returning responses.
- **Ecommerce.WebAPI**: This houses the controllers and is the entry point for client interactions through HTTP requests.

## Unit Testing

Unit tests in this project are to ensure code quality and functionality.
![UnitTests](/document/Img/test.png)
