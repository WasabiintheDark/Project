using CompanyWorkload.BusinessLogic.Interfaces;
using CompanyWorkload.DataAccess.Interfaces;
using CompanyWorkload.DataAccess.Wrapper;
using CompanyWorkload.Domain.DTO.EmployeeSkills;
using CompanyWorkload.Domain.Entities;

namespace CompanyWorkload.BusinessLogic.Services;

public class EmployeeSkillService
    : CrudService<EmployeeSkill, EmployeeSkillReadDto, EmployeeSkillCreateDto, EmployeeSkillUpdateDto>,
      IEmployeeSkillService
{
    public EmployeeSkillService(IEmployeeSkillRepository repository, IRepositoryWrapper wrapper)
        : base(repository, wrapper)
    {
    }

    protected override EmployeeSkillReadDto MapToReadDto(EmployeeSkill es) =>
        new(es.EmployeeId, es.SkillId, es.Level);

    protected override EmployeeSkill MapFromCreateDto(EmployeeSkillCreateDto dto) =>
        new()
        {
            EmployeeId = dto.EmployeeId,
            SkillId    = dto.SkillId,
            Level      = dto.Level
        };

    protected override void MapFromUpdateDto(EmployeeSkillUpdateDto dto, EmployeeSkill es)
    {
        es.Level = dto.Level;
    }
}
