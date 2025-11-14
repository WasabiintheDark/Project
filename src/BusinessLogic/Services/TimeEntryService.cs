using CompanyWorkload.BusinessLogic.Interfaces;
using CompanyWorkload.DataAccess.Interfaces;
using CompanyWorkload.DataAccess.Wrapper;
using CompanyWorkload.Domain.DTO.TimeEntries;
using CompanyWorkload.Domain.Entities;

namespace CompanyWorkload.BusinessLogic.Services;

public class TimeEntryService
    : CrudService<TimeEntry, TimeEntryReadDto, TimeEntryCreateDto, TimeEntryUpdateDto>,
      ITimeEntryService
{
    public TimeEntryService(ITimeEntryRepository repository, IRepositoryWrapper wrapper)
        : base(repository, wrapper)
    {
    }

    protected override TimeEntryReadDto MapToReadDto(TimeEntry t) =>
        new(t.Id, t.EmployeeId, t.TaskId, t.SpentHours, t.EntryDate);

    protected override TimeEntry MapFromCreateDto(TimeEntryCreateDto dto) =>
        new()
        {
            EmployeeId = dto.EmployeeId,
            TaskId     = dto.TaskId,
            SpentHours = dto.SpentHours,
            EntryDate  = dto.EntryDate
        };

    protected override void MapFromUpdateDto(TimeEntryUpdateDto dto, TimeEntry t)
    {
        t.SpentHours = dto.SpentHours;
        t.EntryDate  = dto.EntryDate;
    }
}
