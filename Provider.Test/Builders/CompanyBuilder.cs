using Provider.Domain.Entities;
using System;

namespace Provider.Test.Builders
{
    public class CompanyBuilder
    {
        private Guid _id;
        private string _fantasyName;
        private string _cNPJ;
        private string _uF;
        private bool _active;

        public Company Build()
        {
            return new Company(_fantasyName, _cNPJ, _uF, _active)
            {
                Id = _id
            };
        }

        public CompanyBuilder WithFantasyName(string fantasyName)
        {
            _fantasyName = fantasyName;
            return this;
        }

        public CompanyBuilder WithCNPJ(string cNPJ)
        {
            _cNPJ = cNPJ;
            return this;
        }

        public CompanyBuilder WihtUF(string uF)
        {
            _uF = uF;
            return this;
        }

        public CompanyBuilder Active()
        {
            _active = true;
            return this;
        }

        public CompanyBuilder Inactive()
        {
            _active = false;
            return this;
        }

        public CompanyBuilder WithId(Guid id)
        {
            _id = id;
            return this;
        }
    }
}
