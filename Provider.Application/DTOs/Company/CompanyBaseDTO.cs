using Provider.Domain.Enums;

namespace Provider.Application.DTOs.Company
{
    public abstract class CompanyBaseDTO
    {
        public string FantasyName { get; set; }
        public string CNPJ { get; set; }
        public UF UF { get; set; }
        public bool Active { get; set; }
    }
}
