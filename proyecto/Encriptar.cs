using System.Security.Cryptography;
using System.Text;

namespace proyecto_aula.proyecto
{
    public class Encriptar
    {
        public static int acumulador=0;
        public static int sum = 0;
        public static string EncriptarPassword(string rawData)
        {
            using (SHA256 sha256hash = SHA256.Create())
            {
                byte[] bytes = sha256hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }

         
            
        }


        public static int suma()
        {
            acumulador = sum++;
            return acumulador;
        }
    }
}
