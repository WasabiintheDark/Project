using CompanyWorkload.DataAccess.Models;
using CompanyWorkload.Domain.Entities;

namespace CompanyWorkload.DataAccess.Repositories;

public class TimeEntryRepository : RepositoryBase<TimeEntry>, Interfaces.ITimeEntryRepository
{
    public TimeEntryRepository(CompanyWorkloadDbContext db) : base(db) { }
}
