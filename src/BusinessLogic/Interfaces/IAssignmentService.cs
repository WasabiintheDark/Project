using CompanyWorkload.Domain.DTO.Assignments;

namespace CompanyWorkload.BusinessLogic.Interfaces;

public interface IAssignmentService : ICrudService<AssignmentReadDto, AssignmentCreateDto, AssignmentUpdateDto>
{
}
