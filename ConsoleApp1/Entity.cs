using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainConsole
{
    public class Auto : IComparable<Auto>
    {
        protected double basePrice;

        public int ID { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }

        public Auto()
        {

        }

        public Auto(int id, string name, double basePrice)
        {
            this.ID = id;
            this.Name = name;
            this.basePrice = basePrice;
        }



        public void setPrice(double value)
        {
            basePrice = value;
        }

        public virtual double getPrice()
        {
            return basePrice;
        }

        public double getBasePrice()
        {
            return this.basePrice;
        }

        public virtual void Display()
        {
            Console.WriteLine("Auto ID: {0} - Name: {1} - Price: {2}", ID, Name, getPrice());
        }

        public int CompareTo(Auto other)
        {
            if (this.ID > other.ID) return 1;
            if (this.ID < other.ID) return -1;
            return 0;
        }
    }

    public class Truck : Auto, IComparable<Truck>
    {
        public double Weight { get; set; }
        public double AddedPrice { get; set; }

        public Truck()
        {
            this.Type = 2;
        }

        public Truck(int id, string name, double basePrice, double weight, double addedPrice) : base(id, name, basePrice)
        {
            this.Type = 2;
            this.Weight = weight;
            this.AddedPrice = addedPrice;
        }

        public override void Display()
        {
            Console.WriteLine("Truck ID: {0} - Name: {1} - Price: {2} - AddedPrice: {3}", ID, Name, this.getPrice(), AddedPrice);
        }

        public override double getPrice()
        {
            return AddedPrice + base.getPrice();
        }

        public int CompareTo(Truck other)
        {
            if (this.ID > other.ID) return 1;
            if (this.ID < other.ID) return -1;
            return 0;
        }
    }

    class Car : Auto
    {
        public int SeatNo { get; set; }
        public double PricePerSeat { get; set; }

        public Car()
        {
            this.Type = 1;
        }

        public Car(int id, string name, double basePrice, int seatNo, double pricePerSeeat) : base (id, name, basePrice)
        {
            this.Type = 1;
            this.SeatNo = seatNo;
            this.PricePerSeat = pricePerSeeat;
        }

        public override void Display()
        {
            Console.WriteLine("Car ID: {0} - Name: {1} - Price: {2} - SeatNo: {3}", ID, Name, this.getPrice(), SeatNo);
        }

        public override double getPrice()
        {
            return base.getPrice() + SeatNo * PricePerSeat;
        }
    }
   
}
