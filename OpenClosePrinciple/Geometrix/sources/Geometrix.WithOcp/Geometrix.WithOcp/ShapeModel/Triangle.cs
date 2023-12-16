using System;

namespace iQuest.Geometrix.WithOcp.ShapeModel
{
    internal class Triangle : IShape
    {
        public int LengthA { get; set; }
        public int LengthB { get; set; }
        public int LengthC { get; set; }

        public double CalculateArea()
        {
            return 0.25 * Math.Sqrt((LengthA + LengthB + LengthC) 
                * (-LengthA + LengthB + LengthC) 
                * (LengthA - LengthB + LengthC)
                * (LengthA + LengthB - LengthC));
        }
    }
}
