using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper 
    {                   //json web token servislerinin json web tokenlarının oluşturulabilmesi için credential(Kullanıcı adı parola/ anahtar)
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {                                //wich key, wich algorithm
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }

    }
}
