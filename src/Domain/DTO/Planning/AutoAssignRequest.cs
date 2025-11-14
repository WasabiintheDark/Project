namespace CompanyWorkload.Domain.DTO.Planning;

/// <summary>Запрос на автораспределение задач проекта</summary>
public class AutoAssignRequest
{
    public int ProjectId { get; set; }
    public System.DateTime StartDate { get; set; }
    public System.DateTime EndDate { get; set; }
}
