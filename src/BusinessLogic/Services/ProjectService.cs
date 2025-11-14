using CompanyWorkload.BusinessLogic.Interfaces;
using CompanyWorkload.DataAccess.Interfaces;
using CompanyWorkload.DataAccess.Wrapper;
using CompanyWorkload.Domain.DTO.Projects;
using CompanyWorkload.Domain.Entities;

namespace CompanyWorkload.BusinessLogic.Services;

public class ProjectService
    : CrudService<Project, ProjectReadDto, ProjectCreateDto, ProjectUpdateDto>,
      IProjectService
{
    public ProjectService(IProjectRepository repository, IRepositoryWrapper wrapper)
        : base(repository, wrapper)
    {
    }

    protected override ProjectReadDto MapToReadDto(Project p) =>
        new(p.Id, p.Name, p.StartDate, p.EndDate, p.Status);

    protected override Project MapFromCreateDto(ProjectCreateDto dto) =>
        new()
        {
            Name      = dto.Name,
            StartDate = dto.StartDate,
            EndDate   = dto.EndDate,
            Status    = dto.Status
        };

    protected override void MapFromUpdateDto(ProjectUpdateDto dto, Project p)
    {
        p.Name      = dto.Name;
        p.StartDate = dto.StartDate;
        p.EndDate   = dto.EndDate;
        p.Status    = dto.Status;
    }
}
