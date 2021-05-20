using Provider.Domain.Entities;
using Provider.Infra.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Provider.Infra.Repositories.CompanyRepository
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(MainContext dbContext) : base(dbContext)
        {
        }
    }
}