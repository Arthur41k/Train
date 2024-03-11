namespace Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Console.OutputEncoding=System.Text.Encoding.UTF8;
            Console.Write("Введіть назву потягу: ");
            string Name = Console.ReadLine();
            train Train = new train("Name",1);
            Console.WriteLine("Який у вас потяг ? \n Вантажний(1) \n Пасажирський(2)");
            int N = int.Parse(Console.ReadLine());
            if (N == 1)
            {
                Console.Write("Скільки ви хочете добавити вагонів ? = ");
                int n = int.Parse(Console.ReadLine());  
                for (int i = 0; i < n; i++) 
                {                    
                    FreightCarriage Carriage = new FreightCarriage(i,70);
                    Train.AddCarrige(Carriage);
                    Carriage.Cargo();
                    
                }
            }
            else if(N == 2) 
            {
                Console.Write("Скільки ви хочете добавити вагонів ? = ");
                int n = int.Parse(Console.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    Console.Write("Який добавити вагон ? \n Пасажирський(1) \n Спальний вагон(2) \n Вагон кухня (3) \n = ");
                    int Numeric = int.Parse(Console.ReadLine());
                    switch(Numeric)
                    {
                        case 1:
                            Console.Write("Скільки місць у вагоні ? \n =");
                            int seats = int.Parse(Console.ReadLine());
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
                            PassengerCarriage Carriage = new PassengerCarriage(i,seats,CarrigeClass);
                            Train.AddCarrige(Carriage);
                            Console.Clear();
                            break;
                        case 2:
                            Console.Write("Скільки купе у вагоні ? \n =");
                            int compartmentsCount = int.Parse(Console.ReadLine());
                            bool B = false;
                            Console.Write("У вагоні є душ ? \n Так(1) \n Ні(2) \n =");                            
                            int choese = int.Parse(Console.ReadLine());
                            if (choese == 1)
                            {
                                B = true;
                            }
                            SleepingCarriage Carriage_1 = new SleepingCarriage(i, compartmentsCount, B);
                            Train.AddCarrige(Carriage_1);
                            Console.Clear();
                            break;
                        case 3:
                            Console.Write("Скільки столів у вагоні ? \n =");
                            int tablesCount = int.Parse(Console.ReadLine());
                            bool Boo = false;
                            Console.Write("У вагоні є кухня ? \n Так(1) \n Ні(2) \n =");
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
            }
            else
            {
                Console.WriteLine("Ви ввели не правельне число");
            }
            Train.PrintInfo();

        }
    }
}
