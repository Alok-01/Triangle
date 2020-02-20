The Three main application one is web Client (UI), Identity Webserver & API Backend.


Project: A Sample Domain i.e. Student Registration Form with Authorization & Authenticate

The Technology:

Visual Studio 2019 Version 16.4.4
Identity Server 4 => Sql Server DB Level
.Net Core 3.1 MVC
.Net Core 3.1 WebApi

How To Run?
1) Create DB 
    a) TriangleIdentityServer
       Open the TriangleIdentityServerDb_Table_ScriptWithData and and Excute the Script in Student Database
    b) Student
       Open the StudentDB_Table_SP_ScriptWithData.sql and Excute the Script in Student Database


2) Run by Mutiple Startup project
    a) Triangle.IdentityWebServer
    b) Triangle.ApiStudent
    c) Triangle.MvcClient


Design:
1) SOLID Principal
2) Onion Architecture
3) Domain Based Design
4) Micro services Architecture [A thin layer of MSA applied]
5) CQRS Implementation in Triangle.ApiStudent.StudentMediatRController.cs
6) XUnit Project

Current Application
1) Code Complexity at moment 85%
2) Clean Code
3) SOLID Implementation 

Other: 
1) Inital Note
2) DB Create Srcript
3) Query Idnetity tables for refernce

Future Chnages:
A) Complete  Microservices Archiecture Implementation
B) The UI approvemnt  

=================================================================================================================
Note: 
UI is not good at the moment.
=================================================================================================================
Other usefull Command 
dotnet ef migrations add InitialAppDbContextDbMigration -c AppDbContext -o Data/Migrations/AppDbContextDb
dotnet ef migrations add InitialIdentityServerPersistedGrantDbMigration -c PersistedGrantDbContext -o Data/Migrations/IdentityServer/PersistedGrantDb
dotnet ef migrations add InitialIdentityServerConfigurationDbMigration -c ConfigurationDbContext -o Data/Migrations/IdentityServer/ConfigurationDb

