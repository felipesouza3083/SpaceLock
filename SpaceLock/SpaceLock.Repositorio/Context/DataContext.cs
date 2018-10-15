using SpaceLock.Entidades;
using SpaceLock.Repositorio.Mapping;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLock.Repositorio.Context
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base(ConfigurationManager.ConnectionStrings["SPACELOCK"].ConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new PerfilMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new EspacoMap());
            modelBuilder.Configurations.Add(new TipoEventoMap());
            modelBuilder.Configurations.Add(new EspacoFotoMap());
            modelBuilder.Configurations.Add(new ManutencaoMap());
            modelBuilder.Configurations.Add(new AluguelMap());
        }

        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Espaco> Espaco { get; set; }
        public DbSet<TipoEvento> TipoEvento { get; set; }
        public DbSet<Aluguel> Aluguel { get; set; }
        public DbSet<Manutencao> Manutencao { get; set; }
        public DbSet<EspacoFoto> EspacoFoto { get; set; }
    }
}
