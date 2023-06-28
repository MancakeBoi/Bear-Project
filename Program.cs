using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using bear_project_server.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContextFactory<BearDemoContext>();

builder.Configuration.AddJsonFile(@"C:\Secrets\AppSecrets.json");

var app = builder.Build();


//await using var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateAsyncScope();
//var options = scope.ServiceProvider.GetRequiredService<DbContextOptions<BearDemoContext>>();

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

app.Run();
