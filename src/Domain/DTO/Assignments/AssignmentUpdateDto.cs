namespace CompanyWorkload.Domain.DTO.Assignments;

public record AssignmentUpdateDto(
    decimal AllocationPercent,
    System.DateTime StartDate,
    System.DateTime EndDate);
