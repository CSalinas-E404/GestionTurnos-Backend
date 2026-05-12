

using GestionTurnos.Application.Request;
using GestionTurnos.Domain.Entities;

namespace GestionTurnos.Application.Abstraction
{
    public interface IStaffService
    {
        public List<Staff> GetAll();
        public Staff GetById(Guid id);

        public Staff CreateStaffWhitBusiness(BusinessRequest request);

        public Staff CreateStaff(BusinessRequest request, Guid id_Business); 

        public Staff UpdateStaff(Staff user, Rol? rol);
        public void DeleteStaff(Guid id);

    }
}
