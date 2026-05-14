using Cuuxi.SurePath.Backend.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SurePath")!;
builder.Services.AddScoped<Cuuxi.SurePath.Backend.BLL.Settings>(_ =>
    new Cuuxi.SurePath.Backend.BLL.Settings(connectionString));
builder.Services.AddScoped<Cuuxi.SurePath.Backend.BLL.Connector>();

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
