using Consommation.Database.EntityModels;
using Consommation.Models;
using Microsoft.EntityFrameworkCore;

namespace Consommation.Database;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) : base(options) { }

    public DbSet<Product> Products { get; set; }
    public DbSet<Commentaire> Commentaires { get; set; }
    public DbSet<Recharge> Recharges { get; set; }
    public DbSet<Trajet> Trajets { get; set; }
    public DbSet<Voiture> Voitures { get; set; }
}
