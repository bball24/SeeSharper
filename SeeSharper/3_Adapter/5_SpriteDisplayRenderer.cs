using System.Drawing;
using UnityEngine;

namespace AdapterPattern
{
    public sealed class SpriteDisplayRenderer : ISpriteDisplay
    {
        private SpriteRenderer spriteRenderer;
        public Color color
        {
            get { return spriteRenderer.color; }
            set { spriteRenderer.color = value; }
        }

        public Sprite sprite
        {
            get { return spriteRenderer.sprite; }
            set { spriteRenderer.sprite = value; }
        }

        public static explicit operator SpriteRenderer(SpriteDisplayRenderer spriteDisplayRenderer)
        {
            return spriteDisplayRenderer.spriteRenderer;
        }

        public static explicit operator SpriteDisplayRenderer(SpriteRenderer image)
        {
            return new SpriteDisplayRenderer() { spriteRenderer = image };
        }
    }
}
