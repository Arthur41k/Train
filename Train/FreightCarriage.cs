using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    /// <summary>
    /// Дочірній клас що описує вантажні вагони
    /// </summary>
    class FreightCarriage:Carriage
    {
        public string type { get; set; } 
        public double weight { get; set; }

        public double length { get; set; } 

        public int identifier { get; set; }

        public double maxLoadCapacity { get; set; }

        public string cargoType { get; set; }

        // Власні зміні
        public bool Filling { get; set; } = false;
        public string Mark {  get; set; }

        internal FreightCarriage(int identifier, double maxLoadCapacity) : base(identifier, "FreightCarriage", 23.5, 13.3)
        {
            this.maxLoadCapacity = maxLoadCapacity;
        }
        /// <summary>
        /// Визначає вміст вагону 
        /// </summary>
        /// <returns></returns>
        public void Cargo()
        {
            Random random = new Random();
            int cargo = random.Next(1, 4);
            switch (cargo)
            {
                case 1:

                    cargoType = " заповнений вуглем ";
                    Filling = true;
                    break;
                case 2:
                    cargoType = "заповнений залізом";
                    Filling = true;
                    break;
                case 3:
                    cargoType = "заповнений залізом";
                    Filling = true;
                    break;
                case 4:
                    cargoType = "заповнена газом";
                    Filling = true;
                    break;
                default:
                    cargoType = "порожній";
                    break;
            }
        }

        /// <summary>
        /// Маркування вагона відповідно до країни з якої вантаж
        /// </summary>
        public void Marking()
        {
            Console.Write("Звідки вантаж ? \nУкраїна(1), Польша(2), Турція(3), Німечина(4), Франція(5), Британія(6)\n=");
            int Country = int.Parse(Console.ReadLine());
            switch (Country)
            {
                case 1:
                    Mark = "UA";
                    break;
                case 2:
                    Mark = "PL";
                    break;
                case 3:
                    Mark = "TR";
                    break;
                case 4:
                    Mark = "GR";
                    break;
                case 5:
                    Mark = "FR";
                    break;
                case 6:
                    Mark = "UK";
                    break;
            }
        }

        /// <summary>
        /// Вивантаження вагона
        /// </summary>
        public void Unloading()
        {
            if( Filling )
            {
                Filling = false;
                Console.WriteLine("Вагон вивантажено");

            }
            else 
            { 
                Console.WriteLine("Вагон не можливо вивантажити тому що він порожній"); 
            }
        }
       
    }
    
}

