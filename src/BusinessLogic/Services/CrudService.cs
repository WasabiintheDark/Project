using CompanyWorkload.BusinessLogic.Interfaces;
using CompanyWorkload.DataAccess.Interfaces;
using CompanyWorkload.DataAccess.Wrapper;

namespace CompanyWorkload.BusinessLogic.Services;

/// <summary>Базовый CRUD-сервис поверх IRepositoryBase</summary>
public abstract class CrudService<TEntity, TReadDto, TCreateDto, TUpdateDto>
    : ICrudService<TReadDto, TCreateDto, TUpdateDto>
    where TEntity : class
{
    private readonly IRepositoryBase<TEntity> _repository;
    private readonly IRepositoryWrapper _wrapper;

    protected CrudService(IRepositoryBase<TEntity> repository, IRepositoryWrapper wrapper)
    {
        _repository = repository;
        _wrapper = wrapper;
    }

    protected abstract TReadDto  MapToReadDto(TEntity entity);
    protected abstract TEntity   MapFromCreateDto(TCreateDto dto);
    protected abstract void      MapFromUpdateDto(TUpdateDto dto, TEntity entity);

    public async Task<IEnumerable<TReadDto>> GetAllAsync(CancellationToken ct = default)
    {
        var items = _repository.FindAll(false);
        return items.Select(MapToReadDto).ToList();
    }

    public async Task<TReadDto?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        var entity = await _repository.GetByIdAsync(id, ct);
        return entity == null ? default : MapToReadDto(entity);
    }

    public async Task<TReadDto> CreateAsync(TCreateDto dto, CancellationToken ct = default)
    {
        var entity = MapFromCreateDto(dto);
        await _repository.CreateAsync(entity, ct);
        await _wrapper.SaveAsync(ct);

        return MapToReadDto(entity);
    }

    public async Task<TReadDto?> UpdateAsync(int id, TUpdateDto dto, CancellationToken ct = default)
    {
        var entity = await _repository.GetByIdAsync(id, ct);
        if (entity == null)
            return default;

        MapFromUpdateDto(dto, entity);
        _repository.Update(entity);
        await _wrapper.SaveAsync(ct);

        return MapToReadDto(entity);
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
    {
        var entity = await _repository.GetByIdAsync(id, ct);
        if (entity == null)
            return false;

        _repository.Delete(entity);
        await _wrapper.SaveAsync(ct);
        return true;
    }
}
