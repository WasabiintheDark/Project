namespace CompanyWorkload.Domain.DTO.ProjectTasks;

public record ProjectTaskReadDto(
    int Id,
    int ProjectId,
    string Title,
    string? Description,
    decimal PlannedHours,
    System.DateTime? DueDate);
