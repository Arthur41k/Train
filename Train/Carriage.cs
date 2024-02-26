using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    /// <summary>
    /// Базовий клас Carriage який приймає номер вагона і обробляє інформацію про цей вагон.
    /// </summary>
    class Carriage
    {
        public string type { get; set; }
        public double weight { get; set; }

        public double length { get; set; }

        public int identifier { get; set; }

        //Конструктор приймає номер,вагу та довжину вагона
        public Carriage(int identifier, double weight, double length)
        {
            this.identifier = identifier;   
            this.weight = weight;
            this.length = length;
        }
        /// <summary>
        /// Обраховує приблизну швидкість вагону з урахуванням його ваги та довжини
        /// </summary>
        /// <returns></returns>
        public double Speed()
        {
            double speed = (30 - this.weight / 3 - this.length / 5) - ((30 - this.weight / 3 - this.length / 5) % 1);
            return speed;
        }

        /// <summary>
        /// Вказує на те що вагон рухається
        /// </summary>
        /// <param name="speed"></param>
        /// <returns></returns>
        public string Go(int speed)
        {
            return $"Вагон {identifier} їде зі швидкістю {speed} км на годину";
        }
        /// <summary>
        /// Вказує на те що вагон стоїть
        /// </summary>
        /// <param name="speed"></param>
        /// <returns></returns>
        public string standing()
        {   
                return $"Вагон {identifier} зупинився";  
        }
    }
}
