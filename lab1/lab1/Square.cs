using System;

namespace lab1
{
    public class Square
    {
        private double _x0, _y0, _xc, _yc, _sideLen;

        public Square(double x0, double y0, double sideLen)
        {
            _x0 = x0;
            _y0 = y0;
            SideLen = sideLen;
            _xc = _x0 + sideLen / 2;
            _yc = _y0 - sideLen / 2;
        }

        public double SideLen
        {
            get { return _sideLen; }
            set
            {
                if (value > 0) _sideLen = value;
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
            var newSideLen = _sideLen * coeff;
            _x0 += (newSideLen - _sideLen) / 2;
            _y0 -= (newSideLen - _sideLen) / 2;
            SideLen = newSideLen;
        }

        public void Rotate(double angle)
        {
            angle += 45;
            angle *= Math.PI / 180; //перевод в радианы
            _x0 -= Math.Sin(angle) * Math.Sqrt(2) * _sideLen;
            _y0 += Math.Sin(angle) * Math.Sqrt(2) * _sideLen;
        }

        internal double[,] Dots()
        {
            double[,] arr = new double[5,2];
            
            arr[0,0] = _xc; arr[0,1] = _yc;
            arr[1, 0] = _x0; arr[1, 1] = _y0;
            arr[2, 0] = _x0 + _sideLen; arr[2, 1] = _y0;
            arr[3, 0] = _x0; arr[3, 1] = _y0 - _sideLen;
            arr[4, 0] = _x0 + _sideLen; arr[4, 1] = _y0 - _sideLen;

            return arr;
        }

        internal double[] Borders()
        {
            //крайние значения x, y
            double[] arr = new double[4];

            arr[0] = _x0; arr[1] = _x0 + _sideLen;
            arr[3] = _y0; arr[2] = _y0 - _sideLen;

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
            double[] arr1 = this.Borders();
            double[] arr2 = figure.Borders();

            return HasInputDots(arr1, arr2) || HasInputDots(arr2, arr1);
        }

        public bool Intersect1(Rectangle figure)
        {
            double[] arr1 = this.Borders();
            double[] arr2 = figure.Borders();

            return HasInputDots(arr1, arr2) || HasInputDots(arr2, arr1);
        }

        public bool Intersect(Circle figure)
        {
            return figure.Intersect(this);
        }



        public override string ToString()
        {
            return $"Square([{_x0}; {_y0}], Side = {_sideLen})";
        }
    }
}