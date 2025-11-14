using CompanyWorkload.BusinessLogic.Interfaces;
using CompanyWorkload.Domain.DTO.WorkCalendars;
using Microsoft.AspNetCore.Mvc;

namespace CompanyWorkload.Api.Controllers;

/// <summary>CRUD по календарям сотрудников</summary>
[Route("api/[controller]")]
public class WorkCalendarsController : BaseCrudController<WorkCalendarReadDto, WorkCalendarCreateDto, WorkCalendarUpdateDto>
{
    public WorkCalendarsController(IWorkCalendarService service) : base(service)
    {
    }
}
