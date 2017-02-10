using System.Drawing;
using UnityEngine.UI;
using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace AdapterPattern
{
    class AdapterUsage
    {
        private static Image someImage = new Image();
        private static SpriteRenderer spriteRenderer = new SpriteRenderer();

        private static ISpriteDisplay spriteDisplay;

        public static void UseAdapters()
        {
            Sprite newSprite = new Sprite();
            Color newColor = new Color();

            spriteDisplay = (SpriteDisplayImage)someImage;

            spriteDisplay.color = newColor;
            spriteDisplay.sprite = newSprite;

            spriteDisplay = (SpriteDisplayRenderer)spriteRenderer;

            // They now have the same interface, so the calls will be exactly the same!
            spriteDisplay.color = newColor;
            spriteDisplay.sprite = newSprite;
        }
    }
}
