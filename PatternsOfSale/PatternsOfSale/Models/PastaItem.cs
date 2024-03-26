using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsOfSale.Models
{
    /// <summary>
    /// Pasta menu Item is one of the items that a customer can order.
    /// </summary>
    public class PastaItem : ItemInterface
    {
        public double getPrice()
        {
            return 10;
        }
    }
}
