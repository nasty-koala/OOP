using System;

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
            var cmplx = NewComplex();
            var n = NewDouble();
            Console.WriteLine($"{cmplx} + {n} = {cmplx+n}");
        } 
        
        public static void Minus()
        {
            var cmplx = NewComplex();
            var n = NewDouble();
            Console.WriteLine($"{cmplx} - {n} = {cmplx-n}");
        } 
        
        public static void Mult()
        {
            var cmplx = NewComplex();
            var n = NewDouble();
            Console.WriteLine($"{cmplx} * {n} = {cmplx*n}");
        } 
        
    }
}