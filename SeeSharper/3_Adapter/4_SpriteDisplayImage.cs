using System.Drawing;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

namespace AdapterPattern
{
    public sealed class SpriteDisplayImage : ISpriteDisplay
    {
        private Image image;
        public Color color
        {
            get { return image.color; }
            set { image.color = value; }
        }

        public Sprite sprite
        {
            get { return image.sprite; }
            set { image.sprite = value; }
        }

        public static explicit operator Image(SpriteDisplayImage spriteDisplayImage)
        {
            return spriteDisplayImage.image;
        }

        public static explicit operator SpriteDisplayImage(Image image)
        {
            return new SpriteDisplayImage() { image = image };
        }
    }
}
