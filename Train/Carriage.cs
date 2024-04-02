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

        //Власні зміні
        double speed { get; set; }

        int EnginePower { get; set; }

        string color { get; set; }

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

        /// <summary>
        /// Метод що в залежності від типу потяга визначає силу його двигуна
        /// </summary>
        /// <param name="carriages"></param>
        public void ProcessingEnginer(LinkedList<Carriage> carriages)
        {
            Random random = new Random();
            if (carriages.First?.Value != null && carriages.First.Value.type == "FreightCarriage")
            {
                EnginePower = random.Next(80, 160);
            }
            else
            {
                EnginePower = random.Next(50, 100);
            }
        }

        /// <summary>
        /// Визначає швидкість вагона(а одже і всього потяга) в залежності від ваги та довжини потяга в якому знаходиться цей вагон 
        /// </summary>
        /// <param name="carriages"></param>
        public void Speed(LinkedList<Carriage> carriages)
        {
            double AllWeight = 0;
            double Alllength = 0;
            foreach (Carriage car in carriages)
            {
                AllWeight += car.weight;
                Alllength += car.length;
            }
            speed = (EnginePower - AllWeight * 0.05) - Alllength * 0.01;
        }

        /// <summary>
        /// Визначає колір вагона
        /// </summary>
        public void Color()
        {
            if (type == "FreightCarriage")
            {
                color = "Green";
            }
            else if (type == "PassengerCarriage")
            {
                color = "Blue";
            }
            else if (type == "SleepingCarriage")
            {
                color = "White";
            }
            else if (type == "DiningCarriage")
            {
                color = "Red";
            }
        }
    }
}
