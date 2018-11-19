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

            Property(e => e.Endereco)
                .HasColumnName("Endereco")
                .HasMaxLength(150)
                .IsRequired();

            Property(e => e.Numero)
                .HasColumnName("Numero")
                .IsRequired();

            Property(e => e.Complemento)
                .HasColumnName("Complemento")
                .HasMaxLength(30)
                .IsRequired();

            Property(e => e.Bairro)
                .HasColumnName("Bairro")
                .HasMaxLength(100)
                .IsRequired();

            Property(e => e.Cidade)
                .HasColumnName("Cidade")
                .HasMaxLength(15)
                .IsRequired();

            Property(e => e.Uf)
                .HasColumnName("Uf")
                .HasMaxLength(2)
                .IsRequired();

            Property(e => e.Cep)
                .HasColumnName("Cep")
                .HasMaxLength(9)
                .IsRequired();

            Property(e => e.DataCadastro)
                .HasColumnName("DataCadastro")
                .IsRequired();

            Property(e => e.IdUsuario)
                .HasColumnName("IdUsuario")
                .IsRequired();

            HasRequired(e => e.Usuario).WithMany(u => u.Espacos).HasForeignKey(e => e.IdUsuario).WillCascadeOnDelete(false);
        }
    }
}
