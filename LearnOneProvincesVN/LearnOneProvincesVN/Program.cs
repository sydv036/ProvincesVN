using LearnOneProvincesVN.Api.Profiles;
using LearnOneProvincesVN.Data;
using LearnOneProvincesVN.Data.Entity;
using LearnOneProvincesVN.Reponsitory;
using LearnOneProvincesVN.Reponsitory.implement;
using LearnOneProvincesVN.Service;
using LearnOneProvincesVN.Service.Helper;
using LearnOneProvincesVN.Service.implement;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnect"));
});
builder.Services.AddScoped<IProvinceReponsitory, ProvincesReponsitoryImpl>();
builder.Services.AddScoped<IProvincesService, ProvincesServiceImpl>();
builder.Services.AddScoped<IReponsitory<Provinces>, ProvincesReponsitoryImpl>();
builder.Services.AddScoped<IDistrictsReponsitory, DistrictsReponsitoryImpl>();
builder.Services.AddScoped<IDistrictsService, DistrictsServiceImpl>();
builder.Services.AddScoped<IReponsitory<Districts>, DistrictsReponsitoryImpl>();
builder.Services.AddScoped<IWardsReponsitory, WardsReponsitoryImpl>();
builder.Services.AddScoped<IWardsService, WardsServiceImpl>();
builder.Services.AddScoped<IReponsitory<Wards>, WardsReponsitoryImpl>();
builder.Services.AddAutoMapper(typeof(ApplicationMapper), typeof(ModelRequestProfiles));

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
