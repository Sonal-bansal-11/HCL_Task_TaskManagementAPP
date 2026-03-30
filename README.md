# 🚀 Task Management System (Full-Stack)

A robust, full-stack Task Management Web Application built to demonstrate end-to-end development capabilities. This project was developed as a comprehensive showcase of clean architecture, API design, and modern frontend integration.

It features a centralized **.NET Web API** acting as the single source of truth, serving two distinct frontends: a modern Single Page Application (SPA) using **Angular**, and a Server-Side Rendered (SSR) application using **.NET MVC**.

## 🌟 Features

* **Complete CRUD Operations:** Users can Create, Read, Update, and Delete tasks seamlessly.
* **Dual Frontend Architecture:** Proves backend flexibility by consuming the same RESTful API through both Angular (Client-side) and MVC (Server-side).
* **Clean Layered Architecture:** Implements the strict `Controller -> Service -> Repository` pattern for high maintainability and testability.
* **Zero-Setup Database:** Utilizes Entity Framework Core with an In-Memory Database, making it instantly runnable for evaluators without SQL Server setup.
* **Responsive UI:** Styled with Bootstrap 5 for a clean, intuitive user experience.
* **Automated Data Seeding:** Pre-populates default tasks on startup for immediate demonstration.

## 🛠️ Tech Stack

* **Backend Engine:** C# .NET Web API 
* **Frontend 1 (SPA):** Angular 21, HTML/CSS, TypeScript
* **Frontend 2 (SSR):** .NET MVC (Razor Views)
* **Database & ORM:** Entity Framework Core (In-Memory)
* **API Documentation:** Swagger UI / OpenAPI
* **Styling:** Bootstrap 5

## ⚙️ How to Run the Project Locally

To run this project on your local machine, you will need the .NET SDK and Node.js installed. 
*Note: Both the API and the chosen Frontend need to be running simultaneously.*

### 1. Start the Web API (Backend)
Navigate to the API directory and run the application:
```bash
cd TaskManagement.Api
dotnet run

The API will start (usually on http://localhost:5048). You can append /swagger to the URL to view the interactive API documentation.

2. Start the Angular App (Frontend 1)
Open a new terminal, navigate to the UI directory, and run the Angular server:
cd TaskManagementUi
ng serve -o

The app will automatically open in your default browser at http://localhost:4200.

3. Start the MVC App (Frontend 2 - Optional)
To view the server-side rendered version, open a third terminal:
cd TaskManagement.Mvc
dotnet run

👤 Author
Sonal Bansal
