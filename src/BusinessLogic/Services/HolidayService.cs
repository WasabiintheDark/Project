using CompanyWorkload.BusinessLogic.Interfaces;
using CompanyWorkload.DataAccess.Interfaces;
using CompanyWorkload.DataAccess.Wrapper;
using CompanyWorkload.Domain.DTO.Holidays;
using CompanyWorkload.Domain.Entities;

namespace CompanyWorkload.BusinessLogic.Services;

public class HolidayService
    : CrudService<Holiday, HolidayReadDto, HolidayCreateDto, HolidayUpdateDto>,
      IHolidayService
{
    public HolidayService(IHolidayRepository repository, IRepositoryWrapper wrapper)
        : base(repository, wrapper)
    {
    }

    protected override HolidayReadDto MapToReadDto(Holiday h) =>
        new(h.Id, h.Day, h.Name);

    protected override Holiday MapFromCreateDto(HolidayCreateDto dto) =>
        new()
        {
            Day  = dto.Day,
            Name = dto.Name
        };

    protected override void MapFromUpdateDto(HolidayUpdateDto dto, Holiday h)
    {
        h.Day  = dto.Day;
        h.Name = dto.Name;
    }
}
