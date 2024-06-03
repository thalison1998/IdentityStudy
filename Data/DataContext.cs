using IdentityStudy.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityStudy.Data;

public class DataContext : IdentityDbContext
{
    public DbSet<UserCustom> UserCustom { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
}