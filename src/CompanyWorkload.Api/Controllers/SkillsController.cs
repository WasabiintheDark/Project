using CompanyWorkload.BusinessLogic.Interfaces;
using CompanyWorkload.Domain.DTO.Skills;
using Microsoft.AspNetCore.Mvc;

namespace CompanyWorkload.Api.Controllers;

/// <summary>CRUD по навыкам</summary>
[Route("api/[controller]")]
public class SkillsController : BaseCrudController<SkillReadDto, SkillCreateDto, SkillUpdateDto>
{
    public SkillsController(ISkillService service) : base(service)
    {
    }
}
