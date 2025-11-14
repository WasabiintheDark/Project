using CompanyWorkload.BusinessLogic.Interfaces;
using CompanyWorkload.Domain.DTO.ProjectTasks;
using Microsoft.AspNetCore.Mvc;

namespace CompanyWorkload.Api.Controllers;

/// <summary>CRUD по задачам проектов</summary>
[Route("api/[controller]")]
public class ProjectTasksController : BaseCrudController<ProjectTaskReadDto, ProjectTaskCreateDto, ProjectTaskUpdateDto>
{
    public ProjectTasksController(IProjectTaskService service) : base(service)
    {
    }
}
