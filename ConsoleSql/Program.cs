
using ConsoleSql.Entities;
using ConsoleSql.Repositories;
using ConsoleSql.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var connectionString = @"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Projects\\ConsoleSql\\ConsoleSql\\Data\\local_databas.mdf;Integrated Security=True;Connect Timeout=30";

var app = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddSingleton(new AddressRepository(connectionString));
    services.AddSingleton(new CustomerRepository(connectionString));
    services.AddSingleton<CustomerService>();
    services.AddSingleton<MenuService>();
}).Build();


app.Start();
Console.Clear();

var menuService = app.Services.GetRequiredService<MenuService>();

menuService.CreateNewCustomerMenu();