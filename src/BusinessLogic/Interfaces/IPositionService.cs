using CompanyWorkload.Domain.DTO.Positions;

namespace CompanyWorkload.BusinessLogic.Interfaces;

public interface IPositionService : ICrudService<PositionReadDto, PositionCreateDto, PositionUpdateDto>
{
}
