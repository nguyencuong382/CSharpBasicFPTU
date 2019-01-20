using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Auto
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public double BasePrice { get; set; }

        public void Display()
        {
            return ID + Name + BasePrice;
        }
    }

    class Truck
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            Auto a = new Auto();
            a.ID = 2;
            a.Name = "Cuong";
            a.BasePrice = 2.3;

            Console.WriteLine(a.Display());
            Console.ReadLine();
        }
    }
}
