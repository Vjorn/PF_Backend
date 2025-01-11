using Microsoft.EntityFrameworkCore;
using PlusForward.Backend.Data;
using PlusForward.Backend.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets<Program>();

IServiceCollection services = builder.Services;
IConfiguration config = builder.Configuration;

services.AddControllers();

services.AddHttpContextAccessor();
services.AddDbContextFactory<PlusForwardDbContext>(
    options => options.UseMySql(config.GetConnectionString("Default"),
        ServerVersion.AutoDetect(config.GetConnectionString("Default"))));

services.AddScoped<ServerDataService>();
        

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();