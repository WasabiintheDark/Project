namespace CompanyWorkload.Domain.DTO.Assignments;

public record AssignmentCreateDto(
    int TaskId,
    int EmployeeId,
    decimal AllocationPercent,
    System.DateTime StartDate,
    System.DateTime EndDate);
