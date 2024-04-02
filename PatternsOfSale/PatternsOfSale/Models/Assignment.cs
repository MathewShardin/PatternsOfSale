using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        /// <summary>
        /// The method populates the dishAssignment field with random Menu Items, that a customer will order. The selection is done
        /// dynamically based on the classes that currently inherit the Order class.  
        /// </summary>
        /// <param name="numOfDishes"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void AddDishes(int numOfDishes)
        {
            // Clean the dishAssignment list if the method is accidentally called more than once
            this.dishAssignment.Clear();
            // Make sure that input num of dishes to be ordered is from 1 to 10
            if (numOfDishes > 10 || numOfDishes <= 0)
            {
                numOfDishes = 5;
            }
            List<Type> listOfDishes = GetSubclasses();
            int listDishesCount = listOfDishes.Count; // Number of items avaliable to be ordered
            // Check that the list got properly populated
            if (listDishesCount == 0)
            {
                // Make PlaceHolder assignment
                Order beerOrder = new BeerFactory();
                ItemInterface beerItem = beerOrder.CreateMenuItem();
                this.dishAssignment.Add(beerItem);
                throw new InvalidOperationException("No subclasses found.");
            }

            Random random = new Random();
            for (int i = 0; i < numOfDishes; i++)
            {
                // Choose a random dish to be ordered by customer
                // Max number (listDishesCount) is exclusive, so the random number selected corresponds to an index in listOfDishes
                int randomDishIndex = random.Next(0, listDishesCount);
                Type randomType = listOfDishes[randomDishIndex];
                // Create instance of a Item Factory that was randomly chosen
                Order? newOrderFactory = Activator.CreateInstance(randomType) as Order;
                if (newOrderFactory != null)
                {
                    ItemInterface newItem = newOrderFactory.CreateMenuItem();
                    this.dishAssignment.Add(newItem);
                } 
            }
        }

        /// <summary>
        /// The Player selection from dishPickUpStation gets compared to the assignment found dishAssignment.
        /// </summary>
        /// <param name="dishAssignment"> A List of Menu Items picked by user</param>
        /// <returns>Double. A sum of points of correctly chosen dishes minus points of incorrectly choosen dishes</returns>
        public double CheckAssCompletion(List<ItemInterface> inputSelection)
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
                    finalScore += foundItem.GetPrice();
                    // Remove the Menu Item from Assignment so that players cannot just alway choose one item and get points for it
                    tempDishAssignment.Remove(foundItem);
                }
            }

            // Subtract Score values of dishes that were not a part of the Assignment, but were picked by player
            foreach (ItemInterface dish in tempDishAssignment)
            {
                if (dish != null)
                {
                    finalScore -= dish.GetPrice();
                }

            }
            return finalScore;
        }

        /// <summary>
        /// Method programmatically compiles a list of all child classes of Order class and returns it
        /// </summary>
        /// <returns>List of child classes in format Type</returns>
        public static List<Type> GetSubclasses()
        {
            Type parentClass = typeof(Order);
            Assembly assembly = Assembly.GetAssembly(parentClass);
            return assembly.GetTypes()
                           .Where(type => type.IsSubclassOf(parentClass))
                           .ToList();
        }
    }
}
