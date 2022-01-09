using System;

namespace lab1
{
    public class Menu
    {
        internal static string NewMenu()
        {
            Console.WriteLine("\n\n\tМеню действий\n" + 
                              "Для выбора введите кодовое слово, соответствующее команде (указано в скобках) и следуйте инструкциям\n\n" +
                              "  -  Создание объекта (create)\n" +
                              "  -  Перемещение объекта на плоскости на заданный вектор (move)\n" +
                              "  -  Изменение размеров объекта относительно центра (resize)\n" +
                              "  -  Вращение фигуры на заданый угол (rotate)\n" +
                              "  -  Определение факта пересечения двух выбранных фигур (intersect)\n" +
                              "  -  Очистка консоли (clean)\n" +
                              "  -  Выход (exit)");
            return Console.ReadLine();
        }
        
        private static string TypeInput()
        {
            Console.Write("\tВведите тип объекта (circle/square/rectangle): ");
            return Console.ReadLine();
        }
        
        private static Circle CircleCreate()
        {
            try
            {
                double x0, y0, radius;


                Console.Write("Ввод данных круга:\nкоординаты центра:\n\tx0 = ");
                x0 = double.Parse(Console.ReadLine());

                Console.Write("\ty0 = ");
                y0 = double.Parse(Console.ReadLine());

                Console.Write("\tрадиус = ");
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
        
        private static Square SquareCreate()
        {
            try
            {
                double x0, y0, sideLen;


                Console.Write("Ввод данных квадрата:\nкоординаты левого верхнего угла:\n\tx0 = ");
                x0 = double.Parse(Console.ReadLine());

                Console.Write("\ty0 = ");
                y0 = double.Parse(Console.ReadLine());

                Console.Write("\tдлина стороны = ");
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
        private static Rectangle RectangleCreate()
        {
            try
            {
                double x0, y0, sideLenX, sideLenY;


                Console.Write("Ввод данных прямоугольника:\nкоординаты левого верхнего угла:\n\tx0 = ");
                x0 = double.Parse(Console.ReadLine());

                Console.Write("\ty0 = ");
                y0 = double.Parse(Console.ReadLine());

                Console.Write("\tсторонаX = ");
                sideLenX = double.Parse(Console.ReadLine());
                
                Console.Write("\tсторонаY = ");
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
        
        internal static string Create()
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

        private static double[] VectorInput()
        {
            double[] coordinates = new double[2];

            Console.Write("Ввод вектора перемещения:\n\tx = "); 
            coordinates[0] = double.Parse(Console.ReadLine());
        
            Console.Write("\ty = "); 
            coordinates[1] = double.Parse(Console.ReadLine());
            
            return coordinates;
        }
        
        internal static string MoveTo()
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

        private static double CoeffInput()
        {
            Console.Write("Введите коэффициент увеличения фигуры: ");
            double coeff = double.Parse(Console.ReadLine());
            
            if (coeff>0) return coeff;
            Console.WriteLine("Неверный коэффициент!");
            return coeff;
        }
        
        internal static string Resize()
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
        
        private static double AngleInput()
        {
            Console.Write("Введите введите угол поворота фигуры: ");
            double angle = double.Parse(Console.ReadLine());
            return angle;
        }

        internal static string Rotate()
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

        private static object newObject()
        {
            Console.WriteLine("Фигура 2");
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
        
        internal static string Intersect()
        {
            Console.WriteLine("Фигура 1");
            switch (TypeInput())
            {
                case "circle":
                {
                    Circle figure1 = CircleCreate();
                    object figure2 = newObject();
                    return figure1.Intersect(figure2).ToString();
                }
                case "square":
                {
                    Square figure1 = SquareCreate();
                    object figure2 = newObject();
                    return figure1.Intersect(figure2).ToString();
                }
                case "rectangle":
                {
                    Rectangle figure1 = RectangleCreate();
                    object figure2 = newObject();
                    return figure1.Intersect(figure2).ToString();
                }
                default:
                {
                    Console.WriteLine("Неверный или неизвестный тип объекта!");
                    return Intersect();
                }
            }   
        }

    }
}