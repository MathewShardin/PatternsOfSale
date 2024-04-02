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
        
        public override double CheckAssignment(List<ItemInterface> input, long time)
        {
            double finalScore = 0;
            double scoreMultiplier = time;
            double points = assignment.CheckAssCompletion(input); 
            

            // 25% chance to cancel order
            if (ShouldCancelOrder())
            {
                return finalScore;
            }

            // is time is less than 3 seconds, score is multiplied by 1.5
            if(time < GetGoodThreshold())
            {
                scoreMultiplier = 1.5;
            }
            // does the user need longer than 6 seconds to complete the order, the score is halved
            else if(time > GetBadThreshold())
            {
                scoreMultiplier = 0.5;
            }
            else 
            {
                scoreMultiplier = 1;  
            }
            finalScore = points * scoreMultiplier;

            return finalScore;
        }


        //TODO: Implement GetAssignment
        //gets a random assignment with a number of dishes

    

        public bool ShouldCancelOrder()
        {
            Random random = new Random();
            // 25% chance to cancel order

            return random.Next(0, 100) < GetCancellationChance();
        }
    }
}
