using System;
using System.Threading;

namespace lab2
{
    public class Menu
    {
        public static string NewMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\n\tМеню действий\n" + 
                              "Для выбора введите кодовое слово, соответствующее команде (указано в скобках) и следуйте инструкциям\n\n" +
                              "  -  Сложение(plus)\n" +
                              "  -  Вычитание(minus)\n" +
                              "  -  Умножение(mult)\n" +
                              "  -  Очистить консоль (clean)\n" +
                              "  -  Выход(exit)\n");
            return Console.ReadLine();
        }

        public static Complex NewComplex()
        {
            Console.WriteLine("");
        }

        public static void MainMenu()
        {
            switch (NewMenu())
            {
                case "plus":

                case "minus":
                    
                case "mult":

                case "clean":
                    
                case "exit":
                    Console.WriteLine("До свидвния! ((((((");
                    Thread.Sleep(100);
                    break;
                default:
                    Console.WriteLine("Неопознанная команда!");
                    Console.ReadKey();
                    MainMenu();
                    break;
            }
        }
    }
}