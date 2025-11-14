using CompanyWorkload.BusinessLogic.Interfaces;
using CompanyWorkload.DataAccess.Interfaces;
using CompanyWorkload.DataAccess.Wrapper;
using CompanyWorkload.Domain.DTO.WorkCalendars;
using CompanyWorkload.Domain.Entities;

namespace CompanyWorkload.BusinessLogic.Services;

public class WorkCalendarService
    : CrudService<WorkCalendar, WorkCalendarReadDto, WorkCalendarCreateDto, WorkCalendarUpdateDto>,
      IWorkCalendarService
{
    public WorkCalendarService(IWorkCalendarRepository repository, IRepositoryWrapper wrapper)
        : base(repository, wrapper)
    {
    }

    protected override WorkCalendarReadDto MapToReadDto(WorkCalendar w) =>
        new(w.Id, w.EmployeeId, w.WorkDay, w.CapacityHours, w.IsHoliday);

    protected override WorkCalendar MapFromCreateDto(WorkCalendarCreateDto dto) =>
        new()
        {
            EmployeeId    = dto.EmployeeId,
            WorkDay       = dto.WorkDay,
            CapacityHours = dto.CapacityHours,
            IsHoliday     = dto.IsHoliday
        };

    protected override void MapFromUpdateDto(WorkCalendarUpdateDto dto, WorkCalendar w)
    {
        w.WorkDay       = dto.WorkDay;
        w.CapacityHours = dto.CapacityHours;
        w.IsHoliday     = dto.IsHoliday;
    }
}
