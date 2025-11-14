using CompanyWorkload.Domain.DTO.WorkCalendars;

namespace CompanyWorkload.BusinessLogic.Interfaces;

public interface IWorkCalendarService : ICrudService<WorkCalendarReadDto, WorkCalendarCreateDto, WorkCalendarUpdateDto>
{
}
