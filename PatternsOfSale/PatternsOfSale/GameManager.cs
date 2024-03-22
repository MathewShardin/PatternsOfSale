using CommunityToolkit.Mvvm.ComponentModel;
using PatternsOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsOfSale
{
    internal class GameManager : ObservableObject
    {
        public DateTime CurrentTime { get; private set; }
        public DateTime CimePlayed { get; private set; }
        public PlayerKitchen Kitchen { get; private set; }
        
        public GameManager() {
            
        }

    }
}
