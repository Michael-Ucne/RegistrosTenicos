using RegistrosTenicos.Models;
using Microsoft.EntityFrameworkCore;

namespace RegistrosTenicos.DAL;

public class Contexto(DbContextOptions<Contexto> options) : DbContext(options)
{
    public DbSet<Tecnicos> Tecnicos { get; set; }
    public DbSet<Clientes> Clientes { get; set; }

}
