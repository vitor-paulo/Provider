namespace Provider.Domain.Entities
{
    public class Company : BaseEntity
    {
        public Company(string fantasyName, string cNPJ, string uF, bool active)
        {
            FantasyName = fantasyName;
            CNPJ = cNPJ;
            UF = uF;
            Active = active;
        }

        public void Update(string fantasyName, string cNPJ, string uF)
        {
            FantasyName = fantasyName;
            CNPJ = cNPJ;
            UF = uF;
        }

        public void Desable()
        {
            Active = false;
        }

        public string FantasyName { get; protected set; }
        public string CNPJ { get; protected set; }
        public string UF { get; protected set; }
    }
}
