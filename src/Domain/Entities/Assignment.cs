using System;

namespace CompanyWorkload.Domain.Entities;

/// <summary>Назначение сотрудника на задачу</summary>
public class Assignment
{
    public int Id         { get; set; }
    public int TaskId     { get; set; }
    public int EmployeeId { get; set; }

    /// <summary>Доля занятости, %</summary>
    public decimal AllocationPercent { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate   { get; set; }

    public ProjectTask Task  { get; set; } = default!;
    public Employee   Employee { get; set; } = default!;
}
