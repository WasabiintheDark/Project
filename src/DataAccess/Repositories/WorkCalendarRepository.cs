using CompanyWorkload.DataAccess.Models;
using CompanyWorkload.Domain.Entities;

namespace CompanyWorkload.DataAccess.Repositories;

public class WorkCalendarRepository : RepositoryBase<WorkCalendar>, Interfaces.IWorkCalendarRepository
{
    public WorkCalendarRepository(CompanyWorkloadDbContext db) : base(db) { }
}
