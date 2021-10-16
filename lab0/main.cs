using System;
class HelloWorld {
  static void Main() {
    //Создание объекта для генерации чисел
    Random rnd = new Random();
    //Получить очередное (в данном случае - первое) случайное число
    int value = rnd.Next(1,10);
    
    Console.WriteLine("Какой вы персонаж из Рика и Морти?");
    Console.Write("Введите, пожалуйста, свое полное имя: ");
    string name = Console.ReadLine();
    Console.Write("{0}, вы - ", name);
    
    //while (value != 10) value = rnd.Next(1,10);
    
   switch (value){
    case 1:
        Console.WriteLine("Рик Санчез!");
        break;
    case 2:
        Console.WriteLine("Злой Морти .... ");
        break;
    case 3:
        Console.WriteLine("Мистер Жопосранчик )))))");
        break;
    case 4:
        Console.WriteLine("Морти Смит. Удачи!");
        break;
    case 5:
        Console.WriteLine("Диана Санчез");
        break;
    case 6:
        Console.WriteLine("Птичья Личность.");
        break;
    case 7:
        Console.WriteLine("Сквончи");
        break;
    case 8:
        Console.WriteLine("Бэт Смит");
        break;
    default:
        Console.WriteLine("Случайный житель :/");
        break;
    
   }
    
    
  }
}