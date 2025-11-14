using CompanyWorkload.BusinessLogic.Interfaces;
using CompanyWorkload.DataAccess.Interfaces;
using CompanyWorkload.Domain.DTO.Departments;
using CompanyWorkload.Domain.Entities;

namespace CompanyWorkload.BusinessLogic.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentService(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<DepartmentReadDto>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return list.Select(d => new DepartmentReadDto(d.Id, d.Name));
        }

        public async Task<DepartmentReadDto?> GetByIdAsync(int id)
        {
            var dep = await _repository.GetByIdAsync(id);
            return dep == null ? null : new DepartmentReadDto(dep.Id, dep.Name);
        }

        public async Task<DepartmentReadDto> CreateAsync(DepartmentCreateDto dto)
        {
            var entity = new Department { Name = dto.Name };

            await _repository.CreateAsync(entity);
            await _repository.SaveChangesAsync();

            return new DepartmentReadDto(entity.Id, entity.Name);
        }

        public async Task<bool> UpdateAsync(int id, DepartmentUpdateDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return false;

            entity.Name = dto.Name;

            _repository.Update(entity);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return false;

            _repository.Delete(entity);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
