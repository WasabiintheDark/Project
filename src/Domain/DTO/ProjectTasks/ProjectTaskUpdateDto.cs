namespace CompanyWorkload.Domain.DTO.ProjectTasks;

public record ProjectTaskUpdateDto(
    string Title,
    string? Description,
    decimal PlannedHours,
    System.DateTime? DueDate);
