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

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtOptions"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(SwaggerExtensions.SetupSwaggerBearerSupport());

builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IPlayerRepository, InMemoryPlayerRepository>();
builder.Services.AddScoped<IBetNumberGenerator, BetNumberGenerator>();
builder.Services.AddScoped<PlayerCommandHandler>();
builder.Services.AddScoped<AuthCommandHanlder>();
builder.Services.AddScoped<PlayerQueryService>();

builder.Services
    .AddControllers()
    .AddMvcOptions(x => { x.EnableEndpointRouting = false; });

var jwtOptions = builder.Configuration.GetSection("JwtOptions").Get<JwtOptions>()!;
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtProviderExtensions.SetupJwtOptions(jwtOptions.SecretKey));

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddExceptionHandler<ApplicationExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddHttpContextAccessor();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseMvcWithDefaultRoute();
app.UseExceptionHandler();

app.Run();