using CompanyWorkload.BusinessLogic.Interfaces;
using CompanyWorkload.Domain.DTO.Holidays;
using Microsoft.AspNetCore.Mvc;

namespace CompanyWorkload.Api.Controllers;

/// <summary>CRUD по праздникам</summary>
[Route("api/[controller]")]
public class HolidaysController : BaseCrudController<HolidayReadDto, HolidayCreateDto, HolidayUpdateDto>
{
    public HolidaysController(IHolidayService service) : base(service)
    {
    }
}
