using AccessLogic.Repositories;
using AppLogic.UCInterfaces;
using Domain.RepositoryInterfaces;
using LogicaAplicacion.CasosUso;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddScoped<IRepositoryGenericUsers, GenericUsersRepository>();

builder.Services.AddScoped<IAddUser, AddUserUC>();


// DB config
ConfigurationBuilder configurationBuilder = new();
configurationBuilder.AddJsonFile("appsettings.json", false, true);
var config = configurationBuilder.Build();
string connectionString = config.GetConnectionString("Connection1");
builder.Services.AddDbContextPool<EcosystemContext>(Options => Options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
