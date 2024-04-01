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

        public int seatsCount { get; set; }

        public int compartmentsCount { get; set; }

        //Конструктор приймає номер,вагу та довжину вагона
        public Carriage(int identifier, string type, double weight, double length, int seatsCount = 0, int compartmentsCount = 0)
        {
            this.type = type;
            this.identifier = identifier;
            this.weight = weight;
            this.length = length;
            this.seatsCount = seatsCount;
            this.compartmentsCount = compartmentsCount;
        }
    }
}
