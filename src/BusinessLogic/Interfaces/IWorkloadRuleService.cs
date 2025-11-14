using CompanyWorkload.Domain.DTO.WorkloadRules;

namespace CompanyWorkload.BusinessLogic.Interfaces;

public interface IWorkloadRuleService : ICrudService<WorkloadRuleReadDto, WorkloadRuleCreateDto, WorkloadRuleUpdateDto>
{
}
