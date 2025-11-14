using CompanyWorkload.Api.Middleware;
using CompanyWorkload.BusinessLogic.Interfaces;
using CompanyWorkload.BusinessLogic.Services;
using CompanyWorkload.BusinessLogic.Validation.Employees;
using CompanyWorkload.DataAccess.Interfaces;
using CompanyWorkload.DataAccess.Models;
using CompanyWorkload.DataAccess.Repositories;
using CompanyWorkload.DataAccess.Wrapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using CompanyWorkload.DataAccess.Models;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod());
});

// Controllers + FluentValidation
builder.Services
    .AddControllers()
    .AddJsonOptions(o =>
    {
        // Оставляем имена свойств как в C# (PascalCase),
        // чтобы DTO красиво отображались в Swagger и ответах.
        o.JsonSerializerOptions.PropertyNamingPolicy = null;
    })
    // Регистрация автоматической валидации FluentValidation
    .AddFluentValidation();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext
var connectionString = builder.Configuration.GetConnectionString("CompanyWorkload")
                      ?? "Host=localhost;Port=5432;Database=company_workload;Username=postgres;Password=postgres";

builder.Services.AddDbContext<CompanyWorkloadDbContext>(options =>
    options.UseNpgsql(connectionString));

// Repositories
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IPositionRepository, PositionRepository>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<IEmployeeSkillRepository, EmployeeSkillRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectTaskRepository, ProjectTaskRepository>();
builder.Services.AddScoped<IAssignmentRepository, AssignmentRepository>();
builder.Services.AddScoped<IWorkCalendarRepository, WorkCalendarRepository>();
builder.Services.AddScoped<IHolidayRepository, HolidayRepository>();
builder.Services.AddScoped<IWorkloadRuleRepository, WorkloadRuleRepository>();
builder.Services.AddScoped<ITimeEntryRepository, TimeEntryRepository>();
builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

// Services
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IPositionService, PositionService>();
builder.Services.AddScoped<ISkillService, SkillService>();
builder.Services.AddScoped<IEmployeeSkillService, EmployeeSkillService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IProjectTaskService, ProjectTaskService>();
builder.Services.AddScoped<IAssignmentService, AssignmentService>();
builder.Services.AddScoped<IWorkCalendarService, WorkCalendarService>();
builder.Services.AddScoped<IHolidayService, HolidayService>();
builder.Services.AddScoped<IWorkloadRuleService, WorkloadRuleService>();
builder.Services.AddScoped<ITimeEntryService, TimeEntryService>();
builder.Services.AddScoped<IPlanningService, PlanningService>();

// Validators (если понадобятся дополнительные — сюда же)
builder.Services.AddScoped<IValidator<CompanyWorkload.Domain.DTO.Employees.EmployeeCreateDto>, EmployeeCreateValidator>();
builder.Services.AddScoped<IValidator<CompanyWorkload.Domain.DTO.Employees.EmployeeUpdateDto>, EmployeeUpdateValidator>();

// CORS (на будущее, если будет фронт)
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod());
});

var app = builder.Build();

// По желанию можно миграции применять автоматически
// using (var scope = app.Services.CreateScope())
// {
//     var db = scope.ServiceProvider.GetRequiredService<CompanyWorkloadDbContext>();
//     db.Database.Migrate();
// }

// Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseErrorHandling();

app.UseHttpsRedirection();

app.UseCors();

app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();


// Автоматическое применение миграций при старте
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CompanyWorkloadDbContext>();
    db.Database.Migrate();
}


app.Run();

// Для интеграционных тестов
public partial class Program { }
