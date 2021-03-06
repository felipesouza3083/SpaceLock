﻿using SpaceLock.Entidades;
using SpaceLock.Repositorio.Context;
using SpaceLock.Repositorio.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLock.Repositorio.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public void AtualizaSenha(int idUsuario, string novaSenha)
        {
            var user = new Usuario() { IdUsuario = idUsuario, Senha = novaSenha };
            using (DataContext d = new DataContext())
            {
                d.Usuario.Attach(user);
                d.Entry(user).Property(u => u.Senha).IsModified = true;
                d.SaveChanges();
            }
        }

        public Usuario Find(string login, string senha)
        {
            using (DataContext d = new DataContext())
            {
                return d.Usuario.FirstOrDefault(u => u.Login.Equals(login)
                                                  && u.Senha.Equals(senha));
            }
        }

        public bool HasLogin(string login)
        {
            using (DataContext d = new DataContext())
            {
                return d.Usuario.Count(u => u.Login.Equals(login)) > 0;
            }
        }
    }
}
