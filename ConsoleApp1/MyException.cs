using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainConsole
{
    class MyException : Exception
    {
        public MyException()
        {

        }

        public MyException(String mess) : base(String.Format("My Exception: {0}", mess))
        {

        }
    }

}
