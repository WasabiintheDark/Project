using System;

namespace CompanyWorkload.Domain.Entities;

/// <summary>Праздничный день</summary>
public class Holiday
{
    public int Id      { get; set; }
    public DateTime Day { get; set; }
    public string Name { get; set; } = default!;
}
