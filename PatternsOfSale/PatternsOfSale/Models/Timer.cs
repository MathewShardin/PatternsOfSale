using Microsoft.Maui.Animations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsOfSale.Models
{
    public class Timer
    {
        public List<TimerInterface> timerInterfaces { get; set; }

        
        public Timer() 
        {
            this.timerInterfaces = new List<TimerInterface>();
        }

        public void AddSubscriber(TimerInterface subscriber)
        {
            timerInterfaces.Add(subscriber);
        }

        public void RemoveSubscriber(TimerInterface subscriber)
        {
            timerInterfaces.Remove(subscriber);
        }

        public void sendTickVoid()
        {
            foreach(TimerInterface subscriber in timerInterfaces)
            {
                subscriber.UpdateTime(1);
            }
        }
    }
}
