# Storage

**Storage** is a backend system for managing batches of products in a warehouse. Unlike individual product tracking, this system focuses on batch-based inventory, where each batch shares common production and expiration dates.

## Tech Stack

- **ASP.NET Core Web API** – for creating the backend
- **Entity Framework Core** – ORM
- **MySQL** – as the database
- **Swagger UI** – for testing and exploring API endpoints
- **FluentValidation** – for validating incoming models
- **BackgroundService** – for generating daily reports

## Features

- Create, update, and delete product batches
- Automatically calculate the state of a product based on expiration: `Fresh`, `SoonSpoiled`, or `Spoiled`
- Handle discounts and calculate final prices
- Query product batches by their state
- Automatically generate daily reports on soon-to-expire and expired batches

## Getting Started

1. Clone the repository
2. Configure your MySQL connection string in `appsettings.json`
3. Run EF Core migrations:

    ```bash
    dotnet ef database update --startup-project Storage.Api
    ```

4. Launch the app and test the API via Swagger at:

    ```
    https://localhost:{port}/swagger
    ```

5. To run the database using Docker:

    ```bash
    docker compose -f docker-compose-database.yml up -d
    ```