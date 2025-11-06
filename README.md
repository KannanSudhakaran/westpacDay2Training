# Westpac Day 2 Training - AZ-2002 Workshop

This repository contains the training materials and projects from the Westpac Day 2 Azure training session for the AZ-2002 workshop.

## Projects Overview

### 1. Lab03ProductMinimalAPI
A minimal API project built with ASP.NET Core 8.0 that provides a RESTful API for managing products.

#### Features:
- **Minimal API** implementation using ASP.NET Core 8.0
- **In-Memory Database** using Entity Framework Core
- **Swagger/OpenAPI** documentation
- **CRUD Operations** for Product management
- **Product Model** with Id, Name, Price, and IsAvailable properties

#### API Endpoints:
- `GET /api/v1/products` - Get all products
- `GET /api/v1/products/{productId}` - Get a specific product
- `POST /api/v1/products` - Create a new product
- `PUT /api/v1/products/{productId}` - Update an existing product
- `DELETE /api/v1/products/{productId}` - Delete a product

#### Technology Stack:
- .NET 8.0
- ASP.NET Core Minimal APIs
- Entity Framework Core (In-Memory)
- Swagger/OpenAPI
- Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore

### 2. Lab04RazorPageProductConsumer
A Razor Pages web application that consumes the Product API and provides a web interface for product management.

#### Features:
- **Razor Pages** for server-side rendered web UI
- **HttpClient** integration for API consumption
- **Bootstrap** styling for responsive design
- **Product Management** UI with CRUD operations
- **Error Handling** with success/failure messaging

#### Pages:
- **Index** - Display all products in a table format
- **Add** - Form for creating new products
- **Edit** - Form for updating existing products
- **Delete** - Confirmation page for product deletion

#### Technology Stack:
- .NET 8.0
- ASP.NET Core Razor Pages
- HttpClient for API consumption
- Bootstrap for styling

## Project Structure

```
├── Lab03ProductMinimalAPI/
│   ├── Lab03ProductMinimalAPI.sln
│   └── Lab03ProductMinimalAPI/
│       ├── Program.cs
│       ├── Lab03ProductMinimalAPI.csproj
│       ├── Data/
│       │   └── ProductDbContext.cs
│       └── Model/
│           └── Product.cs
└── Lab04RazorPageProductConsumer/
    ├── Lab04RazorPageProductConsumer.sln
    └── Lab04RazorPageProductConsumer/
        ├── Program.cs
        ├── Lab04RazorPageProductConsumer.csproj
        ├── Model/
        │   └── Product.cs
        └── Pages/
            ├── Index.cshtml
            ├── Index.cshtml.cs
            ├── Add.cshtml
            ├── Edit.cshtml
            └── Delete.cshtml
```

## Getting Started

### Prerequisites
- .NET 8.0 SDK
- Visual Studio 2022 or Visual Studio Code
- Git

### Running the Projects

#### Lab03ProductMinimalAPI
1. Navigate to the `Lab03ProductMinimalAPI` directory
2. Restore dependencies: `dotnet restore`
3. Run the project: `dotnet run`
4. Access Swagger UI at: `https://localhost:7016/swagger`

#### Lab04RazorPageProductConsumer
1. Navigate to the `Lab04RazorPageProductConsumer` directory
2. Restore dependencies: `dotnet restore`
3. Run the project: `dotnet run`
4. Access the web application at: `https://localhost:5001`

## Configuration

The Razor Pages application is configured to consume the API from:
- **Remote API**: `https://apibackend-westpack-2025.azurewebsites.net/`
- **Local API**: `https://localhost:7016/` (when running locally)

## Training Context

This project was created as part of the AZ-2002 Azure training workshop, focusing on:
- ASP.NET Core Minimal APIs
- Razor Pages development
- API consumption patterns
- Entity Framework Core
- Modern .NET development practices

## Author
Created during Westpac AZ-2002 Workshop - Day 2 Training Session