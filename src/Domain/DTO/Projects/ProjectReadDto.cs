using CompanyWorkload.Domain.Enums;

namespace CompanyWorkload.Domain.DTO.Projects;

public record ProjectReadDto(
    int Id,
    string Name,
    System.DateTime StartDate,
    System.DateTime? EndDate,
    ProjectStatus Status);
