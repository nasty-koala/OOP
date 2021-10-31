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

        public override string ToString()
        {
            return $"Circle([{_x0}; {_y0}], R = {_radius})";
        }
        
        
    }

    public class Square
    {
        private double _x0, _y0, _sideLen;

        public Square(double x0, double y0, double sideLen)
        {
            _x0 = x0;
            _y0 = y0;
            SideLen = sideLen;
        }

        public double SideLen
        {
            get
            {
                return _sideLen;
            }
            set
            {
                if (value > 0) _sideLen = value;
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
            var newSideLen = _sideLen * coeff;
            _x0 -= (newSideLen - _sideLen) / 2;
            _y0 += (newSideLen - _sideLen) / 2;
            SideLen = newSideLen;
        }

        public override string ToString()
        {
            return $"Square([{_x0}; {_y0}], Side = {_sideLen})";
        }
        
        public void Rotate(double angle)
        {
            angle += 45;
            angle *= Math.PI / 180; //перевод в радианы
            _x0 -= Math.Sin(angle) * Math.Sqrt(2) * _sideLen;
            _y0 += Math.Sin(angle) * Math.Sqrt(2) * _sideLen;
        }
    }

    public class Rectangle
    {
        private double _x0, _y0, _sideLenX, _sideLenY;

        public Rectangle(double x0, double y0, double sideLenX, double sideLenY)
        {
            _x0 = x0;
            _y0 = y0;
            SideLenX = sideLenX;
            SideLenY = sideLenY;
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

        public override string ToString()
        {
            return $"Rectangle([{_x0}; {_y0}], SideX = {_sideLenX}), SideY = {_sideLenY}";

        }

        public void Rotate(double angle)
        {
            angle += 45; //угол между стороной и диагональю
            angle *= Math.PI / 180; //перевод в радианы
            _x0 -= Math.Sin(angle) * diagonal;
            _y0 += Math.Sin(angle) * diagonal;
        }
    }
}