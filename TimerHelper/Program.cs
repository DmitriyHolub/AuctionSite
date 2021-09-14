using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;

namespace TimerHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            var checker = new Checker();

            var timercall = new TimerCallback(checker.CheckTime);
            var timer = new Timer(timercall, null, 0, 60000);
            Console.ReadLine();
        }
    }
}
