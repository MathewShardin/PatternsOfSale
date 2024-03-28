using Microsoft.Maui.Animations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsOfSale.Models
{
    internal class Timer : TimerInterface
    {
        private int Tick;
        public Timer() { }

        public void UpdateTick(int tick)
        {
            this.Tick += tick;
        }
    }
}
