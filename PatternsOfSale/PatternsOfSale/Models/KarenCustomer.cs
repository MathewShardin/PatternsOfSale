using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsOfSale.Models
{
    public class KarenCustomer : Customer
    {
        const double CHANCE_TO_CANCEL_ORDER = 25;

        public KarenCustomer(Assignment assignment) : base(assignment)
        {
            this.assignment = base.assignment;
        }

        //getter for constant
        public double ChanceToCancelOrder
        {
            get { return CHANCE_TO_CANCEL_ORDER; }
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
