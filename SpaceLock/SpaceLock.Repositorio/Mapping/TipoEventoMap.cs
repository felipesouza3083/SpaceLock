using SpaceLock.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLock.Repositorio.Mapping
{
    public class TipoEventoMap:EntityTypeConfiguration<TipoEvento>
    {
        public TipoEventoMap()
        {
            ToTable("TipoEvento");

            HasKey(t => t.IdTipoEvento);

            Property(t => t.IdTipoEvento)
                .HasColumnName("IdTipoEvento")
                .IsRequired();

            Property(t => t.Descricao)
                .HasColumnName("Descricao")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
