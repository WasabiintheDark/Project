namespace CompanyWorkload.Domain.DTO.WorkloadRules;

public record WorkloadRuleCreateDto(
    string Name,
    decimal MaxAllocationPercent,
    string? Notes);
