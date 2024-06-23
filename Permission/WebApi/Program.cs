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

    //��ȡӦ�ó�������Ŀ¼�����ԣ����ܹ���Ŀ¼Ӱ�죬������ô˷�����ȡ·����
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
//���ݿ�����
builder.Services.AddDbContext<MicroShop.Permission.Entity.PermissionContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PermissionDb")).EnableSensitiveDataLogging());

//Ocelot����
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