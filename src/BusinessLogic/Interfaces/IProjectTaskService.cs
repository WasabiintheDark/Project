using CompanyWorkload.Domain.DTO.ProjectTasks;

namespace CompanyWorkload.BusinessLogic.Interfaces;

public interface IProjectTaskService : ICrudService<ProjectTaskReadDto, ProjectTaskCreateDto, ProjectTaskUpdateDto>
{
}
