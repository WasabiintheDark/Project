using CompanyWorkload.BusinessLogic.Interfaces;
using CompanyWorkload.DataAccess.Interfaces;
using CompanyWorkload.DataAccess.Wrapper;
using CompanyWorkload.Domain.DTO.Employees;
using CompanyWorkload.Domain.Entities;

namespace CompanyWorkload.BusinessLogic.Services;

public class EmployeeService
    : CrudService<Employee, EmployeeReadDto, EmployeeCreateDto, EmployeeUpdateDto>,
      IEmployeeService
{
    public EmployeeService(IEmployeeRepository repository, IRepositoryWrapper wrapper)
        : base(repository, wrapper)
    {
    }

    protected override EmployeeReadDto MapToReadDto(Employee e) =>
        new(e.Id, e.FirstName, e.LastName, e.Email, e.Phone, e.HireDate, e.DepartmentId, e.PositionId);
protected override Employee MapFromCreateDto(EmployeeCreateDto dto) =>
    new()
    {
        FirstName    = dto.FirstName,
        LastName     = dto.LastName,
        Email        = dto.Email,
        Phone        = dto.Phone,
        HireDate     = DateTime.SpecifyKind(dto.HireDate, DateTimeKind.Utc),
        DepartmentId = dto.DepartmentId,
        PositionId   = dto.PositionId
    };

protected override void MapFromUpdateDto(EmployeeUpdateDto dto, Employee e)
{
    e.FirstName    = dto.FirstName;
    e.LastName     = dto.LastName;
    e.Email        = dto.Email;
    e.Phone        = dto.Phone;
    e.HireDate     = DateTime.SpecifyKind(dto.HireDate, DateTimeKind.Utc);
    e.DepartmentId = dto.DepartmentId;
    e.PositionId   = dto.PositionId;
}

}
