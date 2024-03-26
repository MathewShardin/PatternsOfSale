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

        public override double CheckAssignment(List<ItemInterface> input, double time)
        {
            double finalScore = 0;
            double scoreMultiplier = time;
            double points = assignment.checkAssCompletion(input);

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
                scoreMultiplier = ;
            }
            finalScore = points * scoreMultiplier;

            return finalScore;
        }  
        public override Assignment GetAssignment(int numOfDishes)
        {
            Assignment currentAss = this.assignment;
            currentAss.addDishes(numOfDishes);
            return currentAss;
        }
    }

      


    }
}
