using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsOfSale.Models
{
    /// <summary>
    /// Base implementation of the Customer class. Customer places Assignments (orders) and asses them with a score. 
    /// Subclasses of Customer have different implementations of assessing orders with a score, that alter gameplay.
    /// </summary>
    public abstract class Customer
    {
        public Assignment assignment { get; set; }

        /// <summary>
        /// Customer takes the time to pick assignment into consideration. Up until GOOD_THRESHOLD player gets a positive multiplier (Above 1.0).
        /// After GOOD_THRESHOLD and until GOOD_THRESHOLD * 2 player gets a negative multiplier (Below 1.0). Above that, the multiplier is 0.5.
        /// Time specified in seconds.
        /// </summary>
        const long GOOD_THRESHOLD = 3;

        /// <summary>
        /// Gets an instance of Customer with an Assignment that has numOfDishes number of dishes.
        /// </summary>
        /// <param name="numOfDishes">Number of dishes to be in an Assignment (Order)</param>
        public Customer(int numOfDishes)
        {
            Assignment newAss = new Assignment();
            newAss.AddDishes(numOfDishes);
            this.assignment = newAss;
        }

        /// <summary>
        /// Getter for GOOD_THRESHOLD
        /// </summary>
        /// <returns>GOOD_THRESHOLD - long </returns>
        public long GetGoodThreshold()
        {
            return GOOD_THRESHOLD;
        }

        /// <summary>
        /// Checks the Player's selection against a Customer's Assignment (Order).
        /// </summary>
        /// <param name="input">List that contains player selection of ItemInterface objects (Menu Items)</param>
        /// <param name="time">Timeit took to make an order (Assignment) in seconds</param>
        /// <returns></returns>
        public abstract double CheckAssignment(List<ItemInterface> input, long time);

        /// <summary>
        /// Returns a score multiplier based on time to pick an order (Assignment). Multiplier range 0.5 - 2.0.
        /// </summary>
        /// <param name="time">Time to pick order (Assignment) in seconds</param>
        /// <returns>Score Multiplier - double</returns>
        public double getScoreMultiplier(long time)
        {
            double baseMultiplier = 1.0;
            double scoreMultiplier = 0.5;
            if (time <= GetGoodThreshold())
            {
                scoreMultiplier = ((GOOD_THRESHOLD - time)/GOOD_THRESHOLD) + baseMultiplier;
            }
            else if (time > GetGoodThreshold() && time < GetGoodThreshold() * 2)
            {
                scoreMultiplier = baseMultiplier - ((time - GOOD_THRESHOLD) / GOOD_THRESHOLD);
            }

            return scoreMultiplier;
        }
    }
}
