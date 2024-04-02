using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsOfSale.Models
{
    /// <summary>
    /// Concrete creator that returns a Pasta Item (Menu Item that a customer can order)
    /// </summary>
    public class PastaFactory : Order
    {
        public override ItemInterface CreateMenuItem()
        {
            return new PastaItem();
        }
    }
}
