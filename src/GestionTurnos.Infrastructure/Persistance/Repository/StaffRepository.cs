using GestionTurnos.Application.Abstraction.Infrastructure;
using GestionTurnos.Domain.Entities;

namespace GestionTurnos.Infrastructure.Persistance.Repository
{
    public class StaffRepository : BaseRepository<Staff>, IStaffRepository
        {
            public StaffRepository(FMCTurnosDbContext context) : base(context)
            {
            }
        }
       
    
}
