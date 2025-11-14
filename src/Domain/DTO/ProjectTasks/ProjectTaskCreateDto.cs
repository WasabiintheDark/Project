namespace CompanyWorkload.Domain.DTO.ProjectTasks;

public record ProjectTaskCreateDto(
    int ProjectId,
    string Title,
    string? Description,
    decimal PlannedHours,
    System.DateTime? DueDate);
