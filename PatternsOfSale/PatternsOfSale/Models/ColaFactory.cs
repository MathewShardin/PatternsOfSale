using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PatternsOfSale.Models
{
    /// <summary>
    /// Concrete creator that returns a Cola Item (Menu Item that a customer can order)
    /// </summary>
    public class ColaFactory : Order
    {
        public override ItemInterface createMenuItem()
        {
            return new ColaItem();
        }
    }
}
