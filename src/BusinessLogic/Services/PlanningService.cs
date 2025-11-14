using CompanyWorkload.BusinessLogic.Interfaces;
using CompanyWorkload.DataAccess.Wrapper;
using CompanyWorkload.Domain.DTO.Planning;
using CompanyWorkload.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyWorkload.BusinessLogic.Services;

/// <summary>
/// Сервис планирования: простой пример автоназначения и расчёта загрузки.
/// Не претендует на идеальный алгоритм, главное — структура.
/// </summary>
public class PlanningService : IPlanningService
{
    private readonly IRepositoryWrapper _repos;

    public PlanningService(IRepositoryWrapper repos)
    {
        _repos = repos;
    }

    public async Task<AutoAssignResultDto> AutoAssignAsync(AutoAssignRequest request, CancellationToken ct = default)
    {
        // Берём все задачи проекта без назначений
        var tasks = _repos.ProjectTasks
            .FindByCondition(t => t.ProjectId == request.ProjectId, trackChanges: true)
            .Include(t => t.Assignments)
            .ToList();

        var employees = _repos.Employees.FindAll().ToList();

        var created = new List<(int TaskId, int EmployeeId, decimal AllocationPercent)>();

        foreach (var task in tasks.Where(t => !t.Assignments.Any()))
        {
            var employee = employees.FirstOrDefault();
            if (employee == null)
                break;

            var assignment = new Assignment
            {
                TaskId            = task.Id,
                EmployeeId        = employee.Id,
                AllocationPercent = 50m,
                StartDate         = request.StartDate,
                EndDate           = request.EndDate
            };

            await _repos.Assignments.CreateAsync(assignment, ct);
            created.Add((task.Id, employee.Id, assignment.AllocationPercent));
        }

        await _repos.SaveAsync(ct);

        return new AutoAssignResultDto(created.Count, created);
    }

    public async Task<IEnumerable<WorkloadItemDto>> GetWorkloadAsync(WorkloadQueryDto query, CancellationToken ct = default)
    {
        var from = query.From;
        var to   = query.To;

        // Простая модель: считаем суммарные плановые часы по календарю
        var calendars = _repos.WorkCalendars
            .FindByCondition(w => w.WorkDay >= from.ToDateTime(TimeOnly.MinValue)
                               && w.WorkDay <= to.ToDateTime(TimeOnly.MaxValue), false)
            .ToList();

        var result = calendars.Select(c => new WorkloadItemDto(
            Date: System.DateOnly.FromDateTime(c.WorkDay),
            EmployeeId: c.EmployeeId,
            PlannedHours: 0m,               // здесь можно навесить расчёт по Assignments, если нужно
            CapacityHours: c.CapacityHours ?? 0m
        ));

        return result.ToList();
    }
}
