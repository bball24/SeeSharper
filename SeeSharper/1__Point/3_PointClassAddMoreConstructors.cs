using System;
using System.IO;
using Tutorial.Things;

namespace PointClass.AddMoreConstructors
{
    public partial class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public TextWriter OutputWriter { private get; set; }

        public Point(int x = 0, int y = 0, TextWriter outputWriter = null)
        {
            X = x;
            Y = y;
            OutputWriter = outputWriter;
        }

        public Point(Point masterCopy, TextWriter outputWriter = null)
        {
            X = masterCopy.X;
            Y = masterCopy.Y;
            OutputWriter = outputWriter;
        }

        // ...

    }

    public partial class MainProgram
    {
        public Point CreatePoint_WithAddedConstructors(int x, int y)
        {
            TextWriter injectedVariable = new AutomatedTestLogger();

            return new Point(x, y, injectedVariable);
        }

        public Point CreatePoint_WithAddedConstructors_Condensed(int x, int y)
        {
            return new Point(x, y, new AutomatedTestLogger());
        }
    }





    // Problems with this implementation:
    // The more constructors we have, the worse it is to add this feature.
    // Also, What if the class already took in a TextWriter, like this:

    public partial class Point
    {
        public Point(int x = 0, int y = 0, TextWriter someOtherTextWriter = null, TextWriter outputWriter = null) { }
    }

    // And it already gets called from MainProgram like this:

    public partial class MainProgram
    {
        public void ConvienientFunctionToProveMyPoint()
        {
            new Point(0, 0, new ConsoleWriter());
        }
    }

    // Now it's no longer backwards compatible. AutomatedTestLogger might be injected into the wrong value (See Condensed).
}
