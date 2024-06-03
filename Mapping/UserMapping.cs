using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiProduto.Infra.Data.Mapping;

public class RoleMapping : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.Property(r => r.Id)
            .HasColumnName("Id")
            .HasColumnType("serial")
            .IsRequired();

        builder.Property(r => r.Name)
            .HasColumnName("Name")
            .HasColumnType("varchar(256)");

        builder.Property(r => r.NormalizedName)
            .HasColumnName("NormalizedName")
            .HasColumnType("varchar(256)");

        builder.Property(r => r.ConcurrencyStamp)
            .HasColumnName("ConcurrencyStamp")
            .HasColumnType("text");

        builder.HasKey(r => r.Id);
    }
}