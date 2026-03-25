using System.Security.Cryptography;

namespace WinFormsApp1
{
    public class Crypto
    {
        private byte[] Key;

        public Crypto(byte[] keyValue)
        {
            Key = keyValue;
        }

        public byte[] Encrypt(byte[] clearText)
        {
            using (TripleDES tdes = TripleDES.Create())
            {
                tdes.Key = Key;
                tdes.IV = new byte[8]; // 0000000000000000
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.Zeros;

                ICryptoTransform encryptor = tdes.CreateEncryptor();
                return encryptor.TransformFinalBlock(clearText, 0, clearText.Length);
            }
        }

        public byte[] Decrypt(byte[] cipheredText)
        {
            using (TripleDES tdes = TripleDES.Create())
            {
                tdes.Key = Key;
                tdes.IV = new byte[8]; // 0000000000000000
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.Zeros;

                ICryptoTransform decryptor = tdes.CreateDecryptor();
                return decryptor.TransformFinalBlock(cipheredText, 0, cipheredText.Length);
            }
        }

        public string HashPassword(string password)
        {
            const int SaltByteSize = 24;
            const int HashByteSize = 32; // 256-bit
            const int Iterations = 10000;
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] salt = new byte[SaltByteSize];
                rng.GetBytes(salt);

                using (var pbkdf2 = new Rfc2898DeriveBytes(
                    password,
                    salt,
                    Iterations,
                    HashAlgorithmName.SHA512))
                {
                    byte[] hash = pbkdf2.GetBytes(HashByteSize);

                    return $"{Iterations}:{Convert.ToBase64String(salt)}:{Convert.ToBase64String(hash)}";
                }
             }
        }

        public byte[] ConvertHexStringToByteArray(string inputText)
        {
            return Enumerable.Range(0, inputText.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(inputText.Substring(x, 2), 16))
                .ToArray();
        }
        public string ConvertByteArrayToHexString(byte[] inputText)
        {
            return BitConverter.ToString(inputText).Replace("-", "");
        }
    }
}
