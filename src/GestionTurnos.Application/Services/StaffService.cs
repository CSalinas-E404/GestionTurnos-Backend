using GestionTurnos.Application.Abstraction;
using GestionTurnos.Application.Abstraction.Infrastructure;
using GestionTurnos.Application.Request;
using GestionTurnos.Domain.Entities;

namespace GestionTurnos.Application.Services
{
    public class StaffService : IStaffService
    {

        private readonly IStaffRepository _staffRepository;
        private readonly IBusinessRepository _businessRepository;
        public StaffService(IStaffRepository staffRepository, IBusinessRepository businessRepository)
        {
            _staffRepository = staffRepository;
            _businessRepository = businessRepository;
        }      
         public Staff CreateStaff(BusinessRequest request, Guid id_Business)
         {

             var newStaff = new Staff
             {
                 Id = Guid.NewGuid(),
                 Name = request.Name,
                 Email = request.Email,
                 Password = request.Password,
                 Phone = request.Phone,
                 Rol = request.Rol,
                 LinkPhoto = request.LinkPhoto,
                 BusinessId = id_Business,

             };

             _staffRepository.Add(newStaff);
             return newStaff;
         }

         public Staff CreateStaffWhitBusiness(BusinessRequest request)
         {

             var newBusiness = new Business
             {
                 Id = Guid.NewGuid(),
                 Name = $"{request.Name} - {request.BusinessCategory}",
                 Url = $"http://www.{request.Name.Replace(" ", "")}.FCMTurniFy.com"
             };

             var newUser = new Staff
             {
                 Id = Guid.NewGuid(),
                 Name = request.Name,
                 Email = request.Email,
                 Password = request.Password,
                 Phone = request.Phone,
                 Rol = request.Rol,
                 LinkPhoto = request.LinkPhoto,
                 BusinessId = newBusiness.Id,
                 Business = newBusiness
             };

             _staffRepository.Add(newUser);
            _businessRepository.Add(newBusiness);

            return newUser;
         }


         public void DeleteStaff(Guid id)
         {
            var User = _staffRepository.GetById(id) ?? throw new Exception("Usuario no encontrado");
            _staffRepository.Delete(id);
         }
         public List<Staff> GetAll()
         {
             return _staffRepository.GetAll();
         }

         public Staff? GetById(Guid id)
         {
            var existingUser = _staffRepository.GetById(id) ?? throw new Exception("Usuario no encontrado");

            return _staffRepository.GetById(id);
         }

         public Staff UpdateStaff(Staff user, Rol? rol)
         {
            var existingUser = _staffRepository.GetById(user.Id) ?? throw new Exception("Usuario no encontrado");
  
                 existingUser.Name = user.Name;
                 existingUser.Email = user.Email;
                 existingUser.Phone = user.Phone;
                 existingUser.LinkPhoto = user.LinkPhoto;

                 if (rol.HasValue)
                 {
                     existingUser.Rol = rol.Value;
                 }

                 return existingUser;
        
         }
       
    }
}