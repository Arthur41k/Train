using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    /// <summary>
    /// Дочірній клас що описує пасажирські вагони
    /// </summary>
    class PassengerCarriage : Carriage
    {
        public string type { get; set; } 
        public double weight { get; set; } 

        public double length { get; set; } 
        public int identifier { get; set; }

        public int seatsCount { get; set; } 

        public string comfortlevel { get; set; }

        internal PassengerCarriage(int identifier, int seatsCount,string comfortlevel) : base(identifier, "PassengerCarriage", 7,12)
        {
            this.seatsCount = seatsCount;
            this.comfortlevel = comfortlevel;
        }
        /// <summary>
        /// Вказує на кількість зайнятих місць у вагоні
        /// </summary>
        /// <returns></returns>
        public string Seats()
        {
            Random rnd = new Random();
            int busy = rnd.Next(1,seatsCount);
            return $"В {comfortlevel } вагоні {identifier} зайнято {busy} місць";
        }
    }
}
