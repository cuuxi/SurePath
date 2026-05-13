using Cuuxi.SurePath.Backend.Services;
using Cuuxi.SurePath.DAL;
using Cuuxi.SurePath.DAL.DbContexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SurePathDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SurePath")));

builder.Services.AddScoped<Settings>(sp =>
    new Settings(sp.GetRequiredService<SurePathDbContext>()));
builder.Services.AddScoped<Connector>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<TranslationService>();

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();
app.MapRazorPages().WithStaticAssets();

app.Run();
