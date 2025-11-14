using CompanyWorkload.DataAccess.Models;
using CompanyWorkload.Domain.Entities;

namespace CompanyWorkload.DataAccess.Repositories;

public class ProjectTaskRepository : RepositoryBase<ProjectTask>, Interfaces.IProjectTaskRepository
{
    public ProjectTaskRepository(CompanyWorkloadDbContext db) : base(db) { }
}
