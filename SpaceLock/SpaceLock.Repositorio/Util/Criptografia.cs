using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLock.Repositorio.Util
{
    public class Criptografia
    {
        //Método estático para encriptar a senha do usuário..
        public static string EncriptarSenhaMD5(string senha)
        {
            //converter a senha em bytes..
            byte[] senhaBytes = Encoding.UTF8.GetBytes(senha);

            //aplicar o algoritmo de criptografia
            MD5 md5 = new MD5CryptoServiceProvider();

            byte[] hash = md5.ComputeHash(senhaBytes);

            //retornar o hash gerado como string..
            string result = string.Empty;

            foreach (byte b in hash)
            {
                result += b.ToString("X2");
                //X2 -: hexadecimal
            }
            return result;
        }

        //método estático para encriptar a senha do usuário..
        public static string EncriptarSenhaSHA1(string senha)
        {
            //converter a senha em bytes..
            byte[] senhaBytes = Encoding.UTF8.GetBytes(senha);

            //aplicar o algoritmo de criptografia
            SHA1 sha1 = new SHA1CryptoServiceProvider();

            byte[] hash = sha1.ComputeHash(senhaBytes);
            //retornar o hash gerado como string..
            string result = string.Empty;

            foreach (byte b in hash)
            {
                result += b.ToString("X2");
                //X2 -: hexadecimal
            }
            return result;
        }
    }
}
