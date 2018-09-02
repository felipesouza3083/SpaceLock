namespace SpaceLock.Repositorio.Migrations
{
    using SpaceLock.Entidades;
    using SpaceLock.Repositorio.Util;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SpaceLock.Repositorio.Context.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;

            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SpaceLock.Repositorio.Context.DataContext context)
        {
            context.Perfil.AddOrUpdate(
                new Perfil { IdPerfil = 1, Nome = "Administrador" },
                new Perfil { IdPerfil = 2, Nome = "Comum" }
                );

            context.Usuario.AddOrUpdate(
                new Usuario
                {
                    IdUsuario = 1,
                    Nome = "Felipe Araujo de Souza",
                    Email = "felipearaujosouza@hotmail.com",
                    Login = "felipe.souza",
                    Senha = Criptografia.EncriptarSenhaMD5("cd3083"),
                    Foto = "anonimous.jpg",
                    Perfil = context.Perfil.Find(1)
                });
        }
    }
}
