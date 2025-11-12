using CustomAuthTestWithDB;
using CustomAuthTestWithDB.Components;
using CustomAuthTestWithDB.Data;
using CustomAuthTestWithDB.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthorization(config =>
{
    // config.AddPolicy("Admin", policy => policy.RequireClaim("Admin"));
    foreach (var userPolicy in UserPolicy.GetPolicies())
    {
        config.AddPolicy(userPolicy, cfg => cfg.RequireClaim(userPolicy, "true"));
    }
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "auth_token";
        options.LoginPath = "/login";
        // options.LogoutPath = "/logout";
        options.Cookie.MaxAge = TimeSpan.FromMinutes(30);
        options.AccessDeniedPath = "/access-denied";
    });

builder.Services.AddCascadingAuthenticationState();

builder.Services.AddDbContext<UserDbContext>(options => options.UseSqlite("Data Source=Users.db"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();