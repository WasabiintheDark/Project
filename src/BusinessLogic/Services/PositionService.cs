using CompanyWorkload.BusinessLogic.Interfaces;
using CompanyWorkload.DataAccess.Interfaces;
using CompanyWorkload.DataAccess.Wrapper;
using CompanyWorkload.Domain.DTO.Positions;
using CompanyWorkload.Domain.Entities;

namespace CompanyWorkload.BusinessLogic.Services;

public class PositionService
    : CrudService<Position, PositionReadDto, PositionCreateDto, PositionUpdateDto>,
      IPositionService
{
    public PositionService(IPositionRepository repository, IRepositoryWrapper wrapper)
        : base(repository, wrapper)
    {
    }

    protected override PositionReadDto MapToReadDto(Position p) =>
        new(p.Id, p.Name);

    protected override Position MapFromCreateDto(PositionCreateDto dto) =>
        new() { Name = dto.Name };

    protected override void MapFromUpdateDto(PositionUpdateDto dto, Position p)
    {
        p.Name = dto.Name;
    }
}
