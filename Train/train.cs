using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Train
{
   class train
    {
        public string name { get; set; } = "Потяг";
        public string routeNumber { get; set; } = "0";
        internal train(string name,int routeNumber) 
        { 
            this.name = name;
            this.routeNumber = $"Маршрут номер {routeNumber}";
        }
        LinkedList<Carriage> carriages = new LinkedList<Carriage>();


        /// <summary>
        /// Додавання вагона (у кінець або на певну позицію).
        /// </summary>
        /// <param name="CAR"></param>
        /// <param name="id"></param>
        public void AddCarrige( Carriage CAR, int id = 256)
        {
            
            if (carriages.First.Value.type == "FreightCarriage")
            {
                if (CAR.type == "FreightCarriage")
                {
                    //Додає вантажний вагон в кінець якщо не вказано індекс
                    if (id == 256)
                    {
                        carriages.AddLast(CAR);
                    }
                    //Додає вантажний вагон на початок якщо індекс дорівнює 1
                    else if (id == 1)
                    {
                        carriages.AddFirst(CAR);
                    }
                    //Додає вантажний вагон за обраним індексом(порядком починаючи з 1 від початку потяга)
                    else
                    {
                        int Numeric = 1;
                        foreach (Carriage car in carriages)
                        {
                            if (Numeric == id - 1)
                            {
                                LinkedListNode<Carriage> node = carriages.Find(car);
                                carriages.AddAfter(node, CAR);
                                //для перевірики чи індекс не більше ніж елементів у LinkedList
                                Numeric = -5;
                            }
                            Numeric++;
                        }
                        //Якщо індекс більше ніж елементів у LinkedList тоді вагон додається у кінець
                        if (Numeric != -5)
                        {
                            carriages.AddLast(CAR);
                        }

                    }
                }

            }
            //якщо вагон не вантажний 
            else
            {
                if (CAR.type != "FreightCarriage")
                {
                    //Додає вагон в кінець якщо не вказано індекс
                    if (id == 256)
                    {
                        carriages.AddLast(CAR);
                    }
                    //Додає вагон на початок якщо індекс дорівнює 1
                    else if (id == 1)
                    {
                        carriages.AddFirst(CAR);
                    }
                    //Додає вагон за обраним індексом(порядком починаючи з 1 від початку потяга)
                    else
                    {
                        int Numeric = 1;
                        foreach (Carriage car in carriages)
                        {
                            if (Numeric == id - 1)
                            {
                                LinkedListNode<Carriage> node = carriages.Find(car);
                                carriages.AddAfter(node, CAR);
                                //для перевірики чи індекс не більше ніж елементів у LinkedList
                                Numeric = -5;
                            }
                            Numeric++;
                        }
                        //Якщо індекс більше ніж елементів у LinkedList тоді вагон додається у кінець
                        if (Numeric != -5)
                        {
                            carriages.AddLast(CAR);
                        }
                    }

                }
            }
        }
        /// <summary>
        /// Видалення вагона (з кінця або з певної позиції не враховуючи 0).
        /// </summary>
        /// <param name="CAR"></param>
        /// <param name="id"></param>
        public void RemovCarriage (Carriage CAR, int id = 256)
        {
            //Видаляє останій вагон якщо не вказано індекс
            if (id == 256)
            {
                carriages.RemoveLast();
            }
            //Видаляє перший вагон якщо індекс дорівнює 1
            else if (id == 1)
            {
                carriages.RemoveFirst();
            }
            //Видаляє вагон за обраним індексом(порядком починаючи з 1 від початку потяга)
            else
            {
                int Numeric = 1;
                foreach (Carriage car in carriages)
                {
                    if (Numeric == id )
                    {
                       carriages.Remove(car);
                    }
                    Numeric++;
                }
            }
        }

        public string SearchCarrige(string type = "", double weight = 0, double length = 0)
        {
            int Numeric = 0;
            int Number = 0;
            int[] Numerics = new int[10];

                if (type != "")
                {

                    foreach (Carriage car in carriages)
                    {
                        Numeric++;
                        if (car.type == type)
                        {
                            Numerics[Number] = Numeric;
                            Number++;
                        }
                    }
                    string S = "Ось список вагонів з тиаким типом : ";
                    if (Numerics.Length == 0)
                    {
                        S = "В цьому потязі вагонів такого типу немає";
                    }
                    else
                    {
                        for (int i = 0; i < Numerics.Length; i++)
                        {
                            S = S + i + " , ";
                        }
                        S = S + " . ";
                    }
                    return S;
                }
                else if (weight != 0)
                {

                    foreach (Carriage car in carriages)
                    {
                        Numeric++;
                        if (car.weight == weight)
                        {
                            Numerics[Number] = Numeric;
                            Number++;
                        }
                    }
                    string S = "Ось список вагонів з такою вагою: ";
                    if (Numerics.Length == 0)
                    {
                        S = "В цьому потязі вагонів з такою вагою немає";
                    }
                    else
                    {
                        for (int i = 0; i < Numerics.Length; i++)
                        {
                            S = S + i + " , ";
                        }
                        S = S + " . ";
                    }
                    return S;
                }
                else if (length != 0)
                {

                    foreach (Carriage car in carriages)
                    {
                        Numeric++;
                        if (car.length == length)
                        {
                            Numerics[Number] = Numeric;
                            Number++;
                        }
                    }
                    string S = "Ось список вагонів з такою довжиною: ";
                    if (Numerics.Length == 0)
                    {
                        S = "В цьому потязі вагонів з такою довжиною немає";
                    }
                    else
                    {
                        for (int i = 0; i < Numerics.Length; i++)
                        {
                            S = S + i + " , ";
                        }
                        S = S + " . ";
                    }
                    return S;
                }
                else
                {
                    return "";
                }

            }

        /// <summary>
        /// Видає інформацію про окремий вагон або потяг вцілому.
        /// </summary>
        /// <param name="id"></param>
        public void PrintInfo(int id = 999)
        {
            if (id == 999)
            {
                int Numeric = 0;
                double AllWeight = 0;
                double AllLength = 0;
                foreach (Carriage CAR in carriages)
                {
                    AllLength += CAR.length;
                    AllWeight += CAR.weight;
                }
                Console.WriteLine($"Потяг {name} їде по маршруту номер {routeNumber}. \n Вага потягу = {AllWeight}. \n Довжина потягу = {AllLength}");
                Console.WriteLine("Вагони:");
                foreach (Carriage CAR in carriages)
                {
                    Numeric++;
                    Console.WriteLine($"Вагон {Numeric} типу {CAR.type}");
                }
            }
            else
            {
                int Numeric = 0;
                foreach (Carriage car in carriages)
                {
                    if (Numeric == id)
                    {
                        Console.WriteLine($"Вагон номер {id} має довжину {car.length} і вагу {car.weight}");
                    }
                    Numeric++;
                }
            }
        }
    }  
}
