using CompanyWorkload.Domain.DTO.Skills;

namespace CompanyWorkload.BusinessLogic.Interfaces;

public interface ISkillService : ICrudService<SkillReadDto, SkillCreateDto, SkillUpdateDto>
{
}
