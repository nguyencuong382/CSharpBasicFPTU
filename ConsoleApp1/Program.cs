﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainConsole
{

    class Program
    {
        static void Main(string[] args)
        {
            TestMyCollection testMyCollection = new TestMyCollection();
            //testMyCollection.test();
            testMyCollection.testReadCollection();


            //Input i = new Input();
            //try
            //{
            //    i.inputAuto();
            //}
            //catch (MyException ex)
            //{
            //    Console.WriteLine("Loi Roi");
            //    Console.WriteLine(ex.Message);
            //}


            //testeventdelegate e = new testeventdelegate();
            //e.test();
            Console.ReadLine();
        }
    }
}
