namespace CompanyWorkload.Domain.DTO.TimeEntries;

public record TimeEntryCreateDto(
    int EmployeeId,
    int TaskId,
    decimal SpentHours,
    System.DateTime EntryDate);
