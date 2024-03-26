using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsOfSale.Models
{
    public class PlayerKitchen
    {
        public List<ItemInterface> dishPickUpStation { get; set; }
        public int lastUnixTime { get; set; }
        public Customer currentCustomer { get; set; }
        public double score { get; set; }

        public PlayerKitchen()
        {
            dishPickUpStation = new List<ItemInterface>();
            lastUnixTime = 0;
            currentCustomer = null;
            score = 0;
        }

        public void AddOrder(ItemInterface orderItem)
        {
            dishPickUpStation.Add(orderItem);
        }
        public void RemoveOrder(ItemInterface orderItem)
        {
            dishPickUpStation.Remove(orderItem);
        }

        public List<ItemInterface> GetDishes()
        {
            return dishPickUpStation;
        }

        public void SetCustomer(Customer customer)
        {
            if(customer is KarenCustomer || customer is EasyCustomer)
            {
                currentCustomer = customer;
            }
            currentCustomer = customer;
        }

        public void UpdateTicker(int unixTime)
        {
            lastUnixTime = unixTime;
        }
        public double GetScore()
        {
            return score;
        }

        /// <summary>
        /// makes sure that the score is not negative
        /// </summary>
        /// <param name="score"></param>
        public void SetScore(double score)
        {
            if(score < 0 )
            {
                this.score = 0;
                return;
            }
            this.score = score;
        }

        public void resetStats()
        {
            SetCustomer(null);
            SetScore(0);
            dishPickUpStation.Clear();
            lastUnixTime = 0;
        }

        /// <summary>
        /// Checks the current customer's assignment and updates the score
        /// </summary>
        /// <returns>The score of the Customer</returns>
        public double CheckAssForCustomer(Customer customer)
        {
            SetCustomer(customer);
            if(customer is KarenCustomer)
            {
                return customer.CheckAssignment(dishPickUpStation, lastUnixTime);
            }else if(customer is EasyCustomer)
            {
                return customer.CheckAssignment(dishPickUpStation, lastUnixTime);
            }
            return 0;
                
        }
        /// <summary>
        /// Submits the current customer's assignment and updates the score
        /// </summary>
        public void Submit()
        {
               if (currentCustomer != null)
               {
                //send the score of the customer to the game class
                CheckAssForCustomer(currentCustomer);
                GetScore();
                resetStats();
               }
            return;
        }




    }
}
