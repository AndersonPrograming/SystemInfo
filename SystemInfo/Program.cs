using Microsoft.EntityFrameworkCore;
using SystemInfo.Context;
using SystemInfo.Repositories;
using SystemInfo.Repositories.GameRepositories;
using SystemInfo.Services;
using SystemInfo.Services.GameServices;

var builder = WebApplication.CreateBuilder(args);

var conexionString = builder.Configuration.GetConnectionString("Connection");

builder.Services.AddDbContext<SystemContext>(options => options.UseSqlServer(conexionString));

// Add services to the container.

builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
builder.Services.AddScoped<IContactTypeRepository, ContactTypeRepository>();
builder.Services.AddScoped<IDeviceTypeRepository, DeviceTypeRepository>();
builder.Services.AddScoped<IEnergyLogRepository, EnergyLogRepository>();
builder.Services.AddScoped<IEnergyMeterRepository, EnergyMeterRepository>(); 
builder.Services.AddScoped<IFarmRepository, FarmRepository>();
builder.Services.AddScoped<IFarmerRepository, FarmerRepository>();
builder.Services.AddScoped<IFarmTypeRepository, FarmTypeRepository>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IScoreRepository, ScoreRepository>();


builder.Services.AddScoped<IDeviceService, DeviceService>();
builder.Services.AddScoped<IContactTypeService, ContactTypeService>();
builder.Services.AddScoped<IDeviceTypeService, DeviceTypeService>();
builder.Services.AddScoped<IEnergyLogService, EnergyLogService>();
builder.Services.AddScoped<IEnergyMeterService, EnergyMeterService>();
builder.Services.AddScoped<IFarmService, FarmService>();
builder.Services.AddScoped<IFarmerService, FarmerService>();
builder.Services.AddScoped<IFarmTypeService, FarmTypeService>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IScoreService, ScoreService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
