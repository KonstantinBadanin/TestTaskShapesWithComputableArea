using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesWithComputableArea
{
    public abstract class AreaComputer
    {
        public abstract double Compute(Shape shape);
    }

    public class TriangleAreaComputer : AreaComputer
    {
        public override double Compute(Shape shape)
        {
            if (shape is Triangle triangle)
            {
                var halfPerimeter = (triangle.A + triangle.B + triangle.C) / 2;
                return Math.Sqrt(halfPerimeter * (halfPerimeter - triangle.A) * (halfPerimeter - triangle.B) * (halfPerimeter - triangle.C));
            }
            throw new ArgumentException("Shape is not supported");
        }
    }

    public class CircleAreaComputer : AreaComputer
    {
        public override double Compute(Shape shape)
        {
            if (shape is Circle circle)
            {
                return Math.PI * circle.Radius * circle.Radius;
            }
            throw new ArgumentException("Shape is not supported");
        }
    }
}
