using CompanyWorkload.Domain.Enums;

namespace CompanyWorkload.Domain.DTO.Projects;

public record ProjectUpdateDto(
    string Name,
    System.DateTime StartDate,
    System.DateTime? EndDate,
    ProjectStatus Status);
