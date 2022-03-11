using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class Client : IEntityTypeConfiguration<Domain.Entites.Client>
    {
        public void Configure(EntityTypeBuilder<Domain.Entites.Client> builder)
        {
            builder.ToTable("CLIENTS");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(50);

            builder.Property(x => x.Phone)
                .HasMaxLength(30);

            builder.Property(x => x.DateBirth)
                .IsRequired();

            builder.Property(x => x.Address)
                .HasMaxLength(50);

            builder.Property(x => x.Created);


            builder.Property(x => x.CreatedBy)
                .HasMaxLength(30);

            builder.Property(x => x.CreatedOn)
                .HasMaxLength(30);

            builder.Property(x => x.LastModified);

            builder.Property(x => x.LastModifiedBy)
                .HasMaxLength(30);

            builder.Property(x => x.LastModifiedOn)
                .HasMaxLength(30);
        }
    }
}
