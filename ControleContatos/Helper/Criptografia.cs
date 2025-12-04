using System.Security.Cryptography;

namespace ControleContatos.Helper
{
    public static class Criptografia
    {
        public static string GerarHash(this string senha)
        {
            byte[] salt = new byte[16];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            var pbkdf2 = new Rfc2898DeriveBytes(
                senha,
                salt,
                100000,
                HashAlgorithmName.SHA256
            );

            byte[] hash = pbkdf2.GetBytes(32); // 32 bytes = 256 bits

            byte[] hashCompleto = new byte[48];
            Array.Copy(salt, 0, hashCompleto, 0, 16);
            Array.Copy(hash, 0, hashCompleto, 16, 32);

            return Convert.ToBase64String(hashCompleto);
        }
        public static bool ValidarSenha(string senha, string hashArmazenado)
        {
            byte[] hashBytes = Convert.FromBase64String(hashArmazenado);

            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            byte[] hashArmazenadoBytes = new byte[32];
            Array.Copy(hashBytes, 16, hashArmazenadoBytes, 0, 32);

            var pbkdf2 = new Rfc2898DeriveBytes(
                senha,
                salt,
                100000,
                HashAlgorithmName.SHA256
            );

            byte[] hashSenhaInformada = pbkdf2.GetBytes(32);

            return CryptographicOperations.FixedTimeEquals(hashSenhaInformada, hashArmazenadoBytes);
        }
    }
}
