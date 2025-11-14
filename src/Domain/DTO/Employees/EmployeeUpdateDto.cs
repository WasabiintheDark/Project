namespace CompanyWorkload.Domain.DTO.Employees;

public record EmployeeUpdateDto(
    string FirstName,
    string LastName,
    string Email,
    string? Phone,
    System.DateTime HireDate,
    int DepartmentId,
    int PositionId);
