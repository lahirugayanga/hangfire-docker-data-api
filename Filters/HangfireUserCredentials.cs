using System.Collections;
using System.Security.Cryptography;
using System.Text;

namespace data_api.Filters
{
    public class HangfireUserCredentials
    {
        public string UserName { get; set; }
        public byte[] PasswordSha1Hash { get; set; }

        public string Password
        {
            set
            {
                using (var cryptoProvider = SHA1.Create())
                {
                    PasswordSha1Hash = cryptoProvider.ComputeHash(Encoding.UTF8.GetBytes(value));
                }
            }
        }

        public bool ValidateUser(string username, string password)
        {
            if(string.IsNullOrEmpty(username))
                throw new ArgumentNullException("username");

            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException("password");

            if(username == UserName)
            {
                using (var cryptoProvider = SHA1.Create())
                {
                    byte[] passwordHash = cryptoProvider.ComputeHash(Encoding.UTF8.GetBytes(password));
                    return StructuralComparisons.StructuralEqualityComparer.Equals(passwordHash, PasswordSha1Hash);
                }
            }
            else
            {
                return false;
            }

        }
    }
}
