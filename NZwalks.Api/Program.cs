using Microsoft.EntityFrameworkCore;
using NZwalks.Api.Data;
using NZwalks.Api.Mapping;
using NZwalks.Api.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddDbContext<NZwalkDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NZwalksConnectionString"),
        sqlServerOptions => sqlServerOptions.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(10), errorNumbersToAdd: null    )));

// Adding NZwalksAuthDbContext class
builder.Services.AddDbContext<NZwalksAuthDbContext>(options=>
options.UseSqlServer(builder.Configuration.GetConnectionString("NZwalksAuthConnectionString"),
sqlServerOption=>sqlServerOption.EnableRetryOnFailure(maxRetryCount:5,maxRetryDelay:TimeSpan.FromSeconds(10),errorNumbersToAdd:null))
);

//Adding AutoMapper 
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
//register services Repository ojbect to DI container
builder.Services.AddScoped<IRegionRepository,SQLRegionRepository>();
//builder.Services.AddScoped<IRegionRepository,InMemoryRegionRepository>();

//Register WalkRepository service
builder.Services.AddScoped<IWalkRepository,SQLWalkRepository>();




// add swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add JwT Authentication service 
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options=>
    options.TokenValidationParameters=new TokenValidationParameters
    {
        ValidateIssuer=true,
        ValidateAudience=true,
        ValidateIssuerSigningKey=true,
        ValidateLifetime=true,
        ValidIssuer=builder.Configuration["Jwt:Issuer"],
        ValidAudience=builder.Configuration["Jwt:Audience"],
        IssuerSigningKey=new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))

    });

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

if(app.Environment.IsDevelopment()){
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();


var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
