using System;
using System.Linq;

namespace lab3
{
    public static class Menu
    {
        private static Organization myOrganization = new Organization();

        internal static string NewMenu()
        {
            Console.WriteLine("\n\n\tМеню действий\n" +
                              "Для выбора введите кодовое слово, соответствующее команде (указано в скобках) и следуйте инструкциям\n\n" +
                              "  -  Импорт списка из XML (input)\n" +
                              "  -  Добавить работника (add)\n" +
                              "  -  Вывести список персонала (all)\n" +
                              "  -  Отсортировать по убыванию зарплаты (sort)\n" +
                              "  -  Вывод первых 5 рабочих (firstfive)\n" +
                              "  -  Вывод ID трех последних (lastthree)\n" +
                              "  -  Вывод средней зарплаты (total)\n" +
                              "  -  Очистка консоли (clean)\n" +
                              "  -  Выход  и экспорт в XML (exit)");
            return Console.ReadLine();
        }

        internal static void Input()
        {
            Console.WriteLine("Введите путь к файлу:");
            string fileName = Console.ReadLine();
            try
            {
                myOrganization = Organization.FromXml(fileName);
            }
            catch
            {
                Console.WriteLine("Ошибка, попробуйте снова");
                Input();
            }
        }

        private static void AddHourlyWorker()
        {
            try
            {
                Console.WriteLine("1 - Директор, 2 - Менеджер, 3 - Рядовой раотник");
                int type = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите id работника");
                string ident = Console.ReadLine();
                Console.WriteLine("Введите ФИО работника");
                string name = Console.ReadLine();
                Console.WriteLine("Введите ставку работника");
                double bet = double.Parse(Console.ReadLine());

                var worker = new HourlyWorker((WorkerType)type, ident, name, bet);

                myOrganization.Add(worker);
            }
            catch
            {
                Console.WriteLine("Ошибка, попробуйте снова");
                AddHourlyWorker();
            }

        }

        private static void AddFixPayWorker()
        {
            try
            {
                Console.WriteLine("1 - Директор, 2 - Менеджер, 3 - Рядовой раотник");
                int type = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите id работника");
                string ident = Console.ReadLine();
                Console.WriteLine("Введите ФИО работника");
                string name = Console.ReadLine();
                Console.WriteLine("Введите зарплату работника");
                double bet = double.Parse(Console.ReadLine());

                var worker = new FixPayWorker((WorkerType)type, ident, name, bet);

                myOrganization.Add(worker);
            }
            catch
            {
                Console.WriteLine("Ошибка, попробуйте снова");
                AddFixPayWorker();
            }
        }

        internal static void Add()
        {
            Console.WriteLine("Введите тип зп работника (почасовик - \"1\"; с фиксированной оплатой - \"2\"):");
            string type = Console.ReadLine();
            switch (type)
            {
                case "1":
                    AddHourlyWorker();
                    break;
                case "2":
                    AddFixPayWorker();
                    break;
                default:
                    Console.WriteLine("");
                    Add();
                    break;
            }

        }


        internal static void All()
        {
            Console.WriteLine("Список:");

            foreach (var worker in myOrganization.GetWorkers())
            {
                Console.WriteLine(
                    $"{worker.Type}   \t{worker.Ident} : {worker.Name} {worker.Salary} rub");
            }

        }

        internal static void Sort()
        {
            myOrganization.SortBySalary();
        }

        internal static void FirstFive()
        {
            var workers = myOrganization.GetWorkers();

            var workersArr = workers.ToArray();

            for (int i = 0; i < 5 && i < workers.Count(); i++)
            {
                Console.WriteLine($"{workersArr[i].Type}   \t{workersArr[i].Ident} : {workersArr[i].Name} {workersArr[i].Salary} rub");
            }
        }

        internal static void LastThree()
        {
            var workers = myOrganization.GetWorkers();

            var workersArr = workers.ToArray();

            for (int i = workers.Count() - 1; i < workers.Count() - 4 && i >= 0; i--)
            {
                Console.WriteLine($"{workersArr[i].Ident}");
            }
        }

        internal static void Total()
        {
            Console.WriteLine($"Среднемесячная зарпласта на заводе = {myOrganization.TotalSalary}");
        }

        internal static void XML()
        {
            Console.WriteLine("Введите полный путь (с названием) к новому файлу:");
            string fileName = Console.ReadLine();
            try
            { 
                myOrganization.Toxml(fileName);
            }
            catch
            {
                Console.WriteLine("Ошибка, попробуйте снова");
                XML();
            }
        }

    }
}
