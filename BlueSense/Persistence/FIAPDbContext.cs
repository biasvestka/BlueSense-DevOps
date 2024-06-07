using BlueSense.Models;
using Microsoft.EntityFrameworkCore;

namespace BlueSense.Persistence
{
    public class FIAPDbContext : DbContext
    {
        public DbSet<LeituraSensor> LeituraSensor { get; set; }

        public FIAPDbContext(DbContextOptions<FIAPDbContext> options) : base(options)
        {

        }
        public DbSet<BlueSense.Models.Navio> Navio { get; set; } = default!;
        public DbSet<BlueSense.Models.Rota> Rota { get; set; } = default!;
        public DbSet<BlueSense.Models.Sensor> Sensor { get; set; } = default!;
        public DbSet<BlueSense.Models.Notificacao> Notificacao { get; set; } = default!;
        public DbSet<BlueSense.Models.Usuario> Usuario { get; set; } = default!;
        public DbSet<BlueSense.Models.UsuarioAutoridade> UsuarioAutoridade { get; set; } = default!;
        public DbSet<BlueSense.Models.NavioRotas> NavioRotas { get; set; } = default!;
    }
}