using CompanyWorkload.BusinessLogic.Interfaces;
using CompanyWorkload.Domain.DTO.EmployeeSkills;
using Microsoft.AspNetCore.Mvc;

namespace CompanyWorkload.Api.Controllers;

/// <summary>CRUD по навыкам сотрудников</summary>
[Route("api/[controller]")]
public class EmployeeSkillsController : BaseCrudController<EmployeeSkillReadDto, EmployeeSkillCreateDto, EmployeeSkillUpdateDto>
{
    public EmployeeSkillsController(IEmployeeSkillService service) : base(service)
    {
    }
}
