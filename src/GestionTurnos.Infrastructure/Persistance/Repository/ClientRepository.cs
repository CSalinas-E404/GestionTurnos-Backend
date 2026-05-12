using GestionTurnos.Application.Abstraction.Infrastructure;
using GestionTurnos.Domain.Entities;

namespace GestionTurnos.Infrastructure.Persistance.Repository
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(FMCTurnosDbContext context) : base(context)
        {
        }
        public List<Client> GetClientsOfBusiness(Guid businessId)
        {
            return _dbSet.Where(x => x.BusinessId == businessId && !x.IsDeleted).ToList();
        }
    }
}
