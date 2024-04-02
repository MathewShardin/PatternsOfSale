using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsOfSale.Models
{
    /// <summary>
    /// Beer menu Item is one of the items that a customer can order.
    /// </summary>
    public class BeerItem : ItemInterface
    {
        public double GetPrice()
        {
            return 1;
        }
    }
}
