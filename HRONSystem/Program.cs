using Microsoft.EntityFrameworkCore;
using HRONSystem.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<HRONDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); //OLD DATABASE - WORKING
builder.Services.AddDbContext<HRONNewDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HRONNewConnection"))); //NEW DATABASE - TESTING


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
