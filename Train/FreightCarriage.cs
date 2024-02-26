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
        public string type { get; set; } = "Вантажний вагон";
        public double weight { get; set; } = 23.5;

        public double length { get; set; } = 13.3;

        public int identifier { get; set; }

        internal FreightCarriage(int identifier) : base(identifier,23.5,13.3)
        {

        }
        /// <summary>
        /// Визначає вміст вагону та змінює його опис відповідно до заповнення
        /// </summary>
        /// <returns></returns>
        public string Cargo()
        {
            Random random = new Random();
            int cargo = random.Next(1, 4); 
            switch (cargo)
            {
                case 1:
                    weight += 20;
                    return $"Вагон {identifier} заповнений вуглем";
                    break;
                case 2:
                    weight += 40;
                    return $"Вагон {identifier} заповнений залізом";
                    break;
                case 3:
                    weight += 30;
                    return $"Вагон {identifier} заповнений залізом";
                    break;
                case 4:
                    type = "Вагон цестерна";
                    weight += 18;
                    length -= 2;
                    return $"Цестерна {identifier} заповнена газом";
                    break;
                default:
                    return $"Вагон {identifier} порожній";
                    break;



            }
        }
    }
}
