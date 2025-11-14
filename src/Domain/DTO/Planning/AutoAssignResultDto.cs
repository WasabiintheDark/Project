using System.Collections.Generic;

namespace CompanyWorkload.Domain.DTO.Planning;

/// <summary>Результат автораспределения</summary>
public record AutoAssignResultDto(
    int CreatedCount,
    IEnumerable<(int TaskId, int EmployeeId, decimal AllocationPercent)> Created);
