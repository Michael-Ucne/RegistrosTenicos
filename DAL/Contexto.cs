using RegistrosTenicos.Models;
using Microsoft.EntityFrameworkCore;

namespace RegistrosTenicos.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Tecnicos> Tecnicos { get; set; }
    }
}
