using CompanyWorkload.DataAccess.Models;
using CompanyWorkload.Domain.Entities;

namespace CompanyWorkload.DataAccess.Repositories;

public class HolidayRepository : RepositoryBase<Holiday>, Interfaces.IHolidayRepository
{
    public HolidayRepository(CompanyWorkloadDbContext db) : base(db) { }
}