using SpaceLock.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLock.Repositorio.Mapping
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("Usuario");

            HasKey(u => u.IdUsuario);

            Property(u => u.IdUsuario)
                .HasColumnName("IdUsuario")
                .IsRequired();

            Property(u => u.Nome)
                .HasColumnName("NomeUsuario")
                .HasMaxLength(150)
                .IsRequired();

            Property(u => u.Login)
                .HasColumnName("LoginUsuario")
                .HasMaxLength(50)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute
                    ("ix_Login")
                    { IsUnique = true }))
                .IsRequired();

            Property(u => u.Email)
                .HasColumnName("EmailUsuario")
                .HasMaxLength(200)
                .IsRequired();

            Property(u => u.Senha)
                .HasColumnName("SenhaUsuario")
                .HasMaxLength(50)
                .IsRequired();

            Property(u => u.Foto)
                .HasColumnName("FotoUsuario")
                .HasMaxLength(50);
                /*.HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute
                    ("ix_Foto")
                    { IsUnique = true }))
                .IsRequired();*/

            HasRequired(u => u.Perfil).WithMany(p => p.Usuarios).HasForeignKey(u => u.IdPerfil).WillCascadeOnDelete(false);
        }
    }
}
