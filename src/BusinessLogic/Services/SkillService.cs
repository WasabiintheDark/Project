using CompanyWorkload.BusinessLogic.Interfaces;
using CompanyWorkload.DataAccess.Interfaces;
using CompanyWorkload.DataAccess.Wrapper;
using CompanyWorkload.Domain.DTO.Skills;
using CompanyWorkload.Domain.Entities;

namespace CompanyWorkload.BusinessLogic.Services;

public class SkillService
    : CrudService<Skill, SkillReadDto, SkillCreateDto, SkillUpdateDto>,
      ISkillService
{
    public SkillService(ISkillRepository repository, IRepositoryWrapper wrapper)
        : base(repository, wrapper)
    {
    }

    protected override SkillReadDto MapToReadDto(Skill s) =>
        new(s.Id, s.Name);

    protected override Skill MapFromCreateDto(SkillCreateDto dto) =>
        new() { Name = dto.Name };

    protected override void MapFromUpdateDto(SkillUpdateDto dto, Skill s)
    {
        s.Name = dto.Name;
    }
}
