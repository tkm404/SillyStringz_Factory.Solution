using Microsoft.EntityFrameworkCore;

namespace Factory.Models
{
  public class FactoryContext : DbContext
  {
    public DbSet<Engineer> Engineers { get; set; }
    public DbSet<Machine> Machines { get; set; }
    public DbSet<EngineerMachine> EngineerMachines { get; set; }

    public FactoryContext(DbContextOptions options) : base(options) { }
  }
}

// Rename all [ Project Names ]; Rename Primary and Secondary Models with whatever model names you need. You may not need both, so use your best judgement.
// You only need this file if you're working with a database.