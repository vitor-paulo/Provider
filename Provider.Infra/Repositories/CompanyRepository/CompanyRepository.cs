using Provider.Domain.Entities;
using Provider.Domain.Interfaces;
using Provider.Infra.Context;
using Provider.Infra.Repositories.GenericRepository;

namespace Provider.Infra.Repositories.CompanyRepository
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(MainContext dbContext) : base(dbContext)
        {
        }
    }
}