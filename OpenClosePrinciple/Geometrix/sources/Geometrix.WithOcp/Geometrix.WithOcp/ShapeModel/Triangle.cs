using System;

namespace iQuest.Geometrix.WithOcp.ShapeModel
{
    internal class Triangle : IShape
    {
        public double LengthA { get; set; }
        public double LengthB { get; set; }
        public double LengthC { get; set; }

        public double CalculateArea()
        {
            return 0.25 * Math.Sqrt((LengthA + LengthB + LengthC) 
                * (-LengthA + LengthB + LengthC) 
                * (LengthA - LengthB + LengthC)
                * (LengthA + LengthB - LengthC));
        }
    }
}
