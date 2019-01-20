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

            return true;
        }

        public bool Remove(T value)
        {
            foreach (var item in arr_)
            {
                if (value.ID == item.ID)
                {
                    this.arr_.Remove(item);
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
            this.arr_.Sort();
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
