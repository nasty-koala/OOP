//Резанко А.А. - 1 вариант

namespace lab2
{
    public class Complex //комплексные числа как тип данных или новый объект
    {
        // объект сделан неизменяемым, чтобы избежать ошибок, связанных с множеством ссылок на один объект
        private readonly double real; //поля
        private readonly double imag; 
        
        public Complex(double real_num, double imag_num) //конструктор
        {
            real = real_num;
            imag = imag_num;
        }

        //далее идет сама перегрузка операторов по заданию, с учетом вопроса 3 (перестановка элементов разных типов)

        //описание вполне обычное
        //описание, тип возвращаемых данных(результата), оператор и аргументы в скобках

        public static Complex operator +(Complex c1, Complex c2) => new Complex(c1.real + c2.real, c1.imag + c2.imag);

        public static Complex operator -(Complex c1, Complex c2) => new Complex(c1.real - c2.real, c1.imag - c2.imag);

        public static Complex operator +(Complex c1, double c2) => new Complex(c1.real + c2, c1.imag);
        public static Complex operator +(double c2, Complex c1) => c1 + c2;
        
        public static Complex operator -(Complex c1, double c2) => new Complex(c1.real - c2, c1.imag);
        public static Complex operator -(double c2, Complex c1) => new Complex(c2 - c1.real, -c1.imag);
        
        public static Complex operator *(Complex c1, double c2) => new Complex(c1.real * c2, c1.imag * c2);
        public static Complex operator *(double c2, Complex c1) => c1 * c2;
        
        public override string ToString()
        {
            if (imag<0) return $"{real} {imag}i";
            return $"{real} + {imag}i";
        }

    }
}