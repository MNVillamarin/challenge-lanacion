using LaNacion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaNacion.Persistence.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Street)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(x => x.City)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(x => x.State)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(x => x.ZipCode)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
