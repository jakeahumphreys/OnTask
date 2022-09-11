# NTask
A [Blazor Server](https://docs.microsoft.com/en-us/aspnet/core/blazor/hosting-models?view=aspnetcore-6.0) task management application written in .Net Core. As Blazor is the spiritual successor to ASP.Net I wanted to start transferring my knowledge into the framework. Blazor is currently actively developed with plans to make it compatible with MAUI.

One of the big things about Blazor that I enjoy, is the ability to write the UI in CSS/HTML or use a third party library.

## Technologies / Packages
- Entity Framework (Using SQLite).
- NUnit / Moq, for testing.
- [MudBlazor](https://mudblazor.com) for a clean, modern UI.
- MS Dependency Injection (Built into Blazor).

## Design Patterns
- Builder Pattern (used to construct objects for testing).
- Repository Pattern (Baked into EF and copied for my file structure).

## Current Features
- Manage Projects - Projects are a collection of tasks.

## Planned or Potential Features

>❗There's no guarantee that these are implemented

- File Upload Support.
- User Management / Authentication.
- Data Exporting.
- NTask API - Separate the frontend and backend.
- Project / Task Notes.