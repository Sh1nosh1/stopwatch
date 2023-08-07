using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Reflection;

namespace secondomer
{
    internal class Program
    {

        static void Main(string[] args)
        {   
            Thread myThread = new Thread(Lock);
            myThread.Start();
            bool isOpen = true;
            while (isOpen)
            {
                ConsoleKeyInfo Shehanin = Console.ReadKey();
                switch (Shehanin.Key)
                {
                    case ConsoleKey.Escape:
                        myThread.Abort();
                        isOpen = false;
                        break;
                    case ConsoleKey.Spacebar:

                        if (myThread.ThreadState == ThreadState.Suspended)
                        {
                            myThread.Resume();

                        }
                        else { myThread.Suspend(); }
                        break;
                    case ConsoleKey.Backspace:
                        var filehuy = Assembly.GetExecutingAssembly().Location;
                        System.Diagnostics.Process.Start(filehuy);
                        Environment.Exit(0);
                        break;
                }
               
            }
        }
        public static void Lock()
        {
            Console.Clear();
            Console.WriteLine("Hello!\nIt's secondomer\nPress Enter to start");
            bool isopen = true;
            while (isopen)
            {
                ConsoleKeyInfo user = Console.ReadKey();
                if (user.Key == ConsoleKey.Enter)
                {
                    for (int i = 0; i < 60; i++)
                    {
                        for (int k = 0; k < 60; k++)
                        {
                            Console.SetCursorPosition(0, 5);
                            Console.WriteLine($"{i}min:{k}sec  ");
                            Thread.Sleep(1000);
                        }
                    }
                }
            }
        }
    }
}
