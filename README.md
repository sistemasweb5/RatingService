# Rating Service

This is a microservice dedicated to reviews and ratings between a user and worker given a job performed and also to inform who to work for in the future.

# Mac and Cheese Team

- Samuel Escalera
- José Luis Terán

## Architecture & Tech Stack

This project uses a Clean Architecture approach, organized with CQRS (Command Query Responsibility Segregation) to clearly separate read and write operations given the reviews per each user and worker.

- C# with .NET Core
- Entity Framework (EF)
- MediatR
- PostgreSQL
- Code Quality: `Husky.Net` for Git hooks, `dotnet-format` for consistent formatting, and `csharpier` for code linting and styling
