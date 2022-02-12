using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Permission API",
        Description = "An ASP.NET Core Web API for managing Permission items",
        TermsOfService = new Uri("https://www.cnblogs.com/zsxfbj/"),
        Contact = new OpenApiContact
        {
            Name = "Peak Sheng",
            Url = new Uri("https://www.cnblogs.com/zsxfbj/")
        }
    });
});

builder.Services.AddDbContext<MicroShop.Permission.Entity.PermissionContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PermissionDb")).EnableSensitiveDataLogging());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
