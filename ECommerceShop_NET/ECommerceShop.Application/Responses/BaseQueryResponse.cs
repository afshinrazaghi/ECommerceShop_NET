using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Application.Responses
{
    public class BaseQueryResponse<T> : BaseResponse
    {
        public T? Item { get; set; }
        public List<T>? Items { get; set; }
        public int Count { get; set; }
    }
}
