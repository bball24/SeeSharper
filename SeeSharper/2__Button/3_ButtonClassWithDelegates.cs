using Console = System.Console;
using System;

namespace ButtonClass.WithDelegates
{

    public class Button : UIElement
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

        public delegate void OnClickHandler();

        public OnClickHandler Click { get; set; }

        public Button()
        {
            X = 0;
            Y = 0;
            Width = 10;
            Height = 10;
        }

        public override void HandleClickEvent(MouseEventData e)
        {
            if (e.Equals("aClickOnThisUIElement"))
            {
                Click();
            }
        }
    }
    

    public class GameStateManager
    {
        private Button startGameButton;

        public GameStateManager()
        {
            startGameButton = new Button() { X = 400, Y = 600, Width = 200, Height = 120 };
            startGameButton.Click += StartButtonWasClicked;
            startGameButton.Click += OtherThing;
        }

        public void StartButtonWasClicked()
        {
            Console.WriteLine("Do some things here");
        }
        public void OtherThing()
        {
            Console.WriteLine("Do some things here");
        }
    }

    // Pros:
    // The buttons is now decoupled from the GameStateManager:
    //  The button does not need to know of the existence of the GameStateManager at all.
    // We no longer need derived classes for each button we create.
    //  We can simply create a new instance of Button and add a function to the Click delegate.

    // Cons:
    //  Take a look at this:
    namespace DentonsCode
    {
        public static class IWantToWatchTheWorldBurn
        {
            public static void ChangeButtonToDoSomethingElse(Button button)
            {
                button.Click = DoSomethingElse;
            }

            public static void DoSomethingElse()
            {
                // Now I do this instead.
            }

            // Or even
            public static void ClearButtonEvents(Button button)
            {
                // Sets the click to do nothing.
                button.Click = delegate { };
            }


            public static void LieToOthersAndTellThemTheButtonHasBeenClicked(Button button)
            {
                button.Click.Invoke();
            }

            public static void SpyOnOthers(Button button)
            {
                Delegate[] callbacks = button.Click.GetInvocationList();

                foreach (Delegate callback in callbacks)
                {
                    Console.WriteLine(
                        "When click is called " + callback.Target +
                        " calls " + callback.Method + ".");
                }
            }

            public static void KickMarkOutOfTheParty(Button button)
            {
                Delegate[] callbacks = button.Click.GetInvocationList();

                Button.OnClickHandler newCallbacks = delegate { };

                for (int i = 0; i < callbacks.Length; i++)
                {
                    if (!(callbacks[i].Target is Mark))
                    {
                        newCallbacks += (Button.OnClickHandler)callbacks[i];
                    }
                }

                button.Click = newCallbacks;
            }
        }
    }
}







