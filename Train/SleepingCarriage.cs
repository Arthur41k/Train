using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{

    /// <summary>
    /// Дочірній клас що описує спальний вагон
    /// </summary>
    class SleepingCarriage : Carriage
    {
        public string type { get; set; } 
        public double weight { get; set; } 
        public double length { get; set; } 

        public int identifier { get; set; }

        public int compartmentsCount { get; set; }

        public bool hasShowers { get; set; }

        internal SleepingCarriage(int identifier,int compartmentsCount, bool hasShowers) :base(identifier, "SleepingCarriage",7.4,26) 
        {
          this.compartmentsCount = compartmentsCount;
          this.hasShowers = hasShowers;
        }
        /// <summary>
        /// Вказує на кількість обслугованих купе у вагоні
        /// </summary>
        /// <returns></returns>
        public string sleepwear()
        {
            Random rnd = new Random();
            int busy = rnd.Next(1, compartmentsCount);
            return $"В {busy} купе у вагоні {identifier} рознесено подушки та наволочки,ковдри та підковдри";
        }
        
        /// <summary>
        /// Визначає можливість прийняти душ у вагоні
        /// </summary>
        /// <returns></returns>
        public string Showers()
        {
            if (hasShowers)
            {
                return $" У вагоні {identifier} можна прийняти душ";
            }
            else 
            { 
                return $"У вагоні {identifier} не можна прийняти душ"; 
            }
        }
    }
}
