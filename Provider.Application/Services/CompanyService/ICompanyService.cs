using Provider.Application.DTOs.Company;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Provider.Application.Services.CompanyService
{
    public interface ICompanyService
    {
        Task Create(CompanyRequestDTO request);
        Task Update(Guid id, CompanyRequestDTO request);
        Task Delete(Guid id);
        Task<CompanyResponseDTO> GetById(Guid id);
        Task<IList<CompanyResponseDTO>> GetAll();
    }
}