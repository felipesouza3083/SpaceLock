using SpaceLock.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLock.Repositorio.Mapping
{
    public class AluguelMap:EntityTypeConfiguration<Aluguel>
    {
        public AluguelMap()
        {
            ToTable("Aluguel");

            HasKey(a => a.IdAluguel);

            Property(a => a.IdAluguel)
                .HasColumnName("IdAluguel")
                .IsRequired();

            Property(a => a.Descricao)
                .HasColumnName("Descricao")
                .HasMaxLength(100)
                .IsRequired();

            Property(a => a.DataAlguel)
                .HasColumnName("DataAlguel")
                .IsRequired();

            Property(a => a.HoraInicio)
                .HasColumnName("HoraInicio")
                .IsRequired();

            Property(a => a.HoraFim)
                .HasColumnName("HoraFim")
                .IsRequired();

            Property(a => a.ValorAluguel)
                .HasColumnName("ValorAluguel")
                .IsRequired();

            Property(a => a.IdEspaco)
                .HasColumnName("IdEspaco")
                .IsRequired();

            Property(a => a.IdUsuario)
                .HasColumnName("IdUsuario")
                .IsRequired();

            HasRequired(a => a.Espaco).WithMany(e => e.Alugueis).HasForeignKey(a => a.IdEspaco).WillCascadeOnDelete(false);

            HasRequired(a => a.Usuario).WithMany(u => u.Alugueis).HasForeignKey(a => a.IdUsuario).WillCascadeOnDelete(false);
        }
    }
}
