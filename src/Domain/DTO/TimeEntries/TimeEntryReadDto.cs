namespace CompanyWorkload.Domain.DTO.TimeEntries;

public record TimeEntryReadDto(
    int Id,
    int EmployeeId,
    int TaskId,
    decimal SpentHours,
    System.DateTime EntryDate);
