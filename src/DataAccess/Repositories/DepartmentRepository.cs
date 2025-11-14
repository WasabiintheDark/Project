using CompanyWorkload.DataAccess.Interfaces;      // 👈 ЭТО ГЛАВНОЕ
using CompanyWorkload.DataAccess.Models;
using CompanyWorkload.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyWorkload.DataAccess.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly CompanyWorkloadDbContext _context;

        public DepartmentRepository(CompanyWorkloadDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            return await _context.Departments
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Department?> GetByIdAsync(int id)
        {
            return await _context.Departments.FindAsync(id);
        }

        public async Task CreateAsync(Department entity)
        {
            await _context.Departments.AddAsync(entity);
        }

        public void Update(Department entity)
        {
            _context.Departments.Update(entity);
        }

        public void Delete(Department entity)
        {
            _context.Departments.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
