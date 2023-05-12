using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Tests
{
    public class FakeDataGenerator
    {
        public static List<string> GetCategories()
        {
            return new List<string>() {
                    "Home & Kitchen",
                    "Beauty & Personal Car",
                    "Clothing, Shoes & Jewelry",
                    "Toys & games",
                    "Health, Household & Baby Care",
                    "Baby",
                    "Electronics",
                    "Sports & outdoors",
                    "Pet Supplies",
                    "Office Supplies",
                    "Appliances",
                    "Garden & Outdoor",
                    "Cell Phone & Accessories",
                    "Apps & Games",
                    "Automotive",
                    "Handmade",
                    "Computers",
                    "Industrial & Scientific",
                    "Collectibles & Fine Art",
                    "CDs & Vinyl",
                    "Luggage & Travel Gear",
                    "Video Games",
                    "Musical Instruments"};
        }
    }
}
