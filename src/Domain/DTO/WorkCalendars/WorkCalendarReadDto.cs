namespace CompanyWorkload.Domain.DTO.WorkCalendars;

public record WorkCalendarReadDto(
    int Id,
    int EmployeeId,
    System.DateTime WorkDay,
    decimal? CapacityHours,
    bool IsHoliday);
