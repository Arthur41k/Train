using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    /// <summary>
    /// Дочірній клас що описує вагон їдальню
    /// </summary>
    class DiningCarriage :Carriage
    {
        public string type { get; set; } = "Вагон їдальня";
        public double weight { get; set; } = 7;

        public double length { get; set; } = 12;

        public int identifier { get; set; }

        internal DiningCarriage(int identifier) : base(identifier,7,12)
        {

        }
        /// <summary>
        /// Визначає закінчення рознусу їжі по вагону
        /// </summary>
        /// <returns></returns>
        public string Food()
        {
            return $"Всім пасажирам у вагоні {identifier} рознесено їжу";
        }
    }
}
