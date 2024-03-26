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
        
        //use this for the time multiplier
        const double GOOD_THRESHOLD = 3;
        const double BAD_THRESHOLD = 6;


        public Customer(Assignment assignment)
        {
            this.assignment = assignment;
        }

        //getter for constant GOOD_THRESHOLD
        public double GetGoodThreshold()
        {
            return GOOD_THRESHOLD;
        }

        //getter for constant BAD_THRESHOLD

        public double GetBadThreshold()
        {
            return BAD_THRESHOLD;
        }

        public abstract Assignment GetAssignment(int numOfDishes);

        public abstract double CheckAssignment(List<ItemInterface> input, double time);
        //multiply the score by the timeMultiplier
    }
}
