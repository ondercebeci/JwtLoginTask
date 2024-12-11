using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostummerSupport.Application.Tools
{
    public class JwtTokenDefaults
    {
        public const string ValidAudience = "https://localhost";
        public const string ValidIssuer = "https://localhost";
        public const string Key = "CostumerSupport01*CostumerSupport01*CostumerSupport01*CostumerSupport01*CARRRRR-*/";
        public const int Expire = 3;
    }
}
