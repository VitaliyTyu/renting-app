using System;
using System.IO;
using System.Reflection;

using Renting.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Renting.Pages;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Renting.DAL.Entities;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RentingDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"));
});


builder.Services
    .AddRazorPages();

builder.Services
    .AddTransient<IRentsService, RentsService>();



builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.Cookie.HttpOnly = true;
            options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
            options.LoginPath = "/Account/Login";
            options.AccessDeniedPath = "/Account/AccessDenied";
            options.SlidingExpiration = true;
        });



builder.Services.AddIdentity<Account, IdentityRole>(options =>
{
    // настройки
})
    .AddEntityFrameworkStores<RentingDbContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapRazorPages();
//});

app.MapRazorPages();
app.UseHttpsRedirection();



using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    var db = serviceProvider.GetRequiredService<RentingDbContext>();

    await db.Database.EnsureDeletedAsync();
    await db.Database.EnsureCreatedAsync();

    await RentingDbContextSeed.InitializeDb(db);
}

app.Run();
