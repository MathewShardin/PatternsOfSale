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
        const long GOOD_THRESHOLD = 3;
        const long BAD_THRESHOLD = 6;

        public Customer(int numOfDishes)
        {
            Assignment newAss = new Assignment();
            newAss.AddDishes(numOfDishes);
            this.assignment = newAss;
        }

        //getter for constant GOOD_THRESHOLD
        public long GetGoodThreshold()
        {
            return GOOD_THRESHOLD;
        }

        //getter for constant BAD_THRESHOLD

        public long GetBadThreshold()
        {
            return BAD_THRESHOLD;
        }

        //multiply the score by the timeMultiplier
        public abstract double CheckAssignment(List<ItemInterface> input, long time);
    }
}
