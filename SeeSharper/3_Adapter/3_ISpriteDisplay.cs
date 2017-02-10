using System.Drawing;

namespace AdapterPattern
{
    public interface ISpriteDisplay
    {
        Color color { get; set; }
        Sprite sprite { get; set; }
    }
}