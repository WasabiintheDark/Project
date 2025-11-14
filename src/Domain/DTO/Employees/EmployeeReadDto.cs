namespace CompanyWorkload.Domain.DTO.Employees;

public record EmployeeReadDto(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    string? Phone,
    System.DateTime HireDate,
    int DepartmentId,
    int PositionId);
