# Employee CRUD with .NET Framework

## 📌 Project Overview
This project is a **.NET Framework**-based **Employee Management System** that provides full **CRUD (Create, Read, Update, Delete)** functionality. It allows users to manage employee records efficiently, offering a well-structured and scalable architecture.

## 🚀 Features
- **Employee Management**: Add, view, update, and delete employee records.
- **SQL Server Integration**: Uses Microsoft SQL Server for database management.
- **.NET Framework Backend**: Built with robust backend logic.
- **RESTful APIs**: Follows best practices for API development.
- **Docker Support**: Can be containerized for scalable deployment.
- **Logging & Error Handling**: Implements structured logging and exception handling.

## 🛠️ Tech Stack
- **Backend**: .NET Framework (C#)
- **Database**: SQL Server (via `Microsoft.Data.SqlClient`)
- **ORM**: Entity Framework / ADO.NET (if applicable)
- **Containerization**: Docker (for SQL Server setup)

## ⚙️ Installation & Setup
### Prerequisites
- .NET Framework Installed
- SQL Server Installed (or run via Docker)
- Visual Studio (Recommended)

### Clone Repository
```sh
git clone https://github.com/devprince116/Employee-crud-dotnet.git
cd Employee-crud-dotnet
```

### Setup SQL Server (Docker Option)
```sh
docker-compose up -d
```

### Configure Database Connection
Modify `appsettings.json` to update the database connection string:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=EmployeeDB;User Id=sa;Password=YourPassword;"
}
```

### Run the Application
- Open the project in **Visual Studio**
- Restore NuGet Packages
- Build and Run the project

## 📡 API Endpoints
| Method | Endpoint | Description |
|--------|---------|-------------|
| GET | `/api/employees` | Fetch all employees |
| GET | `/api/employees/{id}` | Get a specific employee by ID |
| POST | `/api/employees` | Create a new employee |
| PUT | `/api/employees/{id}` | Update an existing employee |
| DELETE | `/api/employees/{id}` | Delete an employee |

