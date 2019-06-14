using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Q1
{
    public class IncorrectNumberOfSlotException : SystemException
    {
        public IncorrectNumberOfSlotException() : base ("Your input is incorrect format")
        {
            
        }
    }
    public class Subject
    {
        private string code;
        private int numberofslot;

        public Subject(string c)
        {
            this.code = c;
        }

        public void InputInfo()
        {
            Console.WriteLine("Input number of slot for subject. The number of slot must between 0 and 30");
            string tmp = Console.ReadLine();

            if (!int.TryParse(tmp, out this.numberofslot))
            {
                throw new IncorrectNumberOfSlotException();
            }

            if(this.numberofslot < 0 || this.numberofslot > 30)
            {
                throw new IncorrectNumberOfSlotException();
            }

        }

        public override string ToString()
        {
            return String.Format("Subject's Infromation: Code: {0} - NumberOfSlot: {1}", this.code, this.numberofslot);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Subject s = new Subject("SE12067-PRO192");
                s.InputInfo();
                Console.WriteLine(s);
            } catch(IncorrectNumberOfSlotException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
