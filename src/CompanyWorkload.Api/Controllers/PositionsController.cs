using CompanyWorkload.BusinessLogic.Interfaces;
using CompanyWorkload.Domain.DTO.Positions;
using Microsoft.AspNetCore.Mvc;

namespace CompanyWorkload.Api.Controllers;

/// <summary>CRUD по должностям</summary>
[ApiController]
[Route("api/[controller]")]
public class PositionsController 
    : BaseCrudController<PositionReadDto, PositionCreateDto, PositionUpdateDto>
{
    public PositionsController(IPositionService service) : base(service)
    {
    }
}
