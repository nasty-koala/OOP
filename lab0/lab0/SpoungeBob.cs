using System;

namespace lab0
{
    public class SpoungeBob
    {
        //создание объекта, static
        static void Main()
        {
            //Создание объекта для генерации чисел
            Random rnd = new Random();
            //Получить случайное число
            int value = rnd.Next(1, 10);

            Console.WriteLine("Какой вы персонаж из Спанч Боба?");
            Console.Write("Введите, пожалуйста, свое полное имя: ");
            string name = Console.ReadLine();
            Console.Write("{0}, вы - ", name);

            //while (value != 10) value = rnd.Next(1,10);

            switch (value)
            {
                case 1:
                    Console.WriteLine("Патрик Стар!");
                    break;
                case 2:
                    Console.WriteLine("Сквидвард Щупальца, ме..");
                    break;
                case 3:
                    Console.WriteLine("Губка Боб! )))))");
                    break;
                case 4:
                    Console.WriteLine("Миссис Пафф. Удачи!");
                    break;
                case 5:
                    Console.WriteLine("Юджин Крабс, а вы неплох");
                    break;
                case 6:
                    Console.WriteLine("Шелдон Планктон! придумай уже свой рецепт успеха.");
                    break;
                case 7:
                    Console.WriteLine("Сенди Чикс! Красотка, правда?");
                    break;
                case 8:
                    Console.WriteLine("Перл Крабс, хехе");
                    break;
                default:
                    Console.WriteLine("Случайный рыб :/");
                    break;
            }
            Console.ReadKey();
        }
    }
}