# Planilla_UCR
## Project Overview
The goal of this application is to allow employers to handle payroll easily, efficiently, and safely. In addition to providing a practical solution for bill payment, the project showcases the application of clean code design principles and a clean architecture based on Domain-Driven Design (DDD) to generate maintainable code, along with unit tests, integration tests, and system-Selenium tests.

<img src="Images/cleanArchitecture.png" alt="depImg" height="300">


<a href="https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures#clean-architecture">Clean architecture Explanation</a>

## Monolithic Blazor Server
In monolithic applications, the Application Core, Infrastructure, and UI projects operate as a unified application. This architecture consolidates all components into a single runtime environment, ensuring cohesive operation and streamlined management.

## Key Features
- **Entity Framework**: Entity Framework is used along with .NetCore 5 for object-relational mapping, simplifying interactions with the database and enabling rapid development of data-driven applications.
- **SQL Server Database**: SQL Server is employed as the primary database management system, providing robust data storage capabilities for transactional data related to bill payments.

<table>
  <tr>
    <td><img src="Images/payment.png" alt="depImg" height="300"></td>
    <td><div style="text-align: center;"><img src="Images/SQLDB.png" alt="depImg" height="300"></div></td>
  </tr>
</table>

- **Firebase Document Database**: Firebase is utilized as a document database for storing supplementary data, offering scalability and flexibility for non-relational data storage needs like a payments or worked hours history.
<table>
  <tr>
   <td>
    <img src="Images/chartEmployer.png" alt="depImg" height="300">
    <img src="Images/firebaseDB.png" alt="depImg"  height="300">
    </td>
  </tr>
 
</table>

- **ASP .NET Identity**: Utilized for user and role management, facilitating secure authentication and authorization processes within the application.
<img src="Images/authDB.png" alt="depImg" height="300">
<img src="Images/IdentityDB.png" alt="depImg" >

- **Scrum Iterations**: The project follows Agile methodologies, with detailed documentation of Scrum iterations, ensuring clear communication and progress tracking throughout the development lifecycle.
<a href="https://github.com/LeonelCamposM/PlanillaUCR/tree/main/Scrum">Agile metogology documentation</a>

- **Unit-Integration Testing**: Comprehensive unit, integration, system tests are implemented to validate the functionality.
<table>
  <tr>
    <div style="text-align: center;">
    <td><img src="Images/testing.png" alt="depImg" height="300"></td>
    <td><div style="text-align: center;"><img src="Images/selenium.png" alt="depImg" height="100"></div></td>
    
  </tr>
</table>

## Execution instructions
1) Clone the repository locally, using Visual Studio

2) Make sure you have .net 5.0 installed and ASP.net web development
![depImg](Images/dependencies.png)

3) Right click on the Server_Planilla project and select it as the start project
![startImg](Images/startProject.png)

4) With the web server as the default project. and the selected infrastructure layer.
From the Package manager console run:
Update-Database -Context AccountsDbContext
![AuthImg](Images/auth.png)

5) Run Planilla data base using vs options
![databaseImg](Images/databaseImg.png)

6) Click on the button to run using ISSExpress
![rundImg](Images/run.png)


# Colaborators
● Leonel Campos Murillo. B91545.  
● Nayeri Azofeifa Porras. B90841.  
● Wendy Ortiz Alfaro. B75584.  
● Ronald Mauricio Palma Villegas. B95811.  
● Jeremy Vargas Artavia. B98157.  
