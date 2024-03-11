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
                    break;
                case 2:
                    cargoType = "заповнений залізом";
                    break;
                case 3:
                    cargoType = "заповнений залізом";
                    break;
                case 4:
                    cargoType = "заповнена газом";
                    break;
                default:
                    cargoType = "порожній";
                    break;
            }
        }
       
    }
    
}

