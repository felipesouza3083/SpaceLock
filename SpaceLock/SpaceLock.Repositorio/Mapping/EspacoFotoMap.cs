using SpaceLock.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLock.Repositorio.Mapping
{
    public class EspacoFotoMap:EntityTypeConfiguration<EspacoFoto>
    {
        public EspacoFotoMap()
        {
            ToTable("EspacoFoto");

            HasKey(ef => ef.IdEspacoFoto);

            Property(ef => ef.IdEspacoFoto)
                .HasColumnName("IdEspacoFoto")
                .IsRequired();

            Property(ef => ef.Foto)
                .HasColumnName("Foto")
                .HasMaxLength(50)
                .IsRequired();

            Property(ef => ef.DataInsercao)
                .HasColumnName("DataInsercao")
                .IsRequired();

            Property(ef => ef.IdEspaco)
                .HasColumnName("IdEspaco")
                .IsRequired();

            HasRequired(ef => ef.Espaco).WithMany(e => e.EspacoFotos).HasForeignKey(ef => ef.IdEspaco).WillCascadeOnDelete(false);
        }
    }
}
