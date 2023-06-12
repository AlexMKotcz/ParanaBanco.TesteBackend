using ParanaBanco.TesteBackend.IOC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddRepositories()
    .AddDatabase(builder.Configuration)
    .AddServices()
    .AddSwaggerInfo();

builder.Services.AddControllers();
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

app.Run();
