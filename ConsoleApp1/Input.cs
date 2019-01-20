using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainConsole
{
    class Input
    {
        public string getLine(string mess)
        {
            Console.WriteLine(mess);
            string tmp = Console.ReadLine();
            return tmp;
        }
        public void inputAuto ()
        {
            string id = getLine("Enter id");

            int id_;
            if(!int.TryParse(id, out id_))
            {
                throw new MyException("Id is not number!");
            }


        }
    }
}
