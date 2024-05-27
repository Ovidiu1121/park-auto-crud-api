using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using ParkAutoCrudApi.Cars.Repository;
using ParkAutoCrudApi.Cars.Repository.interfaces;
using ParkAutoCrudApi.Cars.Service;
using ParkAutoCrudApi.Cars.Service.interfaces;
using ParkAutoCrudApi.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("Default")!,
        new MySqlServerVersion(new Version(8, 0, 21))));

builder.Services.AddFluentMigratorCore()
    .ConfigureRunner(rb => rb
        .AddMySql5()
        .WithGlobalConnectionString(builder.Configuration.GetConnectionString("Default"))
        .ScanIn(typeof(Program).Assembly).For.Migrations())
    .AddLogging(lb => lb.AddFluentMigratorConsole());


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICarCommandService, CarCommandService>();
builder.Services.AddScoped<ICarQueryService, CarQueryService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
    runner.MigrateUp();
}

app.Run();
