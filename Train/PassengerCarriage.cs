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
        public string type { get; set; } = "Пасажирський вагон";
        public double weight { get; set; } = 7;

        public double length { get; set; } = 12;

        public int identifier { get; set; }

        internal PassengerCarriage(int identifier) : base(identifier,7,12)
        {

        }
        /// <summary>
        /// Вказує на закінчення посадки всіх пасажирів
        /// </summary>
        /// <returns></returns>
        public string Seats()
        {
            return $"Всі пасажири у вагоні {identifier} розсаджені по місцям";
        }
    }
}
