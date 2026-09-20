# DoConnect

> A question-and-answer web application built as an HCLTech training capstone project.

## Overview

DoConnect is an ASP.NET MVC application where users can work with questions and answers. It includes separate user and administrator flows, question search, and management screens for core application data.

This project was created during my HCLTech training and represents my hands-on learning with the MVC pattern, C#, SQL Server, and server-rendered web applications.

## Technology Stack

- ASP.NET MVC on .NET Framework 4.7.2
- C#
- Entity Framework
- SQL Server
- HTML, CSS, and JavaScript
- Visual Studio

## Key Features

- User and administrator login flows
- Question display and search
- Question management screens
- Answer display and management screens
- User management screens for administrators
- API request testing documented with Fiddler screenshots

## Project Structure

```text
DoConnect/
├── Controllers/       # Request handling and application flow
├── Models/            # Application and database models
├── Views/             # Server-rendered user interface
├── Content/           # Stylesheets and static content
├── Scripts/           # Client-side scripts
├── App_Start/         # Application configuration
└── DoConnect.csproj   # Project file
```

The repository also includes:

- `DoConnect.sln` — Visual Studio solution
- `Do connect mini project 2.sql` — SQL Server database script
- `Do connect Project ScreenShots/` — Application and API-testing screenshots

## Running the Project

1. Clone the repository.
2. Open `DoConnect.sln` in Visual Studio.
3. Run the included SQL script in SQL Server.
4. Review and update the database connection string in `Web.config` for your local SQL Server instance.
5. Build and run the application from Visual Studio.

> This training project may require environment-specific configuration updates before it runs locally.

## Screenshots

<p align="center">
  <img src="./Do%20connect%20Project%20ScreenShots/HOME%20Page%28Screen%29.png" alt="DoConnect home page" width="48%" />
  <img src="./Do%20connect%20Project%20ScreenShots/Questions%20display%20and%20search.png" alt="Question display and search" width="48%" />
</p>

<p align="center">
  <img src="./Do%20connect%20Project%20ScreenShots/ADMIN%20Login.png" alt="Administrator login" width="48%" />
  <img src="./Do%20connect%20Project%20ScreenShots/ADMIN%20CRUD%20BUTTON%20PAGE.png" alt="Administrator management page" width="48%" />
</p>

## What I Learned

- Applying MVC architecture in a .NET web application
- Organizing controllers, models, and views
- Building database-backed application features with C# and SQL Server
- Creating user and administrative workflows
- Testing web API requests
- Managing source code with Git and GitHub

## Future Direction

I am continuing to build toward modern full-stack development with ASP.NET Core, React, Azure, and AI-powered application features.
