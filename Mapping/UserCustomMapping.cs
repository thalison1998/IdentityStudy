using ApiProduto.Infra.Data.Constants;
using IdentityStudy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiProduto.Infra.Data.Mapping;

public class UserCustomMapping : IEntityTypeConfiguration<UserCustom>
{
    public void Configure(EntityTypeBuilder<UserCustom> builder)
    {
        builder.ToTable("UsersCustom", Constantes.Schemas.CustomizedSystem);
    }
}