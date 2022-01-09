using System;

namespace lab1
{
    public class Circle
    {
        private double _x0, _y0, _radius;

        public Circle(double x0, double y0, double radius)
        {
            _x0 = x0;
            _y0 = y0;
            this.Radius = radius;
        }

        public double Xcentre
        {
            get
            {
                return _x0;
            }
        }

        public double Ycentre
        {
            get
            {
                return _y0;
            }
        }

        public double Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                if (value > 0) _radius = value;
                else throw new ArgumentException();
            }
        }

        public void MoveTo(double x, double y)
        {
            _x0 += x;
            _y0 += y;
        }

        public void Resize(double coeff)
        {
            _radius *= coeff;
        }

        private double Far(double x1, double y1, double x2, double y2)
        {
            double far = (x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2);
            return Math.Sqrt(far);
        }

        public bool Intersect(object figure)
        {
            if (figure is lab1.Circle) return this.Intersect((Circle)figure);
            if (figure is lab1.Square) return this.Intersect((Square)figure);
            return this.Intersect((Rectangle)figure);
        }

        public bool Intersect(Circle figure) 
        {
            double far = Far(this.Xcentre, this.Ycentre, figure.Xcentre, figure.Ycentre);
            return (far < this.Radius + figure.Radius);
        }

        public bool Intersect(Square figure)
        {
            // centre, s1, s2, s3, s4
            double[,] arr = figure.Dots();

            for (int i = 0; i < 5; i++) if (this.Radius < Far(this.Xcentre, this.Ycentre, arr[i, 0], arr[i, 1])) return true;
           
            return false;
        }

        public bool Intersect(Rectangle figure)
        {
            // centre, s1, s2, s3, s4
            double[,] arr = figure.Dots();

            for (int i = 0; i < 5; i++) if (this.Radius < Far(this.Xcentre, this.Ycentre, arr[i, 0], arr[i, 1])) return true;

            return false;
        }

        public override string ToString()
        {
            return $"Circle([{_x0}; {_y0}], R = {_radius})";
        }

    }
}