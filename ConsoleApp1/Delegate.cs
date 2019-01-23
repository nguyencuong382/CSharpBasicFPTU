using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainConsole
{
    class Employee
    {
        public delegate void ChangeName(string oldName, string newName);
        public event ChangeName changeName;

        private string name;

        public String Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if(value != this.name)
                {
                    string oldName = this.name;
                    this.name = value;
                    if(changeName !=null)
                    {
                        changeName(oldName, value);
                    }
                    
                }
            }
        }
    }
    public class TestEventDelegate
    {
        static void changeNameEvent(string oldName, string newName)
        {
            Console.WriteLine(String.Format("Name change from {0} to {1}", oldName, newName));
        }
        public void test()
        {
            Employee e = new Employee();
            e.Name = "Nguyen Cuong";

            e.changeName += changeNameEvent;

            e.Name = "Tuan an com";
        }
    }
}
