using Location.Data.Access.Data;
using Location.Microservice.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    var port = Environment.GetEnvironmentVariable("RUNNING_IN_DOCKER") is not null ? 443 : 5204;
    options.Listen(System.Net.IPAddress.Any, port, listenOptions =>
    {
        var certificatePath = Environment.GetEnvironmentVariable("CERTIFICATE_PATH") ?? builder.Configuration["Certificate:Path"];
        var certificatePassword = builder.Configuration["Certificate:Password"];
        listenOptions.UseHttps(certificatePath, certificatePassword);
    });
});

var connectionString = Environment.GetEnvironmentVariable("DefaultConnection") ?? builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options => {
    options.UseSqlServer(connectionString);
});

builder.Services.AddServices();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Origins");

app.UseAuthorization();

app.MapControllers();

app.Run();
