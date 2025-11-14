using CompanyWorkload.BusinessLogic.Interfaces;
using CompanyWorkload.DataAccess.Interfaces;
using CompanyWorkload.DataAccess.Wrapper;
using CompanyWorkload.Domain.DTO.Assignments;
using CompanyWorkload.Domain.Entities;

namespace CompanyWorkload.BusinessLogic.Services;

public class AssignmentService
    : CrudService<Assignment, AssignmentReadDto, AssignmentCreateDto, AssignmentUpdateDto>,
      IAssignmentService
{
    public AssignmentService(IAssignmentRepository repository, IRepositoryWrapper wrapper)
        : base(repository, wrapper)
    {
    }

    protected override AssignmentReadDto MapToReadDto(Assignment a) =>
        new(a.Id, a.TaskId, a.EmployeeId, a.AllocationPercent, a.StartDate, a.EndDate);

    protected override Assignment MapFromCreateDto(AssignmentCreateDto dto) =>
        new()
        {
            TaskId            = dto.TaskId,
            EmployeeId        = dto.EmployeeId,
            AllocationPercent = dto.AllocationPercent,
            StartDate         = dto.StartDate,
            EndDate           = dto.EndDate
        };

    protected override void MapFromUpdateDto(AssignmentUpdateDto dto, Assignment a)
    {
        a.AllocationPercent = dto.AllocationPercent;
        a.StartDate         = dto.StartDate;
        a.EndDate           = dto.EndDate;
    }
}
