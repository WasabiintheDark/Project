using System;

namespace CompanyWorkload.Domain.Entities;

/// <summary>Календарь рабочего времени</summary>
public class WorkCalendar
{
    public int Id         { get; set; }
    public int EmployeeId { get; set; }

    public DateTime WorkDay       { get; set; }
    public decimal? CapacityHours { get; set; } = 8m;
    public bool     IsHoliday     { get; set; }

    public Employee Employee { get; set; } = default!;
}
