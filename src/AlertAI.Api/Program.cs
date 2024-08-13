using AlertAI.Api.Configuration;
using AlertAI.Api.Data;
using AlertAI.Api.Interfaces;
using AlertAI.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AlertAIDbContext>();
ConfigureServices(builder.Services);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
});

builder.Services.AddScoped<IGptService, GptService>();
builder.Services.AddSingleton<IEmailService, EmailService>();

ConfigureConventions(builder);

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

await app.RunAsync();


static void ConfigureServices(IServiceCollection services)
{
    // Throw an exception for testing purposes
    // throw new Exception("Deliberate exception for testing");

    services.AddControllers();
    services.AddApiVersioning(config =>
    {
        config.DefaultApiVersion = new ApiVersion(1, 0);
        config.AssumeDefaultVersionWhenUnspecified = true;
        config.ReportApiVersions = true;
    });
}

static void ConfigureConventions(WebApplicationBuilder builder)
{
    builder.Services.Configure<RouteOptions>(options =>
    {
        options.LowercaseUrls = true;
        options.LowercaseQueryStrings = true;
    });

    builder.Services.AddControllers(options => options.Conventions.Add(
        new RouteTokenTransformerConvention(new RouteToKebabCase()))
    );
}