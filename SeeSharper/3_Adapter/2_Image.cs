using System;
using Color = System.Drawing.Color;

namespace UnityEngine.UI
{
    //
    // Summary:
    //     ///
    //     Displays a Sprite for the UI System.
    //     ///
    // [AddComponentMenu("UI/Image", 11)]
    public class Image : MaskableGraphic, ISerializationCallbackReceiver, 
        ILayoutElement, ICanvasRaycastFilter
    {
        protected static Material s_ETC1DefaultUI;

        public Image() { }

        //
        // Summary:
        //     ///
        //     Cache of the default Canvas Ericsson Texture Compression 1 (ETC1) and alpha Material.
        //     ///
        public static Material defaultETC1GraphicMaterial { get; }
        //
        // Summary:
        //     ///
        //     The alpha threshold specifies the minimum alpha a pixel must have for the event
        //     to considered a "hit" on the Image.
        //     ///
        public float alphaHitTestMinimumThreshold { get; set; }
        //
        // Summary:
        //     ///
        //     The alpha threshold specifies the minimum alpha a pixel must have for the event
        //     to considered a "hit" on the Image.
        //     ///
        [Obsolete("eventAlphaThreshold has been deprecated. Use eventMinimumAlphaThreshold instead (UnityUpgradable) -> alphaHitTestMinimumThreshold")]
        public float eventAlphaThreshold { get; set; }
        //
        // Summary:
        //     ///
        //     Amount of the Image shown when the Image.type is set to Image.Type.Filled.
        //     ///
        public float fillAmount { get; set; }
        //
        // Summary:
        //     ///
        //     Whether or not to render the center of a Tiled or Sliced image.
        //     ///
        public bool fillCenter { get; set; }
        //
        // Summary:
        //     ///
        //     Whether the Image should be filled clockwise (true) or counter-clockwise (false).
        //     ///
        public bool fillClockwise { get; set; }
        //
        // Summary:
        //     ///
        //     What type of fill method to use.
        //     ///
        public FillMethod fillMethod { get; set; }
        //
        // Summary:
        //     ///
        //     Controls the origin point of the Fill process. Value means different things with
        //     each fill method.
        //     ///
        public int fillOrigin { get; set; }
        //
        // Summary:
        //     ///
        //     See ILayoutElement.flexibleHeight.
        //     ///
        public virtual float flexibleHeight { get; }
        //
        // Summary:
        //     ///
        //     See ILayoutElement.flexibleWidth.
        //     ///
        public virtual float flexibleWidth { get; }
        //
        // Summary:
        //     ///
        //     True if the sprite used has borders.
        //     ///
        public bool hasBorder { get; }
        //
        // Summary:
        //     ///
        //     See ILayoutElement.layoutPriority.
        //     ///
        public virtual int layoutPriority { get; }
        //
        // Summary:
        //     ///
        //     The image's texture. (ReadOnly).
        //     ///
        public virtual Texture mainTexture { get; }
        //
        // Summary:
        //     ///
        //     The specified Material used by this Image. The default Material is used instead
        //     if one wasn't specified.
        //     ///
        public virtual Material material { get; set; }
        //
        // Summary:
        //     ///
        //     See ILayoutElement.minHeight.
        //     ///
        public virtual float minHeight { get; }
        //
        // Summary:
        //     ///
        //     See ILayoutElement.minWidth.
        //     ///
        public virtual float minWidth { get; }
        //
        // Summary:
        //     ///
        //     Set an override sprite to be used for rendering.
        //     ///
        public Sprite overrideSprite { get; set; }
        public float pixelsPerUnit { get; }
        //
        // Summary:
        //     ///
        //     See ILayoutElement.preferredHeight.
        //     ///
        public virtual float preferredHeight { get; }
        //
        // Summary:
        //     ///
        //     See ILayoutElement.preferredWidth.
        //     ///
        public virtual float preferredWidth { get; }
        //
        // Summary:
        //     ///
        //     Whether this image should preserve its Sprite aspect ratio.
        //     ///
        public bool preserveAspect { get; set; }
        //
        // Summary:
        //     ///
        //     The sprite that is used to render this image.
        //     ///
        public Sprite sprite { get; set; }
        //
        // Summary:
        //     ///
        //     How to display the image.
        //     ///
        public Type type { get; set; }

        //
        // Summary:
        //     ///
        //     See ILayoutElement.CalculateLayoutInputHorizontal.
        //     ///
        public virtual void CalculateLayoutInputHorizontal() { }
        //
        // Summary:
        //     ///
        //     See ILayoutElement.CalculateLayoutInputVertical.
        //     ///
        public virtual void CalculateLayoutInputVertical() { }
        //
        // Summary:
        //     ///
        //     See:ICanvasRaycastFilter.
        //     ///
        //
        // Parameters:
        //   screenPoint:
        //
        //   eventCamera:
        public virtual bool IsRaycastLocationValid(Vector2 screenPoint, Camera eventCamera) { return true; }
        //
        // Summary:
        //     ///
        //     Serialization Callback.
        //     ///
        public virtual void OnAfterDeserialize() { }
        //
        // Summary:
        //     ///
        //     Serialization Callback.
        //     ///
        public virtual void OnBeforeSerialize() { }
        //
        // Summary:
        //     ///
        //     Adjusts the image size to make it pixel-perfect.
        //     ///
        public virtual void SetNativeSize() { }
        protected virtual void OnPopulateMesh(Vector2 toFill) { }
        protected virtual void UpdateMaterial() { }

        //
        // Summary:
        //     ///
        //     Fill method to be used by the Image.
        //     ///
        public enum FillMethod
        {
            //
            // Summary:
            //     ///
            //     The Image will be filled Horizontally.
            //     ///
            Horizontal = 0,
            //
            // Summary:
            //     ///
            //     The Image will be filled Vertically.
            //     ///
            Vertical = 1,
            //
            // Summary:
            //     ///
            //     The Image will be filled Radially with the radial center in one of the corners.
            //     ///
            Radial90 = 2,
            //
            // Summary:
            //     ///
            //     The Image will be filled Radially with the radial center in one of the edges.
            //     ///
            Radial180 = 3,
            //
            // Summary:
            //     ///
            //     The Image will be filled Radially with the radial center at the center.
            //     ///
            Radial360 = 4
        }
        //
        // Summary:
        //     ///
        //     Origin for the Image.FillMethod.Radial180.
        //     ///
        public enum Origin180
        {
            //
            // Summary:
            //     ///
            //     Center of the radial at the center of the Bottom edge.
            //     ///
            Bottom = 0,
            //
            // Summary:
            //     ///
            //     Center of the radial at the center of the Left edge.
            //     ///
            Left = 1,
            //
            // Summary:
            //     ///
            //     Center of the radial at the center of the Top edge.
            //     ///
            Top = 2,
            //
            // Summary:
            //     ///
            //     Center of the radial at the center of the Right edge.
            //     ///
            Right = 3
        }
        //
        // Summary:
        //     ///
        //     One of the points of the Arc for the Image.FillMethod.Radial360.
        //     ///
        public enum Origin360
        {
            //
            // Summary:
            //     ///
            //     Arc starting at the center of the Bottom edge.
            //     ///
            Bottom = 0,
            //
            // Summary:
            //     ///
            //     Arc starting at the center of the Right edge.
            //     ///
            Right = 1,
            //
            // Summary:
            //     ///
            //     Arc starting at the center of the Top edge.
            //     ///
            Top = 2,
            //
            // Summary:
            //     ///
            //     Arc starting at the center of the Left edge.
            //     ///
            Left = 3
        }
        //
        // Summary:
        //     ///
        //     Origin for the Image.FillMethod.Radial90.
        //     ///
        public enum Origin90
        {
            //
            // Summary:
            //     ///
            //     Radial starting at the Bottom Left corner.
            //     ///
            BottomLeft = 0,
            //
            // Summary:
            //     ///
            //     Radial starting at the Top Left corner.
            //     ///
            TopLeft = 1,
            //
            // Summary:
            //     ///
            //     Radial starting at the Top Right corner.
            //     ///
            TopRight = 2,
            //
            // Summary:
            //     ///
            //     Radial starting at the Bottom Right corner.
            //     ///
            BottomRight = 3
        }
        //
        // Summary:
        //     ///
        //     Origin for the Image.FillMethod.Horizontal.
        //     ///
        public enum OriginHorizontal
        {
            //
            // Summary:
            //     ///
            //     Origin at the Left side.
            //     ///
            Left = 0,
            //
            // Summary:
            //     ///
            //     Origin at the Right side.
            //     ///
            Right = 1
        }
        //
        // Summary:
        //     ///
        //     Origin for the Image.FillMethod.Vertical.
        //     ///
        public enum OriginVertical
        {
            //
            // Summary:
            //     ///
            //     Origin at the Bottom edge.
            //     ///
            Bottom = 0,
            //
            // Summary:
            //     ///
            //     Origin at the Top edge.
            //     ///
            Top = 1
        }
        //
        // Summary:
        //     ///
        //     Image Type.
        //     ///
        public enum Type
        {
            //
            // Summary:
            //     ///
            //     Displays the full Image.
            //     ///
            Simple = 0,
            //
            // Summary:
            //     ///
            //     Displays the Image as a 9-sliced graphic.
            //     ///
            Sliced = 1,
            //
            // Summary:
            //     ///
            //     Displays a sliced Sprite with its resizable sections tiled instead of stretched.
            //     ///
            Tiled = 2,
            //
            // Summary:
            //     ///
            //     Displays only a portion of the Image.
            //     ///
            Filled = 3
        }
    }

    public class MaskableGraphic
    {
        //... A bunch of convoluted stuff.

        public Color color { get; set; }

        //... More convoluted stuff.
    }
}




interface ILayoutElement { }
interface ICanvasRaycastFilter { }
interface ISerializationCallbackReceiver { }

public class Sprite { public Sprite() { } }

public class Material : System.Object { }
public class Vector2 : System.Object { }
public class Camera : System.Object { }
public class Texture : System.Object {}
