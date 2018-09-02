using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using SpaceLock.Entidades;

namespace SpaceLock.Repositorio.Mapping
{
    public class PerfilMap: EntityTypeConfiguration<Perfil>
    {
        public PerfilMap()
        {
            ToTable("Perfil");

            HasKey(p => p.IdPerfil);

            Property(p => p.IdPerfil)
                .HasColumnName("IdPerfil")
                .IsRequired();

            Property(p => p.Nome)
                .HasColumnName("NomePerfil")
                .HasMaxLength(100)
                .IsRequired();

        }
    }
}
