using Microsoft.EntityFrameworkCore;
using UnifiedUISystem.Data;
using HRONSystem.Data;
using SDLoenSystem.Data;
using SofdCoreSystem.Data;

var builder = WebApplication.CreateBuilder(args);

// Adds DbContexts for each database
builder.Services.AddDbContext<HRONSystem.Data.HRONNewDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HRONConnection")));
builder.Services.AddDbContext<UnifiedUISystem.Data.HRONNewDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HRONConnection")));
builder.Services.AddDbContext<SDLoenSystem.Data.SDLOENDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SDLOENConnection")));
builder.Services.AddDbContext<UnifiedUISystem.Data.SDLOENDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SDLOENConnection")));
builder.Services.AddDbContext<SofdCoreSystem.Data.SofdCoreDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SofdCoreConnection")));
builder.Services.AddDbContext<UnifiedUISystem.Data.SofdCoreDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SofdCoreConnection")));

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
