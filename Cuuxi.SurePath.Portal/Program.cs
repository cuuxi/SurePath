using Cuuxi.SurePath.Portal.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SurePath")!;
builder.Services.AddScoped<Cuuxi.SurePath.Portal.BLL.Settings>(_ =>
    new Cuuxi.SurePath.Portal.BLL.Settings(connectionString));
builder.Services.AddScoped<Cuuxi.SurePath.Portal.BLL.Connector>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<TranslationService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login";
        options.LogoutPath = "/Logout";
        options.ExpireTimeSpan = TimeSpan.FromHours(8);
    });

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapStaticAssets();
app.MapRazorPages().WithStaticAssets();

app.Run();
