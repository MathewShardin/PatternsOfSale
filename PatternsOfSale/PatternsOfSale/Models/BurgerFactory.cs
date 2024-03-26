using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsOfSale.Models
{
    /// <summary>
    /// Concrete creator that returns a Burger Item (Menu Item that a customer can order)
    /// </summary>
    public class BurgerFactory : Order
    {
        public override ItemInterface createMenuItem()
        {
            return new BurgerItem();
        }
    }
}
