using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;

namespace PatternsOfSale.Models
{
    public class EasyCustomer : Customer
    {
        public EasyCustomer(Assignment assignment) : base(assignment)
        {
            this.assignment = base.assignment;
        }

        public override double CheckAssignment(List<Order> input, int timeMultiplier)
        {
            throw new NotImplementedException();
        }

        public override Assignment GetAssignment(int numOfDishes)
        {
            throw new NotImplementedException();
        }


    }
}
