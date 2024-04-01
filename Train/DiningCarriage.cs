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
        public string type { get; set; } 
        public double weight { get; set; } 

        public double length { get; set; } 

        public int identifier { get; set; }


        bool hasKitchen { get; set; }

        //Власні зміні
        public int tablesCount { get; set; }

        StringBuilder Menu = new StringBuilder();


        internal DiningCarriage(int identifier, int tablesCount, bool hasKitchen) : base(identifier, "DiningCarriage", 7, 12)
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

        /// <summary>
        /// Створення меню вагону їдальні
        /// </summary>
        public void AddMenu()
        {
            Console.WriteLine("Скільки страв буде в вашому меню ? \n= ");
            int Number = int.Parse(Console.ReadLine());
            Console.WriteLine("Записуйте страви");
            for (int i = 0; i < Number; i++)
            {
                Console.Write($"{i} = ");
                Menu.AppendLine(Console.ReadLine());
                Menu.AppendLine(",");
            }
            Menu.Remove(Menu.Length - 1, 1);
            Menu.AppendLine(".");
        }
    }
}
