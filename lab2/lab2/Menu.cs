//Резанко А.А. - 1 вариант
using System;

// В меню выделен вывод самого меню с запросом команды, ввод данных и основные команды

namespace lab2
{
    public static class Menu
    {
        public static string NewMenu()
        {
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
            Console.Write("Введите действительную часть числа: ");
            var r = double.Parse(Console.ReadLine());
            Console.Write("Введите мнимую часть числа: ");
            var i = double.Parse(Console.ReadLine());
            
            return new Complex(r, i);
        }

        public static double NewDouble()
        {
            Console.Write("Введите число: ");
            return double.Parse(Console.ReadLine());
        }
        
        public static void Plus()
        {
            var cmplx1 = NewComplex();
            var cmplx2 = NewComplex();
            Console.WriteLine($"({cmplx1}) + ({cmplx2}) = {cmplx1+cmplx2}");
        } 
        
        public static void Minus()
        {
            var cmplx1 = NewComplex();
            var cmplx2 = NewComplex();
            Console.WriteLine($"({cmplx1}) + ({cmplx2}) = {cmplx1 - cmplx2}");
        } 
        
        public static void Mult()
        {
            var cmplx = NewComplex();
            var n = NewDouble();
            Console.WriteLine($"({cmplx}) * {n} = {cmplx*n}");
        } 
        
    }
}