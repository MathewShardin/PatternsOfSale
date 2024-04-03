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
        public List<ItemInterface> DishPickUpStation { get; set; }
        public long LastUnixTime { get; set; } // TIme stamp of last Ass. placed
        public long PassedSinceLastAssignment { get; set; }
        public Customer? CurrentCustomer { get; set; }
        public double Score { get; private set; }

        public PlayerKitchen()
        {
            DishPickUpStation = new List<ItemInterface>();
            LastUnixTime = 0;
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
       

        public void UpdateTime(long timestamp)
        {
            this.PassedSinceLastAssignment = timestamp - this.LastUnixTime;
        }

        public void NewGameRound(Customer cust, long timeStamp)
        {
            this.LastUnixTime = timeStamp;
            this.CurrentCustomer = cust;
            this.DishPickUpStation.Clear();
        }


    }
}
