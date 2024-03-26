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
        public List<Order> orders { get; set; }
        public int lastUnixTime { get; set; }
        public Customer currentCustomer { get; set; }
        public int score { get; set; }

        public PlayerKitchen()
        {
            orders = new List<Order>();
            lastUnixTime = 0;
            currentCustomer = null;
            score = 0;
        }



    }
}
