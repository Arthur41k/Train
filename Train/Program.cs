namespace Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<int> peopleCount = new List<int>();
            List<int> CompartmentsCount = new List<int>();

            Console.Write("Введіть назву потягу: ");
            string Name = Console.ReadLine();
            train Train = new train(Name, 1);
            Console.WriteLine("Який у вас потяг ? \n Вантажний(1) \n Пасажирський(2)");
            int N = int.Parse(Console.ReadLine());
            if (N == 1)
            {
                Console.Write("Скільки ви хочете додати вагонів (не більше 10) ? \n = ");
                int n = int.Parse(Console.ReadLine());
                if (n<=10)
                {
                    for (int i = 0; i < n; i++)
                    {
                        FreightCarriage Carriage = new FreightCarriage(i, 70);
                        Train.AddCarrige(Carriage);
                        Carriage.Cargo();

                    } 
                }
                else { Console.WriteLine("Забагато вагонів"); }
            }
            else if (N == 2)
            {
                Console.Write("Скільки ви хочете додати вагонів (не більше  10) ? = ");
                int n = int.Parse(Console.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    if (n <= 10)
                    {
                        Console.Write("Який додати вагон ? \n Пасажирський(1) \n Спальний вагон(2) \n Вагон їдальня (3) \n = ");
                        int Numeric = int.Parse(Console.ReadLine());
                        switch (Numeric)
                        {
                            case 1:
                                Console.Write("Скільки місць у вагоні ? \n = ");
                                int seats = int.Parse(Console.ReadLine());
                                peopleCount.Add(seats);
                                Console.Write("Який клас у пасажирського вагона ? \n Звичайний(1) \n Бізнес(2) \n S-клас(3) \n = ");
                                string CarrigeClass;
                                int clas = int.Parse(Console.ReadLine());
                                switch (clas)
                                {
                                    case 1:
                                        CarrigeClass = "Default";
                                        break;
                                    case 2:
                                        CarrigeClass = "Business";
                                        break;
                                    case 3:
                                        CarrigeClass = "S-class";
                                        break;
                                    default:
                                        CarrigeClass = "";
                                        break;
                                }
                                PassengerCarriage Carriage = new PassengerCarriage(i, seats, CarrigeClass);
                                Train.AddCarrige(Carriage);                                 
                                Console.Clear();
                                break;
                            case 2:
                                Console.Write("Скільки купе у вагоні ? \n = ");
                                int Compartments = int.Parse(Console.ReadLine());
                                CompartmentsCount.Add(Compartments);
                                bool B = false;
                                Console.Write("У вагоні є душ ? \n Так(1) \n Ні(2) \n =");
                                int choese = int.Parse(Console.ReadLine());
                                if (choese == 1)
                                {
                                    B = true;
                                }
                                SleepingCarriage Carriage_1 = new SleepingCarriage(i, Compartments, B);
                                Train.AddCarrige(Carriage_1);
                                Console.Clear();
                                break;
                            case 3:
                                Console.Write("Скільки столів у вагоні ? \n = ");
                                int tablesCount = int.Parse(Console.ReadLine());
                                bool Boo = false;
                                Console.Write("У вагоні є кухня ? \n Так(1) \n Ні(2) \n = ");
                                int choeses = int.Parse(Console.ReadLine());
                                if (choeses == 1)
                                {
                                    Boo = true;
                                }
                                DiningCarriage Carriage_2 = new DiningCarriage(i, tablesCount, Boo);
                                Train.AddCarrige(Carriage_2);
                                Console.Clear();
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Забагато вагонів");
                    }

                }
            }
            else
            {
                Console.WriteLine("Ви ввели не правельне число");
            }
            Train.PrintInfo();
            Console.WriteLine($"В потязі {Train.SumPasagire(peopleCount,CompartmentsCount)} пасажирів (включно з машиністом).");
            Thread.Sleep(7000);
            Console.Clear();
            for (; ; )
            {
                Console.Write("Ви хочете видалити якийсь вагон ? Так(1) Ні(2) \n = ");
                int A = int.Parse(Console.ReadLine());
                if (A == 1)
                {
                    Console.Write("Який вагон видалити ? Напишіть номер вагону (починаючи з 1) \n = ");
                    int CarrigeNumber = int.Parse(Console.ReadLine());  
                    
                    Train.RemovCarriage(CarrigeNumber);
                    Train.PrintInfo();
                    Console.WriteLine($"В потязі {Train.SumPasagire(peopleCount, CompartmentsCount)} пасажирів (включно з машиністом).");
                    Thread.Sleep(7000);
                    Console.Clear();
                }
                else
                {
                    break;
                }
            }
            Train.PrintInfo();
            Console.WriteLine($"В потязі {Train.SumPasagire(peopleCount, CompartmentsCount)} пасажирів (включно з машиністом).");
            Thread.Sleep(7000);
            Console.Clear();
            for (; ; )
            {
                Console.Write("Ви хочете знайти якийсь вагон за певною ознакою ? Так(1) Ні(2) \n = ");
                int A = int.Parse(Console.ReadLine());
                if (A == 1)
                {
                    Console.Write("За якою ознаю шукати ? \n Тип вагона (1) \n Вага вагона (2) \n Довжина вагону (3)\n = ");
                    int CarrigeNumber = int.Parse(Console.ReadLine());
                    switch(CarrigeNumber)
                    {
                        case 1:
                            Console.Write("Який тип шукати ? \n PassengerCarriage (1) \n DiningCarriage (2) \n SleepingCarriage (3)\n FreightCarriage (4) \n = ");
                            int B = int.Parse(Console.ReadLine());
                            switch (B)
                            {
                                case 1:
                                    Console.WriteLine(Train.SearchCarrige("PassengerCarriage")); 
                                    break;
                                case 2:
                                    Console.WriteLine(Train.SearchCarrige("DiningCarriage"));
                                    break; 
                                case 3:
                                    Console.WriteLine(Train.SearchCarrige("SleepingCarriage"));
                                    break;
                                case 4:
                                    Console.WriteLine(Train.SearchCarrige("FreightCarriage"));
                                    break;
                                default:
                                    Console.WriteLine("Введено неправильне число");
                                    break;

                            }
                            break;
                        case 2:
                            Console.Write("Яка вага (в тонах) ? \n = ");
                            double C = double.Parse(Console.ReadLine());
                            Console.WriteLine(Train.SearchCarrige(weight:C));
                            break;
                        case 3:
                            Console.Write("Яка довжина (в метрах) ? \n =");
                            double D = double.Parse(Console.ReadLine());
                            Console.WriteLine(Train.SearchCarrige(length: D));
                            break;
                        default:
                            Console.WriteLine("Введено неправильне число");
                            break;
                    }
                }
                else
                {
                    break;
                }
            }


        }
    }
}
