using System;
using System.Collections.Generic;
using CompanyWorkload.Domain.Enums;

namespace CompanyWorkload.Domain.Entities;

/// <summary>Проект</summary>
public class Project
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;

    public DateTime StartDate { get; set; }
    public DateTime? EndDate  { get; set; }

    public ProjectStatus Status { get; set; } = ProjectStatus.Planned;

    public ICollection<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();
}
