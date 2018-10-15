using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLock.Entidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Foto { get; set; }
        public int IdPerfil { get; set; }

        public Perfil Perfil { get; set; }
        public List<Espaco> Espacos { get; set; }
        public List<Manutencao> Manutencoes { get; set; }
        public List<Aluguel> Alugueis { get; set; }

        public Usuario()
        {

        }

        public Usuario(int idUsuario, string nome, string login, string email, string senha, string foto, int idPerfil)
        {
            IdUsuario = idUsuario;
            Nome = nome;
            Login = login;
            Email = email;
            Senha = senha;
            Foto = foto;
            IdPerfil = idPerfil;
        }

        public override string ToString()
        {
            return $"Id do Usuario: {IdUsuario}, Nome: {Nome}, Login: {Login}, Email: {Email}";
        }
    }
}
