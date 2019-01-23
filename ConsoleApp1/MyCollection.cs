using System;
using System.Collections;
using System.Collections.Generic;
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


        private List<T> arr_;

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
    }
}
