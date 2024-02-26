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
        public string type { get; set; } = "Спальний вагон";
        public double weight { get; set; } = 7.4;

        public double length { get; set; } = 26;

        public int identifier { get; set; }

        internal SleepingCarriage(int identifier):base(identifier,7.4,26) 
        {
          
        }
        /// <summary>
        /// Вказує на закінчення роздачі білизни для пасажирів
        /// </summary>
        /// <returns></returns>
        public string sleepwear()
        {
            return $"Всім пасажирам у вагоні {identifier} рознесено подушки та наволочки,ковдри та підковдри";
        }
        
    }
}
