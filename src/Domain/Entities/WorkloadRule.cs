namespace CompanyWorkload.Domain.Entities;

/// <summary>Правило загрузки</summary>
public class WorkloadRule
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public decimal MaxAllocationPercent { get; set; } = 100m;
    public string? Notes { get; set; }
}
