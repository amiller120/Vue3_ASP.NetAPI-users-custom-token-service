global using FastEndpoints;
using FastEndpoints.Security;
using fastEndpointTemplate.Data.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddFastEndpoints()
                .AddCookieAuth(validFor: TimeSpan.FromMinutes(20))
                .AddJWTBearerAuth(builder.Configuration["JWTSigningKey"] ?? "")
                .AddAuthorization();

builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DataContext")));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseFastEndpoints();

app.MapFallbackToFile("index.html");

app.Run();
