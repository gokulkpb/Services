using Microsoft.EntityFrameworkCore;
using UserService.DbContext1;
using UserService.Middleware;
using UserService.Repositories;
using UserService.Security;
using UserService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPasswordService, PasswordService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UserDb")));
var app = builder.Build();

// If the app is hosted on a URL that includes a path base (for example
// http://localhost:5028/swagger) the path base must be configured using
// IApplicationBuilder.UsePathBase so the runtime does not attempt to set
// HttpRequest.PathBase after the pipeline is built.

app.UseMiddleware<ExceptionMiddleware>();
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
