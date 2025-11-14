using CompanyWorkload.DataAccess.Models;
using CompanyWorkload.Domain.Entities;

namespace CompanyWorkload.DataAccess.Repositories;

public class PositionRepository : RepositoryBase<Position>, Interfaces.IPositionRepository
{
    public PositionRepository(CompanyWorkloadDbContext db) : base(db) { }
}
