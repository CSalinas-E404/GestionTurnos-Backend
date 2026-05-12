using GestionTurnos.Domain.Entities;

namespace GestionTurnos.Application.Abstraction
{
    public interface IClientService 
    {
        public List<Client> GetAll();

        public List<Client> GetClientsOfBusiness(Guid businessId);
        public Client GetById(Guid id);

        public Client CreateClient(Client client);

        public void UpdateClient(Client client);
        public void DeleteClient(Guid id);
    }
}
