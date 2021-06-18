using Microsoft.AspNetCore.Mvc;
using Provider.Application.DTOs.Company;
using Provider.Application.Services.CompanyService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Provider.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CompanyRequestDTO request)
        {
            await _companyService.Create(request);
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] CompanyRequestDTO request)
        {
            await _companyService.Update(id, request);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _companyService.Delete(id);
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<CompanyResponseDTO> GetById([FromRoute] Guid id)
        {
            return await _companyService.GetById(id);
        }

        [HttpGet]
        public async Task<IList<CompanyResponseDTO>> GetAll()
        {
            return await _companyService.GetAll();
        }
    }
}