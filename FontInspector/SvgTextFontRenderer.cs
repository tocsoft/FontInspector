using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using MudBlazor;
using SixLabors.Fonts;
using SixLabors.Fonts.Unicode;
using System.Data.SqlTypes;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using static MudBlazor.Icons.Custom;


namespace FontInspector
{
    public class SvgTextFontRenderer : IColorGlyphRenderer
    {
        private StringBuilder svgString = new StringBuilder();
        private GlyphColor? _color = null;
        public string Svg => svgString.ToString();

        private readonly TextOptions options;
        private float fontSize => options.Font.Size;

        /// <remarks>
        ///  only really works in single glyphs situations, don't enable this when rendering larger text strings
        /// </remarks>
        public bool AddMetricAddornments { get; set; } = false;
        public float Padding { get; set; } = 20;

        public SvgTextFontRenderer(TextOptions options)
        {
            this.options = options;
        }

        public float boxWidth = -1;
        public float boxHeight = -1;
        public float boxRight = -1;
        public float boxBottom = -1;
        public void BeginText(in FontRectangle bounds)
        {
            //float maxGlyphWidth = FontScaleToPixelScape(options.Font.FontMetrics.UnitsPerEm);
            float maxGlyphWidth =  FontScaleToPixelScape(options.Font.FontMetrics.HorizontalMetrics.AdvanceWidthMax);
            float maxGlyphHeight = FontScaleToPixelScape(options.Font.FontMetrics.HorizontalMetrics.AdvanceHeightMax);

            var maxWidth = MathF.Max(maxGlyphWidth, bounds.Width);
            var maxHeight = MathF.Max(maxGlyphHeight, bounds.Height);
            boxWidth = maxWidth + Padding * 2;
            boxHeight = maxHeight + Padding * 3;
            boxRight = maxWidth + Padding;
            boxBottom = maxHeight + Padding;
            svgString.Append($"<svg style=\"width:{boxWidth}px; height:{boxHeight}px\" viewBox=\"{-Padding} {-Padding} {maxWidth + Padding} {maxHeight + Padding}\"><g>");
        }

        public void EndText()
        {
            svgString.Append($"</g></svg>");
        }

        public void BeginFigure()
        {
        }

        public void EndFigure()
        {
            svgString.Append("z ");
        }

        public void AddHLine(float y, string className)
        {
            svgString.Append($"<line x1=\"{-Padding}\" y1=\"{y}\" x2=\"{boxRight}\" y2=\"{y}\" class='adornment adornment-{className}' />");
        }

        public void AddVLine(float x, string className)
        {
            svgString.Append($"<line x1=\"{x}\" y1=\"{-Padding}\" x2=\"{x}\" y2=\"{boxBottom}\" class='adornment adornment-{className}' />");
        }

        private float FontScaleToPixelScape(float fontScale)
        {
            return fontScale * (fontSize * 72) / (options.Font.FontMetrics.ScaleFactor);

        }

        public bool BeginGlyph(in FontRectangle bounds, in GlyphRendererParameters parameters)
        {
            if (AddMetricAddornments)
            {
                if (options.Font.FontMetrics.TryGetGlyphMetrics(parameters.CodePoint,
                    parameters.TextRun?.TextAttributes ?? default,
                    parameters.TextRun?.TextDecorations ?? default,
                    options.LayoutMode,
                    ColorFontSupport.MicrosoftColrFormat,
                    out var glyphs))
                {
                    var gid = parameters.GlyphId;
                    var glyph = glyphs.FirstOrDefault(x => x.GlyphId == gid);
                    if (glyph != null)
                    {
                        var lsb = FontScaleToPixelScape(glyph.LeftSideBearing);
                        var rsb = lsb + FontScaleToPixelScape(glyph.AdvanceWidth);
                        AddVLine(lsb, "lsb");
                        AddVLine(rsb, "advance-width");

                        var height = FontScaleToPixelScape(glyph.AdvanceHeight);
                        AddHLine(height, "descender");
                        var baseline = height + FontScaleToPixelScape(options.Font.FontMetrics.HorizontalMetrics.Descender);
                        AddHLine(baseline, "baseline");
                        var asscender = height - FontScaleToPixelScape(options.Font.FontMetrics.HorizontalMetrics.Ascender);
                        AddHLine(asscender, "assender");
                    }
                }
            }

            _color = null;

            svgString.Append($"<path d=\"");
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

            svgString.Append($" />");

        }

        public void CubicBezierTo(Vector2 secondControlPoint, Vector2 thirdControlPoint, Vector2 point)
        {
            svgString.Append($"C {secondControlPoint.X},{secondControlPoint.Y} {thirdControlPoint.X},{thirdControlPoint.Y} {point.X},{point.Y}");
        }

        public TextDecorations EnabledDecorations()
        {
            return TextDecorations.None;
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
