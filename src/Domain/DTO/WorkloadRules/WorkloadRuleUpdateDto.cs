namespace CompanyWorkload.Domain.DTO.WorkloadRules;

public record WorkloadRuleUpdateDto(
    string Name,
    decimal MaxAllocationPercent,
    string? Notes);
