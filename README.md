# ManagementSystemWithMVC

## Overview

ManagementSystemWithMVC is a simple CRUD (Create, Read, Update, Delete) application that demonstrates both frontend and backend development using the MVC (Model-View-Controller) pattern. The project is designed to manage departments and employees, providing a user-friendly interface to perform basic management tasks.

## Features

- Department management: Add, view, update, and delete departments.
- Employee management: Add, view, update, and delete employees.
- Relationship between departments and employees (each employee is assigned to a department).
- Simple and intuitive navigation using a responsive layout.
- Error handling and validation for user input.

## Technologies Used

- **ASP.NET Core MVC**: Backend framework for controllers, models, services, and views.
- **Entity Framework Core**: Database ORM for SQL Server.
- **AutoMapper**: For object-to-object mapping between DTOs and entities.
- **Bootstrap**: For responsive and modern UI components.
- **jQuery & jQuery Validation**: For client-side interactivity and form validation.
- **SCSS**: For advanced styling and responsive design.
- **MSSQL Server**: As the primary database.

## Getting Started

1. **Clone the repository**
   ```bash
   git clone https://github.com/Aftabsattar/ManagementSystemWithMVC.git
   ```

2. **Set up the database connection**
   - Update the `DefaultConnection` string in `appsettings.json` to point to your SQL Server instance.

3. **Apply migrations**
   - Use the following command in the Package Manager Console:
     ```
     Update-Database
     ```

4. **Run the application**
   - Use Visual Studio or run:
     ```bash
     dotnet run
     ```

5. **Navigate**
   - Open your browser and go to `https://localhost:5001` (or the port specified in your project).

## Project Structure

- `Controllers/` - Handles user requests and responses.
- `Models/` - Database entities and DTOs.
- `Views/` - Razor pages for UI rendering.
- `Repository/` - Data access layer.
- `Database/` - DbContext and migrations.
- `wwwroot/` - Static files (CSS, JS, libraries).

## Screenshots

> Add screenshots here to showcase the UI (e.g., Department and Employee management pages).

## License

This project uses third-party libraries such as Bootstrap and jQuery, which are under the MIT License. See the respective `LICENSE` files in the `wwwroot/lib` directory for details.

---

**Author:** [Aftabsattar](https://github.com/Aftabsattar)
