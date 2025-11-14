using CompanyWorkload.Domain.Entities;

namespace CompanyWorkload.DataAccess.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllAsync();
        Task<Department?> GetByIdAsync(int id);
        Task CreateAsync(Department entity);
        void Update(Department entity);
        void Delete(Department entity);

        Task SaveChangesAsync();
    }
}
