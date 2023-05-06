using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Application.Responses
{
    public class BaseCommandResponse : BaseResponse
    {
     
    }

    public class BaseCommandResponse<T> : BaseCommandResponse
    {
        public T? Item { get; set; }
    }
}
