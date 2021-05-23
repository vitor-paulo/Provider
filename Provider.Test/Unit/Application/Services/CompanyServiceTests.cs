using FluentAssertions;
using NSubstitute;
using Provider.Application.DTOs.Company;
using Provider.Application.Services.CompanyService;
using Provider.Domain.Entities;
using Provider.Domain.Interfaces;
using Provider.Test.Builders;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Provider.Test.Unit.Application.Services
{
    public class CompanyServiceTests
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ICompanyService _companyService;

        public CompanyServiceTests()
        {
            _companyRepository = Substitute.For<ICompanyRepository>();
            _companyService = new CompanyService(_companyRepository);
        }

        [Fact]
        public async Task Must_Save_Company()
        {
            //arrange
            var company = new CompanyRequestDTO()
            {
                CNPJ = "00.000.000/0001-91",
                FantasyName = "Banco",
                UF = "SC",
                Active = true
            };

            //action
            await _companyService.Create(company);

            //assert
            await _companyRepository
                .Received(1)
                .Create(Arg.Is<Company>(d => d.CNPJ == "00.000.000/0001-91"
                                             && d.FantasyName == "Banco"
                                             && d.UF == "SC"
                                             && d.Active == true));
        }

        [Fact]
        public async Task Must_Update_Company()
        {
            //arrange
            var companyId = Guid.NewGuid();
            var company = new CompanyRequestDTO()
            {
                CNPJ = "00.000.000/0001-91",
                FantasyName = "Banco",
                Active = true,
                UF = "SC"
            };
            var usuario = new CompanyBuilder()
                .WithFantasyName("Banco")
                .WithCNPJ("00.000.000/0001-91")
                .WihtUF("SC")
                .Active()
                .Build();

            _companyRepository
                .GetById(companyId)
                .Returns(usuario);

            //action
            await _companyService
                .Update(companyId, company);

            //assert
            await _companyRepository
                .Received(1)
                .Update(companyId, Arg.Is<Company>(d => d.Active == true
                                             && d.CNPJ == "00.000.000/0001-91"
                                             && d.FantasyName == "Banco"
                                             && d.UF == "SC"));
        }

        [Fact]
        public async Task Must_Inactivate_Company()
        {
            //arrange
            var companyId = Guid.NewGuid();
            var company = new CompanyBuilder()
                .WithFantasyName("Banco")
                .WithCNPJ("00.000.000/0001-91")
                .WihtUF("SC")
                .Active()
                .Build();

            _companyRepository
                .GetById(companyId)
                .Returns(company);

            //action
            await _companyService
                .Delete(companyId);

            //assert
            await _companyRepository
                .Received(1)
                .Update(companyId, Arg.Is<Company>(d => d.Active == false
                                             && d.CNPJ == "00.000.000/0001-91"
                                             && d.FantasyName == "Banco"
                                             && d.UF == "SC"));
        }

        [Fact]
        public async Task Must_Get_By_Id()
        {
            //arrange
            var companyId = Guid.NewGuid();
            var company = new CompanyBuilder()
                .WithFantasyName("Banco")
                .WihtUF("SC")
                .WithCNPJ("00.000.000/0001-91")
                .WithId(companyId)
                .Active()
                .Build();

            _companyRepository
                .GetById(companyId)
                .Returns(company);

            //action
            var companyReturned = await _companyService
                .GetById(companyId);

            //assert
            companyReturned.FantasyName.Should().Be(company.FantasyName);
            companyReturned.CNPJ.Should().Be(company.CNPJ);
            companyReturned.Active.Should().BeTrue();
            companyReturned.UF.Should().Be(company.UF);
            companyReturned.Id.Should().Be(companyId);
        }

        [Fact]
        public async Task Deve_retornar_todos_os_usuarios()
        {
            //arrange
            var companyId1 = Guid.NewGuid();
            var company1 = new CompanyBuilder()
                .WithFantasyName("Banco")
                .WihtUF("SC")
                .WithCNPJ("00.000.000/0001-91")
                .WithId(companyId1)
                .Active()
                .Build();

            var companyId2 = Guid.NewGuid();
            var company2 = new CompanyBuilder()
                .WithFantasyName("Banco1")
                .WihtUF("SC")
                .WithCNPJ("00.000.000/0001-92")
                .WithId(companyId2)
                .Active()
                .Build();

            var companies = new List<Company>
            {
                company1,
                company2
            };

            _companyRepository.GetAll().Returns(companies);

            //action
            var companyReturns = await _companyService.GetAll();

            //assert
            companyReturns.Should().HaveCount(2);

            companyReturns[0].FantasyName.Should().Be(company1.FantasyName);
            companyReturns[0].CNPJ.Should().Be(company1.CNPJ);
            companyReturns[0].Active.Should().BeTrue();
            companyReturns[0].UF.Should().Be(company1.UF);
            companyReturns[0].Id.Should().Be(companyId1);

            companyReturns[1].FantasyName.Should().Be(company2.FantasyName);
            companyReturns[1].CNPJ.Should().Be(company2.CNPJ);
            companyReturns[1].Active.Should().BeTrue();
            companyReturns[1].UF.Should().Be(company2.UF);
            companyReturns[1].Id.Should().Be(companyId2);
        }
    }
}