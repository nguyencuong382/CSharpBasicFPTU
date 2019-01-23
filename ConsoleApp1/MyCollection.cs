using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainConsole
{
    public class MyCollection<T> where T : Auto
    {
        public delegate void LengthChange();
        public delegate void OrderChange();

        public event LengthChange lengthChange;
        public event OrderChange orderChange;


        protected List<T> arr_;

        public MyCollection()
        {
            this.arr_ = new List<T>();
        }

        public bool Add(T value)
        {
            foreach (var item in arr_)
            {
                if(value.ID == item.ID)
                {
                    return false;
                }
            }

            this.arr_.Add(value);
            if(lengthChange != null)
                lengthChange();
            return true;
        }

        public bool Remove(T value)
        {
            foreach (var item in arr_)
            {
                if (value.ID == item.ID)
                {
                    this.arr_.Remove(item);
                    if(lengthChange != null)
                        lengthChange();
                    return true;
                }
            }

            return false;
        }

        public int Search(T value)
        {

            int i = 0;
            foreach (var item in arr_)
            {
                if (value.ID == item.ID)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }

        public void Display()
        {
            foreach (var item in arr_)
            {
                item.Display();
            }
        }



        public void Sort()
        {
            List<T> tmp_ = new List<T>(arr_);
            
            this.arr_.Sort();

            if(orderChange != null)
            {
                for (int i = 0; i < arr_.Count; i++)
                {
                    if (tmp_[i].ID != arr_[i].ID)
                    {
                        orderChange();
                        break;
                    }
                }
            }
           
        }

        public void Sort(IComparer<T> i)
        {
            this.arr_.Sort((i1, i2) => i.Compare(i1, i2));
        }
    }

    public class AutoCollection : MyCollection<Auto>
    {
        protected Auto CreateItem(string line)
        {
            Auto traffic = null;
            
            string[] split_ = line.Split('|');
            if(split_.Length < 6)
            {
                return traffic;
            }

            int type;
            Int32.TryParse(split_[0], out type);

            int id;
            Int32.TryParse(split_[1], out id);

            string name = split_[2];

            double basePrice;
            Double.TryParse(split_[3], out basePrice);

           

            if(type == 1)
            {
                int seatNo;
                Int32.TryParse(split_[4], out seatNo);

                int pricePerSeat;
                Int32.TryParse(split_[5], out pricePerSeat);

                traffic = new Car(id, name, basePrice, seatNo, pricePerSeat);
            } else
            {
                double weight;
                Double.TryParse(split_[4], out weight);

                double addedPrice;
                Double.TryParse(split_[5], out addedPrice);

                traffic = new Truck(id, name, basePrice, weight, addedPrice);
            }
            traffic.Type = type;
            return traffic;
        }

        public void ReadFile(string fileName)
        {
            // Create an instance of StreamReader to read from a file.
            // The using statement also closes the StreamReader.
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;

                // Read and display lines from the file until 
                // the end of the file is reached. 
                while ((line = sr.ReadLine()) != null)
                {
                    //Console.WriteLine(line);
                    Auto traffic = this.CreateItem(line);

                    if(traffic != null)
                    {
                        this.Add(traffic);
                    }
                    
                }
            }
        }

        public void WriteFile(string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {

                foreach (Auto item in this.arr_)
                {
                    String s;

                    if (item.Type == 1)
                    {
                        Car car = (Car)item;
                        s = String.Format("{0}|{1}|{2}|{3}|{4}|{5}", car.Type, car.ID, car.Name, car.getBasePrice(), car.SeatNo, car.PricePerSeat);
                    } else
                    {
                        Truck truck = (Truck)item;
                        s = String.Format("{0}|{1}|{2}|{3}|{4}|{5}", truck.Type, truck.ID, truck.Name, truck.getBasePrice(), truck.Weight, truck.AddedPrice);
                    }
                    
                    sw.WriteLine(s);
                }
            }
        }
    }

    public class TestMyCollection
    {
        private class AnonymousSortAuto : IComparer<Auto>
        {
            public int Compare(Auto x, Auto y)
            {
                if (x.getBasePrice() > y.getBasePrice()) return 1;
                if (x.getBasePrice() < y.getBasePrice()) return -1;

                return 0;
            }
        }

        public void test()
        {
            MyCollection<Auto> autos = new MyCollection<Auto>();

            autos.orderChange += () => {
                Console.WriteLine("Order has changed");
            };

            autos.lengthChange += () =>
            {
                Console.WriteLine("Lenght has changed");
            };

            autos.Add(new Auto(6, "Nguyen CUong", 13.4));
            autos.Add(new Auto(2, "Phan Thi", 12.5));
            autos.Add(new Auto(2, "Sap Den Tet", 12.9));
            autos.Add(new Auto(3, "Buon Ngu Qua", 12.2));

            Console.WriteLine("----------");
            autos.Display();
            Console.WriteLine("----------");

            autos.Sort();

            Console.WriteLine("----------");
            autos.Display();
            Console.WriteLine("----------");

            
            autos.Sort(new AnonymousSortAuto());

            Console.WriteLine("----------");
            autos.Display();
            Console.WriteLine("----------");

        }

        public void testReadCollection()
        {
            AutoCollection autoCollection = new AutoCollection();

            autoCollection.ReadFile(@"C:\Users\Admin\Desktop\test.txt");

            autoCollection.Display();


            autoCollection.Add(new Car(6, "Audo", 32.3, 4, 34.5));
            autoCollection.Add(new Car(8, "Fork", 235, 3, 23));
            autoCollection.Add(new Truck(2, "DirFor", 23, 232, 434));

            autoCollection.WriteFile(@"C:\Users\Admin\Desktop\test2.txt");

        }
    }
}
