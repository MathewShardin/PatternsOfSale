using Java.Lang;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsOfSale.Models
{
    public abstract class Customer
    {
        public Assignment assignment { get; set; }

        public Customer(Assignment assignment)
        {
            this.assignment = assignment;
        }

        public abstract Assignment GetAssignment(int numOfDishes);

        public abstract double CheckAssignment(List<Order> input, int timeMultiplier);
    }
}
