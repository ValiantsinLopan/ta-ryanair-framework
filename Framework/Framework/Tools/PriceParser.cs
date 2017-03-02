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
            string result = "";
            if (!(string.IsNullOrEmpty(price)))
            {
                for (int i = 0; i < price.Length; i++)
                {
                    if (!char.IsDigit(price[i]) && price[i] == ' ')
                    {
                        result = price.Substring(i + 1);
                        i++;
                    }
                }
                return Double.Parse(result);
            }
            else return 0.0;                        
        }
    }
}
