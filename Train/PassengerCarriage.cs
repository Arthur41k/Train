using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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

        //Власні зміні
        public int personnel = 0;

        public bool equipment = false;

        internal PassengerCarriage(int identifier, int seatsCount,string comfortlevel) : base(identifier, "PassengerCarriage", 7,12,seatsCount:seatsCount)
        {
            this.seatsCount = seatsCount;
            this.comfortlevel = comfortlevel;
        }

        /// <summary>
        /// Обробка рівня комфорту вагону
        /// </summary>
        public void ProComfortlevel()
        {
            if(comfortlevel== "Default")
            {
                Console.WriteLine("Це звичайний вагон");
            }
            else if(comfortlevel == "Business")
            {
                equipment = true;
                Console.WriteLine("В цьому вагоні є ксерокс,сканер та магазинчик канстоварів");
            }
            else if(comfortlevel == "S-class")
            {
                Console.Write("Яка кількість персоналу обслуговує пасажирів (не більше 5)? \n= ");
                int Number = int.Parse(Console.ReadLine());
                if(Number <= 5)
                {
                    personnel = Number;
                }
                else { Console.WriteLine("Вагон не може вмістити таку кількість персоналу"); }
            }
        }

        /// <summary>
        /// Обслуговування вагону S-класу
        /// </summary>
        public void Service()
        {
            if(personnel != 0)
            {
                Console.WriteLine("Персонал приймає побажання");
                Thread.Sleep(7000 - personnel * 1000);
                Console.WriteLine("Побажання виконані");
            }
        }

    }
}
