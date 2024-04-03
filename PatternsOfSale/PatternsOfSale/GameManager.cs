using CommunityToolkit.Mvvm.ComponentModel;
using PatternsOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PatternsOfSale
{
    public class GameManager : TimerInterface
    {
        public long TimeSinceLastOrder { get; private set; }
        public long LastOrderTimeStamp { get; private set; }
        public long TimePlayed { get; private set; }
        public long GameStartTimeStamp {  get; private set; }
        public long LastUnixTime { get; private set; }
        public PlayerKitchen Kitchen { get; private set; }
        public bool isGameRunning { get; private set; }
        const int MAXNUMBEROFDISHES = 10;

        public GameManager() {
            this.Kitchen = new PlayerKitchen();
            this.TimeSinceLastOrder = 0;
            this.TimePlayed = 0;
            this.GameStartTimeStamp = 0;
            this.LastUnixTime = 0;
            this.LastOrderTimeStamp = 0;
            this.isGameRunning = false;
        }

        public void UpdateTime(long timestamp)
        {
            if (this.LastUnixTime == 0)
            {
                this.LastUnixTime = timestamp;
            }

            if (this.LastOrderTimeStamp == 0)
            {
                this.LastOrderTimeStamp = timestamp;
            }
            this.TimeSinceLastOrder = timestamp - this.LastOrderTimeStamp;

            if (this.GameStartTimeStamp == 0)
            {
                this.GameStartTimeStamp = timestamp;
            }
            this.TimePlayed = timestamp - this.GameStartTimeStamp;

            this.LastUnixTime = timestamp;

        
        }

        public void StartGame()
        {
            this.GameStartTimeStamp = LastUnixTime;
            GameTimer gameTimer = new GameTimer(); // REFERS TO SINGELTON
            // Reset Player
            PlayerKitchen newplayerKitchen = new PlayerKitchen();
            gameTimer.AddSubscriber(newplayerKitchen);
            this.Kitchen = newplayerKitchen;
            // Change game status
            this.isGameRunning = true;
            this.Kitchen.NewGameRound(GetRandomCustomer(), TimeSinceLastOrder);
        }

        public void StopGame()
        {
            GameTimer gameTimer = new GameTimer(); // REFERS TO SINGELTON
            // Change game status
            this.isGameRunning = false;
            gameTimer.RemoveSubscriber(this.Kitchen);
        }

        public void Submit()
        {
            this.Kitchen.Submit();
            // UPDATE GUI HERE

            // Give new Assignment
            this.Kitchen.NewGameRound(GetRandomCustomer(), TimeSinceLastOrder);
            this.TimeSinceLastOrder = 0;
            this.LastOrderTimeStamp = this.LastUnixTime;
        }

        public Customer GetRandomCustomer()
        {
            Random random = new Random();
            // Get random number of dishes a customer will order
            int numOfDishes = random.Next(0, MAXNUMBEROFDISHES);

            List<Type> listOfCustomers = GetSubclassesCustomer();
            int listCustomersCount = listOfCustomers.Count; // Number of customer types that can come to cafe
            // Check that the list got properly populated
            if (listCustomersCount == 0)
            {
                // Assign a placeholder customer in case of an issue
                Customer customerPlaceHolder = new EasyCustomer(numOfDishes);
                return customerPlaceHolder;
            }

            // Choose a random customer to come to a cafe
            // Max number (listCustomersCount) is exclusive, so the random number selected corresponds to an index in listOfCustomers
            int randomCustIndex = random.Next(0, listCustomersCount);
            Type randomType = listOfCustomers[randomCustIndex];
            // Create instance of a Customer that was randomly chosen
            Customer? newCustomer = Activator.CreateInstance(randomType, numOfDishes) as Customer;
            if (newCustomer != null)
            {
                return newCustomer;
            } else
            {
                // Assign a placeholder customer in case of an issue
                Customer customerPlaceHolder = new EasyCustomer(numOfDishes);
                return customerPlaceHolder;
            }

        }

        /// <summary>
        /// Method programmatically compiles a list of all child classes of Customer class and returns it
        /// </summary>
        /// <returns>List of child classes in format Type</returns>
        public static List<Type> GetSubclassesCustomer()
        {
            Type parentClass = typeof(Customer);
            Assembly assembly = Assembly.GetAssembly(parentClass);
            return assembly.GetTypes()
                           .Where(type => type.IsSubclassOf(parentClass))
                           .ToList();
        }
    }
}
