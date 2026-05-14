var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SurePath")!;
builder.Services.AddScoped<Cuuxi.SurePath.API.BLL.Settings>(_ =>
    new Cuuxi.SurePath.API.BLL.Settings(connectionString));
builder.Services.AddScoped<Cuuxi.SurePath.API.BLL.Connector>();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
