using DemoDapper.Model;
using DemoDapper.Repository;
using DemoDapper.Repository.Interface;
using DemoDapper.Service;
using DemoDapper.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

//register custom converter from Ulid to string
Dapper.SqlMapper.AddTypeHandler(new StringUlidHandler());

// Add services to the container.
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();

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
