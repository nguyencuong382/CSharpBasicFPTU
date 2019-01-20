using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainConsole;

namespace Collection
{
    class Program
    {
        public static void show()
        {

        }
        static void Main(string[] args)
        {
            List<Truck> trucks = new List<Truck>();
            ArrayList cars = new ArrayList();

            trucks.Add(new Truck(1, "Nguyen Cuong", 1123, 12.3, 5));
            trucks.Add(new Truck(2, "Do Tuan", 64, 12.3, 3));
            trucks.Add(new Truck(9, "Bui Tung", 123, 12.3, 4));
            trucks.Add(new Truck(7, "Ba Thanh", 31, 12.3, 2));
            trucks.Add(new Truck(8, "Tran Ngan",42, 12.3, 5));


            trucks.Sort();

            foreach (var truck in trucks)
            {
                truck.Display();
            }


            Console.WriteLine("------------");

            trucks.Sort(
                (t1, t2) => {
                    if (t1.getPrice() > t2.getPrice()) return 1;
                    if (t1.getPrice() < t2.getPrice()) return -1;
                    return 0;
                }
            );

            foreach (var truck in trucks)
            {
                truck.Display();
            }


            Console.WriteLine("------------");

            trucks.Sort(
                (t1, t2) => {
                    if (t1.getBasePrice() > t2.getBasePrice()) return 1;
                    if (t1.getBasePrice() < t2.getBasePrice()) return -1;
                    return 0;
                }
            );

            foreach (var truck in trucks)
            {
                truck.Display();
            }


            Console.ReadLine();
        }
    }
}
