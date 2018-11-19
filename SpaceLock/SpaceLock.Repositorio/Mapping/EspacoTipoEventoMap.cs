using SpaceLock.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLock.Repositorio.Mapping
{
    public class EspacoTipoEventoMap : EntityTypeConfiguration<EspacoTipoEvento>
    {
        public EspacoTipoEventoMap()
        {
            ToTable("EspacoTipoEvento");

            HasKey(e => e.IdEspacoTipoEvento);

            Property(e => e.IdEspacoTipoEvento)
                .HasColumnName("IdEspacoTipoEvento")
                .IsRequired();

            Property(e => e.IdEspaco)
                .HasColumnName("IdEspaco")
                .IsRequired();

            Property(e => e.IdTipoEvento)
                .HasColumnName("IdTipoEvento")
                .IsRequired();

            Property(e => e.DataCriacao)
                .HasColumnName("DataCriacao")
                .IsRequired();

            HasRequired(e => e.Espaco).WithMany(ee => ee.EspacoTipoEventos).HasForeignKey(e => e.IdEspaco).WillCascadeOnDelete(false);

            HasRequired(e => e.TipoEvento).WithMany(te => te.EspacoTipoEventos).HasForeignKey(e => e.IdTipoEvento).WillCascadeOnDelete(false);
        }
    }
}
