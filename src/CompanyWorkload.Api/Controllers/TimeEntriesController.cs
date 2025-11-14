using CompanyWorkload.BusinessLogic.Interfaces;
using CompanyWorkload.Domain.DTO.TimeEntries;
using Microsoft.AspNetCore.Mvc;

namespace CompanyWorkload.Api.Controllers;

/// <summary>CRUD по учёту рабочего времени</summary>
[Route("api/[controller]")]
public class TimeEntriesController : BaseCrudController<TimeEntryReadDto, TimeEntryCreateDto, TimeEntryUpdateDto>
{
    public TimeEntriesController(ITimeEntryService service) : base(service)
    {
    }
}
