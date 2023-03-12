using System;
using System.IO;
using System.Reflection;

using Lab9.App.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Renting.Server.Controllers.Rents.Services;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RentingDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"));
});


builder.Services
    .AddControllers();

builder.Services
    .AddTransient<IRentsService, RentsService>();

builder.Services
    .AddSwaggerGen();

builder.Services
    .AddAutoMapper(typeof(Program).Assembly);


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();
app.UseHttpsRedirection();
app.MapControllers();


using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    var db = serviceProvider.GetRequiredService<RentingDbContext>();

    await db.Database.EnsureCreatedAsync();

    await RentingDbContextSeed.InitializeDb(db);
}

app.Run();
