using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsOfSale.Models
{
    /// <summary>
    /// Cola menu Item is one of the items that a customer can order.
    /// </summary>
    public class ColaItem : ItemInterface
    {
        public double getPrice()
        {
            return 2;
        }
    }
}
