using GestionTurnos.Application.Abstraction;
using GestionTurnos.Application.Abstraction.Infrastructure;
using GestionTurnos.Application.Mapper;
using GestionTurnos.Application.Response;
using GestionTurnos.Domain.Entities;
using System.Linq;

namespace GestionTurnos.Application.Services
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository _branchRepository;

        public BranchService(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public List<BranchResponse> GetByBusinessId( Guid businessId)
        {
            return _branchRepository.GetByBusinessId(businessId)
                .OrderBy(x => x.Name)
                .Select(x => x.ToBranchResponse())
                .ToList();
        }
    }
}
