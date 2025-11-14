using CompanyWorkload.BusinessLogic.Interfaces;
using CompanyWorkload.Domain.DTO.Employees;
using Microsoft.AspNetCore.Mvc;

namespace CompanyWorkload.Api.Controllers;

/// <summary>CRUD по сотрудникам</summary>
[Route("api/[controller]")]
public class EmployeesController : BaseCrudController<EmployeeReadDto, EmployeeCreateDto, EmployeeUpdateDto>
{
    public EmployeesController(IEmployeeService service) : base(service)
    {
    }
}
