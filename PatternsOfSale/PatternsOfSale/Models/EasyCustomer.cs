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
        public EasyCustomer(int numOfDishes) : base(numOfDishes)
        {
            Assignment newAss = new Assignment();
            newAss.AddDishes(numOfDishes);
            this.assignment = newAss;
        }

        public override double CheckAssignment(List<ItemInterface> input, long time)
        {
            double finalScore = 0;
            double scoreMultiplier = time;
            double points = assignment.CheckAssCompletion(input);

            // is time is less than 3 seconds, score is multiplied by 1.5
            if (time < GetGoodThreshold())
            {
                scoreMultiplier = 1.5;
            }
            // does the user need longer than 6 seconds to complete the order, the score is halved
            else if (time > GetBadThreshold())
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
    
    }

}
