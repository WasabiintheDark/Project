namespace CompanyWorkload.BusinessLogic.Interfaces;

/// <summary>Базовый CRUD-сервис для DTO</summary>
public interface ICrudService<TReadDto, in TCreateDto, in TUpdateDto>
{
    Task<IEnumerable<TReadDto>> GetAllAsync(CancellationToken ct = default);
    Task<TReadDto?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<TReadDto> CreateAsync(TCreateDto dto, CancellationToken ct = default);
    Task<TReadDto?> UpdateAsync(int id, TUpdateDto dto, CancellationToken ct = default);
    Task<bool> DeleteAsync(int id, CancellationToken ct = default);
}
