using System;
using System.Threading;
using static lab2.Menu;

namespace lab2
{
    public static class Program
    {
        public static void Main()
        {
            switch (NewMenu())
            {
                case "plus":
                    Plus();
                    Main();
                    break;
                case "minus":
                    Minus();
                    Main();
                    break;
                case "mult":
                    Mult();
                    Main();
                    break;
                case "clean":
                    Console.Clear();
                    Main();
                    break;
                case "exit":
                    Console.WriteLine("До свидания! ((((((");
                    Thread.Sleep(100);
                    break;
                default:
                    Console.WriteLine("Неопознанная команда!");
                    Console.ReadKey();
                    Main();
                    break;
            }
        }
    }
}