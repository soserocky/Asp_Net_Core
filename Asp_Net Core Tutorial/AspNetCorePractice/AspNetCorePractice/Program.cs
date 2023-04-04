using AspNetCorePractice.Data.DBContext;
using AspNetCorePractice.Models.Entities.IdentityEntities;
using AspNetCorePractice.Services.Contracts;
using AspNetCorePractice.Services.Implementations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AspNetCorePracticeDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddTransient<IGenderService, GenderService>();
builder.Services.AddTransient<ICountryService, CountryService>();
builder.Services.AddTransient<IPersonsService, PersonService>();
builder.Services.AddTransient<IBookingService, BookingService>();

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<AspNetCorePracticeDbContext>()
                .AddDefaultTokenProviders()
                .AddUserStore<UserStore<ApplicationUser, ApplicationRole, AspNetCorePracticeDbContext, Guid>>()
                .AddRoleStore<RoleStore<ApplicationRole, AspNetCorePracticeDbContext, Guid>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
