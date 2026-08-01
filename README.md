# Employee Management API

Backend API untuk Employee Management System yang dibangun menggunakan **ASP.NET Core Web API (.NET 8)** dengan **Entity Framework Core** dan **SQL Server**.

Project ini menerapkan clean coding practice, separation of concerns, serta server-side data processing untuk mendukung fitur employee management.

---

# Tech Stack

## Backend

* ASP.NET Core Web API (.NET 8)
* Entity Framework Core 8
* SQL Server
* AutoMapper
* Swagger / OpenAPI
* Dependency Injection
* Repository Pattern
* Service Layer Pattern

## Database

* SQL Server
* Entity Framework Core Migration

---

# Features

## Employee Management

### Get Employee List

Endpoint untuk mengambil data employee dengan dukungan:

* Server-side pagination
* Searching
* Sorting
* Filtering

Data diproses langsung dari database menggunakan query EF Core sehingga hanya data pada halaman yang diminta yang dikirim ke client.

Example:

```
GET /api/employees?page=1&pageSize=10&search=lumi&sortBy=firstname&sortDirection=asc
```

---

### Get Employee Detail

Mengambil detail employee berdasarkan ID.

Response mencakup:

* Employee information
* Department
* Job Title

Example:

```
GET /api/employees/{id}
```

---

### Create Employee

Menambahkan employee baru.

Example:

```
POST /api/employees
```

Request:

```json
{
  "nik": "EMP001",
  "firstName": "John",
  "lastName": "Doe",
  "email": "john@example.com",
  "jobTitleId": 1
}
```

---

### Update Employee

Mengubah data employee existing.

Example:

```
PUT /api/employees/{id}
```

---

### Delete Employee

Menghapus employee berdasarkan ID.

Example:

```
DELETE /api/employees/{id}
```

---

# Project Architecture

Project menggunakan pendekatan layered architecture untuk memisahkan tanggung jawab setiap bagian aplikasi.

```
dotnet-backend-crud-base-model

│
├── Controllers
│   └── EmployeeController.cs
│
├── Services
│   ├── Interfaces
│   └── Implementations
│
├── Repositories
│   ├── Interfaces
│   └── Implementations
│
├── Data
│   ├── ApplicationDbContext.cs
│   ├── Configurations
│   └── Seed
│
├── Models
│   └── Entities
│
├── DTOs
│
├── Requests
│
├── Mappings
│
├── Common
│
└── Program.cs
```

---

# Architecture Flow

Request flow pada aplikasi:

```
Client
  |
  |
  v
Controller
  |
  |
  v
Service Layer
  |
  |
  v
Repository Layer
  |
  |
  v
Entity Framework Core
  |
  |
  v
SQL Server
```

---

# Layer Responsibility

## Controller

Bertanggung jawab untuk:

* Handling HTTP request
* Validation response status
* Returning API response

Controller tidak menangani business logic maupun database operation.

---

## Service Layer

Bertanggung jawab untuk:

* Business logic
* Mapping DTO
* Mengatur flow antara controller dan repository

Contoh:

```
EmployeeService
```

---

## Repository Layer

Bertanggung jawab untuk:

* Database operation
* Entity Framework Core query
* CRUD operation

Contoh:

```
EmployeeRepository
```

---

## Entity Layer

Representasi tabel database.

Contoh:

```
Employee
Department
JobTitle
```

---

## DTO Layer

DTO digunakan untuk memisahkan database entity dengan object yang diterima/dikirim melalui API.

Keuntungan:

* Menghindari expose langsung database model
* Request dan response lebih fleksibel
* Lebih aman untuk pengembangan kedepannya

---

# Database Relationship

Entity relationship:

```
Department
    |
    |
    | 1 : Many
    |
    v

JobTitle
    |
    |
    | 1 : Many
    |
    v

Employee
```

Employee memiliki satu JobTitle.

JobTitle memiliki satu Department.

---

# Entity Framework Core Migration

Database schema dibuat menggunakan EF Core Migration.

Create migration:

```bash
dotnet ef migrations add InitialCreate
```

Apply migration:

```bash
dotnet ef database update
```

---

# Database Seeder

Project memiliki database seeder untuk memasukkan initial data development.

Seeder akan berjalan ketika aplikasi dijalankan.

Command:

```bash
dotnet run
```

atau:

```bash
dotnet watch run
```

---

# Configuration

Connection string menggunakan environment-specific configuration.

Development:

```
appsettings.Development.json
```

Production:

```
appsettings.json
```

Sensitive information seperti connection string tidak disimpan dalam repository production.

---

# Running Project

## 1. Clone Repository

```bash
git clone <repository-url>
```

---

## 2. Restore Package

```bash
dotnet restore
```

---

## 3. Update Database

```bash
dotnet ef database update
```

---

## 4. Run Application

```bash
dotnet watch run
```


---

# Engineering Practices Applied

Project ini menerapkan beberapa best practices:

✅ Layered Architecture
✅ Dependency Injection
✅ Repository Pattern
✅ Service Layer
✅ DTO Pattern
✅ AutoMapper Mapping
✅ Async Programming
✅ EF Core Migration
✅ Server-side Pagination
✅ Search & Sorting Query
✅ Swagger Documentation

---

# Future Improvement

Beberapa improvement yang dapat dikembangkan:

* FluentValidation
* Global Exception Middleware
* Authentication & Authorization
* Unit Testing
* Docker Containerization
* CI/CD Pipeline

---

# Author

Lumi Novri

Fullstack Developer

.NET | React | SQL Server
