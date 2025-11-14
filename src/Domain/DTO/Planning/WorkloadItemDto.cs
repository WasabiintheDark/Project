namespace CompanyWorkload.Domain.DTO.Planning;

/// <summary>Загрузка сотрудника по дням</summary>
public record WorkloadItemDto(
    System.DateOnly Date,
    int EmployeeId,
    decimal PlannedHours,
    decimal CapacityHours);
