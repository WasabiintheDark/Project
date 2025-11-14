using System;
using System.Collections.Generic;

namespace CompanyWorkload.Domain.Entities;

/// <summary>Задача проекта</summary>
public class ProjectTask
{
    public int Id        { get; set; }
    public int ProjectId { get; set; }

    public string  Title       { get; set; } = default!;
    public string? Description { get; set; }

    public decimal  PlannedHours { get; set; }
    public DateTime? DueDate     { get; set; }

    public Project Project { get; set; } = default!;
    public ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();
    public ICollection<TimeEntry>  TimeEntries { get; set; } = new List<TimeEntry>();
}
