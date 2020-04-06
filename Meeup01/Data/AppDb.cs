using Meeup01.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meeup01.Data
{
  public class AppDb : DbContext
  {
    public AppDb(DbContextOptions<AppDb> options): base(options)
    {

    }

    public DbSet<Suspect> Suspects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Suspect>().HasIndex(x => x.CitizenId).IsUnique();
    }
  }
}
