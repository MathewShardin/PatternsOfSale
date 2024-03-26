using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsOfSale.Models
{
    /// <summary>
    /// Part of the Factory Method. Interface allows the the respective factories of items to have
    /// their own implemntation of constructors and behaviours.
    /// </summary>
    public interface ItemInterface
    {
        public double getPrice();
    }
}
