using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesWithComputableArea
{
    public class ShapeWithComputableArea : Shape
    {
        public AreaComputer AreaComputer { get; set; }
        public double Area
        {
            get
            {
                return AreaComputer?.Compute(this) ?? throw new Exception("Area computer is not defined");
            }
        }
    }

    public class Triangle : ShapeWithComputableArea
    {
        public Triangle(double a, double b, double c, AreaComputer areaComputer)
        {
            if (a.CompareTo(b + c) >= 0 || b.CompareTo(a + c) >= 0 || c.CompareTo(b + a) >= 0)
            {
                throw new ArgumentException("Segments do not form triangle");
            }
            A = a; B = b; C = c; AreaComputer = areaComputer;
        }
        public double A { get; private set; }
        public double B { get; private set; }
        public double C { get; private set; }
        public bool IsARightTriange
        {
            get
            {
                double zero = 0;
                double aSqr = Math.Pow(A, 2);
                double bSqr = Math.Pow(B, 2);
                double cSqr = Math.Pow(C, 2);
                return zero.CompareTo(aSqr + bSqr - cSqr) == 0 || zero.CompareTo(aSqr + cSqr - bSqr) == 0 || zero.CompareTo(cSqr + bSqr - aSqr) == 0;
            }
        }
    }

    public class Circle : ShapeWithComputableArea
    {
        public Circle(double radius, AreaComputer areaComputer)
        {
            if (radius.CompareTo(0) <= 0)
            {
                throw new ArgumentException("Radius must be a positive number");
            }
            Radius = radius; AreaComputer = areaComputer;
        }

        public double Radius { get; private set; }
    }
}
