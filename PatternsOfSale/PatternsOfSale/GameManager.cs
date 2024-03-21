using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsOfSale
{
    internal class GameManager : ObservableObject
    {
        [ObservableProperty]
        private DateTime currentTime { get; set; }
        private DateTime timePlayed { get; set; }
        
        public GameManager() {
            
        }

    }
}
