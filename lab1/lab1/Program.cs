using System;
using static lab1.Menu;

namespace lab1
{
    class Program
    { 
        static void Main()
        {
            while (true)
            {
                switch (NewMenu())
                {
                    case "create":
                        Console.WriteLine("Новая фигура - " + Create());
                        continue;
                    case "move":
                        Console.WriteLine("Новая фигура - " + MoveTo());
                        continue;
                    case "resize":
                        Console.WriteLine("Новая фигура - " + Resize());
                        continue;
                    case "rotate":
                        Console.WriteLine("Новая фигура - " + Rotate());
                        continue;
                    case "intersect":
                        Console.WriteLine("Фигуры Пересекаются? -" + Intersect());
                        continue;
                    case "clean":
                        Console.Clear();
                        continue;
                    case "exit":
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