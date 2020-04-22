using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace RestAppUdemy.Security.Configuration
{
    public class SigningConfigutaions
    {
        public SecurityKey Key { get; }
        public SigningCredentials SigninCredentials { get; }

        public SigningConfigutaions()
        {
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }

            SigninCredentials = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);
        }
    }
}
