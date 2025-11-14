using CompanyWorkload.DataAccess.Models;
using CompanyWorkload.Domain.Entities;

namespace CompanyWorkload.DataAccess.Repositories;

public class EmployeeRepository : RepositoryBase<Employee>, Interfaces.IEmployeeRepository
{
    public EmployeeRepository(CompanyWorkloadDbContext db) : base(db) { }
}
