<div align="center">
<img src="https://i.imgur.com/h7KHBm4.png" alt="An image of OnTask" alt="Markdown Monster icon" style="margin-right: 10px; border-style: solid; margin-bottom: 20px;" width="600" height="350"/>
</div>


# OnTask
A [Blazor Server](https://docs.microsoft.com/en-us/aspnet/core/blazor/hosting-models?view=aspnetcore-6.0) task management application written in .Net Core. As Blazor is the spiritual successor to ASP.Net I wanted to start transferring my knowledge into the framework. Blazor is currently actively developed with plans to make it compatible with MAUI.

One of the big things about Blazor that I enjoy, is the ability to write the UI in CSS/HTML or use a third party library.

## Stats
![Alt](https://repobeats.axiom.co/api/embed/b098a65599c756408fdd9e47e281401b635b837c.svg "Repobeats analytics image")

## Technologies / Packages
- Entity Framework (Using SQLite).
- NUnit / Moq, for testing.
- [MudBlazor](https://mudblazor.com) for a clean, modern UI.
- MS Dependency Injection (Built into Blazor).
- [ElectronNET](https://github.com/ElectronNET/Electron.NET) - An Electron Wrapper for .NET

## Electron
As referenced above, this application utilises the ElectronNET package. This allows blazor to be run as a desktop application inside an electron shell. This is a great option whilst waiting for Blazor Hybrid to become mainstream.

### Running Electron
If you download this repository, to run the application within electron you'll need the ElectronNET.CLI tool:

```dotnet tool install ElectronNET.CLI -g```

Then run the application with:
```electronize start```

~~Or for a hot-reload type experience: ```electronize start /watch```~~
(Doesn't work with MudBlazor)


The application can be built as an electron .exe with:

```
electronize build /target win
electronize build /target osx
electronize build /target osx-arm64
electronize build /target linux
```

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
