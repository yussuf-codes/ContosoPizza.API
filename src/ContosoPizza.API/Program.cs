using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using ContosoPizza.API.Data;
using ContosoPizza.API.Models;
using ContosoPizza.API.Extensions;
using ContosoPizza.API.Services;
using ContosoPizza.API.Services.IServices;

namespace ContosoPizza.API;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.AddScoped<IGenericService<Pizza>, PizzaService>();
        builder.Services.AddScoped<IGenericService<Sauce>, GenericService<Sauce>>();
        builder.Services.AddScoped<IGenericService<Topping>, GenericService<Topping>>();

        string? connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
        builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));

        WebApplication app = builder.Build();

        if (app.Environment.IsProduction())
            app.UseHttpsRedirection();

        if (app.Environment.IsDevelopment())
            app.CreateDummyDatabase();

        app.MapControllers();

        app.Run();
    }
}
