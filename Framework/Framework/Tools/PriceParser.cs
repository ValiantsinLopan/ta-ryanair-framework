using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Tools
{
    public static class PriceParser
    {
        public static double ParsePrice(string price)
        {
            var result = "";
            if (string.IsNullOrEmpty(price)) return 0.0;

            for (var i = 0; i < price.Length; i++)
            {
                if (price[i] != ' ') continue;
                result = price.Substring(i + 1);
                break;
            }

            return double.Parse(result);
        }
    }
}
