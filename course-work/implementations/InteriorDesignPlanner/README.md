# Interior Design Planner

## Student Information

Name: Byushra Halil

Faculty Number: 2401321069

---

## Project Description

Interior Design Planner is a full-stack ASP.NET Core application for managing interior design projects, rooms, and furniture items.

The system includes:

* ASP.NET Core Web API
* ASP.NET Core MVC Client
* Entity Framework Core
* SQL Server Database
* JWT Authentication
* CRUD Operations

---

# Features

## Authentication

* User Registration
* User Login
* JWT Token Authentication
* Protected API Endpoints

---

## Rooms Management

Users can:

* Create rooms
* Edit rooms
* Delete rooms
* View all rooms

Each room contains:

* Name
* Type
* Size
* Style
* Budget
* Created Date

---

## Design Projects Management

Users can:

* Create projects
* Edit projects
* Delete projects
* View all projects

Each project contains:

* Title
* Description
* Style
* Room Type
* Budget
* Created Date

---

## Furniture Items Management

Users can:

* Create furniture items
* Edit furniture items
* Delete furniture items
* View all furniture items

Each furniture item contains:

* Name
* Category
* Price
* Material
* Color
* Availability
* Created Date

---

# Technologies Used

* C#
* ASP.NET Core 8
* ASP.NET Core MVC
* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* JWT Authentication
* Bootstrap 5

---

# Architecture

The application uses a layered architecture:

* Controllers
* Services
* Repositories
* DTOs
* Models
* Database Layer

---

# Database

Database: SQL Server

Main tables:

* Rooms
* DesignProjects
* FurnitureItems
* Users

Relationships between the entities are implemented through Entity Framework Core.

---

# Security

* JWT Authentication
* Authorized API Endpoints
* Secure Password Handling

---

# Installation and Run

## Requirements

* Visual Studio 2022
* SQL Server
* .NET 8 SDK

## Steps

1. Open the solution:

InteriorDesignPlanner.API.sln

2. Configure the connection string in appsettings.json if necessary.

3. Apply database migrations:

Update-Database

4. Start the API project.

5. Start the MVC Client project.

## Default URLs

API:

https://localhost:7122

Client:

https://localhost:7290

---

# Future Improvements

* Admin Panel
* Role-based Authorization
* Image Upload
* Advanced Filtering
* Dashboard Statistics

---

# Author

Byushra Halil

Faculty Number: 2401321069
