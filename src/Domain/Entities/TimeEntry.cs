using System;

namespace CompanyWorkload.Domain.Entities;

/// <summary>Факт-учёт времени</summary>
public class TimeEntry
{
    public int Id         { get; set; }
    public int EmployeeId { get; set; }
    public int TaskId     { get; set; }

    public decimal SpentHours { get; set; }
    public DateTime EntryDate { get; set; }

    public Employee   Employee { get; set; } = default!;
    public ProjectTask Task    { get; set; } = default!;
}
