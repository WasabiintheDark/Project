namespace CompanyWorkload.Domain.DTO.Assignments;

public record AssignmentReadDto(
    int Id,
    int TaskId,
    int EmployeeId,
    decimal AllocationPercent,
    System.DateTime StartDate,
    System.DateTime EndDate);
