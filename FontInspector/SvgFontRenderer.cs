using Microsoft.Extensions.Primitives;
using SixLabors.Fonts;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using static MudBlazor.Icons.Custom;

namespace FontInspector
{
    public class SvgFontRenderer : IColorGlyphRenderer
    {
        private StringBuilder svgString = new StringBuilder();
        private GlyphColor? _color = null;
        private GlyphMetrics _glyphMetrics;
        private readonly Font font;
        private float fontSize => font.Size;

        public SvgFontRenderer(Font font)
        {
            this.font = font;
        }
        public string Svg => svgString.ToString();

        public void BeginFigure()
        {
        }

        public void SetCurrentGlyphMetric(GlyphMetrics glyphMetrics)
        {
            _glyphMetrics = glyphMetrics;
        }

        public void EndFigure()
        {
            svgString.Append("z ");
        }

        public bool BeginGlyph(in FontRectangle bounds, in GlyphRendererParameters parameters)
        {
            _color = null;
            svgString.Append($"<svg viewBox=\"{-fontSize} {-fontSize} {fontSize * 3} {fontSize * 3}\">");

            static void AddHLine(float y, string className, float offset, Font font, StringBuilder sb)
            {
                y *= (font.Size * 72) / (font.FontMetrics.ScaleFactor);
                y += offset;
                sb.Append($"<line transform=\"translate(0,{font.Size})\" x1=\"{-font.Size}\" y1=\"{-y}\" x2=\"{font.Size * 3}\" y2=\"{-y}\" class='adornment adornment-{className}' />");
            }

            static void AddVLine(float x, string className, float offset, Font font, StringBuilder sb)
            {
                x *= (font.Size * 72) / (font.FontMetrics.ScaleFactor);
                x += offset;
                sb.Append($"<line transform=\"translate(0,0)\" x1=\"{x}\" y1=\"{-font.Size}\" x2=\"{x}\" y2=\"{font.Size * 3}\" class='adornment adornment-{className}' />");
            }
            AddVLine(_glyphMetrics.LeftSideBearing, "lsb", 0, font, svgString);
            AddVLine(_glyphMetrics.LeftSideBearing + _glyphMetrics.AdvanceWidth, "advance-width", 0, font, svgString);

            AddHLine(font.FontMetrics.HorizontalMetrics.Ascender, "assender", 0, font, svgString);
            AddHLine(font.FontMetrics.HorizontalMetrics.Descender, "descender", 0, font, svgString);

            svgString.Append($"<path transform=\"translate({bounds.Left},{fontSize - bounds.Bottom})\" d=\"");
            return true;
        }

        public void EndGlyph()
        {
            svgString.Append($"\" style=\"");

            //inject other styles here!!!
            if (_color != null)
            {
                svgString.Append($"fill:#{_color.Value.Red:X2}{_color.Value.Red:X2}{_color.Value.Red:X2}; ");
            }

            svgString.Append($"fill-rule: evenodd;\"");

            svgString.Append($" /></svg>");

        }

        public void BeginText(in FontRectangle bounds)
        {
        }

        public void CubicBezierTo(Vector2 secondControlPoint, Vector2 thirdControlPoint, Vector2 point)
        {
            svgString.Append($"C {secondControlPoint.X},{secondControlPoint.Y} {thirdControlPoint.X},{thirdControlPoint.Y} {point.X},{point.Y}");
        }

        public TextDecorations EnabledDecorations()
        {
            return TextDecorations.None;
        }


        public void EndText()
        {
        }

        public void LineTo(Vector2 point)
        {
            svgString.Append($"L {point.X},{point.Y}");
        }

        public void MoveTo(Vector2 point)
        {
            svgString.Append($"M {point.X},{point.Y}");
        }

        public void QuadraticBezierTo(Vector2 secondControlPoint, Vector2 point)
        {
            svgString.Append($"Q {secondControlPoint.X},{secondControlPoint.Y} {point.X},{point.Y}");
        }

        public void SetColor(GlyphColor color)
        {
            _color = color;
        }

        public void SetDecoration(TextDecorations textDecorations, Vector2 start, Vector2 end, float thickness)
        {
        }
    }
}
