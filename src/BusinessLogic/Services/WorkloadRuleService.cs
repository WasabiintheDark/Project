using CompanyWorkload.BusinessLogic.Interfaces;
using CompanyWorkload.DataAccess.Interfaces;
using CompanyWorkload.DataAccess.Wrapper;
using CompanyWorkload.Domain.DTO.WorkloadRules;
using CompanyWorkload.Domain.Entities;

namespace CompanyWorkload.BusinessLogic.Services;

public class WorkloadRuleService
    : CrudService<WorkloadRule, WorkloadRuleReadDto, WorkloadRuleCreateDto, WorkloadRuleUpdateDto>,
      IWorkloadRuleService
{
    public WorkloadRuleService(IWorkloadRuleRepository repository, IRepositoryWrapper wrapper)
        : base(repository, wrapper)
    {
    }

    protected override WorkloadRuleReadDto MapToReadDto(WorkloadRule r) =>
        new(r.Id, r.Name, r.MaxAllocationPercent, r.Notes);

    protected override WorkloadRule MapFromCreateDto(WorkloadRuleCreateDto dto) =>
        new()
        {
            Name               = dto.Name,
            MaxAllocationPercent = dto.MaxAllocationPercent,
            Notes              = dto.Notes
        };

    protected override void MapFromUpdateDto(WorkloadRuleUpdateDto dto, WorkloadRule r)
    {
        r.Name                = dto.Name;
        r.MaxAllocationPercent = dto.MaxAllocationPercent;
        r.Notes               = dto.Notes;
    }
}
