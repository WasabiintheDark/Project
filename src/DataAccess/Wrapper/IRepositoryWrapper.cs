using CompanyWorkload.DataAccess.Interfaces;

namespace CompanyWorkload.DataAccess.Wrapper;

public interface IRepositoryWrapper
{
    IEmployeeRepository      Employees      { get; }
    IDepartmentRepository    Departments    { get; }
    IPositionRepository      Positions      { get; }
    ISkillRepository         Skills         { get; }
    IEmployeeSkillRepository EmployeeSkills { get; }
    IProjectRepository       Projects       { get; }
    IProjectTaskRepository   ProjectTasks   { get; }
    IAssignmentRepository    Assignments    { get; }
    IWorkCalendarRepository  WorkCalendars  { get; }
    IHolidayRepository       Holidays       { get; }
    IWorkloadRuleRepository  WorkloadRules  { get; }
    ITimeEntryRepository     TimeEntries    { get; }

    Task<int> SaveAsync(CancellationToken ct = default);
}
