using MicroShop.Permission.Entity;
using MicroShop.Permission.WebApi.Filter;
using MicroShop.Web.Common.Filter;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Ocelot.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new GlobalExceptionFilter());
});

// add HttpContextAccessor 
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

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
    options.OrderActionsBy(o => o.RelativePath);

    //获取应用程序所在目录（绝对，不受工作目录影响，建议采用此方法获取路径）
    var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);
    if(!string.IsNullOrEmpty(basePath))
    {
        options.IncludeXmlComments(Path.Combine(basePath, "MicroShop.Permission.Enums.xml"));
        options.IncludeXmlComments(Path.Combine(basePath, "MicroShop.Permission.Model.xml"));
        options.IncludeXmlComments(Path.Combine(basePath, "MicroShop.Web.Common.xml"));
        options.IncludeXmlComments(Path.Combine(basePath, "MicroShop.Permission.WebApi.xml"));
    }    
    options.OperationFilter<HeaderParameterOperationFilter>();
    options.DocumentFilter<HideOcelotControllersFilter>();
    options.DocumentFilter<SwaggerEnumFilter>();
});
//数据库配置
builder.Services.AddDbContext<MicroShop.Permission.Entity.PermissionContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PermissionDb")).EnableSensitiveDataLogging());

//Ocelot配置
builder.Services.AddOcelot(builder.Configuration.AddJsonFile("Ocelot.json").Build());

//Cors configuring
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.SetIsOriginAllowed((x) => true)
       .AllowAnyOrigin()
       .AllowAnyHeader()
       .AllowAnyMethod();
    });
});


 


var app = builder.Build();

PermissionContext permissionContext = new PermissionContext();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    if (!permissionContext.Database.EnsureCreated())
    {
        permissionContext.Database.Migrate();
    }
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    permissionContext.Database.EnsureCreated();
    app.UseHsts();
}

app.UseCors("cors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();