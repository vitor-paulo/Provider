using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Provider.Domain.Entities;

namespace Provider.Infra.Mapping
{
    public class CompanyMapping : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Property(x => x.FantasyName)
                .IsRequired();

            builder.Property(x => x.CNPJ)
                .IsRequired();

            builder.Property(x => x.UF)
                 .IsRequired();

            builder.Property(d => d.Active)
                .IsRequired();
        }
    }
}