using CompanyWorkload.BusinessLogic.Interfaces;
using CompanyWorkload.DataAccess.Interfaces;
using CompanyWorkload.DataAccess.Wrapper;
using CompanyWorkload.Domain.DTO.ProjectTasks;
using CompanyWorkload.Domain.Entities;

namespace CompanyWorkload.BusinessLogic.Services;

public class ProjectTaskService
    : CrudService<ProjectTask, ProjectTaskReadDto, ProjectTaskCreateDto, ProjectTaskUpdateDto>,
      IProjectTaskService
{
    public ProjectTaskService(IProjectTaskRepository repository, IRepositoryWrapper wrapper)
        : base(repository, wrapper)
    {
    }

    protected override ProjectTaskReadDto MapToReadDto(ProjectTask t) =>
        new(t.Id, t.ProjectId, t.Title, t.Description, t.PlannedHours, t.DueDate);

    protected override ProjectTask MapFromCreateDto(ProjectTaskCreateDto dto) =>
        new()
        {
            ProjectId     = dto.ProjectId,
            Title         = dto.Title,
            Description   = dto.Description,
            PlannedHours  = dto.PlannedHours,
            DueDate       = dto.DueDate
        };

    protected override void MapFromUpdateDto(ProjectTaskUpdateDto dto, ProjectTask t)
    {
        t.Title        = dto.Title;
        t.Description  = dto.Description;
        t.PlannedHours = dto.PlannedHours;
        t.DueDate      = dto.DueDate;
    }
}
