﻿using System.Security.Cryptography;
using System.Text;

namespace TrabajoIntegradorSofttek.Helpers
{
    public class PasswordEncryptHelper
    {
        /// <summary>
        /// Método que cifra una contraseña utilizando una técnica de saltin1g a partir del cuil y contraseña.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="cuil"></param>
        /// <returns>La contraseña cifrada </returns>   
        public static string EncryptPassword(string password, long cuil)
        {
            var salt = CreateSalt(cuil.ToString());
            string saltAndPwd = String.Concat(password, salt);
            var sha256 = SHA256.Create();
            var encoding = new ASCIIEncoding();
            var stream = Array.Empty<byte>();
            var sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(saltAndPwd));
            for (int i = 0; i < stream.Length; i++)
            {
                sb.AppendFormat("{0:x2}", stream[i]);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Método privado para generar un salt único basado en el cuil del usuario.
        /// </summary>
        /// <param name="cuil"></param>
        /// <returns>Una cadena que representa el salt generado.</returns>
        private static string CreateSalt(string cuil)
        {
            var salt = cuil;
            byte[] saltBytes;
            string saltStr;
            saltBytes = ASCIIEncoding.ASCII.GetBytes(salt);
            long XORED = 0x00;

            foreach (int x in saltBytes)
            {
                XORED = XORED ^ x;
            }

            Random rand = new Random(Convert.ToInt32(XORED));
            saltStr = rand.Next().ToString();
            saltStr += rand.Next().ToString();
            saltStr += rand.Next().ToString();
            saltStr += rand.Next().ToString();
            return saltStr;
        }
    }
}
