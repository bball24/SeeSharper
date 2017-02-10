using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointClass.LanguageFeatures
{
    // Extension Methods must be in a static class.
    public static class PointExtensions
    {
        // An extension method for the point class (shown as the Vector class in the workshop)
        // The extension method must be declared as static with the first parameter declared as "this [ParamType] [paramName]"
        public static double DistanceFrom(this Point a, Point b)
        {
            return Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
        }
        // This function can either be called as:
        //      double distance = myPoint.DistanceFrom(otherPoint);
        // or
        //      double distance = DistanceFrom(myPoint, otherPoint);
    }
}
