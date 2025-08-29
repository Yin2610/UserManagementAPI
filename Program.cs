using Microsoft.EntityFrameworkCore;
using UserManagementAPI;
using UserManagementAPI.data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseInMemoryDatabase("UserDb"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware order matters:
app.UseMiddleware<ErrorHandlingMiddleware>();     // First: catch exceptions
app.UseMiddleware<JwtAuthenticationMiddleware>();   // Second: validate tokens
app.UseMiddleware<LoggingMiddleware>();           // Last: log request/response

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
