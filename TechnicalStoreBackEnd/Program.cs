// Program.cs
using Microsoft.EntityFrameworkCore;
using TechnicalStoreBackEnd.Models;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Подключение базы данных
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Контроллеры + сериализация JSON
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    });

// Swagger для документации
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "TechnicalStore API",
        Version = "v1"
    });
});

// Разрешение CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Поддержка статических файлов (например, изображений)
app.UseStaticFiles();

// Разрешение CORS глобально
app.UseCors("AllowAll");

// Swagger только в режиме разработки
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TechnicalStore API v1");
    });
}

// Авторизация и маршруты контроллеров
app.UseAuthorization();
app.MapControllers();

// Указание порта
app.Urls.Add("http://localhost:5085");

app.Run();
