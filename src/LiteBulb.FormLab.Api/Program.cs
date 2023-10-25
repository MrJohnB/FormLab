using LiteBulb.FormLab.Application.Configuration;
using LiteBulb.FormLab.Infrastructure.Repositories.EntityFramework.Configuration;
using Microsoft.OpenApi.Models;
using Serilog;

const string ConnectionStringName = "DefaultConnection";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add MVC services
builder.Services.AddControllers(options =>
{
    // ASP.NET Core trims the suffix Async from action names by default
    options.SuppressAsyncSuffixInActionNames = false; // re-enable
});

// Add EntityFramework Core
var connectionString = builder.Configuration.GetConnectionString(ConnectionStringName)
    ?? throw new InvalidOperationException($"Connection string: '{ConnectionStringName}' not found.");
builder.Services.AddApplicationDbContext(connectionString);

// Add custom service registrations
builder.Services.AddMappers();
builder.Services.AddRepositories();
builder.Services.AddServices();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "FormLab API",
            Version = "v1",
            Description = "RESTful endpoints to be consumed by FormLab"
        });

    var filePath = Path.Combine(AppContext.BaseDirectory, "LiteBulb.FormLab.Api.xml");
    options.IncludeXmlComments(filePath);
});

// Logging
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

//builder.Services.BuildServiceProvider(validateScopes: true);

var app = builder.Build();

app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors(options => options // Call to UseCors() must be placed after UseRouting, but before UseAuthorization
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();
