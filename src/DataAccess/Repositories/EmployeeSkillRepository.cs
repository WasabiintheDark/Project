using CompanyWorkload.DataAccess.Models;
using CompanyWorkload.Domain.Entities;

namespace CompanyWorkload.DataAccess.Repositories;

public class EmployeeSkillRepository : RepositoryBase<EmployeeSkill>, Interfaces.IEmployeeSkillRepository
{
    public EmployeeSkillRepository(CompanyWorkloadDbContext db) : base(db) { }
}
