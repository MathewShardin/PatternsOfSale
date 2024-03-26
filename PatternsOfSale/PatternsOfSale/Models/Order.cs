using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsOfSale.Models
{
    /// <summary>
    /// Order is the creator class that return new ItemInterface objects (Items that can ordered by customer)
    /// </summary>
    public abstract class Order
    {
        /// <summary>
        /// Child classes of Order (Factories for each Menu Item that can be ordered) will return their respective Menu Items type
        /// inside their implementations of createMenuItem method
        /// </summary>
        /// <returns>ItemInterface - Menu Item that a cutomer can order</returns>
        public abstract ItemInterface createMenuItem();

        public ItemInterface makeOrder()
        { 
            ItemInterface item = createMenuItem();
            return item;
        }

    }
}
