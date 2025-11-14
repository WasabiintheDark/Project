namespace CompanyWorkload.Domain.DTO.WorkCalendars;

public record WorkCalendarCreateDto(
    int EmployeeId,
    System.DateTime WorkDay,
    decimal? CapacityHours,
    bool IsHoliday);
