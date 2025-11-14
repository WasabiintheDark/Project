using CompanyWorkload.DataAccess.Interfaces;
using CompanyWorkload.DataAccess.Models;

namespace CompanyWorkload.DataAccess.Wrapper;

public class RepositoryWrapper : IRepositoryWrapper
{
    private readonly CompanyWorkloadDbContext _db;

    public RepositoryWrapper(
        CompanyWorkloadDbContext db,
        IEmployeeRepository employees,
        IDepartmentRepository departments,
        IPositionRepository positions,
        ISkillRepository skills,
        IEmployeeSkillRepository employeeSkills,
        IProjectRepository projects,
        IProjectTaskRepository projectTasks,
        IAssignmentRepository assignments,
        IWorkCalendarRepository workCalendars,
        IHolidayRepository holidays,
        IWorkloadRuleRepository workloadRules,
        ITimeEntryRepository timeEntries)
    {
        _db = db;
        Employees      = employees;
        Departments    = departments;
        Positions      = positions;
        Skills         = skills;
        EmployeeSkills = employeeSkills;
        Projects       = projects;
        ProjectTasks   = projectTasks;
        Assignments    = assignments;
        WorkCalendars  = workCalendars;
        Holidays       = holidays;
        WorkloadRules  = workloadRules;
        TimeEntries    = timeEntries;
    }

    public IEmployeeRepository      Employees      { get; }
    public IDepartmentRepository    Departments    { get; }
    public IPositionRepository      Positions      { get; }
    public ISkillRepository         Skills         { get; }
    public IEmployeeSkillRepository EmployeeSkills { get; }
    public IProjectRepository       Projects       { get; }
    public IProjectTaskRepository   ProjectTasks   { get; }
    public IAssignmentRepository    Assignments    { get; }
    public IWorkCalendarRepository  WorkCalendars  { get; }
    public IHolidayRepository       Holidays       { get; }
    public IWorkloadRuleRepository  WorkloadRules  { get; }
    public ITimeEntryRepository     TimeEntries    { get; }

    public Task<int> SaveAsync(CancellationToken ct = default) =>
        _db.SaveChangesAsync(ct);
}
