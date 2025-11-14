using CompanyWorkload.DataAccess.Models;
using CompanyWorkload.Domain.Entities;

namespace CompanyWorkload.DataAccess.Repositories;

public class ProjectRepository : RepositoryBase<Project>, Interfaces.IProjectRepository
{
    public ProjectRepository(CompanyWorkloadDbContext db) : base(db) { }
}
