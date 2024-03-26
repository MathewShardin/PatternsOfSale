using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Google.Crypto.Tink.Signature;

namespace PatternsOfSale.Models
{
    public class KarenCustomer : Customer
    {
        const double CHANCE_TO_CANCEL_ORDER = 25;

        public KarenCustomer(Assignment assignment) : base(assignment)
        {
            this.assignment = base.assignment;
        }

        public double GetCancellationChance()
        {
            return CHANCE_TO_CANCEL_ORDER;
        }
        
        public override double CheckAssignment(List<Order> input, int timeMultiplier)
        {
            int scoreMultiplier = timeMultiplier;
            this.assignment.checkAssCompletion(input);
            // 25% chance to cancel order
            if (shouldCancelOrder())
            {
                return 0;
            }


        }

        public override Assignment GetAssignment(int numOfDishes)
        {
            throw new NotImplementedException();
        }

        public bool shouldCancelOrder()
        {
            Random random = new Random();
            // 25% chance to cancel order

            return random.Next(0, 100) < GetCancellationChance();
        }
    }
}
