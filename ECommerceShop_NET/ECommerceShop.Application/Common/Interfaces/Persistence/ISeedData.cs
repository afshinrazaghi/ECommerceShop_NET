using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Application.Common.Interfaces.Persistence
{
    public interface ISeedData
    {
        public Task SeedDatabase();
    }
}
