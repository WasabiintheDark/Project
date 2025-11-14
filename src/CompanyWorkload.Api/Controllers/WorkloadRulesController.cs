using CompanyWorkload.BusinessLogic.Interfaces;
using CompanyWorkload.Domain.DTO.WorkloadRules;
using Microsoft.AspNetCore.Mvc;

namespace CompanyWorkload.Api.Controllers;

/// <summary>CRUD по правилам загрузки</summary>
[Route("api/[controller]")]
public class WorkloadRulesController : BaseCrudController<WorkloadRuleReadDto, WorkloadRuleCreateDto, WorkloadRuleUpdateDto>
{
    public WorkloadRulesController(IWorkloadRuleService service) : base(service)
    {
    }
}
