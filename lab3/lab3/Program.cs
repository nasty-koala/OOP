using System;
using static lab3.Menu;

namespace lab3
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                switch (NewMenu())
                {
                    case "input":
                        Input();
                        continue;
                    case "add":
                        Add();
                        continue;
                    case "all":
                        All();
                        continue;
                    case "sort":
                        Sort();
                        continue;
                    case "firstfive":
                        FirstFive();
                        continue;
                    case "lastthree":
                        LastThree();
                        continue;
                    case "total":
                        Total();
                        continue;
                    case "clean":
                        Console.Clear();
                        continue;
                    case "exit":
                        XML();
                        Console.WriteLine("До свидания!");
                        return;
                    default:
                        Console.WriteLine("Неопознанная команда!");
                        Console.ReadKey();
                        continue;
                }
            }
        }
    }
}

