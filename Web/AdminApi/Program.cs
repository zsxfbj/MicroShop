using Lazy.Captcha.Core.Generator;
using Lazy.Captcha.Core;
using MicroShop.Permission.Entity;
using MicroShop.Utility.Cache;
using MicroShop.Web.AdminApi.Filter;
using MicroShop.Web.Common.Filter;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MicroShop.Product.Entity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new GlobalExceptionFilter());
});

// add HttpContextAccessor 
builder.Services.AddHttpContextAccessor();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Adminn API",
        Description = "MicroShop Admin API docs",
        TermsOfService = new Uri("https://www.cnblogs.com/zsxfbj/"),
        Contact = new OpenApiContact
        {
            Name = "Peak Sheng",
            Url = new Uri("https://www.cnblogs.com/zsxfbj/")
        }
    });
    options.OrderActionsBy(o => o.RelativePath);

    
    var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);
    if (!string.IsNullOrEmpty(basePath))
    {
        options.IncludeXmlComments(Path.Combine(basePath, "MicroShop.Permission.Enums.xml"));
        options.IncludeXmlComments(Path.Combine(basePath, "MicroShop.Permission.Model.xml"));
        options.IncludeXmlComments(Path.Combine(basePath, "MicroShop.Web.Common.xml"));
        options.IncludeXmlComments(Path.Combine(basePath, "MicroShop.Web.AdminApi.xml"));
    }
    options.OperationFilter<HeaderParameterOperationFilter>();
});


builder.Services.AddDbContext<PermissionContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CONNECTION_STRING_NON_DTC")).EnableSensitiveDataLogging());

builder.Services.AddDbContext<ProductContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CONNECTION_STRING_NON_DTC")).EnableSensitiveDataLogging());

// 图形验证码
builder.Services.AddCaptcha(builder.Configuration, option =>
{
    option.CaptchaType = CaptchaType.WORD;  
    option.CodeLength = 4;  
    option.ExpirySeconds = 600;  
    option.IgnoreCase = true;  
    option.StoreageKeyPrefix = "img-vcode";  

    option.ImageOption.Animation = true;  
    option.ImageOption.FrameDelay = 30;  

    option.ImageOption.Width = 150;  
    option.ImageOption.Height = 50; 
    option.ImageOption.BackgroundColor = SixLabors.ImageSharp.Color.White;  

    option.ImageOption.BubbleCount = 5;  
    option.ImageOption.BubbleMinRadius = 3;  
    option.ImageOption.BubbleMaxRadius = 10; 
    option.ImageOption.BubbleThickness = 1;  

    option.ImageOption.InterferenceLineCount = 3; 

    option.ImageOption.FontSize = 28;  
    option.ImageOption.FontFamily = DefaultFontFamilys.Instance.Kaiti;  

    
});

//Init Redis
string redisConnectionString = builder.Configuration.GetConnectionString("RedisConnectionString");
if (!string.IsNullOrEmpty(redisConnectionString))
{
    RedisClient.InitConnect(redisConnectionString);

}

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

 
builder.Services.AddMvc(
    o => {
        o.Filters.Add<DefaultActionFilter>();
    });

var app = builder.Build();

MicroShop.Utility.Common.HttpContext.Configure(app.Services.GetRequiredService<IHttpContextAccessor>());

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
