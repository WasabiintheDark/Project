using CompanyWorkload.DataAccess.Models;
using CompanyWorkload.Domain.Entities;

namespace CompanyWorkload.DataAccess.Repositories;

public class SkillRepository : RepositoryBase<Skill>, Interfaces.ISkillRepository
{
    public SkillRepository(CompanyWorkloadDbContext db) : base(db) { }
}
