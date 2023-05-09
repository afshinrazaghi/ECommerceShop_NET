using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Infrastructure.Settings
{
    public class JwtSettings
    {
        public string Secret { get; set; } = default!;
        public int ExpireMinutes { get; set; } = default!;
        public string Issuer { get; set; } = default!;
        public string Audience { get; set; } = default!;
        public const string SectionName = "JwtSettings";
    }
}
