using CommunityToolkit.Mvvm.ComponentModel;
using PatternsOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsOfSale
{
    public class GameManager : ObservableObject
    {
        public DateTime CurrentTime { get; private set; }
        public DateTime TimePlayed { get; private set; }
        public PlayerKitchen Kitchen { get; private set; }
        
        public GameManager() {
            this.Kitchen = new PlayerKitchen();
            this.CurrentTime = DateTime.Now;
            this.TimePlayed = DateTime.Now;
        }

    }
}
