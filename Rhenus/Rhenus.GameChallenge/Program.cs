using Microsoft.AspNetCore.Authentication.JwtBearer;
using Rhenus.GameChallenge.Application.Autentication;
using Rhenus.GameChallenge.Application.Players;
using Rhenus.GameChallenge.Domain.Bets;
using Rhenus.GameChallenge.Domain.Players;
using Rhenus.GameChallenge.Extensions;
using Rhenus.GameChallenge.Infrastructure.Authentication;
using Rhenus.GameChallenge.Infrastructure.ExceptionHandlers;
using Rhenus.GameChallenge.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IPlayerRepository, InMemoryPlayerRepository>();
builder.Services.AddScoped<IBetNumberGenerator, BetNumberGenerator>();
builder.Services.AddScoped<PlayerCommandHandler>();
builder.Services.AddScoped<AuthCommandHanlder>();
builder.Services.AddScoped<PlayerQueryService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtOptions"));
builder.Services.AddSwaggerGen(SwaggerExtensions.SetupSwaggerBearerSupport());
var jwtOptions = builder.Configuration.GetSection("JwtOptions").Get<JwtOptions>()!;
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtProviderExtensions.SetupJwtOptions(jwtOptions.SecretKey));

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddExceptionHandler<ApplicationExceptionHandler>();
builder.Services.AddProblemDetails();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseExceptionHandler();
app.MapControllers();

app.Run();