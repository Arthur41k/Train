using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
            if (routeNumber % 2 == 0)
            {
                this.routeNumber = $"Закордоний маршрут номер {routeNumber}";
            }
            else
            {
                this.routeNumber = $"Український маршрут номер {routeNumber}";
            }
        }
        LinkedList<Carriage> carriages = new LinkedList<Carriage>();


        /// <summary>
        /// Додавання вагона (у кінець або на певну позицію).
        /// </summary>
        /// <param name="CAR"></param>
        /// <param name="id"></param>
        public void AddCarrige( Carriage CAR, int id = 256)
        {
            // Якщо потяг порожній то добавляє вагон в список
            if (carriages.First?.Value == null)
            {
                carriages.AddLast(CAR);
            }
            //Якщо перший вагон це вантажний вагон
            else if (carriages.First?.Value != null && carriages.First.Value.type == "FreightCarriage")
            {
                //Перевіряє чи доданий елемент є вантажним вагоном
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
                else
                {
                    throw new Exception("CarrigeIsNotFreightCarriage");
                }
            }
            //якщо перший вагон не вантажний 
            else
            {
                //Перевірка чи доданий елемент не є вантажним вагоном

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
        public void RemovCarriage (int id = 256)
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
            else if (id != 256 && id != 1)
            {
                if (id > 0 && id <= carriages.Count)
                {
                    carriages.Remove(carriages.ElementAt(id - 1));
                }
                else 
                {
                    Console.WriteLine("Такого вагону немає");
                }
            }
        }

        /// <summary>
        /// Вертає список вагонів з певною ознакою
        /// </summary>
        /// <param name="type"></param>
        /// <param name="weight"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public string SearchCarrige(string type = "", double weight = 0, double length = 0)
        {
            int Numeric = 0;  
            List<int> Numerics = new List<int>();

            foreach (Carriage car in carriages)
            {
                if (!string.IsNullOrEmpty(type) && car.type == type)
                {
                    Numerics.Add(Numeric);
                }
                else if (weight != 0 && car.weight == weight)
                {
                    Numerics.Add(Numeric);
                }
                else if (length != 0 && car.length == length)
                {
                    Numerics.Add(Numeric);
                }

                Numeric++;
            }

            StringBuilder result = new StringBuilder();

            if (Numerics.Count == 0)
            {
                result.Append($"В цьому потязі немає таких вагонів");
            }
            else
            {
                result.Append($"Ось список вагонів з такими ознаким:");

                foreach (int i in Numerics)
                {
                    result.Append($" {i},");
                }

                result.Remove(result.Length - 1, 1);  // Видалення останньої коми
                result.Append(" . ");
            }

            return result.ToString();
        }


        /// <summary>
        /// Видає інформацію про окремий вагон або потяг вцілому.
        /// </summary>
        /// <param name="id"></param>
        public void PrintInfo(int id = 999)
        {
            //Якщо id не було введено виводить інформацію про весь потяг
            if (id == 999)
            {
                //Перевірка чи не є потяг порожнім і чи є потяг вантажним
               if (carriages.First?.Value != null ) 
                { 
                int Numeric = 0;
                double AllWeight = 0;
                double AllLength = 0;
                foreach (Carriage CAR in carriages)
                {
                    AllLength += CAR.length;
                    AllWeight += CAR.weight;
                }
                Console.WriteLine($"Потяг {name}. {routeNumber}. \n Вага потягу = {AllWeight} тон. \n Довжина потягу = {AllLength} метрів");
                Console.WriteLine("Вагони:");
                    foreach (Carriage CAR in carriages)
                    {
                        Numeric++;
                        Console.WriteLine($"Вагон {Numeric} типу {CAR.type} ");    
                    }
                }
               else
                {
                    Console.WriteLine("В потязі немає вагонів");
                }
                
            }
            else
            {
                int Numeric = 0;
                foreach (Carriage car in carriages)
                {
                    if (Numeric == id)
                    {
                        Console.WriteLine($"{id} Вагон типу {car.type} має довжину {car.length} і вагу {car.weight}");
                    }
                    Numeric++;
                }
            }
        }

        ///Метод що рахує кількість вагонів
        public int SumCarriage()
        {
            int SumCarriage = 0;
            foreach (Carriage car in carriages)
            {
                SumCarriage++;
            }
            return SumCarriage;
        }
    }  
}
