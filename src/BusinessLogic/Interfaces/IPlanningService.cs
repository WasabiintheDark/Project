using CompanyWorkload.Domain.DTO.Planning;

namespace CompanyWorkload.BusinessLogic.Interfaces;

public interface IPlanningService
{
    Task<AutoAssignResultDto> AutoAssignAsync(AutoAssignRequest request, CancellationToken ct = default);
    Task<IEnumerable<WorkloadItemDto>> GetWorkloadAsync(WorkloadQueryDto query, CancellationToken ct = default);
}
