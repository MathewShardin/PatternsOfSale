using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsOfSale.Models
{
    public class KarenCustomer : Customer
    {
        const double CHANCE_TO_CANCEL_ORDER = 25; // 25% chance to cancel order

        public KarenCustomer(int numOfDishes) : base(numOfDishes)
        {
            Assignment newAss = new Assignment();
            newAss.AddDishes(numOfDishes);
            this.assignment = newAss;
        }

        public double GetCancellationChance()
        {
            return CHANCE_TO_CANCEL_ORDER;
        }
        /// <summary>
        /// Implementation of CheckAssignment for KarenCustomer. KarenCustomer has a 25% chance to cancel the order randomly
        /// </summary>
        /// <param name="input"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        
        public override double CheckAssignment(List<ItemInterface> input, long time)
        {
            double finalScore = 0;
            double scoreMultiplier = getScoreMultiplier(time);
            double points = assignment.CheckAssCompletion(input); 
            
            // 25% chance to cancel order as it is a Karen
            if (ShouldCancelOrder())
            {
                return finalScore;
            }

            finalScore = points * scoreMultiplier;

            return finalScore;
        }

        /// <summary>
        /// You know the drill. Karen has a 25% chance to cancel the order
        /// </summary>
        /// <returns>Random chance to cancel the order</returns>
        public bool ShouldCancelOrder()
        {
            Random random = new Random();
            // 25% chance to cancel order

            return random.Next(0, 100) < GetCancellationChance();
        }
    }
}
