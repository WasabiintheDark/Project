using CompanyWorkload.BusinessLogic.Interfaces;
using CompanyWorkload.Domain.DTO.Projects;
using Microsoft.AspNetCore.Mvc;

namespace CompanyWorkload.Api.Controllers;

/// <summary>CRUD по проектам</summary>
[Route("api/[controller]")]
public class ProjectsController : BaseCrudController<ProjectReadDto, ProjectCreateDto, ProjectUpdateDto>
{
    public ProjectsController(IProjectService service) : base(service)
    {
    }
}
