using Lazy.Captcha.Core.Generator;
using Lazy.Captcha.Core;
using MicroShop.Utility.Cache;
using MicroShop.Web.AdminApi.Filter;
using MicroShop.Web.Common.Filter;
using Microsoft.OpenApi.Models;
using MicroShop.Utility;

var builder = WebApplication.CreateBuilder(args);

//Init Redis
StaticGlobalVariables.RedisConnectionString = builder.Configuration.GetConnectionString("RedisConnectionString");
if (!string.IsNullOrEmpty(StaticGlobalVariables.RedisConnectionString))
{
    RedisClient.InitConnect(StaticGlobalVariables.RedisConnectionString);
}

//数据库链接字符串
StaticGlobalVariables.SQLConnectionString = builder.Configuration.GetConnectionString("CONNECTION_STRING_NON_DTC");

//是否调试模式
string? isDebug = builder.Configuration.GetSection("IsDebug").Value;
StaticGlobalVariables.IsDebug = bool.Parse((string.IsNullOrEmpty(isDebug) ? "false" : isDebug.Trim()));

//数据访问仓库
string? dalType = builder.Configuration.GetSection("MicroShopDAL").Value;
StaticGlobalVariables.MicroShopDAL = string.IsNullOrEmpty(dalType) ? "MicroShop.SQLServerDAL" : dalType.Trim();

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
    options.SwaggerDoc("v1.0", new OpenApiInfo
    {
        Version = "v1.0",
        Title = "MicroShop API",
        Description = "MicroShop API docs",
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
        options.IncludeXmlComments(Path.Combine(basePath, "MicroShop.Enums.xml"));
        options.IncludeXmlComments(Path.Combine(basePath, "MicroShop.Model.xml"));
        options.IncludeXmlComments(Path.Combine(basePath, "MicroShop.WebApi.xml"));
    }
    options.OperationFilter<HeaderParameterOperationFilter>();
});


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
    option.ImageOption.BackgroundColor = SkiaSharp.SKColor.Parse("#0000000");  

    option.ImageOption.BubbleCount = 5;  
    option.ImageOption.BubbleMinRadius = 3;  
    option.ImageOption.BubbleMaxRadius = 10; 
    option.ImageOption.BubbleThickness = 1;  

    option.ImageOption.InterferenceLineCount = 3; 

    option.ImageOption.FontSize = 28;  
    option.ImageOption.FontFamily = DefaultFontFamilys.Instance.Kaiti;  

});

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

 
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHsts();
}

app.UseCors("cors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
