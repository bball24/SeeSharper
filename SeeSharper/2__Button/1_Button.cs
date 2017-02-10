using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButtonClass.Bascis
{
    public class Button
    {
        int X { get; set; }
        int Y { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        int Left => X;
        int Right
        {
            get { return X + Width; }

            set
            {
                if (value - X < 0)
                {
                    throw new InvalidOperationException("The right side must be greater than the left!");
                }
                Width = value - X;
            }
        }
        int Top => Y;
        int Bottom
        {
            get { return Y + Height; }

            set
            {
                if (value - X < 0)
                {
                    throw new InvalidOperationException("The right side must be greater than the left!");
                }
                Width = value - X;
            }
        }

        public Button()
        {
            X = 0;
            Y = 0;
            Width = 10;
            Height = 10;
        }

        public void Clicked()
        {
            // ???
        }
    }
}
