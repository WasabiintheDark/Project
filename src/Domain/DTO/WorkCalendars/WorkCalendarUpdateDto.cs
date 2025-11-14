namespace CompanyWorkload.Domain.DTO.WorkCalendars;

public record WorkCalendarUpdateDto(
    System.DateTime WorkDay,
    decimal? CapacityHours,
    bool IsHoliday);
