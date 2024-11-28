using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PracticaSemana2.Areas.Identity.Data;
using PracticaSemana2.Models;

namespace PracticaSemana2.Data;

public class PracticaSemana2Context : IdentityDbContext<PracticaSemana2User>
{
    public PracticaSemana2Context(DbContextOptions<PracticaSemana2Context> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

public DbSet<PracticaSemana2.Models.Productos> Productos { get; set; } = default!;
}
