namespace CompanyWorkload.Domain.Entities;

/// <summary>Навык сотрудника (многие-ко-многим)</summary>
public class EmployeeSkill
{
    public int EmployeeId { get; set; }
    public int SkillId    { get; set; }

    /// <summary>Уровень 1..5</summary>
    public int Level { get; set; }

    public Employee Employee { get; set; } = default!;
    public Skill    Skill    { get; set; } = default!;
}
