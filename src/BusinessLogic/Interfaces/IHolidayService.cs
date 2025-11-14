using CompanyWorkload.Domain.DTO.Holidays;

namespace CompanyWorkload.BusinessLogic.Interfaces;

public interface IHolidayService : ICrudService<HolidayReadDto, HolidayCreateDto, HolidayUpdateDto>
{
}
