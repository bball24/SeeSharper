using System;
using System.IO;
using Tutorial.Things;

namespace PointClass.FluentDesign
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
        
        public Point SetOutputWriter(TextWriter fileWriter)
        {
            OutputWriter = fileWriter;
            return this;
        }

        // ...

    }

    public partial class MainProgram
    {
        public Point CreatePoint_WithFluentDesign(int x, int y)
        {
            TextWriter injectedVariable = new AutomatedTestLogger();

            return new Point(x, y).SetOutputWriter(injectedVariable);
        }

        public Point CreatePoint_WithFluentDesign_Condensed(int x, int y)
        {
            return new Point(x, y).SetOutputWriter(new AutomatedTestLogger());
        }

        // Problems with this:
        //
        //  Can you tell that SetOutputWriter() returns a point?
        //  Wouldn't it make sense for it to return a TextWriter?
        //
        //  Now there are two ways to set the OutputWriter property:
        //      SetOutputWriter(value);
        //      OutputWriter { set; }
    }
}
