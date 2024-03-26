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

            //if the user neeeds longer than 3 sek to complete the order, the score is halved
            if(time < GetGoodThreshold())
            {
                scoreMultiplier = 1.5;
            }else if(time > GetBadThreshold())
            {
                scoreMultiplier = 0.5;
            }

            finalScore = points * scoreMultiplier;

            return finalScore;
        }

        public override Assignment GetAssignment(int numOfDishes)
        {
            
            throw new NotImplementedException();
        }


    }
}
