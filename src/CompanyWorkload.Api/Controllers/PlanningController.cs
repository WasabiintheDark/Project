using CompanyWorkload.BusinessLogic.Interfaces;
using CompanyWorkload.Domain.DTO.Planning;
using Microsoft.AspNetCore.Mvc;

namespace CompanyWorkload.Api.Controllers;

/// <summary>Планирование и загрузка</summary>
[ApiController]
[Route("api/[controller]")]
public class PlanningController : ControllerBase
{
    private readonly IPlanningService _planningService;

    public PlanningController(IPlanningService planningService)
    {
        _planningService = planningService;
    }

    /// <summary>Автораспределение задач проекта по сотрудникам</summary>
    [HttpPost("auto-assign")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<AutoAssignResultDto>> AutoAssign(
        [FromBody] AutoAssignRequest request,
        CancellationToken ct)
    {
        var result = await _planningService.AutoAssignAsync(request, ct);
        return Ok(result);
    }

    /// <summary>Получить загрузку сотрудников по дням</summary>
    [HttpPost("workload")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<WorkloadItemDto>>> GetWorkload(
        [FromBody] WorkloadQueryDto query,
        CancellationToken ct)
    {
        var result = await _planningService.GetWorkloadAsync(query, ct);
        return Ok(result);
    }
}
