using System;

namespace lab1
{
    public class Menu
    {
        public static string NewMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\n\tМеню действий\n" + 
                              "Для выбора введите кодовое слово, соответствующее команде (указано в скобках) и следуйте инструкциям\n\n" +
                              "  -  Создание объекта (create)\n" +
                              "  -  Перемещение объекта на плоскости на заданный вектор (move)\n" +
                              "  -  Изменение размеров объекта относительно центра (resize)\n" +
                              "  -  Вращение фигуры на заданый угол (rotate)\n" +
                              "  -  Определение факта пересечения двух выбранных фигур (intersect)\n");
            return Console.ReadLine();
        }
        
        static string TypeInput()
        {
            Console.Write("\tВведите тип объекта (circle/square/rectangle): ");
            return Console.ReadLine();
        }
        
        public static Circle CircleCreate()
        {
            try
            {
                double x0, y0, radius;


                Console.Write("Ввод данных круга:\nкоординаты центра:\tx0 = ");
                x0 = double.Parse(Console.ReadLine());

                Console.Write("\t\t\ty0 = ");
                y0 = double.Parse(Console.ReadLine());

                Console.Write("\tрадиус: ");
                radius = double.Parse(Console.ReadLine());

                //object figure = 
                return new Circle(x0, y0, radius);
            }
            catch
            {
                Console.WriteLine("Ошибка данных. Попробуйте снова");
                return CircleCreate();
            }
        }
        
        public static Square SquareCreate()
        {
            try
            {
                double x0, y0, sideLen;


                Console.Write("Ввод данных квадрата:\nкоординаты левого верхнего угла:\tx0 = ");
                x0 = double.Parse(Console.ReadLine());

                Console.Write("\t\t\ty0 = ");
                y0 = double.Parse(Console.ReadLine());

                Console.Write("\tдлина стороны: ");
                sideLen = double.Parse(Console.ReadLine());

                //object figure = 
                return new Square(x0, y0, sideLen);
            }
            catch
            {
                Console.WriteLine("Ошибка данных. Попробуйте снова");
                return SquareCreate();
            }
        }
        public static Rectangle RectangleCreate()
        {
            try
            {
                double x0, y0, sideLenX, sideLenY;


                Console.Write("Ввод данных круга:\nкоординаты левого верхнего угла:\tx0 = ");
                x0 = double.Parse(Console.ReadLine());

                Console.Write("\t\t\ty0 = ");
                y0 = double.Parse(Console.ReadLine());

                Console.Write("\tсторонаX: ");
                sideLenX = double.Parse(Console.ReadLine());
                
                Console.Write("\tсторонаY: ");
                sideLenY = double.Parse(Console.ReadLine());

                //object figure = 
                return new Rectangle(x0, y0, sideLenX, sideLenY);
            }
            catch
            {
                Console.WriteLine("Ошибка данных. Попробуйте снова");
                return RectangleCreate();
            }
        }
        
        static string Create()
        {
            switch (TypeInput())
            {
                case "circle":
                {
                    return CircleCreate().ToString();
                }
                case "square":
                {
                    return SquareCreate().ToString();
                }
                case "rectangle":
                {
                    return RectangleCreate().ToString();
                }
                default:
                {
                    Console.WriteLine("Неверный или неизвестный тип объекта!");
                    return Create();
                }
            }
        }

        static double[] VectorInput()
        {
            double[] coordinates = new double[2];

            Console.Write("Ввод вектора перемещения:\tx = "); 
            coordinates[0] = double.Parse(Console.ReadLine());
        
            Console.Write("\t\t\ty = "); 
            coordinates[1] = double.Parse(Console.ReadLine());
            
            return coordinates;
        }
        
        static string MoveTo()
        {
            switch (TypeInput())
            {
                case "circle":
                {
                    Circle figure = CircleCreate();
                    double[] vector = VectorInput();
                    figure.MoveTo(vector[0], vector[1]);
                    return figure.ToString();
                }
                case "square":
                {
                    Square figure = SquareCreate();
                    double[] vector = VectorInput();
                    figure.MoveTo(vector[0], vector[1]);
                    return figure.ToString();
                }
                case "rectangle":
                {
                    Rectangle figure = RectangleCreate();
                    double[] vector = VectorInput();
                    figure.MoveTo(vector[0], vector[1]);
                    return figure.ToString();
                }
                default:
                {
                    Console.WriteLine("Неверный или неизвестный тип объекта!");
                    return MoveTo();
                }
            }   
        }

        static double CoeffInput()
        {
            Console.Write("Введите коэффициент увеличения фигуры: ");
            double coeff = double.Parse(Console.ReadLine());
            
            if (coeff>0) return coeff;
            Console.WriteLine("Неверный коэффициент!");
            return coeff;
        }
        
        static string Resize()
        {
            switch (TypeInput())
            {
                case "circle":
                {
                    Circle figure = CircleCreate();
                    double coeff = CoeffInput();
                    figure.Resize(coeff);
                    return figure.ToString();
                }
                case "square":
                {
                    Square figure = SquareCreate();
                    double coeff = CoeffInput();
                    figure.Resize(coeff);
                    return figure.ToString();
                }
                case "rectangle":
                {
                    Rectangle figure = RectangleCreate();
                    double coeff = CoeffInput();
                    figure.Resize(coeff);
                    return figure.ToString();
                }
                default:
                {
                    Console.WriteLine("Неверный или неизвестный тип объекта!");
                    return Resize();
                }
            }   
        }
        
        static double AngleInput()
        {
            Console.Write("Введите введите угол поворота фигуры: ");
            double angle = double.Parse(Console.ReadLine());
            return angle;
        }
        
        static string Rotate()
        {
            switch (TypeInput())
            {
                case "circle":
                {
                    Circle figure = CircleCreate();
                    return "круг при повороте неизменен -> " + figure.ToString();
                }
                case "square":
                {
                    Square figure = SquareCreate();
                    double angle = AngleInput();
                    figure.Rotate(angle);
                    return figure.ToString();
                }
                case "rectangle":
                {
                    Rectangle figure = RectangleCreate();
                    double angle = AngleInput();
                    figure.Rotate(angle);
                    return figure.ToString();
                }
                default:
                {
                    Console.WriteLine("Неверный или неизвестный тип объекта!");
                    return Rotate();
                }
            }   
        }

        public static object newObject()
        {
            switch (TypeInput())
            {
                case "circle":
                {
                    Circle figure = CircleCreate();
                    return figure;
                }
                case "square":
                {
                    Square figure = SquareCreate();
                    return figure;
                }
                case "rectangle":
                {
                    Rectangle figure = RectangleCreate();
                    return figure;
                }
                default:
                {
                    Console.WriteLine("Неверный или неизвестный тип объекта!");
                    return newObject();
                }
            }
        }
        
        static string Intersect()
        {
            Console.WriteLine("Фигура 1");
            switch (TypeInput())
            {
                case "circle":
                {
                    Circle figure1 = CircleCreate();
                    object figure2 = newObject();
                    return figure1.Intersect(figure2);
                }
                case "square":
                {
                    Square figure1 = SquareCreate();
                    object figure2 = newObject();
                    return figure1.Intersect(figure2);
                }
                case "rectangle":
                {
                    Rectangle figure1 = RectangleCreate();
                    object figure2 = newObject();
                    return figure1.Intersect(figure2);
                }
                default:
                {
                    Console.WriteLine("Неверный или неизвестный тип объекта!");
                    return Resize();
                }
            }   
        }
        

        public static void MainMenu()
        {
            switch (NewMenu())
            {
                case "create":
                    Console.WriteLine("Новая фигура - " + Create());
                    break;
                case "move":
                    Console.WriteLine("Новая фигура - " + MoveTo());
                    break;
                case "resize":
                    Console.WriteLine("Новая фигура - " + Resize());
                    break;
                case "rotate":
                    Console.WriteLine("Новая фигура - " + Rotate());
                    break;
                case "intersect":
                    Console.WriteLine("Новая фигура - " + Intersect());
                    break;
                default:
                    Console.WriteLine("Неопознанная команда!");
                    Console.ReadKey();
                    break;
            }
        }
           
    }
}