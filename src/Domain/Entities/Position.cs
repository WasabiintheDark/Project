using System.Collections.Generic;

namespace CompanyWorkload.Domain.Entities;

/// <summary>Должность</summary>
public class Position
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
