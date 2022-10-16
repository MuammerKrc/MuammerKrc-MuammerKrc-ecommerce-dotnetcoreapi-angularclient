using System.Security.Claims;
using System.Text;
using ECommerce.Api.Middlewares;
using ECommerce.Application;
using ECommerce.Application.ConfigurationModels;
using ECommerce.Application.Validators.Products;
using ECommerce.Infrastructure;
using ECommerce.Infrastructure.CustomControllerFilters;
using ECommerce.Infrastructure.Enum;
using ECommerce.Persistence;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Core;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
builder.Services.AddApplicationServiceRegistration(builder.Configuration);
builder.Services.AddPersistenceServiceRegistration();
builder.Services.AddInfrastructureServices();

builder.Services.AddStorage(StorageType.Local);

// Add services to the container.

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("AngularClientCors", cfg =>
    {
        cfg.WithOrigins("https://localhost:4200", "http://localhost:4200").AllowAnyHeader().AllowAnyMethod()
            .AllowCredentials();
    });
});
Logger log = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt")
    //.WriteTo.MSSqlServer(builder.Configuration.GetConnectionString("PostgreSQL"), "logs",
    //    columnOptions: new Dictionary<string, ColumnWriterBase>
    //    {
    //        {"message", new RenderedMessageColumnWriter(NpgsqlDbType.Text)},
    //        {"message_template", new MessageTemplateColumnWriter(NpgsqlDbType.Text)},
    //        {"level", new LevelColumnWriter(true , NpgsqlDbType.Varchar)},
    //        {"time_stamp", new TimestampColumnWriter(NpgsqlDbType.Timestamp)},
    //        {"exception", new ExceptionColumnWriter(NpgsqlDbType.Text)},
    //        {"log_event", new LogEventSerializedColumnWriter(NpgsqlDbType.Json)},
    //        {"user_name", new UsernameColumnWriter()}
    //    })
    //.WriteTo.Seq(builder.Configuration["Seq:ServerURL"])
    .Enrich.FromLogContext()
    .MinimumLevel.Information()
    .CreateLogger();

builder.Host.UseSerilog(log);
builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
});

builder.Services.AddControllers(opt => opt.Filters.Add<CustomValidatorFilter>()).AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<ProductCreateValidator>()).ConfigureApiBehaviorOptions(
    opt =>
    {
        opt.SuppressModelStateInvalidFilter = true;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var tokenConfiguration = builder.Configuration.GetSection("Token").Get<TokenConfigurationModel>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer("admin", opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidAudience = tokenConfiguration.Audience,
        ValidIssuer = tokenConfiguration.Issuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfiguration.SecurityKey)),
        LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false,
        NameClaimType = ClaimTypes.Name
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();
app.UseHttpLogging();
app.UseStaticFiles();
app.UseCors("AngularClientCors");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<SerilogUsernameMiddleware>();
app.MapControllers();

app.Run();
