using SpaceLock.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLock.Repositorio.Mapping
{
    public class EspacoMap : EntityTypeConfiguration<Espaco>
    {
        public EspacoMap()
        {
            ToTable("Espaco");

            HasKey(e => e.IdEspaco);

            Property(e => e.IdEspaco)
                .HasColumnName("IdEspaco")
                .IsRequired();

            Property(e => e.NomeEspaco)
                .HasColumnName("NomeEspaco")
                .HasMaxLength(50)
                .IsRequired();

            Property(e => e.Capacidade)
                .HasColumnName("Capacidade")
                .IsRequired();

            Property(e => e.Tamanho)
                .HasColumnName("Tamanho")
                .IsRequired();

            Property(e => e.UnidadeMedida)
                .HasColumnName("UnidadeMedida")
                .HasMaxLength(15)
                .IsRequired();

            Property(e => e.DataCadastro)
                .HasColumnName("DataCadastro")
                .IsRequired();

            Property(e => e.IdUsuario)
                .HasColumnName("IdUsuario")
                .IsRequired();

            HasRequired(e => e.Usuario).WithMany(u => u.Espacos).HasForeignKey(e => e.IdUsuario).WillCascadeOnDelete(false);

            HasMany(e => e.TipoEventos)
                .WithMany(ti => ti.Espacos)
                .Map(
                    map =>
                    {
                        map.ToTable("EspacoTipoEvento");

                        map.MapLeftKey("IdEspaco");

                        map.MapRightKey("IdTipoEvento");
                    }
                );
        }
    }
}
