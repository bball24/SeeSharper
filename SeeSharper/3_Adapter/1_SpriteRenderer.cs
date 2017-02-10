using Renderer = System.Object;
using Color = System.Drawing.Color;

namespace UnityEngine
{
    public sealed class SpriteRenderer : Renderer
    {
        public SpriteRenderer() { }
        public Color color { get; set; }
        public bool flipX { get; set; }
        public bool flipY { get; set; }
        public Sprite sprite { get; set; }
    }
}