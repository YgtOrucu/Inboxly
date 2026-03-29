using FluentValidation;
using FluentValidation.AspNetCore;
using Inboxly.Context;
using Inboxly.Entities;
using Inboxly.Models;
using Inboxly.Validator.ValidateMarker;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<InboxlyContext>();
builder.Services.AddAutoMapper(opt => opt.AddMaps(typeof(Program)));
builder.Services.AddIdentity<AppUser, AppRole>(option =>
{
    option.User.RequireUniqueEmail = true;
    option.Password.RequireUppercase = true;
    option.Password.RequireLowercase = true;
    option.Password.RequireDigit = true;
    option.Password.RequiredLength = 6;
    option.Password.RequireNonAlphanumeric = false;
}).AddEntityFrameworkStores<InboxlyContext>().AddDefaultTokenProviders().AddErrorDescriber<TurkishIdentityErrorDescriber>();


builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<ValidationMarker>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=StartupPage}/{action=StartPage}/{id?}");

app.Run();
