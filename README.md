# Simple Employee Management Application

*Technical Test Submission – Jullie Bert Cogueron*

---

## Table of Contents
1. [Project Overview](#project-overview)  
2. [Prerequisites](#prerequisites)
3. [Technology Used](#technologies-used)
4. [Frameworks](#frameworks)
5. [Run & Setup](#installation--setup) 
6. [How to use] (#how-to-use) 

---

## Project Overview
This project is a **Simple WinForms Employee Management Application** developed in **C# (.NET 8 / EF Core)** as part of a technical test.  
It implements CRUD operations for employees, input validation, and uses Dependency Injection for service management.

---

## Prerequisites
Before running the application, ensure you have:

- Visual Studio 2022 installed  
- .NET 8 Runtime installed  
- SQL Server (LocalDB or full version) (I used SSMS 2019)

---

## Technologies Used
- Visual Studio 2022
- SSMS
- Github

---

## Frameworks
- .Net Framework WINFORMS
- EF Core (Entity Framework)


---

## Installation & Setup
1. Clone the repository:

```bash
git clone [https://github.com/yourusername/EmployeeManagementApp.git](https://github.com/Zallien/TechnicalTest.git)
```
2. Open the 2 Solution in Visual Studio 2022:
   
```bash
API Folder : MyAPI.sln - ASP.Net Core Web API
FrontEnd Folder : EmployeeListApplication.sln - Winforms Application
```
3.Before Running the API Database must be already Installed or Created in SSMS. Download the Database and install it inside you SSMS
```bash
TechnicalTestDb - Backup File
TechnicalTestDbDatatier.bacpac - Data Tier Application
```
4. After Opening MyAPI.sln, change the connectionstring of it
```bash
appsettings.json
This part :
  "ConnectionString": {
    "DefaultConnection": "Server=YOURSERNAME; Database=TechnicalDatabase; Trusted_Connection=True; TrustServerCertificate=True;"
  },

MyAPIDbContext.cs
This part :
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlServer("Server=YOURSERVERNAME; Database=TechnicalDatabase; Trusted_Connection=True; TrustServerCertificate=True;");
  }
```
5. After API Configuration next is the Frontend. On this part

```bash
program.cs :
  //Change this based on the Localhost or URL of API
  BaseURL = "http://localhost:5129";
```
 Change the BaseURL Based on the url of your API 
```bash
MyAPI.http :
  @MyAPI_HostAddress = http://localhost:5129
```

6. After that you can now Run the API First then Run the Frontend or the Winform Application;

## How to use
**Add Employee** - Clicking the Button
**Delete Employee** - Select Employee/s and Right Click
**Update Employee** - Double click Employee then Update its Credentials