using CompanyWorkload.Domain.DTO.TimeEntries;

namespace CompanyWorkload.BusinessLogic.Interfaces;

public interface ITimeEntryService : ICrudService<TimeEntryReadDto, TimeEntryCreateDto, TimeEntryUpdateDto>
{
}
