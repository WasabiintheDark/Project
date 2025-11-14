using CompanyWorkload.BusinessLogic.Interfaces;
using CompanyWorkload.Domain.DTO.Assignments;
using Microsoft.AspNetCore.Mvc;

namespace CompanyWorkload.Api.Controllers;

/// <summary>CRUD по назначениям на задачи</summary>
[Route("api/[controller]")]
public class AssignmentsController : BaseCrudController<AssignmentReadDto, AssignmentCreateDto, AssignmentUpdateDto>
{
    public AssignmentsController(IAssignmentService service) : base(service)
    {
    }
}
