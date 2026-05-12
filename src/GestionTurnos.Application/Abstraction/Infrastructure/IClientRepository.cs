using GestionTurnos.Domain.Entities;

namespace GestionTurnos.Application.Abstraction.Infrastructure
{
    public interface IClientRepository : IBaseRepository<Client>
    {
        List<Client> GetClientsOfBusiness(Guid businessId);
    }
}
