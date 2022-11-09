using EmployeeBenefits.Data.Repositories;
using EmployeeBenefits.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using EmployeeBenefits.Data.Models.Mapping;
using EmployeeBenefits.Data.Services;
using EmployeeBenefits.Data.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// add the db context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DataContext") ?? 
                         throw new InvalidOperationException("Connection string 'DataContext' not found.")));

// add automapper
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// register our repository and service classes
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IBenefitService, BenefitService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

// add swagger
builder.Services.AddSwaggerGen();

builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyHeader())
);


var app = builder.Build();


// add cors since we are running front-end under another app
app.UseCors();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


// use swagger only in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
};

app.UseAuthentication();

app.UseAuthorization();

app.UseHttpsRedirection();

app.UseRouting();

// map our api controllers
app.MapControllers();

app.Run();
