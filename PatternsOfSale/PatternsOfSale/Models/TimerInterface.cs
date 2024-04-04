using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsOfSale.Models
{
    public interface TimerInterface
    {
        /// <summary>
        /// Implements the update call for all subscribers
        /// </summary>
        /// <param name="timestamp"></param>
        public void UpdateTime(long timestamp);
    }
}
