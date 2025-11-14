using CompanyWorkload.Domain.DTO.Employees;

namespace CompanyWorkload.BusinessLogic.Interfaces;

public interface IEmployeeService : ICrudService<EmployeeReadDto, EmployeeCreateDto, EmployeeUpdateDto>
{
}
