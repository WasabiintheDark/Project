using CompanyWorkload.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CompanyWorkload.Api.Controllers;

/// <summary>Базовый CRUD-контроллер, работающий через ICrudService</summary>
[ApiController]
public abstract class BaseCrudController<TReadDto, TCreateDto, TUpdateDto> : ControllerBase
{
    protected readonly ICrudService<TReadDto, TCreateDto, TUpdateDto> Service;

    protected BaseCrudController(ICrudService<TReadDto, TCreateDto, TUpdateDto> service)
    {
        Service = service;
    }

    /// <summary>Получить все записи</summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public virtual async Task<ActionResult<IEnumerable<TReadDto>>> GetAll(CancellationToken ct)
    {
        var items = await Service.GetAllAsync(ct);
        return Ok(items);
    }

    /// <summary>Получить запись по идентификатору</summary>
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public virtual async Task<ActionResult<TReadDto>> GetById(int id, CancellationToken ct)
    {
        var item = await Service.GetByIdAsync(id, ct);
        if (item is null)
            return NotFound();

        return Ok(item);
    }

    /// <summary>Создать новую запись</summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public virtual async Task<ActionResult<TReadDto>> Create([FromBody] TCreateDto dto, CancellationToken ct)
    {
        var created = await Service.CreateAsync(dto, ct);
        return CreatedAtAction(nameof(GetById), new { id = GetId(created) }, created);
    }

    /// <summary>Обновить запись</summary>
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public virtual async Task<ActionResult<TReadDto>> Update(int id, [FromBody] TUpdateDto dto, CancellationToken ct)
    {
        var updated = await Service.UpdateAsync(id, dto, ct);
        if (updated is null)
            return NotFound();

        return Ok(updated);
    }

    /// <summary>Удалить запись</summary>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public virtual async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        var ok = await Service.DeleteAsync(id, ct);
        if (!ok)
            return NotFound();

        return NoContent();
    }

    /// <summary>Рефлексия Id у TReadDto (ожидается свойство Id)</summary>
    private static int GetId(TReadDto dto)
    {
        var prop = typeof(TReadDto).GetProperty("Id");
        if (prop is null) return 0;
        var value = prop.GetValue(dto);
        return value is int i ? i : 0;
    }
}
