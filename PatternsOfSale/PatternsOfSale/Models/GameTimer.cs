using Microsoft.Maui.Animations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsOfSale.Models
{
    public class GameTimer
    {
        public List<TimerInterface> TimerInterfaces { get; set; }

        
        public GameTimer() 
        {
            this.TimerInterfaces = new List<TimerInterface>();
        }

        public void AddSubscriber(TimerInterface subscriber)
        {
            TimerInterfaces.Add(subscriber);
        }

        public void RemoveSubscriber(TimerInterface subscriber)
        {
            TimerInterfaces.Remove(subscriber);
        }

        public void SendTick()
        {
            foreach(TimerInterface subscriber in TimerInterfaces)
            {
                long unixTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                subscriber.UpdateTime(unixTimestamp);
            }
        }
    }
}
