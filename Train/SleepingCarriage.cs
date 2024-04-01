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

        //Власні зміні

        public bool compartment = false;

        public bool sauna = false;

        internal SleepingCarriage(int identifier,int compartmentsCount, bool hasShowers) :base(identifier, "SleepingCarriage",7.4,26, compartmentsCount: compartmentsCount)
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
        /// Визначає можливість прийняти душ та попаритись в бані 
        /// </summary>
        /// <returns></returns>
        public string Showers()
        {
            Random rand = new Random();
            if (rand.Next(1,5) == 1)
            {
                sauna = true ;
            }
            if (hasShowers)
            {
                if (sauna)
                {
                    return $"У вагоні {identifier} можна прийняти душ або попаритись в бані";
                }
                else 
                { 
                    return $" У вагоні {identifier} можна прийняти душ"; 
                }
            }
            else 
            { 
                return $"У вагоні {identifier} не можна прийняти душ"; 
            }
        }

        /// <summary>
        /// Обробка можливості конфліктів
        /// </summary>
        public void Conflicts()
        {
            if(compartment)
            {
                Console.WriteLine("Через те що цей вагон з купе конфлікти дуже рідкісні");
            }
            else 
            { 
                Random rand = new Random();
                int Case = rand.Next(1, 5);
                if (Case == 5)
                {
                    Console.WriteLine("В вагоні плацкарт стався конфлікт");
                }
                else 
                { 
                    Console.WriteLine("В вагоні плацкарт,але конфліктів не було");
                }   
            }
        }
    }
}
