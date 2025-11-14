namespace CompanyWorkload.Domain.DTO.Holidays;

public record HolidayReadDto(
    int Id,
    System.DateTime Day,
    string Name);
