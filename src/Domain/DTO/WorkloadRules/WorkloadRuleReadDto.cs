namespace CompanyWorkload.Domain.DTO.WorkloadRules;

public record WorkloadRuleReadDto(
    int Id,
    string Name,
    decimal MaxAllocationPercent,
    string? Notes);
