using FluentAssertions;
using Provider.Test.Builders;
using System;
using Xunit;

namespace Provider.Test.Unit.Domain.Entidade
{
    public class CompanyTest
    {

        [Fact]
        public void Must_Inactivate_Company()
        {
            //arrange
            var company = new CompanyBuilder().Active().Build();
            //action
            company.Desable();
            //assert
            company.Active.Should().BeFalse();
        }

        [Fact]
        public void Must_Update_Company()
        {
            //arrange
            var companyId = Guid.NewGuid();
            var company = new CompanyBuilder()
                .WithFantasyName("Banco")
                .WithCNPJ("00.000.000/0001-91")
                .WihtUF("SC")
                .WithId(companyId)
                .Active()
                .Build();

            //action
            company.Update("Banco", "00.000.000/0001-91", "SC");

            //assert
            company.FantasyName.Should().Be(company.FantasyName);
            company.CNPJ.Should().Be(company.CNPJ);
            company.Active.Should().BeTrue();
            company.UF.Should().Be(company.UF);
            company.Id.Should().Be(companyId);
        }
    }
}

