namespace CompanyWorkload.Domain.DTO.Planning;

/// <summary>Запрос на расчёт загрузки по датам</summary>
public record WorkloadQueryDto(System.DateOnly From, System.DateOnly To);
