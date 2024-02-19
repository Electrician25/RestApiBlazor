using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using RESTapi.Data;
using RESTapi.Users;
using RestApiBlazor.JwtTokenServices;
using RestApiBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddMvc();
builder.Services.AddJwtToken();
builder.AddApplicationContext();
builder.Services.AddServerSideBlazor();

var mongoClient = new MongoClient("mongodb://localhost:27017");
var dbContextOptions =
    new DbContextOptionsBuilder<ApplicationContext>().UseMongoDB(mongoClient, "users");
var db = new ApplicationContext(dbContextOptions.Options);

db.Users.Add(new User() { Id = 2, Email = "John@mail.ru", Password = "123" });
db.SaveChanges();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();