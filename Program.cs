using CQRSAPI.Configuration;
using Microsoft.Extensions.Options;
using MediatR;
using System.Reflection;
using CQRSAPI.DbSettings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
var env = builder.Environment.EnvironmentName;
var config = builder.Configuration;
var appName=builder.Environment.ApplicationName;

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        var config = builder.Configuration;
        var connectionString = config.GetConnectionString("AppConnection");
        options.UseSqlServer(connectionString);
    });
}
//builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection(DatabaseSettings.SectionName));
//builder.Configuration.AddSecretsManager(region: Amazon.RegionEndpoint.APSouth1, configurator: Options =>
//{
//    Options.SecretFilter = entry => entry.Name.StartsWith($"{env}_{appName}_");
//    Options.KeyGenerator = (_, s) => s.Replace($"{env}_{appName}_", string.Empty).Replace("__", ":");
//});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthorization();
app.MapControllers();
app.Run();
