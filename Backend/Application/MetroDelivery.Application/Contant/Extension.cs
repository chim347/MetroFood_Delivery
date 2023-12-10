using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Contant
{
    public static class Extension
    {
        public static string Ok = "1";
        public static string OutOfStock = "-1";
        public static string Fail = "0";
        public static string CreateOrderFailedBecauseSomeProductWasOutOfStock = "Create order failed because some order was out of stock! Please check menu again!";
    }
}
