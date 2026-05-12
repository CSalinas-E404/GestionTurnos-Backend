using GestionTurnos.Application.Abstraction;
using GestionTurnos.Application.Abstraction.Infrastructure;
using GestionTurnos.Domain.Entities;

namespace GestionTurnos.Application.Services
{
    public class BusinessService : IBusinessService
    {
        private readonly IBusinessRepository _businessRepository;
        public BusinessService(IBusinessRepository businessRepository)
        {
            _businessRepository = businessRepository;
        }
        /*
         public List<Business> GetAll()
         {
             return _businesses;
         }

         public Business Create(Business business)
         {
             _businesses.Add(business);
             return business;
         }

         public bool Delete(Guid id)
         {
             var businessDeleted = _businesses.FirstOrDefault(x => x.Id == id);

             if (businessDeleted is null){
                 return false;
             } 

             _businesses.Remove(businessDeleted);
             return true;
         }

         public Business GetById(Guid id)
         {
             var businessById = _businesses.FirstOrDefault(x => x.Id == id);
             if(businessById is null)
             {
                 throw new NotImplementedException();
             }
             return businessById;
         }

         public Business Update(Guid id, string value)
         {
             return new Business();
         }*/
        public Business Create(Business business)
        {
            _businessRepository.Add(business);
            return business;
        }

        public bool Delete(Guid id)
        {

            _businessRepository.Delete(id);
            return true;
        }

        public List<Business> GetAll()
        {
            return _businessRepository.GetAll();
        }

        public Business GetById(Guid id)
        {

            return _businessRepository.GetById(id);
        }

        public void Update(Guid id, string value)
        {
           _businessRepository.Update(value);
        }
    }
}