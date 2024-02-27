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
        public string type { get; set; } = "DiningCarriage";
        public double weight { get; set; } = 7;

        public double length { get; set; } = 12;

        public int identifier { get; set; }

        public int tablesCount { get; set; }

        bool hasKitchen { get; set; }

        internal DiningCarriage(int identifier, int tablesCount, bool hasKitchen) : base(identifier, 7, 12)
        {
            this.tablesCount = tablesCount;
            this.hasKitchen = hasKitchen;
        }
        /// <summary>
        /// Визначає закінчення рознусу їжі 
        /// </summary>
        /// <returns></returns>
        public string Food()
        {
            if (hasKitchen)
            {
                Random rnd = new Random();
                int busy = rnd.Next(1, tablesCount);
                return $"{busy} пасажирам у вагоні {identifier} рознесено їжу";
            }
            else 
            {
                return $"У вагоні {identifier} {tablesCount} місць для того аби поїсти власну їжу ";
            }
        }
    }
}
