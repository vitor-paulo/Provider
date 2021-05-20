using Provider.Application.DTOs.Company;
using Provider.Domain.Entities;
using Provider.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Provider.Application.Services.CompanyService
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task Create(CompanyRequestDTO request)
        {
            var company = new Company(request.FantasyName, request.CNPJ, request.UF, request.Active);
            await _companyRepository.Create(company);
        }

        public async Task Delete(Guid id)
        {
            var company = await _companyRepository.GetById(id);
            company.Desable();
            await _companyRepository.Update(id, company);
        }

        public async Task<IList<CompanyResponseDTO>> GetAll()
        {
            var company = await _companyRepository.GetAll();

            return company.Select(d => new CompanyResponseDTO()
            {
                Active = d.Active,
                Id = d.Id,
                FantasyName = d.FantasyName,
                CNPJ = d.CNPJ
            }).ToList();
        }

        public async Task<CompanyResponseDTO> GetById(Guid id)
        {
            var company = await _companyRepository.GetById(id);
            return new CompanyResponseDTO()
            {
                Active = company.Active,
                Id = company.Id,
                FantasyName = company.FantasyName,
                CNPJ = company.CNPJ
            };
        }

        public async Task Update(Guid id, CompanyRequestDTO request)
        {
            var company = await _companyRepository.GetById(id);
            company.Update(request.FantasyName, request.CNPJ, request.UF);
            await _companyRepository.Update(id, company);
        }
    }
}
