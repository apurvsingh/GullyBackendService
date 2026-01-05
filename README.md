# Gully Backend API

This project is a simple **ASP.NET Core 9 Web API** that persists gully configurations created by the Angular frontend.

The application follows **Clean Architecture** principles and applies **Domain-Driven Design (DDD)** to keep domain logic isolated from infrastructure concerns.
This does not include tests or error handling
---

## Technology Stack

- ASP.NET Core 9
- Entity Framework Core
- SQL Server LocalDB
- Clean Architecture
- Domain-Driven Design (DDD)

---

## Architecture Overview

The solution is structured into clear layers:

- **Domain** – core business entities and rules
- **Application** – use cases and application services
- **Infrastructure** – EF Core, database access, persistence
- **API** – HTTP endpoints and request handling

This separation ensures maintainability, testability, and clear boundaries.

---

## API Endpoint

```
POST /api/v1/gullies
```

Persists a gully configuration sent from the frontend.

---

## Running the Application

1. Ensure SQL Server LocalDB is available
2. Update the connection string if required
3. Run the API

The service starts at:

```
https://localhost:7129
```

---

## Notes

- Database schema is managed via Entity Framework Core migrations
- CORS is enabled for local frontend development
- The API is intentionally minimal and focused
