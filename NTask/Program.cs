using ElectronNET.API;
using ElectronNET.API.Entities;
using MudBlazor.Services;
using NTask.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();
builder.Services.AddSingleton<IProjectRepository, ProjectRepository>();
builder.Services.AddElectron();

builder.WebHost.UseElectron(args); //Add Electron

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

Task.Run(async () =>
{
    var window = await Electron.WindowManager.CreateWindowAsync(
        new BrowserWindowOptions
        {
            AutoHideMenuBar = true,
            Show = false,
            WebPreferences = new WebPreferences
            {
                WebSecurity = false
            }
        });

    await window.WebContents.Session.ClearCacheAsync();

    window.OnReadyToShow += () => window.Show();

    window.OnClose += () => Environment.Exit(0);
});

app.Run();