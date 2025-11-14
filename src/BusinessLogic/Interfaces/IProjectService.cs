using CompanyWorkload.Domain.DTO.Projects;

namespace CompanyWorkload.BusinessLogic.Interfaces;

public interface IProjectService : ICrudService<ProjectReadDto, ProjectCreateDto, ProjectUpdateDto>
{
}
