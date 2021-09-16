using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Bank
{
    class Utility
    {
        static public string Ask(string Question)
        {
            Console.WriteLine(Question);
            return Console.ReadLine();
        }

        static public void DelayedClear(int Timer)
        {
            Thread.Sleep(Timer);
            Console.Clear();
        }
    }
}
