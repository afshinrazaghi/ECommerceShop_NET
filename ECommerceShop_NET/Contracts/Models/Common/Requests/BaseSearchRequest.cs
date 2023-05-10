using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Contracts.Models.Common.Requests
{
    public class BaseSearchRequest
    {
        public string? SearchParam { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
