using System;
using System.IO;
using Tutorial.Things;

namespace PointClass.Basics
{
    public class Point
    {
        public int x = 0;
        public int y = 0;

        //TODO: Add magnitude

        public Point(int x = 0, int y = 0)
        {
            this.x = x;
            this.y = y;
        }

        public Point(Point masterCopy)
        {
            x = masterCopy.x;
            y = masterCopy.y;
        }

        // ...

    }
}
