//Резанко А.А. - 1 вариант
using System;
using System.Threading;
using static lab2.Menu;

//Составить описание класса для представления комплексных чисел. Обеспечить выполнение
//операций сложения, вычитания и умножения комплексного числа на вещественное число.
//Предусмотреть поддержку числа в алгебраической форме. Все операции реализовать в виде
//перегрузки операторов. Программа должна содержать меню, позволяющее осуществлять
//проверку всех методов.


//программа разбита на три файла:
// - основная программа, которая управляет меню
// - меню с командами
// - класс комплексных чисел

// Основная программа реализована с помощью switch

namespace lab2
{
    public static class Program
    {
        public static void Main()
        {
            while (true) 
            {
                switch (NewMenu())
                {
                    case "plus":
                        Plus();
                        continue;
                    case "minus":
                        Minus();
                        continue;
                    case "mult":
                        Mult();
                        continue;
                    case "clean":
                        Console.Clear();
                        continue;
                    case "exit":
                        Console.WriteLine("До свидания! ((((((");
                        Thread.Sleep(1000);
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