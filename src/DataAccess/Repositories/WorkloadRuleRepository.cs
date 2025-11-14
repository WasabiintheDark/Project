using CompanyWorkload.DataAccess.Models;
using CompanyWorkload.Domain.Entities;

namespace CompanyWorkload.DataAccess.Repositories;

public class WorkloadRuleRepository : RepositoryBase<WorkloadRule>, Interfaces.IWorkloadRuleRepository
{
    public WorkloadRuleRepository(CompanyWorkloadDbContext db) : base(db) { }
}
