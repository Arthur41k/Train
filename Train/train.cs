using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
   class train
    {
        public string name {  get; set; }
        public string routeNumber { get; set; }
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
    }
}
