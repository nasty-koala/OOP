using System;

namespace lab1
{
    public class Rectangle
    {
        private double _x0, _y0, _xc, _yc, _sideLenX, _sideLenY;

        public Rectangle(double x0, double y0, double sideLenX, double sideLenY)
        {
            _x0 = x0;
            _y0 = y0;
            SideLenX = sideLenX;
            SideLenY = sideLenY;
            _xc = _x0 + sideLenX / 2;
            _yc = _y0 - sideLenY / 2;
        }

        public double SideLenX
        {
            get
            {
                return _sideLenX;
            }
            set
            {
                if (value > 0) _sideLenX = value;
                else throw new ArgumentException();
            }
        }
        
        public double SideLenY
        {
            get
            {
                return _sideLenY;
            }
            set
            {
                if (value > 0) _sideLenY = value;
                else throw new ArgumentException();
            }
        }

        public double Xcentre
        {
            get
            {
                return _xc;
            }
        }

        public double Ycentre
        {
            get
            {
                return _yc;
            }
        }

        public void MoveTo(double x, double y)
        {
            _x0 += x;
            _y0 += y;
        }

        public void Resize(double coeff)
        {
            var newSideLenX = _sideLenX * coeff;
            var newSideLenY = _sideLenY * coeff;
            _x0 -= (newSideLenX - _sideLenX) / 2;
            _y0 += (newSideLenY - _sideLenY) / 2;
            SideLenX = newSideLenX;
            SideLenY = newSideLenY;
        }

        public void Rotate(double angle)
        {
            angle += 45; //угол между стороной и диагональю
            angle *= Math.PI / 180; //перевод в радианы
            double diagonal = Math.Sqrt(_sideLenX * _sideLenX + _sideLenY * _sideLenY);
            _x0 += Math.Sin(angle) * diagonal;
            _y0 -= Math.Sin(angle) * diagonal;
        }

        internal double[,] Dots()
        {
            double[,] arr = new double[5, 2];

            arr[0, 0] = _xc; arr[0, 1] = _yc;
            arr[1, 0] = _x0; arr[1, 1] = _y0;
            arr[2, 0] = _x0 + _sideLenX; arr[2, 1] = _y0;
            arr[3, 0] = _x0; arr[3, 1] = _y0 - _sideLenY;
            arr[4, 0] = _x0 + _sideLenX; arr[4, 1] = _y0 - _sideLenY;

            return arr;
        }

        internal double[] Borders()
        {
            //крайние значения x, y
            double[] arr = new double[4];

            arr[0] = _x0; arr[1] = _x0 + _sideLenX;
            arr[3] = _y0; arr[2] = _y0 - _sideLenY;

            return arr;
        }

        private static bool HasInputDots(double[] arr1, double[] arr2)
        {
            return ((arr2[0] < arr1[0] && arr1[0] < arr2[1] && arr2[2] < arr1[3] && arr1[3] < arr2[3]) ||
                    (arr2[0] < arr1[1] && arr1[1] < arr2[1] && arr2[2] < arr1[3] && arr1[3] < arr2[3]) ||
                    (arr2[0] < arr1[0] && arr1[0] < arr2[1] && arr2[2] < arr1[2] && arr1[2] < arr2[3]) ||
                    (arr2[0] < arr1[1] && arr1[1] < arr2[1] && arr2[2] < arr1[2] && arr1[2] < arr2[3]));
        }

        public bool Intersect(object figure)
        {
            if (figure is lab1.Circle) return this.Intersect((Circle)figure);
            if (figure is lab1.Square) return this.Intersect((Square)figure);
            return this.Intersect((Rectangle)figure);
        }

        public bool Intersect(Square figure)
        {
            return figure.Intersect(this);
        }

        public bool Intersect(Rectangle figure)
        {
            double[] arr1 = this.Borders();
            double[] arr2 = figure.Borders();

            return HasInputDots(arr1, arr2) || HasInputDots(arr2, arr1);
        }

        public bool Intersect(Circle figure)
        {
            return figure.Intersect(this);
        }


        public override string ToString()//object
        {
            return $"Rectangle([{_x0}; {_y0}], SideX = {_sideLenX}, SideY = {_sideLenY})";

        }
    }
}