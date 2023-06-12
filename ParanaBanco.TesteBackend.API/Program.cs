using System.Reflection;
using System.Text.Json.Serialization;

using ParanaBanco.TesteBackend.Domain.Exceptions;
using ParanaBanco.TesteBackend.Domain.Exceptions.Validations;
using ParanaBanco.TesteBackend.IOC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddRepositories()
    .AddDatabase(builder.Configuration)
    .AddServices()
    .AddSwaggerInfo(Assembly.GetExecutingAssembly().GetName().Name ?? "ParanaBanco.TesteBackEnd.API");

builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStatusCodePages();
app.UseRouting();

app.MapControllers();

app.UseExceptionHandler("/error");
app.Map("/error", (HttpContext http) =>
{
    var error = http.Features?.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>()?.Error;

    string? errorMessage = null;

    if (error != null)
    {
        errorMessage = app.Environment.IsDevelopment()
            ? $"Message: {error.Message}\r\nInnerException:{error.InnerException}\r\nStackTrace:{error.StackTrace}"
            : $"Message: {error.Message}";

        if (error is DomainExceptionValidation)
            return Results.Problem(title: "Validation exception", detail: errorMessage, statusCode: StatusCodes.Status400BadRequest);
        else if (error is ArgumentException)
            return Results.Problem(title: "Argument exception", detail: errorMessage, statusCode: StatusCodes.Status400BadRequest);
        else if (error is EntryNotFoundException)
            return Results.Problem(title: "Entry not found", detail: errorMessage, statusCode: StatusCodes.Status404NotFound);
    }

    return Results.Problem(title: "an error ocurred", detail: errorMessage ?? "Details not available.", statusCode: StatusCodes.Status500InternalServerError);
});

app.Run();
