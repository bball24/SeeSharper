using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButtonClass.WithInheritance
{
    public abstract class Button : UIElement
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }
        public int Left => X;
        public int Right
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
        public int Top => Y;
        public int Bottom
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

        public override void HandleClickEvent(MouseEventData e)
        {
            if(e.Equals("aClickOnThisUIElement"))
            {
                OnClick();
            }
        }

        public abstract void OnClick();
    }

    public sealed class StartButton : Button
    {
        private GameStateManager gameStateManager { get; set; } = null;

        public StartButton(GameStateManager gameStateManager)
        {
            this.gameStateManager = gameStateManager;
        }

        public override void OnClick()
        {
            gameStateManager.StartButtonWasClicked();
        }
    }

    public class GameStateManager
    {
        private StartButton startGameButton;

        public GameStateManager()
        {
            startGameButton = new StartButton(this) { X = 400, Y = 600, Width = 200, Height = 120 };
        }

        public void StartButtonWasClicked()
        {
            Console.WriteLine("Do some things here");
        }
    }
}



























public abstract class UIElement
{
    public abstract void HandleClickEvent(MouseEventData e);
}

public class MouseEventData { }
public class Mark { }