using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CompanyWorkload.Domain.Entities;

/// <summary>Сотрудник</summary>
public class Employee
{
    public int Id { get; set; }

    [MaxLength(100)] public string FirstName { get; set; } = default!;
    [MaxLength(100)] public string LastName  { get; set; } = default!;
    [MaxLength(256)] public string Email     { get; set; } = default!;
    [MaxLength(30)]  public string? Phone    { get; set; }
    public DateTime HireDate { get; set; }

    public int DepartmentId { get; set; }
    public int PositionId   { get; set; }

    public Department Department { get; set; } = default!;
    public Position   Position   { get; set; } = default!;

    public ICollection<EmployeeSkill> Skills        { get; set; } = new List<EmployeeSkill>();
    public ICollection<Assignment>    Assignments   { get; set; } = new List<Assignment>();
    public ICollection<WorkCalendar>  WorkCalendars { get; set; } = new List<WorkCalendar>();
    public ICollection<TimeEntry>     TimeEntries   { get; set; } = new List<TimeEntry>();
}
