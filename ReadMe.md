BookStore Platform
==================

Environments
------------

### Local Development

| Component | Details |
| --------- | ------- |
| Web URL   | http://localhost:4200/ |
| API URL   | https://localhost:49155/ |
| Docker LocalHost URL | host.docker.internal |
| DB Server | ::1,31434 |
| Database  | Bookstore, user: sa / BookstorePass123 |

### First Time Run

#### Database:

- Run `docker compose up -d`

- This will configure the SQL database, set its name, and configure the SA with the details found in docker.

#### Migrations:

- Open a terminal
- Navigate to the root project directory
- Run the following command
	-  `dotnet ef database update --project bookstore-data --startup-project bookstore-api`
- To add a migration follow this command pattern
	- `dotnet ef migrations add MigrationName --project bookstore-data --startup-project bookstore-api`
