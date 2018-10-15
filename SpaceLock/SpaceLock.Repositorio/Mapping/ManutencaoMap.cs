using SpaceLock.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLock.Repositorio.Mapping
{
    public class ManutencaoMap : EntityTypeConfiguration<Manutencao>
    {
        public ManutencaoMap()
        {
            ToTable("Manutencao");

            HasKey(m => m.IdManutencao);

            Property(m => m.IdManutencao)
                .HasColumnName("IdManutencao")
                .IsRequired();

            Property(m => m.DataInicio)
                .HasColumnName("DataInicio")
                .IsRequired();

            Property(m => m.DataFim)
                .HasColumnName("DataFim")
                .IsRequired();

            Property(m => m.Motivo)
                .HasColumnName("Motivo")
                .IsRequired();

            Property(m => m.Motivo)
                .HasColumnName("Motivo")
                .HasMaxLength(100)
                .IsRequired();

            Property(m => m.IdEspaco)
                .HasColumnName("IdEspaco")
                .IsRequired();

            Property(m => m.IdUsuario)
                .HasColumnName("IdUsuario")
                .IsRequired();

            HasRequired(m => m.Espaco).WithMany(e => e.Manutencoes).HasForeignKey(m => m.IdEspaco).WillCascadeOnDelete(false);

            HasRequired(m => m.Usuario).WithMany(u => u.Manutencoes).HasForeignKey(m => m.IdUsuario).WillCascadeOnDelete(false);
        }
    }
}
