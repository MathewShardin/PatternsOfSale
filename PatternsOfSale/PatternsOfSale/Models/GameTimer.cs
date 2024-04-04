using Microsoft.Maui.Animations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PatternsOfSale.Models
{
    public class GameTimer
    {
        public List<TimerInterface> TimerInterfaces { get; set; }
        private readonly object lockObject = new object();
        private bool isRunning = false;
        private const int TIMESPEED = 1000; //Speed of one Game Tick in milliseconds

        public GameTimer(GameManager manager) 
        {
            this.TimerInterfaces = new List<TimerInterface>();

            this.AddSubscriber(manager);

            // Launch the timer forever on a seprate thread
            //Thread threadTimer = new Thread(() =>
            Task.Run(async () =>
            {
                while (true)
                {
                    while (manager.isGameRunning == true)
                    {
                        await Task.Delay(TIMESPEED);
                        this.SendTick();
                    }

                }
            });
            //threadTimer.IsBackground = true;
            //threadTimer.Start();
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
            foreach (TimerInterface subscriber in TimerInterfaces)
            {
                long unixTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                subscriber.UpdateTime(unixTimestamp);
            }
        }
    }
}
