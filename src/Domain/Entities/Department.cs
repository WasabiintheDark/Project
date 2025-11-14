using System.Collections.Generic;

namespace CompanyWorkload.Domain.Entities;

/// <summary>Подразделение</summary>
public class Department
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
