using System;
using System.IO;
using Tutorial.Things;

namespace PointStruct.FluentDesign
{
    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public FileWriter OutputWriter { private get; set; }

        public Point(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
            OutputWriter = null;
        }

        public Point SetOutputStream(FileWriter fileWriter)
        {
            OutputWriter = fileWriter;
            return this;
        }
    }
    
    // ...

    public partial class MainProgram
    {
        public Point CreatePoint_WithFluentDesign(int x, int y)
        {
            FileWriter injectedVariable = new SomeEnterpriseClassForLogging();

            Point point = new Point(x, y);
            point.OutputWriter = injectedVariable;
            return point;
        }
    }
}
