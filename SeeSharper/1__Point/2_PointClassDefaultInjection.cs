using System;
using System.IO;
using Tutorial.Things;

namespace PointClass.DefaultInjection
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public TextWriter OutputWriter { private get; set; }

        public Point(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }

        public Point(Point masterCopy)
        {
            X = masterCopy.X;
            Y = masterCopy.Y;
        }

        // ...

    }

    public partial class MainProgram
    {
        public Point CreatePoint_WithBasicInjection(int x, int y)
        {
            TextWriter injectedVariable = new AutomatedTestLogger();

            Point point = new Point(x, y);
            point.OutputWriter = injectedVariable;

            return point;
        }
    }

    // Problems with this:
    // We want to write less lines of code.
    //
    // Keeping everything in the construction of Point is much cleaner. 
    // Keeping them in the constructor keeps the lines together, and prevents someone
    // From adding a line of code between construction and injection.
}
