using CompanyWorkload.DataAccess.Models;
using CompanyWorkload.Domain.Entities;

namespace CompanyWorkload.DataAccess.Repositories;

public class AssignmentRepository : RepositoryBase<Assignment>, Interfaces.IAssignmentRepository
{
    public AssignmentRepository(CompanyWorkloadDbContext db) : base(db) { }
}
