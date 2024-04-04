using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsOfSale.Models
{
    public class PlayerKitchen : TimerInterface
    {
        /// <summary>
        /// Gets or sets the list of items in the DishPickUpStation
        /// </summary>
        public List<ItemInterface> DishPickUpStation { get; set; }
        /// <summary>
        /// Time stamp of last assignment placed
        /// </summary>
        public long LastUnixTime { get; set; } 
        /// <summary>
        /// Time passed since last assignment
        /// </summary>
        public long PassedSinceLastAssignment { get; set; }
        /// <summary>
        /// Current customer assigned to the player, can be null
        /// </summary>
        public Customer? CurrentCustomer { get; set; }
        /// <summary>
        /// Score of the player
        /// </summary>
        public double Score { get; private set; }

        public PlayerKitchen()
        {
            DishPickUpStation = new List<ItemInterface>();
            LastUnixTime = -1;
            Score = 0;
        }

        public void AddOrder(ItemInterface orderItem)
        {
            DishPickUpStation.Add(orderItem);
        }
        public void RemoveOrder(ItemInterface orderItem)
        {
            DishPickUpStation.Remove(orderItem);
        }



        /// <summary>
        /// Sets the score field to a input score, but makes sure that the score is never negative
        /// </summary>
        /// <param name="score">Double. New score to be set</param>
        public void SetScore(double score)
        {
            if(score < 0 )
            {
                this.Score = 0;
                return;
            }
            this.Score = score;
        }

        /// <summary>
        /// Adds the input to the score field of player
        /// </summary>
        /// <param name="scoreInp">Double. Score to be added or subtracted</param>
        public void AddScore(double scoreInp)
        {
            SetScore(this.Score + scoreInp);
        }

        /// <summary>
        /// Checks the current customer's assignment and updates the score
        /// </summary>
        public void CheckAssForCustomer()
        {
            if (this.CurrentCustomer != null)
            {
                double tempScore = this.CurrentCustomer.CheckAssignment(DishPickUpStation, PassedSinceLastAssignment);
                AddScore(tempScore);
            }
        }

        /// <summary>
        /// Prepares the PlayerKitchen object to recieve a new Assignment. Method shoud be called by GameManager
        /// </summary>
        public void Submit()
        {
            if (this.CurrentCustomer != null)
            {
                CheckAssForCustomer();
                this.DishPickUpStation.Clear();
            }
        }
       
        /// <summary>
        /// Implementation of the TimerInterface. Updates the time passed since last assignment
        /// </summary>
        /// <param name="timestamp"></param>
        public void UpdateTime(long timestamp)
        {
            if (LastUnixTime == -1)
            {
                LastUnixTime = timestamp;
            }
            this.PassedSinceLastAssignment = timestamp - this.LastUnixTime;
            this.LastUnixTime = timestamp;
        }

        public void NewGameRound(Customer cust, long timeStamp)
        {
            this.LastUnixTime = timeStamp;
            this.CurrentCustomer = cust;
            //this.DishPickUpStation.Clear();
        }


    }
}
