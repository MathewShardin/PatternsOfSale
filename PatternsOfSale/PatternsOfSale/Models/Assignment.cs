using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsOfSale.Models
{
    /// <summary>
    /// Assignment is a Customer's order. An instance of Assignment class tells the player what Menu Items should be picked
    /// and delivered.
    /// </summary>
    public class Assignment
    {
        private List<ItemInterface> dishAssignment;

        public Assignment() 
        {
            dishAssignment = new List<ItemInterface>();
        }

        public void addDishes(int numOfDishes)
        {
            // TO DO add random dishes
        }

        /// <summary>
        /// The Player selection from dishPickUpStation get compared to the assignment found dishAssignment.
        /// </summary>
        /// <param name="dishAssignment"> A List of Menu Items picked by user</param>
        /// <returns>Double. A sum of points of correctly chosen dishes minus points of incorrectly choosen dishes</returns>
        public double checkAssCompletion(List<ItemInterface> inputSelection)
        {
            double finalScore = 0;
            List<ItemInterface> tempDishAssignment = dishAssignment;

            // Iterate through user dish selection and check if each item is present in the Assignment
            foreach (ItemInterface dish in inputSelection)
            {
                // Skip loop iteration if a selected Item is null
                if (dish == null) { continue; }
                ItemInterface? foundItem = tempDishAssignment.FirstOrDefault(item => item.GetType() == dish.GetType());
                if (foundItem != null) 
                {
                    // Add the score value of a Menu Item if it was picked correctly
                    finalScore += foundItem.getPrice();
                    // Remove the Menu Item from Assignment so that players cannot just alway choose one item and get points for it
                    tempDishAssignment.Remove(foundItem);
                }
            }

            // Subtract Score values of dishes that were not a part of the Assignment, but were picked by player
            foreach (ItemInterface dish in tempDishAssignment)
            {
                if (dish != null)
                {
                    finalScore -= dish.getPrice();
                }

            }
            return finalScore;
        }
    }
}
