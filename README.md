# FormLab

![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)

## Introduction

FormLab is an application for generating a dynamic web form.  Admin users should be able to add, update, and delete fields from this form as well as review any client submitted data.  Normal users should be able to see the form, fill it in, and submit their form/data.

## Problem Statement

Create a back-end RESTful API using C# and ASP.NET.  Admin users can add/read/edit/delete new form field definitions.  Admin users can also read submitted forms and data.  Normal users can fill out the form and submit it.

Create a front-end UI with React with the follow pages:

1. For admin to manage the field definitions for the forms.
2. For admin to review all form submissions.
3. For user to view and submit the form.

[Instructions.md](docs/Instructions.md)

_Note: also demonstrate the proper use of C# coding standards and clean architecture.

## API Documentation

Click on the link below to view the Swagger UI and interact with the REST API:

[Swagger UI](https://formlabapi.azurewebsites.net/swagger/index.html)

[FormDefinition endpoint](https://formlabapi.azurewebsites.net/api/v1/formdefinitions)

[FormSubmssion endpoint](https://formlabapi.azurewebsites.net/api/v1/formsubmissions)

## Components

The solution is comprised of 8 main projects and 5 test projects:
1. FormLab API is a REST API that allows for client applications to interact with the FormLab system.  Provides data access and back-end processing.
2. FormLab Application contains business logic and implementation of services used by the system.
3. FormLab Domain is where the models are (POCOs).
4. FormLab Infrastructure contains the data access layer (DAL) code (using the Repository Pattern).
5. FormLab Infrastructure.Migrations contains database schema migration code (EF Core).
6. FormLab Infrastructure.Shared contains shareable abstract base classes for the DAL code (could be moved into NuGet package).
7. FormLab Shared contains shareable code, interfaces and base classes for other projects (could be moved into NuGet package).
8. FormLab Web.Blazor contains a Blazor Web Assembly (WASM) front-end UI web client.
9. FormLab Application Tests is a set of unit tests for the Application project.
10. FormLab Domain Tests is a set of unit tests for the Domain project.
11. FormLab Infrastructure Tests is a set of unit tests for the Infrastructure project.
12. FormLab Infrastructure.Shared Tests is a set of unit tests for the Infrastructure.Shared project.
13. FormLab Shared Tests is a set of unit tests for the Shared project.

## Project Structure

```
src\

    LiteBulb.FormLab.Api (RESTful API for CRUD operations)
    LiteBulb.FormLab.Application (Business logic and services)
    LiteBulb.FormLab.Domain (Models)
    LiteBulb.FormLab.Infrastructure (Database repository code implementation)
    LiteBulb.FormLab.Infrastructure.Migrations (Entity Framework Migrations)
    LiteBulb.FormLab.Infrastructure.Shared (Database repository code base classes)
    LiteBulb.FormLab.Shared (Interfaces and base classes)
    LiteBulb.FormLab.Web.Blazor (Front-end client application in Blazor WASM)

test\

    LiteBulb.FormLab.Application.Tests (Unit and integration tests)
    LiteBulb.FormLab.Domain.Tests (Unit and integration tests)
    LiteBulb.FormLab.Infrastructure.Tests (Unit and integration tests)
    LiteBulb.FormLab.Infrastructure.Shared.Tests (Unit and integration tests)
    LiteBulb.FormLab.Shared.Tests (Unit and integration tests)
```

_Note: See below for links to code repositories._

## Tech Stack

1. .NET 7.0 (for Web API, Blazor WebAssembly and libraries)
2. Entity Framework Core 7.0 (for ORM)
3. Azure SQL - MySQL 8.0 (for database)
4. Swagger (API documentation)
5. Serilog (logging)
6. Azure App Service (for cloud hosting)
7. MSTest2 (for unit & integration testing)

_Note: no .NET Standard 2.1 or .NET Standard 2.0._

## GitHub

- [Algorithms Repository](https://github.com/MrJohnB/FormLab)

## Documentation

- [Docs folder](docs)

## Build and Test

- Build the solution in Visual Studio 2022 and run.
- TODO: Describe and show how to build your code and run the tests.

## References

If you want to learn more about creating good readme files then refer the following [guidelines](https://docs.microsoft.com/en-us/azure/devops/repos/git/create-a-readme?view=azure-devops). You can also seek inspiration from the below readme files:
- [ASP.NET Core](https://github.com/aspnet/Home)
- [Visual Studio Code](https://github.com/Microsoft/vscode)
- [Chakra Core](https://github.com/Microsoft/ChakraCore)