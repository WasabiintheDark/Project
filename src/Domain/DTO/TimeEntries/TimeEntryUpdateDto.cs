namespace CompanyWorkload.Domain.DTO.TimeEntries;

public record TimeEntryUpdateDto(
    decimal SpentHours,
    System.DateTime EntryDate);
