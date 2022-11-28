using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace SistemaProtoA
{
    [Table("tbl_credencial")]
    internal class Credencial
    {
        // Primary key equal to User's foreign key - One-To-One Relationship
        public Int64 Id { get; set; }

        public const String SALT = "1FnM6_";

        //[Required]
        [Index(IsUnique = true)]
        [StringLength(250)]
        public String Email { get; set; }

        private String _senha;

        [Required]
        [StringLength(64)]
        public String Senha
        {


            get
            {
                return _senha;
            }
            set
            {
                //_senha = ComputeSHA256(value);
                _senha = ComputeSHA256(value, SALT);
            }
        }

        public bool Administrador { get; set; }

        // Usuario is the *principal* / REQUIRED
        // and Credencial is *dependent*
        [Required]
        public Usuario Usuario { get; set; }


        #region Hashing
        public static String ComputeSHA256(String input)
        {
            return ComputeSHA256(input, null);
        }

        public static String ComputeSHA256(String input, String salt)
        {
            String hash = String.Empty;

            // 
            // https://learn.microsoft.com/en-us/dotnet/standard/security/cryptographic-services
            // https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.sha256?view=netframework-4.8
            // https://www.techiedelight.com/generate-sha-256-hash-of-string-csharp/
            // 

            // Initialize a SHA256 hash object
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash of the given string
                byte[] hashValue = sha256.ComputeHash(
                    Encoding.UTF8.GetBytes(salt + input));

                // Convert the byte array to string format
                foreach (byte b in hashValue)
                {
                    hash += $"{b:X2}";
                }
            }

            return hash;
        }
        #endregion

        public override String ToString()
        {
            return Id
                + ", " + Email
                + ", " + Senha
                + ", " + (Administrador ? "Administrador" : "Usuário comum")
                + ", Usuário: " + Usuario?.Id;
        }
    }
}
