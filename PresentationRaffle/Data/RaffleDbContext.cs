using Microsoft.EntityFrameworkCore;
using PresentationRaffle.Entities;

namespace PresentationRaffle.Data;

public class RaffleDbContext : DbContext
{
    public RaffleDbContext(DbContextOptions<RaffleDbContext> options) : base(options) { }

    public DbSet<Student> Students { get; set; }
}
