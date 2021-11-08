namespace lab2
{
    public class Complex
    {
        private readonly double real;
        private readonly double imag;

        public Complex(double real_num, double imag_num)
        {
            real = real_num;
            imag = imag_num;
        }

        public static Complex operator +(Complex c1, double c2) => new Complex(c1.real + c2, c1.imag);
        public static Complex operator +(double c1, Complex c2) => c1 + c2;
        
        public static Complex operator -(Complex c1, double c2) => new Complex(c1.real - c2, c1.imag);
        public static Complex operator -(double c1, Complex c2) => c1 - c2;
        
        public static Complex operator *(Complex c1, double c2) => new Complex(c1.real * c2, c1.imag * c2);
        public static Complex operator *(double c1, Complex c2) => c1 * c2;
        
        public override string ToString()
        {
            if (imag<0) return $"{real} {imag}i";
            return $"{real} + {imag}i";
        }

    }
}