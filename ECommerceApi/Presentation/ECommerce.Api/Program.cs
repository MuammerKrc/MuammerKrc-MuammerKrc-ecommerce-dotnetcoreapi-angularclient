using ECommerce.Application;
using ECommerce.Application.Validators.Products;
using ECommerce.Infrastructure.CustomControllerFilters;
using ECommerce.Persistence;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("AngularClientCors", cfg =>
    {
        cfg.WithOrigins("https://localhost:4200", "http://localhost:4200").AllowAnyHeader().AllowAnyMethod()
            .AllowCredentials();
    });
});
builder.Services.AddControllers(opt => opt.Filters.Add<CustomValidatorFilter>()).AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<ProductCreateValidator>()).ConfigureApiBehaviorOptions(
    opt =>
    {
        opt.SuppressModelStateInvalidFilter = true;
    });
builder.Services.AddApplicationServiceRegistration();
builder.Services.AddPersistenceServiceRegistration();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseCors("AngularClientCors");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
