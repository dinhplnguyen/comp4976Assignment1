using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using Models;

namespace SeedIdentity.Data;

public class ApplicationDbContext : IdentityDbContext
{
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
  {
  }

  public DbSet<Resolution> Resolutions { get; set; }
  protected override void OnModelCreating(ModelBuilder builder)
  {
    base.OnModelCreating(builder);
    builder.Entity<Resolution>().HasKey(r => r.ResolutionId);
    builder.Entity<Resolution>().Property(r => r.ResolutionId).ValueGeneratedOnAdd();
    builder.Entity<Resolution>().Property(r => r.CreationDate).ValueGeneratedOnAdd();
    builder.Entity<Resolution>().Property(r => r.Status).HasDefaultValue(Resolution.ResolutionStatus.draft);

    // builder.Entity<IdentityUser>().Property(u => u.Name);

    builder.Entity<Resolution>().ToTable("Resolution");

  }
}
