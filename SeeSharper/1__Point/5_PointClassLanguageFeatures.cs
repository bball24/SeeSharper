using System;
using System.IO;
using Tutorial.Things;

namespace PointClass.LanguageFeatures
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
        public Point CreatePoint_WithObjectInitializer(int x, int y)
        {
            TextWriter injectedVariable = new AutomatedTestLogger();

            return new Point(x, y) { OutputWriter = injectedVariable };
        }

        public Point CreatePoint_WithObjectInitializer_Condensed(int x, int y)
        {
            return new Point(x, y) { OutputWriter = new AutomatedTestLogger() };
        }
    }
}
