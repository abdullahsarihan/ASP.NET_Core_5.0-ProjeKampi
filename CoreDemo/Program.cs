using Autofac;
using Autofac.Extensions.DependencyInjection;
using BusinessLayer.AutoMapper.Profiles;
using BusinessLayer.DependencyResolvers;
using BusinessLayer.Errors;
using CoreDemo.AutoMapper.Profiles;
using CoreDemo.Models;
using CoreLayer.DependancyResolvers;
using CoreLayer.Utilities.IoC;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Globalization;
using Core.Extensions;
using DataAccessLayer.DependancyInjection;
using BusinessLayer.Extension;
using CoreDemo;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<Worker>();

builder.Services.AddRazorPages();

Host.CreateDefaultBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(
    builder =>
    {
        builder.RegisterModule(new AutofacBusinessModule());
        builder.RegisterModule(new AutofacValidationModule());
    });

var config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false)
        .Build();

builder.Services.AddDbContext<Context>(options =>
            options.UseSqlServer(config.GetConnectionString("SQLServer")), ServiceLifetime.Scoped);

CultureInfo[] supportedCultures = new[] { new CultureInfo("tr"), };

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture("tr");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
    options.RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider()
                };
});

builder.Services.AddIdentity<AppUser, AppRole>(x =>
{
    x.User.RequireUniqueEmail = true;
    x.Password.RequireUppercase = true;
    x.Password.RequireNonAlphanumeric = true;
    x.Password.RequireDigit = true;
    x.Password.RequireLowercase = true;
    x.Password.RequireNonAlphanumeric = true;
    x.SignIn.RequireConfirmedEmail = true;
}).AddEntityFrameworkStores<Context>()
            .AddErrorDescriber<LocalizedIdentityErrorDescriber>()
            .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(30);
    options.Cookie.IsEssential = true;
});

builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));

}).AddRazorRuntimeCompilation();

builder.Services.Configure<DataProtectionTokenProviderOptions>(opt =>
opt.TokenLifespan = TimeSpan.FromMinutes(30)
);

builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(x =>
    {
        x.LoginPath = "/Login/Index";
    }
);

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(30);
    options.LoginPath = "/Login/Index";
    options.LogoutPath = "/Login/Logout";
    options.AccessDeniedPath = new PathString("/Login/AccessDenied");
    options.SlidingExpiration = true;
});

builder.Services.AddSingleton(new WriterCity());
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

builder.Services.AddAutoMapper(typeof(BusinessImages));
builder.Services.AddAutoMapper(typeof(UIImage));
builder.Services.AddAutoMapper(typeof(DBOImages));

builder.Services.IocDataAccessInstall();

builder.Services.IocBusinessInstall();

builder.Services.AddDependencyResolvers(new ICoreModule[] {
               new CoreModule()
            });

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts();
    app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");
    app.ConfigureCustomExceptionMiddleware();   
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.UseUserDestroyer();

app.MapRazorPages();

app.MapControllerRoute(
    name: "Admin",
    pattern: "/admin/{controller=Home}/{action=Index}/{id?}",
    defaults: new { area = "Admin" },
    constraints: new { area = "Admin" }
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Blog}/{action=Index}/{id?}"
);

app.Run();