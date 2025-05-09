using FinanceControlAPI.API.Filters;
using FinanceControlAPI.API.Middleware;
using FinanceControlAPI.Infrastructure;
using FinanceControlAPI.Application;
using FinanceControlAPI.Infrastructure.Migrations;
using FinanceControlAPI.API.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

builder.Services.AddProjectConfigurations(builder.Configuration);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<CultureMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

await MigrateDataBase();

app.Run();

async Task MigrateDataBase()
{
  await using var scope = app.Services.CreateAsyncScope();

  await DataBaseMigration.MigrateDataBase(scope.ServiceProvider);
}